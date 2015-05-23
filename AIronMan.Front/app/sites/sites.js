(function () {
    'use strict';
    var controllerId = 'sites';
    angular.module('app.ironman').controller(controllerId, ['common', '$filter', 'siteService', '$timeout', sites]);

    function sites(common, $filter, siteService, $timeout) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.title = 'Sites';

        activate();

        function activate() {
            var promises = [getSites()];
            common.activateController([], controllerId)
                .then(function () { log('Activated Sites View'); });
        }

        function getSites() {
            return siteService.get().then(function (results) {
                return vm.sites = results;

            }, function (error) {
                alert(error.data.message);
            });
        }
    }
})();