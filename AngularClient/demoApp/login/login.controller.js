(function () {
    'use strict';

    angular.module('app.login')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$scope', '$state', 'AuthenticationService'];

    function LoginController($scope, $state, AuthenticationService) {

        var vm = this;
        vm.error = false;
        vm.login = function () {
            AuthenticationService.login(vm.user).then(function (response) {
                if (response === "Bad Request") {
                    vm.error = true;
                }
                else {
                    vm.error = false;
                    $state.go('home');
                }
            });
        }

    };

})();