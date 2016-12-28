xiudadaApp.controller("articlesController", ["$scope", "$state", "articlesResource", function ($scope, $state, articlesResource) {
    console.log($state);
    var state = $state.current.name;

    if (state = "articles:overview") {
        articlesResource.list({ page: 1, pageSize: 15 }, function (data) {
            $scope.articles = data.Items;
        }, function () {

        });

        $scope.goToDetail = function (id) {
            $state.go("articles:edit", { id: id });
        }
    } else {
        // add
        // detail
        console.log($state);

        $scope.submit = function () {
            articlesResource.create($scope.vm, function (data) {
                alert("success");
            }, function () {

            });
        }
    }
}]);