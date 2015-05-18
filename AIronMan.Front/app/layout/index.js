//Top level controller 
(function () {
    'use strict';
    var controllerId = 'indexCtrl';
    angular.module('app.ironman').controller(controllerId, ['common', '$location', 'authService' , index]);

    function index(common, $location, authService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var top = this;
        top.title = "index";

        top.authentication = authService.authentication;
        top.logOut = function () {
            authService.logOut();
            $location.path("/login");
        };
    }
})();