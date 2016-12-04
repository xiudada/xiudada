//sharedModule.factory('ImageService', ['realNext.Configs', function (realNextConfig) {
//    var mediaApiDomain = realNextConfig.ImageApiDomain,
//        getImageAbsoluteUrl = function (url, args) {
//            if (!url) {
//                return "";
//            }
//            if (url.indexOf("http://") === -1) {
//                url = "{0}{1}".formatWith(mediaApiDomain, url);
//            }
//            if (args) {
//                url = url.addQueryStringArgs(args);
//            }
//            return url;
//        };

//    return {
//        getImageUrl: getImageAbsoluteUrl
//    }
//}]);