(function () {
    'use strict'
    // We'll create a separate module that we can depend on
    // in our main application module.
    var translate = angular.module('translate', []);

    translate.factory('translateService', ['localStorageService', function (localStorageService) {
        // This function will be executed once. We use it as
        // a scope to keep our current language in (thus avoiding
        // the ugly use of root scope).
        var currentLanguage = 'en';
        // We copy the initial translation table that we included
        // in a separate file to our scope. (As may might change
        // this dynamically, it's good practice to make a deep copy
        // rather than just refer to it.)
        var tables = $.extend(true, {}, _translationTable);
        // We return the service object that will be injected into
        // both our filter and our application module.
        return {
            setCurrentLanguage: function (newCurrentLanguage) {
                currentLanguage = newCurrentLanguage;
            },
            getCurrentLanguage: function () {
                return currentLanguage;
            },
            translate: function (label, parameters) {
                // This is where we will add more functionality
                // once we start to do something more than
                // simply look up a label.
                var res = tables[currentLanguage][label];
                if (res) {
                    return res;
                }
                return "ERROR#" + currentLanguage + "#" + label + "#";
            }
        };
    }]);

    // The filter itself has now a very short definition; it simply
    // acts as a proxy to the xlatService's xlat function.
    translate.filter('translate', ['translateService', function (translateService) {
        return function (label) {
            return translateService.translate(label);
        };
    }]);
}())