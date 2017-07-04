(function () {
    'use strict';

    angular.module("blocks.authentication").factory("AuthenticationService", AuthenticationService);


    AuthenticationService.$inject = ['$rootScope', '$http', '$q', '$interval', 'session', 'API', 'jwtHelper'];

    function AuthenticationService($rootScope, $http, $q, $interval, session, API, jwtHelper) {

        var serviceBase = "http://localhost:60472/";
        var AuthenticationServiceFactory = {};
        var deferred = $q.defer();
        var registerUser = function (userModel) {
            return $http.post(serviceBase + 'api/account/create', {
                "email": userModel.email,
                "firstName": userModel.firstName,
                "lastName": userModel.lastName,
                "roleName": userModel.roleName,
                "password": userModel.password,
                "confirmPassword": userModel.confirmPassword
            }).then(function (response) {
                return response;
            })
        }

        var login = function (userModel) {
            return $http.post(serviceBase + 'api/account/login', {
                "username": userModel.username,
                "password": userModel.password
            }).then(function (response) {
              
                if (response.status == 200 && response.data.accessToken) {
                    session.setAccessToken(response.data.accessToken);
                    if (response.data.refreshToken) {
                        session.setRefreshToken(response.data.refreshToken);
                    }
                }
                return response;
            });
        }


        var autoLogin = function () {
            var accessToken = session.getAccessToken();
            var refreshToken = session.getRefreshToken();
            if (accessToken && refreshToken) {
                $http({
                    method: 'POST',
                    url: API.TOKEN_URI,
                    skipAuthorization: true,
                    headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                    transformRequest: function (obj) {
                        var str = [];
                        for (var p in obj) {
                            str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                        }
                        return str.join("&");
                    },
                    data: {
                        refresh_token: refreshToken,
                        grant_type: 'refresh_token'
                    }
                }).then(function (response) {
                    if (response.status == 200 && response.data.access_token) {
                        session.setAccessToken(response.data.access_token);
                        deferred.resolve(response.data.access_token);
                    }
                    else {
                        session.destroy();
                        deferred.reject();
                    }
                });
            }
            else {
                deferred.reject();
            }

            return deferred.promise;
        }

        var isLoggedIn = function() {
            var accessToken = session.getAccessToken();
            var user = false;

            if (accessToken != undefined && accessToken != 'null') {
                var isTokenExpired = jwtHelper.isTokenExpired(accessToken);
                if (isTokenExpired) {
                    user = false;
                } else {
                    user = true;
                }
            } else {
                user = false;
            }

            if (user) {
                return true;
            } else {
                return false;
            }
        };

        var logOut = function() {
            session.destroy();
            $interval.cancel($rootScope.promise);
        };

        AuthenticationServiceFactory.registerUser = registerUser;
        AuthenticationServiceFactory.login = login;
        AuthenticationServiceFactory.autoLogin = autoLogin;
        AuthenticationServiceFactory.isLoggedIn = isLoggedIn;
        AuthenticationServiceFactory.logOut = logOut;

        return AuthenticationServiceFactory;

    }
})();