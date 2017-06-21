(function () {
    'use strict';

    angular.module('demoApp').controller('ContactController', ContactController);

    ContactController.$inject = ['$scope']

    function ContactController($scope) {

        $scope.contact = "Contact";


    }



})();