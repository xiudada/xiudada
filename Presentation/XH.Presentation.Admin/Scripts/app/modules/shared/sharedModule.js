////Call this to register our module to main application
var sharedModuleName = "realNext.service.sharedModule";
if (AppDependencies != undefined) {
    AppDependencies.push(sharedModuleName);
}
var sharedModule = angular.module(sharedModuleName, []);
//sharedModule.config(function ($httpProvider) {
//    var defaultHeaders = {
//        'Content-Type': 'application/json',
//        'Ocp-Apim-Subscription-Key': 'b4a82d1c45794491acb90b8ed1256723'
//    };

//    $httpProvider.defaults.headers.get = defaultHeaders;
//    $httpProvider.defaults.headers.post = defaultHeaders;
//    $httpProvider.defaults.headers.put = defaultHeaders;
//    $httpProvider.defaults.headers.delete = defaultHeaders;
//});
sharedModule
.constant("LINKED_OFFER_EVENT", {
    updateInvitationSuccess: "update-invitation-success"
})
.constant("ModuleType", {
    SearchModule: "SearchModule",
    ServiceModule: "ServiceModule",
    ManagementModule: "ManagementModule"
})
.constant('TransactionType', {
    DebitTransaction: 'DebitTransaction',
    CreditTransaction: 'CreditTransaction'
});

sharedModule.filter('trustAsHtml', ['$sce', function ($sce) {
    return function (html) {
        return $sce.trustAsHtml("" + html);
    };
}]);