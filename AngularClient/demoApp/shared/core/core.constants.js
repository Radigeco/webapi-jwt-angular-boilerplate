(function () {
    'use strict';

    angular
        .module('app.core')
        .constant('API', {
            URI: '//localhost:60472/',
            TOKEN_URI: '//localhost:60472/api/oauth/token',
            TOKEN_ACCESS_KEY: 'jwtAccessToken',
            TOKEN_REFRESH_KEY: 'jwtRefreshToken',
        })
        .constant('ngAuthSettings', {
            apiServiceBaseUri: "http://localhost:60472/",
            clientId: 'ngAuthApp'
        });
})();