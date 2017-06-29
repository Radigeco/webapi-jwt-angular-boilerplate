(function () {
    'use strict';

    angular.module('app.contact').controller('ContactController', ContactController);

    ContactController.$inject = ['$scope']

    function ContactController($scope) {

        $scope.contact = "Contact";


    }



})();