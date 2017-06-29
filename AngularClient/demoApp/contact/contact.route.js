(function () {
    'use strict';

    angular.module('app.contact')
        .run(contactRoute);

    contactRoute.$inject = ['routerHelper'];

    function contactRoute(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [
            {
                state: 'contact',
                config: {
                    url: '/contact',
                    parent: 'private',
                    title: 'Home',
                    views: {
                        'main-content': {
                            templateUrl: 'demoApp/contact/contact.template.html',
                            controller: 'ContactController',
                            controllerAs: 'vm'
                        }
                    }
                }
            }
        ];
    };

})();