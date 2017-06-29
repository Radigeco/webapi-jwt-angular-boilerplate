(function () {
    'use strict';

    angular
        .module('blocks.session')
        .factory('session', session);

    session.$inject = ['$http', '$q', 'API', '$window', 'jwtHelper'];

    /* @ngInject */
    function session($http, $q, API, $window, jwtHelper) {

        //var _user = null;
        //var _accessToken = $window.localStorage[API.TOKEN_ACCESS_KEY];
        //var _refreshToken = $window.localStorage[API.TOKEN_REFRESH_KEY];

        var service = {
            getUser: getUser,
            getAccessToken: getAccessToken,
            setAccessToken: setAccessToken,
            getRefreshToken: getRefreshToken,
            setRefreshToken: setRefreshToken,
            destroy: destroy
        };

        return service;
        /////////////////////

        function getUser() {
            var token = $window.localStorage[API.TOKEN_ACCESS_KEY];
            if (token == undefined || token == 'null') {
                return null;
            } else {                
                return jwtHelper.decodeToken(token);
            }            
        };

        function getAccessToken() {            
            var token = $window.localStorage[API.TOKEN_ACCESS_KEY];
            if (token == undefined || token == 'null') {
                return null;
            } else {
                return token;
            }
        };

        function setAccessToken(token) {            
            $window.localStorage[API.TOKEN_ACCESS_KEY] = token;
        };

        function getRefreshToken(token) {
            return $window.localStorage[API.TOKEN_REFRESH_KEY];
        };

        function setRefreshToken(token) {            
            $window.localStorage[API.TOKEN_REFRESH_KEY] = token;
        };

        function destroy() {            
            setAccessToken(null);
            setRefreshToken(null);
        };
    }
}());
