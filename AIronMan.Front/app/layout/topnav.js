(function () {
    'use strict';

    var controllerId = 'topnav';

    angular.module('app.ironman')
        .controller(controllerId, ['$scope', '$location', 'common',  topnav]);

    function topnav($scope, $location, common) {
        var vm = this;
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
    };
})();
