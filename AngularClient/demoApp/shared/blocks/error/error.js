(function () {
    'use strict';

    angular
        .module('blocks.error')
        .factory('errorInterceptor', errorInterceptor);

    errorInterceptor.$inject = ['$injector'];

    function errorInterceptor($injector) {
        return {
            'response': function (response) {
                //Will only be called for HTTP up to 300
                return response;
            },
            'responseError': function (rejection) {
                //    if (rejection.statusText != 'User Friendly Exception') {
                //        return rejection;
                //    }
                

                //var errormessage = '';

                //if (rejection.data) {
                //    errormessage = rejection.data;
                //}
                //else {
                //    errormessage = rejection;
                //}
                //var messageTitle = 'Error';
                //var actionConfirmationTitle = 'Close';
                //var modalInstance = $injector.get('$uibModal').open({
                //    templateUrl: 'src/app/genericmodal/genericModal.html',
                //    controller: 'GenericModalController',
                //    resolve: {
                //        message: function () {

                //            return errormessage;
                //        },
                //        messageTitle: function () {
                //            return messageTitle;
                //        },
                //        actionConfirmationTitle: function () {
                //            return actionConfirmationTitle;
                //        },
                //        actionDismissiveTitle: function () {
                //            return '';
                //        },
                //    }
                //});
                return rejection;
            }
        };
      
    }

})();
