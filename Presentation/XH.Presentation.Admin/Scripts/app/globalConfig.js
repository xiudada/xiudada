/* Configure ocLazyLoader(refer: https://github.com/ocombe/ocLazyLoad) */
angular.module("xiudada").config(['$ocLazyLoadProvider', function ($ocLazyLoadProvider) {
    $ocLazyLoadProvider.config({
        // global configs go here
    });
}]);

/* config http header */
angular.module("xiudada").config(['$httpProvider', function ($httpProvider) {
    $httpProvider.defaults.withCredentials = true;
}]);

//AngularJS v1.3.x workaround for old style controller declarition in HTML
angular.module("xiudada").config(['$controllerProvider', function ($controllerProvider) {
    // this option might be handy for migrating old apps, but please don't use it
    // in new ones!
    $controllerProvider.allowGlobals();
}]);
