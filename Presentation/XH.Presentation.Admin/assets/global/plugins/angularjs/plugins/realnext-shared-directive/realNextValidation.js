/***
 GLobal Directives
 ***/

(function () {
    angular.module('realNext.Validation', []);
})();

(function () {
    var rnValidationModule = angular.module('realNext.Validation');

    rnValidationModule.directive('rnVlYear', [function () {
        return {
            restrict: 'A',
            require: 'ngModel',
            scope: {
                rnYear: '=',
            },
            link: function (scope, ele, attrs, ctrl) {
                ctrl.$parsers.unshift(function (value) {
                    if (value) {
                        var reg = /^[1-2]\d{3}$/;
                        if (!reg.test(value)) {
                            ctrl.$setValidity('rnVlYear', false);
                            ctrl.$setValidity('ngModel', undefined);
                            return undefined;
                        } else {
                            ctrl.$setValidity('rnVlYear', true);
                            ctrl.$setValidity('ngModel', value);
                            return value;
                        }
                    }
                });
            }
        };
    }]);

    rnValidationModule.directive('rnVlPostcode', [function () {
        return {
            restrict: 'A',
            require: 'ngModel',
            scope: {
                rnYear: '=',
            },
            link: function (scope, ele, attrs, ctrl) {
                ctrl.$parsers.unshift(function (value) {
                    if (value) {
                        var reg = /^[1-9][0-9]{3}[A-Za-z]{2}$/;
                        if (!reg.test(value)) {
                            ctrl.$setValidity('rnVlPostcode', false);
                            ctrl.$setValidity('ngModel', false);
                            return undefined;
                        } else {
                            ctrl.$setValidity('rnVlPostcode', true);
                            ctrl.$setValidity('ngModel', true);
                            return value;
                        }
                    }
                });
            }
        };
    }]);

    rnValidationModule.directive('rnVlDomain', [function () {
        return {
            restrict: 'A',
            require: 'ngModel',
            scope: {
                rnYear: '=',
            },
            link: function (scope, ele, attrs, ctrl) {
                ctrl.$parsers.unshift(function (value) {
                    if (value) {
                        var reg = /^([a-z0-9]+(-[a-z0-9]+)*\.)+[a-z]{2,}$/;
                        if (value == "localhost") {
                            ctrl.$setValidity('rnVlDomain', true);
                            ctrl.$setValidity('ngModel', true);
                            return value;
                        }

                        if (!reg.test(value)) {
                            ctrl.$setValidity('rnVlDomain', false);
                            ctrl.$setValidity('ngModel', false);
                            return undefined;
                        } else {
                            ctrl.$setValidity('rnVlDomain', true);
                            ctrl.$setValidity('ngModel', true);
                            return value;
                        }
                    }
                });
            }
        };
    }]);

    rnValidationModule.directive('rnVlInt', function () {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, ele, attrs, ctrl) {
                ctrl.$parsers.unshift(function (value) {
                    if (value) {
                        var reg = /^(\+|-)?([1-9]\d*|0)$/;
                        if (!reg.test(value)) {
                            ctrl.$setValidity('rnVlInt', false);
                            ctrl.$setValidity('ngModel', false);
                            return undefined;
                        } else {
                            ctrl.$setValidity('rnVlInt', true);
                            ctrl.$setValidity('ngModel', true);
                            return value;
                        }
                    }
                });
            }
        };
    });

    rnValidationModule.directive('rnMinWordscount', function () {
        return {
            restrict: 'A',
            require: '?ngModel',
            scope: {
                rnMinWordscount: "="
            },
            link: function (scope, elm, attr, ctrl) {
                ctrl.$parsers.unshift(function (value) {
                    if (!ctrl.$isEmpty(value) && value.getWordsCount() >= scope.rnMinWordscount) {
                        ctrl.$setValidity('rnMinWordscount', true);
                        return value;
                    } else {
                        ctrl.$setValidity('rnMinWordscount', false);
                        return value;
                    }
                });
            }
        };
    })
})();