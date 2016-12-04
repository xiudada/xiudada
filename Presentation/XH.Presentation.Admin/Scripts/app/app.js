var AppDependencies = [
    'ui.router',
    'ui.bootstrap',
    'ui.tinymce',
    'ui.select',
    'ngCookies',
    'oc.lazyLoad',
    'ngSanitize',
    'ngResource',
    'angularFileUpload',
    'oitozero.ngSweetAlert',
    'frapontillo.bootstrap-switch',
    'angularMoment',
    'bootstrap-tagsinput',
    'pascalprecht.translate'
];

angular.module("xiudada", AppDependencies);



/* constant start */
angular.module("xiudada").constant("realNext.Service.Configs", {
    "ApiDomain": undefined,
    "MediaApiDomain": undefined,
    "AzureBlobStorageDomain": undefined,
    'OrganizationId': undefined,
    'SearchEngineId': undefined,
    "IsRealNextSearchEngine": undefined
});

/* constant end */
angular.module("xiudada")
    .config(['$translateProvider', "$uibModalProvider", "blockUIConfig",
        function ($translateProvider, $uibModalProvider, blockUIConfig) {
            /*
            $translateProvider
                .translations('en', {
                    HEADLINE: 'Hello there, This is my awesome app!',
                    INTRO_TEXT: 'And it has i18n support!',
                    BUTTON_TEXT_EN: 'english',
                    BUTTON_TEXT_DE: 'german'
                })
                .translations('de', {
                    HEADLINE: 'Hey, das ist meine gro遖rtige App!',
                    INTRO_TEXT: 'Und sie unters黷zt mehrere Sprachen!',
                    BUTTON_TEXT_EN: 'englisch',
                    BUTTON_TEXT_DE: 'deutsch'
                });
        
            //eg: {{ 'HEADLINE' | translate }}
            */

            $translateProvider.useStaticFilesLoader({
                prefix: '/Areas/Service/scripts/languages/',
                suffix: '.json'
            });

            $translateProvider.preferredLanguage('nl');

            // Config bootstrap ui-modal
            $uibModalProvider.options.backdrop = false;

            // Config block ui
            blockUIConfig.autoBlock = false;
        }]);

/* Setup global settings */
angular.module("xiudada").factory('settings', ['$rootScope', function ($rootScope) {
    // supported languages
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

    $rootScope.maskCurrencySetting = {
        alias: "numeric",
        groupSeparator: ".",
        radixPoint: ",",
        autoGroup: true,
        digits: 2,
        prefix: "€ ",
        rightAlign: false,
        autoUnmask: true,
        unmaskAsNumber: true
    };

    $rootScope.maskIntSetting = {
        alias: "numeric",
        groupSeparator: ".",
        radixPoint: ",",
        autoGroup: true,
        digits: 0,
        rightAlign: false,
        autoUnmask: true,
        unmaskAsNumber: true
    };

    $rootScope.maskDecimalSetting = {
        alias: "numeric",
        groupSeparator: ".",
        radixPoint: ",",
        autoGroup: true,
        digits: 2,
        rightAlign: false,
        autoUnmask: true,
        unmaskAsNumber: true
    };

    $rootScope.settings = settings;
    return settings;
}]);

/* Init global settings and run the app */
angular.module("xiudada").run(["$rootScope", "settings", "$state", "realNext.Service.Configs", function ($rootScope, settings, $state, realNextConfig) {
    $rootScope.$state = $state; // state to be accessed from view
    $rootScope.$settings = settings; // state to be accessed from view
    $rootScope.ImageUrl = function (url, args) {
        if (!url) {
            return "";
        }
        if (url.indexOf("http://") === -1) {
            url = "{0}{1}{2}".formatWith(realNextConfig.MediaApiDomain, '/image-resizing', url);
        }
        if (args) {
            url = url.addQueryStringArgs(args);
        }
        return url;
    };
    $rootScope.BrochureUrl = function (url) {
        if (!url) {
            return "";
        }
        if (url.indexOf("http://") === -1) {
            url = "{0}{1}".formatWith(realNextConfig.AzureBlobStorageDomain, url);
        }
        return url;
    }
}]);

