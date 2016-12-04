sharedModule.factory('GoogleMaps', [function () {
    var maps = {};
    var markersInfoWindows = [];

    var crossDomainAjax = function (url, successCallback) {

        // IE8 & 9 only Cross domain JSON GET request
        if (navigator.userAgent.match("MSIE") && 'XDomainRequest' in window && window.XDomainRequest !== null) {

            var xdr = new XDomainRequest(); // Use Microsoft XDR
            xdr.open('get', url);
            xdr.onload = function () {
                var dom = new ActiveXObject('Microsoft.XMLDOM'), JSON = $.parseJSON(xdr.responseText);
                dom.async = false;
                successCallback(JSON); // internal function
            };
            xdr.onerror = function () {

            };
            xdr.send();
        }
            // Do normal jQuery AJAX for everything else          
        else {
            $.ajax({
                url: url,
                cache: false,
                dataType: 'json',
                type: 'GET',
                async: false, // must be set to false
                success: function (data, success) {
                    successCallback(data);
                }
            });
        }
    };

    var getLatAndLngByCityName = function (cityName, callback) {
        var latitude, longitude;
        var url = location.protocol + "//maps.googleapis.com/maps/api/geocode/json?address=" + encodeURIComponent(cityName) + "&sensor=false";
        crossDomainAjax(url, function (res) {
            if (res.results[0]) {
                latitude = res.results[0].geometry.location.lat;
                longitude = res.results[0].geometry.location.lng;
                if (callback) callback.call(this, latitude, longitude);
            }
        });
        return { CityName: cityName, Latitude: "" + latitude + "", Longitude: "" + longitude + "" };
    };

    function addMap(mapId, zoom, centerPosition) {
        maps[mapId] = new google.maps.Map(document.getElementById(mapId), {
            zoom: zoom || 8,
            center: centerPosition || new google.maps.LatLng(52.379189, 4.899431),
            disableDefaultUI: true
        });
        window.maps = maps;
        markersInfoWindows = [];
    };

    function getMap(mapId, zoom, centerPosition) {
        if (!maps[mapId]) addMap(mapId, zoom, centerPosition);
        return maps[mapId];
    };

    function addStreetView(mapId, options) {
        maps[mapId] = new google.maps.StreetViewPanorama(document.getElementById(mapId), options);
        window.maps = maps;
    }

    function getStreetView(mapId, options) {
        if (!maps[mapId]) addStreetView(mapId, options);
        return maps[mapId];
    }

    function getStreetViewUrl(mapId) {
        var url,
            $element = $("#" + mapId + " .gm-iv-address-link a");
        if ($element.length) {
            url = $element.attr("href");
        }
        return url;
    }

    function removeMap(mapId) {
        maps[mapId] = undefined;
    }

    function closeOtherInfoWindows() {
        for (var index in markersInfoWindows) {
            var item = markersInfoWindows[index];
            if (item != null) {
                item.close();
            }
        }
    };

    function addMarkerToExsitmap(options,map)
    {
        var icon = options.isCluster ? 'http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld={0}|FE6256|000000'.replace("{0}", options.number) : '';
        var userMarker = new google.maps.Marker({
            position: options.position,
            map: map,
            draggable: options.draggable,
            title: options.title,
            icon: options.icon ? options.icon : icon
        });
        return userMarker;
    }


    function addMarker(options, mapId) {
        var isCluster = options.isCluster || false;
        var map = getMap(mapId);
        var icon = options.isCluster ? 'http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld={0}|FE6256|000000'.replace("{0}", options.number) : '';
        var userMarker = new google.maps.Marker({
            position: new google.maps.LatLng(options.lat, options.lon),
            map: map,
            draggable: options.draggable,
            title: options.title,
            icon: options.icon ? options.icon : icon
        });
        if (!isCluster) {
            setTimeout(function () {
                var markerInfoWindow;
                if (options.contentId) {
                    var dom = document.getElementById(options.contentId);
                    options.content = (dom != null ? dom : options.content);
                }

                if (options.templateId) {
                    var dom = document.getElementById(options.templateId);
                    options.content = (dom != null ? dom.innerHTML : options.content);
                }

                if (options.content) {
                    markerInfoWindow = new google.maps.InfoWindow({
                        content: options.content
                    })

                    markersInfoWindows.push(markerInfoWindow);

                    google.maps.event.addListener(userMarker, 'click', function () {
                        closeOtherInfoWindows();
                        markerInfoWindow.open(map, userMarker);
                    });

                    if (options.showInfoWindow) {
                        closeOtherInfoWindows();
                        markerInfoWindow.open(map, userMarker);
                    }
                }
            }, 500);
        }
        return userMarker;
    };

    function fitBounds(markers, map) {
        var bounds = new google.maps.LatLngBounds();
        for (var index in markers) {
            var item = markers[index];
            bounds.extend(item.position);
        }
        map.fitBounds(bounds);
    };

    function getLocationNameByLatlng(lat, lng, callback) {
        var geocoder = new google.maps.Geocoder();
        var latlng = new google.maps.LatLng(lat, lng);
        geocoder.geocode({ 'latLng': latlng }, function (results, status) {
            if (status == google.maps.GeocoderStatus.OK) {
                if (results[1]) {
                    var city = {};
                    for (var i = 0; i < results[0].address_components.length; i++) {
                        for (var b = 0; b < results[0].address_components[i].types.length; b++) {
                            if (results[0].address_components[i].types[b].indexOf("administrative_area_level") > -1) {
                                city = results[0].address_components[i];
                                break;
                            }
                        }
                    }
                    //city data
                    callback(city.long_name);
                    return city.long_name;
                } else {
                    return "";
                }
            } else {
                return undefined;
            }
        });
    };

    function getStreetViewParamsFromUrl(url) {
        if (!url) {
            return;
        }
        var params = null,
            reg = /\/@([^/]+?)\//gi,
            matches = reg.exec(url);
        if (matches) {
            var info = matches[1];
            reg = /(-?\d*\.?\d*),(-?\d*\.?\d*),(-?\d+\.?\d*)a,(-?\d+\.?\d*)y,(-?\d+\.?\d*)h,(-?\d+\.?\d*)t/i;
            matches = reg.exec(info);
            if (matches) {
                params = {
                    lat: parseFloat(matches[1]),
                    lng: parseFloat(matches[2]),
                    a: parseFloat(matches[3]),
                    y: parseFloat(matches[4]),
                    heading: parseFloat(matches[5]),
                    pitch: parseFloat(matches[6])-90
                };
            }
            return params;
        }
    }

    return {
        addMap: addMap,
        getMap: getMap,
        addMarker: addMarker,
        fitBounds: fitBounds,
        getLocationNameByLatlng: getLocationNameByLatlng,
        getLatAndLngByCityName: getLatAndLngByCityName,
        removeMap: removeMap,
        getStreetViewParamsFromUrl: getStreetViewParamsFromUrl,
        addStreetView: addStreetView,
        getStreetView: getStreetView,
        getStreetViewUrl: getStreetViewUrl,
        addMarkerToExsitmap: addMarkerToExsitmap
    };
}])
.directive('streetviewUrl', ['GoogleMaps', function (googleMaps) {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function (scope, elm, attrs, ctrl) {
            ctrl.$parsers.unshift(function (viewValue) {
                if (!viewValue || googleMaps.getStreetViewParamsFromUrl(viewValue)) {
                    ctrl.$setValidity('streetviewurl', true);
                    return viewValue;
                } else {
                    ctrl.$setValidity('streetviewurl', false);
                    return undefined;
                }
            });
        }
    }
}]);
