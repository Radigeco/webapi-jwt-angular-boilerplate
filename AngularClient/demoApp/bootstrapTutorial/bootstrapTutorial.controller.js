(function () {
    'use strict';

    angular.module('demoApp').controller('BootstrapTutorialController', BootstrapTutorialController);

    BootstrapTutorialController.$inject = ['$scope']

    function BootstrapTutorialController($scope) {

        $scope.title = "Grid system";


    }



})();