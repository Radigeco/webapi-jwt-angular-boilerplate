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
                controller: 'MoviesController as vm'
            })

            // route for the contact page
            .when('/contact', {
                templateUrl: 'demoApp/contact/contact.template.html',
                controller: 'ContactController'
            });
    })


})();