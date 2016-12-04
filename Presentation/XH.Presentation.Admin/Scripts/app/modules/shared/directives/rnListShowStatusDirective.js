sharedModule.directive("rnListShowStatus", [function(){
	return {
		restrict: 'EA',
		template: '\
			<div ng-show="translateValue">\
                {{resultKey|translate}}\
            </div>',
		replace: true,
		scope : {
		    key: '@',
            translateValue: "="
		},
		link: function(scope, elements, attrs){
		    scope.resultKey = scope.key + '.' + scope.translateValue;
		    if (_.isEmpty(scope.translateValue)) {
		        console.log("rnListShowStatus translateValue null");
		    }
		},
	};
}]);