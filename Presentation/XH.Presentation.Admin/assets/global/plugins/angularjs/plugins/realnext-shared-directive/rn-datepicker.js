// directive for bootstrap-datepicker
// https://github.com/eternicode/bootstrap-datepicker
angular.module('realNext.sharedDirectiveModule').directive('rnDatepicker', function () {
    return {
        restrict: 'AE',
        replace: true,
        scope: {
            ngModel: '='
        },
        template: '<div class="input-group date datepicker">\
                        <input type="text" class="form-control" ng-model="ngModel" readonly>\
                        <span class="input-group-btn">\
                            <button class="btn default" type="button">\
                                <i class="fa fa-calendar"></i>\
                            </button>\
                        </span>\
                    </div>',
        link: function (scope, element) {
            scope.inputHasFocus = false;

            var defaultOptions = {
                autoclose: true,
                format: 'yyyy-mm-dd',
                language: 'en',
                clearBtn: false
            };

            element.datepicker(defaultOptions).on('changeDate', function (e) {
                return scope.$apply(function () {
                    console.log(e.date);
                    return scope.ngModel = $.fn.datepicker.DPGlobal.formatDate(e.date, defaultOptions.format, defaultOptions.language);
                });
            });

            element.find('input').on('focus', function () {
                return scope.inputHasFocus = true;
            }).on('blur', function () {
                return scope.inputHasFocus = false;
            });

            return scope.$watch('ngModel', function (newValue) {
                if (!scope.inputHasFocus) {
                    return element.datepicker('update', newValue);
                }
            });
        }
    };
});