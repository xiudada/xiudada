(function () {
    var appConfig = window.appConfig || (window.appConfig = {});
    appConfig.appName = "xhApp";
    appConfig.angularDependencies = [
        'ui.router',
        'ngCookies',
        'ngAnimate',
        'ngResource'
    ];

    appConfig.app = angular.module(appConfig.appName, appConfig.angularDependencies);
})();