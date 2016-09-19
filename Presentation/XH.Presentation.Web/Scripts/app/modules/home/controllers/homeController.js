appConfig.app
.controller("xh.home.homeController", ["$scope", "$interval", function ($scope, $interval) {
    $scope.pageTitle = "page title";
    $scope.date = new Date();

    $interval(function () {
        $scope.date = new Date();
    }, 100);
}]);