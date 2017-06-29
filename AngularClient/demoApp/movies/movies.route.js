(function () {
    'use strict';

    angular.module('app.movies')
        .run(movieRoute);

    movieRoute.$inject = ['routerHelper'];

    function movieRoute(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [
            {
                state: 'movie',
                config: {
                    url: '/movie',
                    parent: 'private',
                    title: 'Movie',
                    views: {
                        'main-content': {
                            templateUrl: 'demoApp/movie/movie.template.html',
                            controller: 'MovieController',
                            controllerAs: 'vm'
                        }
                    }
                }
            }
        ];
    };

})();