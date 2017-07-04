(function () {
    'use strict';

    angular
        .module('blocks.error')
        .service('errorService', errorService);
    errorService.$inject = ['errorInterceptor'];

    function errorService(errorInterceptor) {

    }
})();