(function () {
    'use strict';
    var siteService = angular.module('app.ironman');

    siteService.factory('siteService', [
            '$http', '$q', 'localStorageService', 'config', function ($http, $q, localStorageService, config) {

                var serviceBase = config.apiServiceBaseUri;
                var siteServiceFactory = {};

                var _get = function (loginData) {

                    var deferred = $q.defer();

                    var request = {
                        method: 'GET',
                        url: serviceBase + '/site',
                        headers: {
                            'Content-Type': undefined
                        }
                    }

                    $http(request).success(function (data, status, headers, config) {

                        deferred.resolve(data);

                    }).error(function (data, status, headers, config) {

                        deferred.reject(data);

                    });

                    return deferred.promise;

                };

                siteServiceFactory.get = _get;

                return siteServiceFactory;

            }
    ]);
})();