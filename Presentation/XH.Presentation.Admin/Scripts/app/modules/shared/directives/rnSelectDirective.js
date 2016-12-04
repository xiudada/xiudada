sharedModule.directive("rnSelect", ['DropDownListDataService',function(DropDownListDataService){
	return {
		restrict: 'EA',
		template: '\
			<select class="form-control">\
				<option ng-show="showEmptyOption" value="">{{ "COMMONS.PLEASE_SELECT_AN_OPTION"|translate }}</option>\
                <option ng-repeat="item in selectSource" ng-hide="item.isHidden" value="{{ item.value }}" >{{ translateKey+"."+item.label|translate }}</option>\
            </select>',
		replace: true,
		scope : {
			sourceKey: '@',
			translateKey: '@',
			filterOption: '=',
			hasEmpty: '@'
		},
		link: function(scope, elements, attrs){
		    if (!_.isEmpty(scope.hasEmpty) && scope.hasEmpty == "true") {
			    scope.showEmptyOption = true;
			} else {
			    scope.showEmptyOption = false;
			}

			if (_.isEmpty(scope.translateKey)) {
				scope.translateKey = "SELECT_LIST";
			}

			if(!_.isEmpty(scope.sourceKey)){
				scope.selectSource = DropDownListDataService.getSelectSource(scope.sourceKey);
			}else{
				scope.selectSource = [];
			}
		},
	};

	function setSource(selectSource, filterOption){
		if(_.isArray(filterOption)){
			_.each(filterOption, function(optionItem, key, list){
				_.each(selectSource,function(selectItem, key){
					if(selectItem.value == optionItem.value){
						selectItem.isHidden = optionItem.hide;
					}
				});
			});
		}
	}
}]);