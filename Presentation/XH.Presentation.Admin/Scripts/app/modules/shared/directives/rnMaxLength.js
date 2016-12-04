sharedModule.directive("rnMaxlength", function (DropDownListDataService) {
    function link(scope, element, attrs) {
        $(element).maxlength({
            limitReachedClass: "label label-danger",
            alwaysShow: true
        });
    }

    return {
        restrict: 'A',
        scope: {
            rnMaxlength: '@'
        },
        link: link
    };
});