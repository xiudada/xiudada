angular.module("realNext.service.sharedModule")
.provider("LimitRealNextSearchEngine", function () {
    var inValidStates = [
        /^offer:/,
        /^lead:/,
        /^financialtransaction:/,
        /^setting:/
    ];

    function isValidState(stateName) {
        var valid = inValidStates.every(function (item) {
            if (item instanceof RegExp) {
                return !item.test(stateName);
            } else if (typeof item === "string") {
                return item != stateName;
            }
            return false;
        });
        return valid;
    }

    return {
        isValidState: isValidState,
        $get: function () {
            return "";
        }
    };
});
