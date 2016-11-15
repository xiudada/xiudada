(function () {
    var utility = window.utility || (window.utility = {});
    
    var isType = function (type) {
        return function (obj) {
            return Object.prototype.toString.call(obj) === "[object " + type + "]";
        }
    }

    utility.isNumber = isType("Number");
    utility.isArray = isType("Array");
    utility.isString = isType("String");
})();