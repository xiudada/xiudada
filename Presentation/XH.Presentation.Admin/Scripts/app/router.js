/* Setup Rounting For All Pages */
angular.module("xiudada").config(['$stateProvider', '$urlRouterProvider', '$locationProvider', 'PermissionNameConstrant', 
function ($stateProvider, $urlRouterProvider, $locationProvider, PermissionNameConstrant) {
    var isRealNextSearchEngine = configs.IsRealNextSearchEngine;
    $urlRouterProvider.otherwise("/home");
    var states = {
        commonStates: [
            {
                name: "dashboard",
                config: {
                    url: "/home",
                    templateUrl: "/Templates/home/dashboard.tpl.html".mapPath(),
                    data: { pageTitle: 'Admin Dashboard Template' },
                    permissionCode: PermissionNameConstrant.Open,
                    controller: "DashboardController"
                }
            },
            {
                name: "resetpassword",
                config: {
                    url: '/account/resetpassword?userid&code',
                    templateUrl: '/Templates/account/resetpassword.tpl.html'.mapPath(),
                    permissionCode: PermissionNameConstrant.Open,
                    controller: 'resetPasswordController'
                }
            },
            {
                name: "nopermission",
                config: {
                    url: '/nopermission/:denyPage',
                    templateUrl: '/Templates/common/nopermission.tpl.html'.mapPath(),
                    controller: "NoPermissionController",
                    permissionCode: 'Open'
                }
            }
        ]
    }

    function registerStates(states) {
        for (var key in states) {
            var stateArr = states[key],
                state;
            for (var i = 0, len = stateArr.length; i < len; i++) {
                state = stateArr[i];
                $stateProvider.state(state.name, state.config);
            }
        }
    }

    registerStates(states);
    $locationProvider.html5Mode(true);
}]);