(function (angular) {
    'use strict';

    var app = angular.module('cricApp');
    app.service('homeService', constructor);

    constructor.$inject = [];

    function constructor() {
        this.teams = ['Bangladesh', 'India', 'Sri lanka', 'Pakistan', 'New Zealand'];

        this.getTeams = function() {
            return this.teams;
        }
    }

})(window.angular);