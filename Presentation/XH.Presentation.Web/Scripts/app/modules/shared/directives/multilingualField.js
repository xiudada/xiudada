angular.module("ui.bookchoice", ["ui.bookchoice.tpls", "ui.bookchoice.multilingualField"]);
angular.module("ui.bookchoice.tpls", ["template/multilingualField.html"]);
angular.module("ui.bookchoice.multilingualField", [])
.controller("multilingualFieldController", ["$scope", function ($scope) {
    var tc = $scope.tc = $scope.translationCollection || [],
        tm = $scope.tm = new TranslationManager(tc);
}])
.directive("multilingualField", ["$parse", function () {
    return {
        restrict: 'EA',
        transclude: true,
        templateUrl: 'template/multilingualField.html',
        controller: "multilingualFieldController",
        scope: {
            fieldName: "@multilingualField",
            translationCollection: "="
        },
        link: function (scope, element, attrs, ctrl, transclude) {
            transclude(scope, function (clone) {

            });
        }
    }
}])
.directive("multilingualFieldElement", ["$parse", function ($parse) {
    return {
        restrict: 'EA',
        transclude: true,
        required: "",
        scope: {
            fieldName: "@multilingualField",
            translationCollection: "="
        },
        link: function (scope, element, attrs, ctrl, transclude) {

        }
    }
}])

angular.module("template/multilingualField.html", []).run(["$templateCache", function ($templateCache) {
    $templateCache.put("template/multilingualField.html",
        '<uib-tabset>\n' +
        '    <uib-tab ng-repeat="item in tm.translationCollection">\n' +
        '        <uib-tab-heading>\n' +
        '            {{item.LanguageName}} <span ng-if="item.LanguageCode!=\'en\'" style="position:absolute;right:5px;top:0px;" onclick="return false;" ng-click="tm.removeTranslation(item.LanguageCode);">x</span>\n' +
        '        </uib-tab-heading>\n' +
        '        <input type="hidden" name="fieldName[{{$index}}].LanguageCode" value="{{item.LanguageCode}}" />\n' +
        '        <div ng-transclude></div>\n' +
        '    </uib-tab>\n' +
        '    <uib-tab ng-if="tm.remainTranslations.length">\n' +
        '        <uib-tab-heading>\n' +
        '            <div class="btn-group" uib-dropdown dropdown-append-to-body>\n' +
        '                <a href="javascript:;" id="simple-dropdown" uib-dropdown-toggle>\n' +
        '                    + New language\n' +
        '                </a>\n' +
        '                <ul class="dropdown-menu" uib-dropdown-menu role="menu" aria-labelledby="simple-dropdown">\n' +
        '                    <li role="menuitem" ng-repeat="item in tm.remainTranslations"><a href="javascript:;" ng-click="tm.addTranslation(item.code)">+ {{item.name}}</a></li>\n' +
        '                </ul>\n' +
        '            </div>\n' +
        '        </uib-tab-heading>\n' +
        '    </uib-tab>\n' +
        '</uib-tabset>\n');
}]);