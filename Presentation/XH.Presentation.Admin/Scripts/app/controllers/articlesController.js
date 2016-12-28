xiudadaApp.controller("articlesController", ["$scope", "$state", "articlesResource", function ($scope, $state, articlesResource) {
    var state = $state.current.name;
    console.log(state);
    if (state == "articles:overview") {
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
        var isEdit=state=="articles:edit";
        articlesResource.get({ id: $state.params.id }, function (data) {
            $scope.vm = data;
        });

        $scope.submit = function () {
            articlesResource[isEdit?"update":"create"]($scope.vm, function (data) {
                alert("success");
            }, function () {

            });
        }
    }
}]);