angular.module("realNext.service.sharedModule")
.factory('showErrorService', ['$rootScope', function ($rootScope) {
    function showError(formName) {
        $('html, body').animate({
            scrollTop: $("form[name='{0}'] .ng-invalid".formatWith(formName)).offset().top - 50
        });
    };

    function showTabError(formName) {
        var activeClass = "active";
        var errorElement = $("form[name='{0}'] .ng-invalid".formatWith(formName));

        var errorTabItem = errorElement.parents(".tab-pane");
        var errorTabItems = errorElement.parents(".tab-content").children();
        var errorIndex = errorTabItems.index(errorTabItem);

        var errorNavItems = $($(".nav-tabs .nav-item")[errorIndex]);

        var navTabs = $(".nav-tabs .nav-item").removeClass(activeClass);
        errorNavItems.addClass(activeClass);
        errorTabItem.addClass(activeClass);

        showError(formName);
    };

    return {
        showError: showError,
        showTabError: showTabError
    }
}]);