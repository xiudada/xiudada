(function () {
    function formatWithStrings(originalString, strings) {
        var i = 0,
            len = strings.length,
            fragment;

        for (; i < len; i++) {
            fragment = strings[i];
            if (fragment === undefined || fragment === null) {
                fragment = "";
            }

            fragment = fragment.toString();
            originalString = originalString.replace("{" + i + "}", fragment);
        }

        return originalString;
    }

    function tryGetValueFromObject(obj, key) {
        var keyHierarchys = key.split('.'),
            value = obj,
            i = 0,
            len = keyHierarchys.length,
            tempKey;

        for (; i < len; i++) {
            tempKey = keyHierarchys[i];
            value = value[tempKey];
            if (value === undefined || value === null) {
                break;
            }
        }

        return value;
    }

    function formatWithObject(originalString, obj, undefinedAsEmpty) {
        // get all keys in original string
        var regExp = /\{\{([^{}]+)\}\}/g,
            matches,
            key,
            value;

        undefinedAsEmpty = !!undefinedAsEmpty;
        do {
            matches = regExp.exec(originalString);
            if (matches) {
                key = matches[1];
                value = tryGetValueFromObject(obj, key);
                if ((value === undefined || value === null) && undefinedAsEmpty) {
                    value = "";
                }

                originalString = originalString.replace(matches[0], value);
            }
        } while (matches);

        return originalString;
    }


    // FormatWith
    String.prototype.formatWith = function () {
        var originalString = this;
        if (arguments.length >= 1 && typeof (arguments[0]) === "object") {
            return formatWithObject(this.toString(), arguments[0], arguments[1]);
        }

        return formatWithStrings(this.toString(), Array.prototype.slice.call(arguments));
    }
})();