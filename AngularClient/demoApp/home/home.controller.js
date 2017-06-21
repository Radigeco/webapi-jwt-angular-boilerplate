(function () {
    'use strict';

    angular.module('demoApp').controller('HomeController', HomeController);

    HomeController.$inject = ['$scope']

    function HomeController($scope) {

        $scope.home = "Home";
    }



})();