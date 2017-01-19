xiudadaApp.controller("articlesOverviewController",
["$scope", "$state", "articlesResource", "notifyServices",
function ($scope, $state, articlesResource, notifyServices) {
    articlesResource.list({ page: 1, pageSize: 15 }, function (data) {
        $scope.articles = data.Items;
    }, function () {

    });

    $scope.goToDetail = function (id) {
        $state.go("articles:edit", { id: id });
    }

    $scope.addArticle = function () {
        $state.go("articles:add");
    }
}]);