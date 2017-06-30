(function () {
    'use strict';

    angular.module('app.login')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$scope', '$state', 'AuthenticationService'];

    function LoginController($scope, $state, AuthenticationService) {

        var vm = this;
        vm.error = false;
        vm.errorMessage = "";

        vm.login = function () {
            AuthenticationService.login(vm.user).then(function (response) {
                if (response.data.success === false) {
                    vm.error = true;
                    vm.errorMessage = response.data.reason;
                }
                else {
                    vm.error = false;
                    vm.errorMessage = "";
                    $state.go('home');
                }
            });
        }

    };

})();