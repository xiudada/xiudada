﻿xiudadaApp.factory("articlesResource", ["$resource", "urlServices", function ($resource, urlServices) {
    var g = urlServices.getApiUrl;

    return $resource(g("/articles/:id"), { id: "@id" }, {
        get: { method: "GET" },
        getNew: { method: "GET", url: g("/articles/getnew") },
        create: { method: "POST" },
        update: { method: "PUT" },
        list: { method: "POST", url: g("/articles/list") },
        "delete": { method: "DELETE" }
    });
}]);