angular.module("xiudada").run(['$rootScope', '$state', '$window', 'Auth', 'AUTH_EVENTS', 'PermissionNameConstrant', 'realNext.Service.Configs',
    function ($rootScope, $state, $window, Auth, AUTH_EVENTS, permissionNameConstrant, configs) {
        $rootScope.isRealNextSearchEngine = configs.IsRealNextSearchEngine;
        $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
            // when tostate is empty . it's a ajax request
            if (!_.isEmpty(toState)) {
                if ($rootScope.hasLogin) {
                    // every controller need to set PermissionCode
                    if (_.isEmpty(toState.permissionCode)) {
                        // temp comment:  when don't set permissionCode in router.js let it go
                        //$state.go('nopermission', {denyPage: toState.url});
                    } else {

                        var hasPermission = Auth.checkPermission(toState.permissionCode);

                        if (!hasPermission) {
                            $state.go('nopermission', { denyPage: toState.url });
                        }
                    }
                }
            } else {

            }
        });

        /* To show current active state on menu */
        $rootScope.getClass = function (path) {
            if ($state.current.name == path) {
                return "active";
            } else {
                return "";
            }
        }

        $rootScope.logout = function () {
            Auth.logout();
        };

        // permissionNameList is a array
        $rootScope.checkMainMenu = function (permissionNameList) {
            var permissionCodeList = [];
            if (_.isEmpty(permissionNameList)) {
                return false;
            }

            for (var i = permissionNameList.length - 1; i >= 0; i--) {
                var permissionName = permissionNameList[i];
                if (_.isEmpty(permissionName)) {
                    console.log("Please input permission name!")
                } else {
                    permissionCodeList.push(permissionNameConstrant[permissionName]);
                }
            };

            for (var i = permissionCodeList.length - 1; i >= 0; i--) {
                if (Auth.checkPermission(permissionCodeList[i])) {
                    return true;
                }
            };

            return false;
        }

        $rootScope.checkMenu = function (permissionName) {
            var permissionCode = permissionNameConstrant[permissionName];
            if (_.isEmpty(permissionCode)) {
                console.log("Please input permission name!");
                return false;
            }
            return Auth.checkPermission(permissionCode);
        }

        $rootScope.checkMutiplyPermission = function (permissionNameList) {
            if (_.isEmpty(permissionNameList)) {
                return false;
            }

            for (var i = permissionNameList.length - 1; i >= 0; i--) {
                if ($rootScope.checkPermission(permissionNameList[i])) {
                    return true;
                }
            };

            return false;
        }

        $rootScope.checkPermission = function (permissionName) {
            var permissionCode = permissionNameConstrant[permissionName];
            if (_.isEmpty(permissionCode)) {
                console.log("Please input permission name!");
                return false;
            }
            return Auth.checkPermission(permissionCode);
        }

        $rootScope.getCulumnClass = function (paginationConfig, culumnName) {
            if (paginationConfig.sortCulumn.sortName == culumnName) {
                if (paginationConfig.sortCulumn.sortType == "asc") {
                    return "sorting_asc";//sorting_desc
                }
                else if (paginationConfig.sortCulumn.sortType == "desc") {
                    return "sorting_desc";
                }
            }
            else {
                return "sorting";
            }
        };

        $rootScope.sortCulumnClick = function (paginationConfig, sortCulumnName) {
            if (paginationConfig.sortCulumn.sortName == sortCulumnName) {
                if (paginationConfig.sortCulumn.sortType == "asc") {
                    paginationConfig.sortCulumn.sortType = "desc";
                } else if (paginationConfig.sortCulumn.sortType == "desc") {
                    paginationConfig.sortCulumn.sortType = "asc";
                }
            } else {
                paginationConfig.sortCulumn.sortName = sortCulumnName;
                paginationConfig.sortType = "asc";
            }
        };

        $rootScope.back = function () {
            $window.history.back();
        };

        $rootScope.getHouseNumberStr = function (houseNumber, houseNumberTo, houseNumberAddition) {
            var result = "";

            if (houseNumber) {
                result += houseNumber;
            }

            if (houseNumberTo) {
                if (houseNumber && houseNumberTo) {
                    result += ("-" + houseNumberTo);
                } else {
                    result += houseNumberTo;
                }
            }

            if (houseNumberAddition) {
                result += " " + houseNumberAddition;
            }

            return result;
        }

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