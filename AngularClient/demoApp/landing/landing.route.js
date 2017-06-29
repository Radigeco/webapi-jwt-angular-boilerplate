(function () {
    'use strict';

    angular.module('app.landing')
        .run(landingRoute);

    landingRoute.$inject = ['routerHelper'];

    function landingRoute(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        // these 2 states are needed for the following urls:
        // //localhost:XXXX
        // //localhost:XXXX/#/
        return [
            {
                state: 'domain',
                config: {
                    parent: 'public',                    
                    templateUrl: '/demoApp/landing/landing.template.html',
                    title: 'Home',
                }
            },
            {
                state: 'index',
                config: {
                    url: '/',
                    parent: 'public',
                    title: 'Home',
                    views: {
                        'public-view': {
                            templateUrl: '/demoApp/landing/landing.template.html',
                            controller: 'LandingController',
                            controllerAs: 'vm',
                        }
                    },
                }
            },
            {
                state: 'index2',
                config: {
                    url: '',
                    parent: 'public',
                    title: 'Home',
                    views: {
                        'public-view': {
                            templateUrl: '/demoApp/landing/landing.template.html',
                            controller: 'LandingController',
                            controllerAs: 'vm',
                        }
                    },
                }
            }
        ];
    }
})();