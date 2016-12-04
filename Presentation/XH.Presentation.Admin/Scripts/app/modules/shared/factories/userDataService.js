sharedModule.factory('UserDataService', function () {
    function getUserTypeList() {
        return [
            { label: 'Broker manager', value: 'BrokerManager' },
            { label: 'Customer', value: 'Customer' },
        ]
    };

    function getUserTypeValueList() {
        return ['BrokerManager', 'Customer'];
    };

    return {
        getUserTypeList: getUserTypeList,
        getUserTypeValueList: getUserTypeValueList
    }
});