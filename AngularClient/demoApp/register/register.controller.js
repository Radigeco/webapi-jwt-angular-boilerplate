(function () {
    'use strict';

    angular.module('app.register')
        .controller('RegisterController', RegisterController);

    RegisterController.$inject = ['$scope', '$state', 'AuthenticationService'];

    function RegisterController($scope, $state, AuthenticationService) {

        var vm = this;

        vm.user = [];

        vm.register = function () {
            AuthenticationService.registerUser(vm.user).then(function (response) {
                $state.go('login');

            });
        }

    }

})();