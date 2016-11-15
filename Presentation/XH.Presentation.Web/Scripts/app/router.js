appConfig.app
.config(['$stateProvider', '$urlRouterProvider', '$locationProvider',
 function ($stateProvider, $urlRouterProvider, $locationProvider) {
     $urlRouterProvider.otherwise('/');

     $urlRouterProvider.rule(function ($injector, $location) {
         var path = $location.path();
         var normalized = path.toLowerCase();
         if (path != normalized) {
             $location.replace().path(normalized);
         }

         var path = $location.path();
         var hasTrailingSlash = path[path.length - 1] === '/';

         if (hasTrailingSlash) {
             //if last charcter is a slash, return the same url without the slash  
             var newPath = path.substr(0, path.length - 1);
             return newPath;
         }
     });

     var states = {
         commonStates: [
             {
                 name: "home",
                 config: {
                     url: '/',
                     views: {
                         '': {
                             templateUrl: 'Templates/Home/index.tpl.html',
                             controller: "xh.home.homeController"
                         }
                     }
                 }
             },
              {
                  name: "home1",
                  config: {
                      url: '/knockout',
                      controller: "knockoutController"
                  }
              }
         ]
     }

     function registerStates(states) {
         for (var key in states) {
             var stateArr = states[key];
             if (stateArr.length) {
                 var state;
                 for (var i = 0, len = stateArr.length; i < len; i++) {
                     state = stateArr[i];
                     $stateProvider.state(state.name, state.config);
                 }
             }
         }
     }

     registerStates(states);
     $locationProvider.html5Mode(true);
 }]);