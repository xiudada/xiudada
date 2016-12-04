/* Setup Layout Part - Header */
angular.module("xiudada").controller('HeaderController', ['$rootScope', '$scope', '$cookies', '$state', 'Auth',
    function ($rootScope, $scope, $cookies, $state, Auth) {
        $scope.$on('$includeContentLoaded', function () {
            Layout.initHeader(); // init header
        });

        $scope.logout = function () {
            Auth.logout();
        }
    }]);

/* Setup Layout Part - Sidebar */
angular.module("xiudada").controller('SidebarController', ['$scope', function ($scope) {
    $scope.$on('$includeContentLoaded', function () {
        // init sidebar
        Layout.initSidebar();
    });
}]);

/* Setup Layout Part - Quick Sidebar */
angular.module("xiudada").controller('QuickSidebarController', ['$scope', function ($scope) {
    $scope.$on('$includeContentLoaded', function () {
        setTimeout(function () {
            QuickSidebar.init(); // init quick sidebar        
        }, 2000);
    });
}]);

/* Setup Layout Part - Theme Panel */
angular.module("xiudada").controller('ThemePanelController', ['$scope', function ($scope) {
    $scope.$on('$includeContentLoaded', function () {
        Demo.init(); // init theme panel
    });
}]);

/* Setup Layout Part - Footer */
angular.module("xiudada").controller('FooterController', ['$scope', function ($scope) {
    $scope.$on('$includeContentLoaded', function () {
        Layout.initFooter(); // init footer
    });
}]);
