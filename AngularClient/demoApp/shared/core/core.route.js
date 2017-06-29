(function () {
    'use strict';

    angular
        .module('app.core')
        .run(appRun);

    function appRun(routerHelper) {
        var otherwise = '/404';
        routerHelper.configureStates(getStates(), otherwise);
    }

    function getStates() {
        return [
            {
                state: '404',
                config: {
                    url: '/404',
                    templateUrl: '/demoApp/shared/core/404.template.html',
                    title: '404'
                }
            },
            {
                state: 'private',
                config: {                    
                    abstract: true,                    
                    templateUrl: '/demoApp/shared/core/private.layout.template.html',
                    resolve: {
                        //auth: ["$q", "authentication", "session", function ($q,authentication, session) {
                        //    //console.log('private.resolve.auth' + authentication.isLoggedIn());

                        //    var deferred = $q.defer();

                        //    if (authentication.isLoggedIn()) {
                        //        var user = session.getUser();
                        //        deferred.resolve(user);
                        //    } else {
                        //        deferred.reject('AUTH_REQUIRED');
                        //    }

                        //    return deferred.promise;
                        //}],
                    }
                }
            },
             {
                 state: 'public',
                 config: {
                     abstract: true,                    
                     templateUrl: '/demoApp/shared/core/public.layout.template.html',
                     resolve: {
                         //auth: ["$q", "authentication", function ($q,authentication) {
                         //    //console.log('public');                             
                         //    var deferred = $q.defer();

                         //    deferred.resolve(null);

                         //    return deferred.promise;
                         //}]                        
                     }
                 }
             },
        ];
    }
})();