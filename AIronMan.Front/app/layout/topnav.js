(function () {
    'use strict';

    var controllerId = 'topnav';

    angular.module('app.ironman')
        .controller(controllerId, ['$scope', '$location', 'common', 'authService', topnav]);

    function topnav($scope, $location, common, authService) {
        var vm = this;
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        vm.authentication = authService.authentication;
        vm.logOut = function () {
            authService.logOut();
            $location.path("/login");
        };

    };
})();
