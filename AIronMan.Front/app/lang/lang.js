(function () {
    'use strict'

    var controllerId = 'LangController';
    angular.module('app.ironman').controller(controllerId, ['$scope', 'config', 'translateService', lang]);

    function lang($scope, config, translateService) {
        // So we can create a $scope function that can be linked
        // to the click of a change-language button.
        $scope.setCurrentLanguage = function (language) {
            config.currentLanguage = language;
            translateService.setCurrentLanguage(language);
        };
    }
})();