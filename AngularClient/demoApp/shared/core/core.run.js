(function () {
    'use strict';

    var core = angular.module('app.core');

    core.run(runCore);

    runCore.$inject = ['$rootScope', '$state'];

    function runCore($rootScope, $state) {
        // some spinner
        //$rootScope.spinner = { active: true };
        //editableOptions.theme = 'bs3';

        // use state change because we use ui.router
        $rootScope.$on('$stateChangeStart', function (event, next, current) {
            console.log('stateChangeStart->next:' + next.name);

            //// when user logged in, no need to access login page
            //if (next.name == 'login.index' && authentication.isLoggedIn()) {
            //    event.preventDefault();
            //    $state.go('index');
            //}
            //// when user not logged in, always force login
            //if (next.name != 'login.index' && authentication.isLoggedIn() === false) {
            //    event.preventDefault();
            //    // try to auto login with refresh token
            //    authentication.autoLogin().then(function () {
            //        $state.go('login.index');
            //    }, function () {
            //        $state.go('login.index');
            //    });
            //}

        });
    };

})();