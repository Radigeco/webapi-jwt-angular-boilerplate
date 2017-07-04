(function () {
    'use strict';

    var core = angular.module('app.core');

    var config = {
        appTitle: 'App'
    };
    core.value('config', config);
    core.config(configCore);
    core.$inject = ['$uibModal']
    configCore.$inject = ['API', '$logProvider', '$httpProvider', '$injector', 'routerHelperProvider', 'jwtInterceptorProvider', 'jwtOptionsProvider'];

    function configCore(API, $logProvider, $httpProvider, $injector, routerHelperProvider, jwtInterceptorProvider, jwtOptionsProvider) {
        // logging
        if ($logProvider.debugEnabled) {
            $logProvider.debugEnabled(true);
        }

        //exceptionHandlerProvider.configure(config.appErrorPrefix);
        routerHelperProvider.configure({ docTitle: config.appTitle + ': ' });
        jwtOptionsProvider.config({
            whiteListedDomains: ['localhost']
        });

        // token
        jwtInterceptorProvider.tokenGetter = [
            '$state', 'session', 'AuthenticationService', 'jwtHelper',
            function ($state, session, AuthenticationService, jwtHelper) {
                var access_token = session.getAccessToken();
                if (access_token != null && jwtHelper.isTokenExpired(access_token)) {
                    // handle refresh token
                    return AuthenticationService.autoLogin().then(function (token) {
                        return token;
                    }, function () {
                        $state.go('index');
                        return null;
                    });
                } else {
                    //if (access_token == null) {
                    //    $state.go('login');
                    //}
                    return access_token;
                }
            }];
        $httpProvider.interceptors.push('jwtInterceptor', 'errorInterceptor');
    };

   

})();