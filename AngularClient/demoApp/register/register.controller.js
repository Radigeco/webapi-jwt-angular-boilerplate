(function () {
    'use strict';

    angular.module('app.register')
        .controller('RegisterController', RegisterController);

    RegisterController.$inject = ['$scope', '$state', 'AccountService'];

    function RegisterController($scope, $state, AccountService) {

        var vm = this;

        vm.user = [];

        vm.register = function () {
            AccountService.registerUser(vm.user).then(function (response) {
                $state.go('login');

            });
        }

    }

})();