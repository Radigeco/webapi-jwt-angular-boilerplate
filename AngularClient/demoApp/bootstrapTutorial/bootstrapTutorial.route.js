(function () {
    'use strict';

    angular.module('app.bootstrapTutorial')
        .run(bootstrapTutorialRoute);

    bootstrapTutorialRoute.$inject = ['routerHelper'];

    function bootstrapTutorialRoute(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [
            {
                state: 'bootstrapTutorial',
                config: {
                    url: '/bootstrapTutorial',
                    parent: 'private',
                    title: 'Bootstrap tutorial',
                    views: {
                        'main-content': {
                            templateUrl: 'demoApp/bootstrapTutorial/bootstrapTutorial.template.html',
                            controller: 'BootstrapTutorialController',
                            controllerAs: 'vm'
                        }
                    }
                }
            }
        ];
    };

})();