(function () {
    'use strict';
    var controllerId = 'sites';
    angular.module('app').controller(controllerId, ['common', sites]);

    function sites(common) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.title = 'Sites';

        activate();

        function activate() {
            common.activateController([], controllerId)
                .then(function () { log('Activated Sites View'); });
        }
    }
})();