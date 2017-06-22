(function () {
    'use strict';

    angular.module("demoApp").factory("DemoAppService", DemoService);


    DemoService.$inject = ['$http'];

    function DemoService($http) {


        var serviceBase = "http://localhost:60472/";
        var DemoServiceFactory = {};

        var getMoviesData = function () {
            return $http.get(serviceBase + 'api/movie/get').then(function (movies) {
                return movies;
            });
        }

        var addNewMovie = function (movieModel) {
            return $http.post(serviceBase + 'api/movie/create', movieModel).then(function (newMovie) {
                return newMovie;
            })
        }

        var updateMovie = function (movieModel) {
            return $http.put(serviceBase + 'api/movie/update', movieModel).then(function (updatedMovie) {
                return updatedMovie;
            })
        }

        var deleteMovie = function (id) {
            return $http.delete(serviceBase + 'api/movie/delete?id=' + id).then(function (deletedMovie) {
                return deletedMovie;
            });
        }

        DemoServiceFactory.getMoviesData = getMoviesData;
        DemoServiceFactory.addNewMovie = addNewMovie;
        DemoServiceFactory.updateMovie = updateMovie;
        DemoServiceFactory.deleteMovie = deleteMovie;

        return DemoServiceFactory;
    }

})()