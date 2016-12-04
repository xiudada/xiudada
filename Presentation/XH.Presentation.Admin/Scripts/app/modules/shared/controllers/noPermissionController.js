angular.module('realNext.service.sharedModule')
.controller('NoPermissionController', ['$scope', '$stateParams', function($scope, $stateParams){
	$scope.denyPage = decodeURIComponent($stateParams.denyPage);
}])