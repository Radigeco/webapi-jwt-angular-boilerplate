(function () {
    'use strict';

    angular.module('demoApp').config(function ($routeProvider) {

        $routeProvider
            // route for the home page
            .when('/', {
                templateUrl: 'demoApp/home/home.template.html',
                controller: 'HomeController'
            })

            // route for the about page
            .when('/movies', {
                templateUrl: 'demoApp/movies/movies.template.html',
                controller: 'MoviesController'
            })

            // route for the contact page
            .when('/bootstrapTutorial', {
                templateUrl: 'demoApp/bootstrapTutorial/bootstrapTutorial.template.html',
                controller: 'BootstrapTutorialController'
            });
    })


})();