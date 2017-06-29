(function ready() {
    'use strict';


    angular.module('demoApp', [
        'app.core',
        'app.landing',
        'app.register',
        'app.login',
        'app.home',
        'app.movies',
        'app.contact',
        'app.directives'
    ]);


    angular.bootstrap(document, ['demoApp']);


})();