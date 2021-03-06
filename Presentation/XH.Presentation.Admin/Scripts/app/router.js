﻿/* setup rounting for all pages */
xiudadaApp.config(['$stateProvider', '$urlRouterProvider', "$locationProvider",
function ($stateProvider, $urlRouterProvider, $locationProvider) {
    $urlRouterProvider.otherwise("/dashboard");
    var states = {
        commonStates: [
            {
                name: "dashboard",
                config: {
                    url: "/dashboard",
                    templateUrl: "/Templates/home/dashboard.tpl.html",
                    controller: "dashboardController"
                }
            },
            {
                name: "resetpassword",
                config: {
                    url: '/account/resetpassword?userid&code',
                    templateUrl: '/templates/account/resetpassword.tpl.html',
                    controller: 'resetpasswordcontroller'
                }
            },
            {
                name: "nopermission",
                config: {
                    url: '/nopermission/:denypage',
                    templateUrl: '/templates/common/nopermission.tpl.html',
                    controller: "nopermissioncontroller",
                    permissioncode: 'open'
                }
            }
        ],
        articles: [
            {
                name: "articles:overview",
                config: {
                    url: "/articles/overview",
                    templateUrl: "/Templates/articles/overview.tpl.html",
                    controller: "articlesOverviewController"
                }
            },
            {
                name: "articles:add",
                config: {
                    url: "/articles/add",
                    templateUrl: "/Templates/articles/detail.tpl.html",
                    controller: "articlesDetailController"
                }
            },
            {
                name: "articles:edit",
                config: {
                    url: "/articles/edit/:id",
                    templateUrl: "/Templates/articles/detail.tpl.html",
                    controller: "articlesDetailController"
                }
            }
        ]
    }

    function registerStates(states) {
        for (var key in states) {
            var statearr = states[key],
                state;
            for (var i = 0, len = statearr.length; i < len; i++) {
                state = statearr[i];
                $stateProvider.state(state.name, state.config);
            }
        }
    }

    registerStates(states);
    $locationProvider.html5Mode(true);
}]);