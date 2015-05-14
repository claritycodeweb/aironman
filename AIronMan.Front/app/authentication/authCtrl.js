(function () {
    'use strict';

    var controllerId = 'authCtrl';

    angular.module('authentication')
        .controller(controllerId, ['$scope', '$location',  '$filter', 'common', 'authService', authentication]);

    function authentication($scope, $location, $filter, common, authService) {

        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        $scope.loginData = {
            userName: "",
            password: ""
        };

        $scope.message = "";

        $scope.login = function (isValid) {

            if (isValid) {
                $scope.message = "Validation";
                authService.login($scope.loginData)
                    .then(function(response) {

                            $location.path('/');
                        },
                        function(err) {
                            $scope.message = err;
                        });
            } else {
                $scope.message = $filter('translate')('MSG_UserNameAndPassowrdArRequired');
            }
        };

        activate();

        function activate() {
            common.activateController([], controllerId)
                .then(function () { log('Activated Login View'); });
        }

    };
})();
