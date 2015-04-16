(function() {
    'use strict';
    var authentication = angular.module('authentication', []);

    authentication.factory('authService', [
            '$http', '$q', 'localStorageService', 'config', function($http, $q, localStorageService, config) {

                var serviceBase = config.apiServiceBaseUri;
                var authServiceFactory = {};

                var _authentication = {
                    isAuth: false,
                    userName: "",
                    useRefreshTokens: false
                };

                var _login = function(loginData) {

                    var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

                    if (loginData.useRefreshTokens) {
                        data = data + "&client_id=" + ngAuthSettings.clientId;
                    }

                    var deferred = $q.defer();

                    $http.post(serviceBase + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function(response) {

                        if (loginData.useRefreshTokens) {
                            localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName, refreshToken: response.refresh_token, useRefreshTokens: true });
                        } else {
                            localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName, refreshToken: "", useRefreshTokens: false });
                        }
                        _authentication.isAuth = true;
                        _authentication.userName = loginData.userName;
                        _authentication.useRefreshTokens = loginData.useRefreshTokens;

                        deferred.resolve(response);

                    }).error(function(err, status) {
                        _logOut();
                        deferred.reject(err);
                    });

                    return deferred.promise;

                };

                var _logOut = function() {

                    localStorageService.remove('authorizationData');

                    _authentication.isAuth = false;
                    _authentication.userName = "";
                    _authentication.useRefreshTokens = false;

                };

                var _fillAuthData = function() {

                    var authData = localStorageService.get('authorizationData');
                    if (authData) {
                        _authentication.isAuth = true;
                        _authentication.userName = authData.userName;
                        _authentication.useRefreshTokens = authData.useRefreshTokens;
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