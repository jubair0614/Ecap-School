(function (angular) {
    'use strict';

    var app = angular.module('cricApp');
    app.controller('homeController', constructor);

    constructor.$inject = [];

    function constructor() {
        this.message = 'Hello Home!!!';
        this.teams = ['Bangladesh', 'India', 'Sri lanka', 'Pakistan', 'New Zealand'];

    }

})(window.angular);