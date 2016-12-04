angular.module("xiudada").controller('AppController', ['$scope', '$rootScope', '$cookies', '$window', '$translate', 'Auth', 'AUTH_EVENTS', 'USER_ROLES',
	function($scope, $rootScope, $cookies, $window, $translate, Auth, AUTH_EVENTS, USER_ROLES) {

		$scope.$on('$viewContentLoaded', function() {

		});

		var language = $cookies.get('language');
	    if (language) {
	        $translate.use(language);
	    } else {
	        $translate.use('nl');
	        $cookies.put("language", 'nl');
	    }

	    $window.changeLanguage = function (langKey) {
	        $translate.use(langKey);
	        $cookies.put("language", langKey);
	    };

		$rootScope.loginSubmitting = false;

		$rootScope.hasLogin = Auth.isAuthenticated();
		var showLoginDialog = function() {
		    Auth.clearLoginUser();
		    $rootScope.hasLogin = false;
		    $rootScope.loginSubmitting = false;
		};

		var setCurrentUser = function() {
			$rootScope.hasLogin = true;
			$rootScope.currentUser = $rootScope.currentUser;
		}

		var showNotAuthorized = function() {
			alert("Not Authorized");
		}

		$rootScope.userRoles = USER_ROLES;

		

		//listen to events of unsuccessful logins, to run the login dialog
		$rootScope.$on(AUTH_EVENTS.notAuthorized, showNotAuthorized);
		$rootScope.$on(AUTH_EVENTS.notAuthenticated, showLoginDialog);
		$rootScope.$on(AUTH_EVENTS.sessionTimeout, showLoginDialog);
		$rootScope.$on(AUTH_EVENTS.logoutSuccess, showLoginDialog);
		$rootScope.$on(AUTH_EVENTS.loginSuccess, setCurrentUser);
	}
]);
