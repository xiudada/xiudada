(function () {


    // bind
    if (Function.prototype.bind == undefined) {
        Function.prototype.bind = function () {
            var self = this,
                context = [].shift.call(arguments),
                args = [].slice.call(arguments);

            return function () {
                return self.apply(context, [].concat.apply(args, [].slice.call(arguments)));
            }
        }
    }

    // Before
    Function.prototype.before = function (fn) {
        var self=this;
        return function () {
            fn.apply(this,arguments);
            return self.apply(this,arguments);
        };
    }

    // After
    Function.prototype.after = function (fn) {
        var self = this;
        return function () {
            var ret = self.apply(this, arguments);
            fn.apply(this, arguments);

            return ret;
        };
    }
})();