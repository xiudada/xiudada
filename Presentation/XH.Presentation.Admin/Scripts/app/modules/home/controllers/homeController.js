angular.module('xiudada')
.controller("xh.home.homeController", ["$scope", "$interval", function ($scope, $interval) {
    $scope.pageTitle = "page title";
    $scope.date = new Date();

    $interval(function () {
        $scope.date = new Date();
    }, 100);

    var str = "time:{{time}},age:{{age}},name:{{name}},street:{{address.street}},contactPersonName:{{address.contactPerson.name}}".formatWith({
        time: new Date(),
        age: 18,
        name: "huang",
        address: {
            street: "xinqiao",
            city: "sanming",
            contactPerson: {
                name: "skyfighter"
            }
        }
    });

    console.log(str);
}]);