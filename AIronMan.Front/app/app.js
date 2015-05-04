/**
 * IronMan Web CMS config
 * @author Rafał Pisarczyk <rafalpisarczyk@gmail.com>
 */

(function () {
    'use strict';

    var app = angular.module('app.ironman', [
        // Angular modules 
        'ngAnimate',        // animations
        'ngRoute',          // routing
        'ngSanitize',       // sanitizes html bindings (ex: sidebar.js)

        'LocalStorageModule',
        'angular-loading-bar',

        // Custom modules 
        'common',           // common functions, logger, spinner
        'common.bootstrap', // bootstrap dialog wrapper functions
        'translate',
        'authentication',
        // 3rd Party Modules
        'ui.bootstrap'      // ui-bootstrap (ex: carousel, pagination, dialog)
    ]);

    // Handle routing errors and success events
    app.run(['$route', function ($route) {
        // Include $route to kick start the router.
    }]);

    app.run(['$rootScope', 'authService', '$location', function ($rootScope, authService, $location) {

        authService.fillAuthData();

        $rootScope.page = {
            setTitle: function (title) {
                this.title = title + ' | Site Name';
            }
        }

        $rootScope.$on('$routeChangeSuccess', function (event, current, previous) {
            $rootScope.page.setTitle(current.$$route.title || 'Default Title');
        });

        // register listener to watch route changes
        $rootScope.$on("$locationChangeStart", function (event, next, current) {
            if (!authService.authentication.isAuth) {
                // no logged user, we should be going to #login
                if (next.templateUrl == "app/authentication/views/login.html") {
                    // already going to #login, no redirect needed
                } else {
                    // not going to #login, we should redirect now
                    //console.log("redirect to login");
                    $location.path("/login");
                }
            }
        });
    }]);
})();