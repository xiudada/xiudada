xiudadaApp.controller("articlesDetailController", ["$scope", "$state", "articlesResource", "notifyServices",
   function ($scope, $state, articlesResource, notifyServices) {
       var isAdd = $state.current.name === "articles:add";
       if (isAdd) {
           articlesResource.getNew({}, function (data) {
               $scope.vm = data;
           });
       } else {
           articlesResource.get({ id: $state.params.id }, function (data) {
               $scope.vm = data;
           });
       }

       $scope.submit = function () {


           articlesResource[isAdd ? "create" : "update"]($scope.vm, function (data) {
               notifyServices.success(isAdd ? "添加成功" : "更新成功");
           }, function () {
               notifyServices.error(isAdd ? "添加失败" : "更新失败");
           });
       }
   }]);