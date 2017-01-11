// Global app
var xiudadaApp = angular.module("xiudadaApp", [
    "ui.router",
    "ui.bootstrap",
    "oc.lazyLoad",
    "ui.tinymce",
    "ngSanitize",
    "ngResource"
]);

/* Configure ocLazyLoader(refer: https://github.com/ocombe/ocLazyLoad) */
xiudadaApp.config(['$ocLazyLoadProvider', function ($ocLazyLoadProvider) {
    $ocLazyLoadProvider.config({
        // global configs go here
    });
}]);

//AngularJS v1.3.x workaround for old style controller declarition in HTML
xiudadaApp.config(['$controllerProvider', function ($controllerProvider) {
    // this option might be handy for migrating old apps, but please don't use it
    // in new ones!
    $controllerProvider.allowGlobals();
}]);

/* Setup global settings */
xiudadaApp.factory('settings', ['$rootScope', function ($rootScope) {
    var settings = {
        layout: {
            pageSidebarClosed: false, // sidebar menu state
            pageContentWhite: true, // set page content layout
            pageBodySolid: false, // solid body color state
            pageAutoScrollOnLoad: 1000 // auto scroll to top on page load
        },
        assetsPath: '/assets',
        globalPath: '/assets/global',
        layoutPath: '/assets/layouts/layout',
    };

    $rootScope.settings = settings;
    return settings;
}]);

xiudadaApp.constant("siteConfiguration", {
    "apiDomain": "http://api.xiudada.com"
});

/* Init global settings and run the app */
xiudadaApp.run(["$rootScope", "settings", "$state", function ($rootScope, settings, $state) {
    $rootScope.$state = $state; // state to be accessed from view
    $rootScope.$settings = settings; // state to be accessed from view

    // tinymce options
    $rootScope.tinymceOptions = {
        selector: 'textarea',
        height: 300,
        plugins: [
            'advlist autolink lists link image charmap print preview anchor',
            'searchreplace visualblocks code fullscreen',
            'insertdatetime media table contextmenu paste'
        ],
        contextmenu: "cut copy paste | link image inserttable | cell row column deletetable",
        browser_spellcheck: true,
        //content_css: "css/content.css",
        toolbar: "insertfile undo redo | styleselect | bold italic forecolor backcolor | fontselect | fontsizeselect | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | preview",
        relative_urls: false, //required for images display
        force_br_newlines: false,
        force_p_newlines: false,
        forced_root_block: '',
        convert_urls: false,
        resize: "both",
        valid_children: "+body[style],+body[link],+body[script],",
        extended_valid_elements: "link[href|rel|type],script[src|type],style[type],iframe[src|style|width|height|scrolling|marginwidth|marginheight|frameborder]",
        verify_html: false,
        valid_elements: '*[*]',
        style_formats: [
            { title: 'Bold text', inline: 'b' },
            { title: 'Red text', inline: 'span', styles: { color: '#ff0000' } },
            { title: 'Red header', block: 'h1', styles: { color: '#ff0000' } },
            { title: 'Example 1', inline: 'span', classes: 'example1' },
            { title: 'Example 2', inline: 'span', classes: 'example2' },
            { title: 'Table styles' },
            { title: 'Table row 1', selector: 'tr', classes: 'tablerow1' }
        ],
        setup: function (ed) {
            ed.on('BeforeSetContent', function (e) {
                e.format = 'raw';
            });
        },
        init_instance_callback: function (editor) {
            editor.on('PastePreProcess', function (e) {
                console.log(e);
                //e.content += 'My custom content!';
            });
        }
    }
}]);