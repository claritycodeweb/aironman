(function () {
    'use strict';

    var controllerId = 'authCtrl';

    angular.module('authentication')
        .controller(controllerId, ['$scope', '$location', 'common', 'authService', authentication]);

    function authentication($scope, $location, common, authService) {

        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        $scope.loginData = {
            userName: "",
            password: ""
        };

        $scope.message = "";

        $scope.login = function () {

            authService.login($scope.loginData)
                .then(function (response) {

                    $location.path('/');
                },
                function (err) {
                    $scope.message = err;
                });
        };

        activate();

        function activate() {
            common.activateController([], controllerId)
                .then(function () { log('Activated Login View'); });
        }

    };
})();
