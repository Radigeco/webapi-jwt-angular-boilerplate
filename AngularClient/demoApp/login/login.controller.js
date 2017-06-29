(function () {
    'use strict';

    angular.module('app.login')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$scope', '$state', 'AccountService'];

    function LoginController($scope, $state, AccountService) {

        var vm = this;
        vm.login = function () {
            AccountService.login(vm.user).then(function (response) {
                $state.go('home');
            });
        }

    };

})();