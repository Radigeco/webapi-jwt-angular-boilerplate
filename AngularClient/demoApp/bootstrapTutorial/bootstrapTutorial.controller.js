(function () {
    'use strict';

    angular.module('app.bootstrapTutorial').controller('BootstrapTutorialController', BootstrapTutorialController);

    BootstrapTutorialController.$inject = ['$scope']

    function BootstrapTutorialController($scope) {

        $scope.html = "HTML5 doctype";
        $scope.tableTitle = "Grid system";
        $scope.gridTitle="Grid classes";
    }

})();