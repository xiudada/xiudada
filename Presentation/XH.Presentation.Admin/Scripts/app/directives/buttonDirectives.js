(function () {
    xiudadaApp.directive("buttonAdd", ["$rootScope", function () {
        return {
            restrict: "E",
            template: "<button><ng-transclude></ng-transclude></button>",
            transclude: true,
            replace: true,
            compile: function (element) {
                element.addClass("btn green btn-sm");
                element.append("<i class='fa fa-plus'></i>")
            }
        }
    }]);

    xiudadaApp.directive("buttonEdit", ["$rootScope", function () {
        return {
            restrict: "E",
            compile: function (element) {
                element.addClass("btn green btn-xs ");
                element.append("<i class='fa fa-edit'></i>");
            }
        }
    }]);

    xiudadaApp.directive("buttonDelete", ["$rootScope", function () {
        return {
            restrict: "E",
            compile: function (element) {
                element.addClass("btn green btn-xs");
                element.append("<i class='fa fa-edit'></i>");
            }
        }
    }]);

    xiudadaApp.directive("button", ["$rootScope", function () {
        return {
            restrict: "E",
            compile: function (element) {
                element.addClass("btn");
            }
        }
    }]);
})();
