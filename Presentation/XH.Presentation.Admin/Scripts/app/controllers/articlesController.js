xiudadaApp.controller("articlesController", ["$scope", "articlesResource", function ($scope, articlesResource) {
    articlesResource.list({ page: 1, pageSize: 15 }, function (data) {
        $scope.articles = data.Items;
    }, function () {

    });
}]);