sharedModule.directive("rnBooleanLabel", [function(){
	return {
		restrict: 'EA',
		template: '\
			<div>\
                <span ng-show="show" class="label {{trueCss}}">{{"COMMONS."+show|translate}}</span>\
                <span ng-show="!show" class="label {{falseCss}}">{{"COMMONS."+show|translate}}</span>\
            </div>',
		replace: true,
		scope : {
		    show: '=',
		    trueCss: "@",
            falseCss: "@"

		},
		link: function(scope, elements, attrs){
		    if (_.isEmpty(scope.trueCss)) {
		        scope.trueCss = 'label-info';
		    }

		    if (_.isEmpty(scope.falseCss)) {
		        scope.falseCss = "label-danger";
		    }
		},
	};
}]);