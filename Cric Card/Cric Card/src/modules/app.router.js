(function (angular) {
    'use strict';

    var app = angular.module('cricApp');

    app.config(addRoutes);

    addRoutes.$inject = ['$stateProvider', '$locationProvider', '$urlRouterProvider'];
    function addRoutes($stateProvider, $locationProvider, $urlRouterProvider) {
        $stateProvider
            .state('home', {
                url: '/home',
                templateUrl: 'views/home.view.html',
                controller: 'homeController',
                controllerAs: 'vm'
            })
            .state('play', {
                url: '/play',
                templateUrl: 'views/play.view.html',
                controller: 'playController',
                controllerAs: 'vm'
            })
            .state('match', {
                url: '/match/:matchid/:over/:run',
                templateUrl: 'views/match.view.html',
                controller: 'matchController',
                controllerAs: 'vm'
            })
            .state('404', {
                url: '/404',
                templateUrl: 'views/notFound.view.html'
            });

        $urlRouterProvider.otherwise('/404');
        $locationProvider.hashPrefix('');
        
    }
})(window.angular);