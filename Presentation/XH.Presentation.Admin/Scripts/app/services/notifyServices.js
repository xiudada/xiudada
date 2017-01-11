xiudadaApp.factory("notifyServices", ["$rootScope", function ($rootScope) {
    var notifyOptions = {
        "closeButton": true,
        "debug": false,
        "positionClass": "toast-top-right",
        "onclick": null,
        "showDuration": "1000",
        "hideDuration": "1000",
        "timeOut": "3000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };

    function notify(msg, type, title) {
        var typedic = {
            0: "error",
            1: "success",
            2: "info",
            3: "warning"
        };
        type = typedic[type] || "info";
        toastr.options = this.notifyOptions;
        msg = msg || "";
        title = title || "";
        toastr[type](msg, title);
    }

    return {
        success: function (msg, title) {
            notify(msg, 1, title);
        },
        error: function (msg, title) {
            notify(msg, 0, title);
        },
        info: function (msg, title) {
            notify(msg, 2, title);
        },
        notify: notify
    }
}]);