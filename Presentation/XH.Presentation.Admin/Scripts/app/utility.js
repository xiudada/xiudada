
//String extensions
String.prototype.formatWith = function () {
    var str = this;
    for (var i = 0, len = arguments.length; i < len; i++) {
        str = str.replace('{' + i + '}', arguments[i]);
    }
    return str;
}

String.prototype.mapPath = function () {
    var url = this;
    if (/^\s*(~?\/)?assets.+?$/.test(url)) {
        return url;
    }
    return "/areas/service{0}".formatWith(this);
}

Array.prototype.remove = function (from, to) {
    var rest = this.slice((to || from) + 1 || this.length);
    this.length = from < 0 ? this.length + from : from;
    return this.push.apply(this, rest);
};

Array.prototype.swap = function (indexA, indexB) {
    var temp = this[indexA];
    this[indexA] = this[indexB];
    this[indexB] = temp;
}

Array.prototype.removeItem = function (item) {
    _.without(this, _.findWhere(this, item));
}

Array.prototype.contain = function (item) {
    return _.contains(this, item);
}

Date.prototype.addDays = function (days) {
    var dat = new Date(this.valueOf());
    dat.setDate(dat.getDate() + days);
    return dat;
}

String.prototype.addQueryStringArgs = function (args) {
    var url = this,
        qs = "",
        value,
        connectChar = url.indexOf('?') > -1 ? '&' : '?';
    if (typeof (args) === "object") {
        for (var name in args) {
            value = encodeURIComponent(args[name].toString());
            if (value.length > 0) {
                qs += "&{0}={1}".formatWith(encodeURIComponent(name), value);
            }
        }
    }
    if (typeof (args) === "string") {
        qs = args;
    }
    if (qs.length > 0) {
        qs = qs.substring(1);
        url = "{0}{1}{2}".formatWith(url, connectChar, qs);
    }
    return url;
};

String.prototype.replaceAll = function (target, replacement) {
    return this.split(target).join(replacement);
};

String.prototype.getPlainText = function () {
    var text = this;
    var temp = document.createElement("div");
    temp.innerHTML = text;
    var output = temp.innerText || temp.textContent;
    temp = null;
    return output;
}

String.prototype.getWordsCount = function () {
    var count = 0,
        words = this.trim();
    count = words ? words.split(/\s+/g).length : 0;
    return count;
}

String.prototype.equals = function (str, ignoreCase) {
    var leftStr = this;
    ignoreCase = !!ignoreCase;//convert to boolean;
    if (str == null || str == undefined) {
        return false;
    }
    str = str.toString();
    var isEquals = false;
    if (!ignoreCase) {
        isEquals = (str == leftStr);
    } else {
        if (this.length != str.length) {
            isEquals = false;
        } else {
            var abs = 0;
            isEquals = true;
            for (var i = 0, len = leftStr.length; i < len; i++) {
                abs = Math.abs(leftStr.charCodeAt(i) - str.charCodeAt(i));
                if (abs != 0 && abs != 32) {
                    isEquals = false;
                    break;
                }
            }
        }
    }
    return isEquals;
}

function transformOrganization(source) {
    str = JSON.stringify(source);
    str = str.replaceAll("Id", "id");
    str = str.replaceAll("Name", "name");
    str = str.replaceAll("SubOrganizations", "children");
    return JSON.parse(str);
}

var GlobalUtility = {
    clone: function(source){
        str = JSON.stringify(source);
        return JSON.parse(str);
    }
};

(function (window) {
    'use strict';

    var MAX_DEPTH = 100;
    var getKeys = Object.keys;
    var isNaN = window.isNaN;
    /**
     * Returns "true" if any is object
     * @param {*} any
     * @returns {Boolean}
     */
    function isObject(any) {
        return any instanceof Object;
    }
    /**
     * Returns "true" if any is number
     * @param {*} any
     * @returns {Boolean}
     */
    function isNumber(any) {
        return typeof any === 'number' && !isNaN(any);
    }
    /**
     * Walks object recursively
     * @param {Object} object
     * @param {Function} cb
     * @param {*} ctx
     * @param {Boolean} mode
     * @param {Boolean} ignore
     * @param {Number} max
     * @returns {Object}
     */
    function walk(object, cb, ctx, mode, ignore, max) {
        var stack = [
            [], 0, getKeys(object).sort(), object
        ];
        var cache = [];

        do {
            var node = stack.pop();
            var keys = stack.pop();
            var depth = stack.pop();
            var path = stack.pop();

            cache.push(node);

            while (keys[0]) {
                var key = keys.shift();
                var value = node[key];
                var way = path.concat(key);
                var strategy = cb.call(ctx, node, value, key, way, depth);

                if (strategy === true) {
                    continue;
                } else if (strategy === false) {
                    stack.length = 0;
                    break;
                } else {
                    if (max <= depth || !isObject(value)) continue;

                    if (cache.indexOf(value) !== -1) {
                        if (ignore) continue;
                        throw new Error('Circular reference');
                    }

                    if (mode) {
                        stack.unshift(way, depth + 1, getKeys(value).sort(), value);
                    } else {
                        stack.push(path, depth, keys, node);
                        stack.push(way, depth + 1, getKeys(value).sort(), value);
                        break;
                    }
                }
            }
        } while (stack[0]);

        return object;
    }
    /**
     * Walks object recursively
     * @param {Object} object
     * @param {Function} callback
     * @param {*} [context]
     * @param {Number} [mode=0]
     * @param {Boolean} [ignoreCircularReferences=false]
     * @param {Number} [maxDepth=100]
     * @returns {Object}
     */
    function traverse(object, callback, context, mode, ignoreCircularReferences, maxDepth) {
        var cb = callback;
        var ctx = context;
        var _mode = mode === 1;
        var ignore = !!ignoreCircularReferences;
        var max = isNumber(maxDepth) ? maxDepth : MAX_DEPTH;

        return walk(object, cb, ctx, _mode, ignore, max);
    }

    // export
    Object.traverse = traverse;

}(window));

