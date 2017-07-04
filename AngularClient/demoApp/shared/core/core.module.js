(function () {
    'use strict';

    angular.module('app.core', [
        'app.login',
        'angular-jwt',
        'blocks.authentication',
        'blocks.router',
        'blocks.error',
        'blocks.session',
        'datatables',
        'datatables.bootstrap',
        'ui.bootstrap'
    ]);
})();