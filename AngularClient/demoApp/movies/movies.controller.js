(function () {
    'use strict';

    angular.module('demoApp').controller('MoviesController', MoviesController);

    MoviesController.$inject = ['$scope', 'DemoAppService', 'DTOptionsBuilder', 'DTColumnDefBuilder']

    function MoviesController($scope, DemoAppService, DTOptionsBuilder, DTColumnDefBuilder) {

        $scope.movies = [];

        $scope.getMovies = function () {
            DemoAppService.getMoviesData().then(function (response) {
                $scope.movies = response.data;
            });
        }

        $scope.getMovies();
    }

})();