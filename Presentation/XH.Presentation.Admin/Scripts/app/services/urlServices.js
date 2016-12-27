xiudadaApp.factory("urlServices", ["siteConfiguration", function (siteConfiguration) {
    var getApiUrl = function (url) {
        if (url.indexOf("http") == -1) {
            return siteConfiguration.apiDomain + url;
        }

        return url;
    }


    return {
        getApiUrl: getApiUrl
    }
}]);