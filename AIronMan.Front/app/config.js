(function () {
    'use strict';

    var app = angular.module('app.ironman');
    
    // Configure Toastr
    toastr.options.timeOut = 4000;
    toastr.options.positionClass = 'toast-bottom-right';

    // For use with the HotTowel-Angular-Breeze add-on that uses Breeze
    var remoteServiceName = 'breeze/Breeze';

    var events = {
        controllerActivateSuccess: 'controller.activateSuccess',
        spinnerToggle: 'spinner.toggle'
    };

    var config = {
        appErrorPrefix: '[AIron Error] ', //Configure the exceptionHandler decorator
        docTitle: 'AIronMan: ',
        events: events,
        remoteServiceName: remoteServiceName,
        version: '0.0.1',
        apiServiceBaseUri: 'http://localhost/AIronMan.Api/Api',
        currentLanguage: 'pl'
    };

    app.value('config', config);

    app.config(function ($httpProvider) {
        $httpProvider.interceptors.push('httpResponseInterceptorService');
    });

    app.config(['$logProvider', function ($logProvider) {
        // turn debugging off/on (no info or warn)
        if ($logProvider.debugEnabled) {
            $logProvider.debugEnabled(true);
        }
    }]);

    //#region Configure the common services via commonConfig
    app.config(['commonConfigProvider', function (cfg) {
        cfg.config.controllerActivateSuccessEvent = config.events.controllerActivateSuccess;
        cfg.config.spinnerToggleEvent = config.events.spinnerToggle;
    }]);

    app.run(['translateService', function (translateService) {
        translateService.setCurrentLanguage(config.currentLanguage);
    }]);
})();