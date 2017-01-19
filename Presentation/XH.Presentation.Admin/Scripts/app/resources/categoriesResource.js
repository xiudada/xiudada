xiudadaApp.factory("categoriesResource", ["$resource", "urlServices", function ($resource, urlServices) {
    var g = urlServices.getApiUrl;

    return $resource(g("/categories/:id"), { id: "@id" }, {
        get: { method: "GET" },
        getNew: { method: "GET", url: g("/categories/getnew") },
        create: { method: "POST" },
        update: { method: "PUT" },
        list: { method: "POST", url: g("/categories/list") },
        "delete": { method: "DELETE" }
    });
}]);