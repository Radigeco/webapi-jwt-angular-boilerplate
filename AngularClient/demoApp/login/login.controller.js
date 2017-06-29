(function () {
    'use strict';

    angular.module('app.login')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$scope', '$state', 'AuthenticationService'];

    function LoginController($scope, $state, AuthenticationService) {

        var vm = this;
        vm.login = function () {
            AuthenticationService.login(vm.user).then(function (response) {
                $state.go('home');
            });
        }

    };

})();