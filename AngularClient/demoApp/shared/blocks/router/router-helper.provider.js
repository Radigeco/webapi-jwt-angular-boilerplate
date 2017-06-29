/* Help configure the state-base ui.router */
(function () {
    'use strict';

    angular
        .module('blocks.router')
        .provider('routerHelper', routerHelperProvider);

    routerHelperProvider.$inject = ['$locationProvider', '$stateProvider', '$urlRouterProvider'];
    
    function routerHelperProvider($locationProvider, $stateProvider, $urlRouterProvider) {
        
        var config = {
            docTitle: undefined,
            resolveAlways: {}
        };

        //github.com/angular-ui/ui-router/wiki/Frequently-Asked-Questions#how-to-configure-your-server-to-work-with-html5mode
        // we are not ready yet for this.
        $locationProvider.html5Mode(false);

        this.configure = function (cfg) {
            angular.extend(config, cfg);
        };

        this.$get = RouterHelper;
        RouterHelper.$inject = ['$location', '$rootScope', '$state'];
        
        function RouterHelper($location, $rootScope, $state) {
            var handlingStateChangeError = false;
            var hasOtherwise = false;
            var stateCounts = {
                errors: 0,
                changes: 0
            };

            var service = {
                configureStates: configureStates,
                getStates: getStates,
                stateCounts: stateCounts
            };

            handleRoutingErrors();
            updateDocTitle();

            return service;

            // ---------------------------------------------------------------------------------------------

            function configureStates(states, otherwisePath) {                

                states.forEach(function (state) {
                    state.config.resolve = angular.extend(state.config.resolve || {}, config.resolveAlways);
                    $stateProvider.state(state.state, state.config);
                });
                if (otherwisePath && !hasOtherwise) {
                    hasOtherwise = true;
                    $urlRouterProvider.otherwise(otherwisePath);                    
                }
            }          

            function getStates() { return $state.get(); }         

            function handleRoutingErrors() {
                // Route cancellation:
                // On routing error, go to the login.
                // Provide an exit clause if it tries to do it twice.
                $rootScope.$on('$stateChangeError',
                    function (event, toState, toParams, fromState, fromParams, error) {
                        //console.log('$stateChangeError');
                        //console.log(error);
                        if (handlingStateChangeError) {
                            return;
                        }
                        stateCounts.errors++;
                        handlingStateChangeError = true;
                        var destination = (toState &&
                            (toState.title || toState.name || toState.loadedTemplateUrl)) ||
                            'unknown target';
                        var msg = 'Error routing to ' + destination + '. ' +
                            (error.data || '') + '. <br/>' + (error.statusText || '') +
                            ': ' + (error.status || '');
                        //logger.warning(error);
                        //$location.path('/');
                        //$state.go('index');
                        
                        if (error === "AUTH_REQUIRED") {
                            $state.go('index');
                        }
                        if (error == "Error: PERMISSION_DENIED: Permission denied") {
                            alert('PERMISSION_DENIED ERROR');
                            //$state.go('index');
                        }
                    });

                $rootScope.$on('$stateNotFound',
                    function (event, unfoundState, fromState, fromParams) {
                        //console.log('$stateNotFound');
                        //console.log(unfoundState.to);
                        //console.log(unfoundState.toParams);
                        //console.log(unfoundState.options);
                    });
            }

            function updateDocTitle() {
                $rootScope.$on('$stateChangeSuccess',
                    function (event, toState, toParams, fromState, fromParams) {
                        //console.log('$stateChangeSuccess');
                        //console.log($location);
                        stateCounts.changes++;
                        
                        handlingStateChangeError = false;                        
                        var title = (toState.title || '');
                        $rootScope.docTitle = config.docTitle + title; // data bind to <title>
                    }
                );
            }
        }
    }
})();
