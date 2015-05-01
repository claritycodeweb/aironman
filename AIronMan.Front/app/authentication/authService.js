(function () {
    'use strict';
    var authentication = angular.module('authentication', []);

    authentication.factory('authService', [
            '$http', '$q', 'localStorageService', 'config', function ($http, $q, localStorageService, config) {

                var serviceBase = config.apiServiceBaseUri;
                var authServiceFactory = {};

                var _authentication = {
                    isAuth: false,
                    userName: "",
                    useRefreshTokens: false
                };

                var _login = function (loginData) {

                    var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

                    var deferred = $q.defer();

                    $http.post(serviceBase + '/account/Authenticate', data,
                        {
                             headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' }
                        })
                        .success(function (data, status, headers, config) {

                            localStorageService.set('authorizationData', {
                                userName: loginData.userName,
                                token: data.Token,
                            });

                            _authentication.isAuth = true;
                            _authentication.userName = loginData.userName;

                            deferred.resolve(data);

                        }).error(function (data, status, headers, config) {
                            console.log(data);
                            console.log(status);
                            _logOut();
                            deferred.reject(data);
                        });

                    return deferred.promise;

                };

                var _logOut = function () {

                    localStorageService.remove('authorizationData');

                    _authentication.isAuth = false;
                    _authentication.userName = "";

                };

                var _fillAuthData = function () {

                    var authData = localStorageService.get('authorizationData');

                    if (authData) {
                        _authentication.isAuth = true;
                        _authentication.userName = authData.userName;
                    }
                };

                authServiceFactory.login = _login;
                authServiceFactory.logOut = _logOut;
                authServiceFactory.fillAuthData = _fillAuthData;
                authServiceFactory.authentication = _authentication;

                return authServiceFactory;
            }
    ]);
})();