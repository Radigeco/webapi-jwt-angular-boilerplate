(function () {
    'use strict';

    angular.module('app.home')
        .run(homeRoute);

    homeRoute.$inject = ['routerHelper'];

    function homeRoute(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [
            {
                state: 'home',
                config: {
                    url: '/home',
                    parent: 'private',
                    title: 'Home',
                    views: {
                        'main-content': {
                            templateUrl: 'demoApp/home/home.template.html',
                            controller: 'HomeController',
                            controllerAs: 'vm'
                        }
                    }
                }
            }
        ];
    };

})();