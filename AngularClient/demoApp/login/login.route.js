(function () {
    'use strict';

    angular.module('app.login')
        .run(appRunLoginRoute);

    appRunLoginRoute.$inject = ['routerHelper'];

    function appRunLoginRoute(routerHelper) {        
        routerHelper.configureStates(getStates());        
    }

    function getStates() {
        return [
        {
            state: 'login',
            config: {
                    parent: 'public',
                    url:'/login',
                    title: 'Login - Abstract',
                    settings: {
                        group: 'loginGroup',
                    },
                    views: {
                        'public-view': {
                            templateUrl: '/demoApp/login/login.template.html',
                            controller: 'LoginController',
                            controllerAs: 'vm'
                        }
                    },
                }
            },
            {
                state: 'logout',
                config: {
                    url: '/logout',
                    template: 'nothing...',
                    //controller: function ($scope, $state, $http, $window, authentication) {                        
                    //    authentication.logOut();
                    //    $state.go('index');
                    //},
                    title: 'Logout',
                    settings: {
                        group: 'logoutGroup'
                    }
                },
            }
        ];
    }
})();
