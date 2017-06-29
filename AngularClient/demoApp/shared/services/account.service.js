(function () {
    'use strict';

    angular.module("app.login").factory("AccountService", AccountService);


    AccountService.$inject = ['$http'];

    function AccountService($http) {
        var serviceBase = "http://localhost:60472/";
        var AccountServiceFactory = {};

        var registerUser = function (userModel) {
            return $http.post(serviceBase + 'api/account/create', {
                "email": userModel.email,
                "firstName": userModel.firstName,
                "lastName": userModel.lastName,
                "roleName": userModel.roleName,
                "password": userModel.password,
                "confirmPassword": userModel.confirmPassword
            }).then(function (response) {
                return response;
            })
        }

        var login = function (userModel) {
            return $http.post(serviceBase + 'api/account/login', {
                "username": userModel.username,
                "password": userModel.password
            }).then(function (response) {
                return response;
            });
        }


        AccountServiceFactory.registerUser = registerUser;
        AccountServiceFactory.login = login;

        return AccountServiceFactory;

    }
})();