(function () {
    'use strict';
    var controllerId = 'admin';
    angular.module('app.ironman')
        .controller(controllerId, ['$scope', 'common', '$http', 'config', admin]);

    function admin($scope, common, $http, config) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.title = 'Admin';

        $scope.testApi = function () {
            var serviceBase = config.apiServiceBaseUri;
            $http.get(serviceBase + '/default1')
                .success(function (data, status, headers, config) {
                    console.log("success");
                })
                .error(function (data, status, headers, config) {
                    console.log("error");
                });
        }

        activate();

        function activate() {
            common.activateController([], controllerId)
                .then(function () { log('Activated Admin View'); });
        }
    }
})();