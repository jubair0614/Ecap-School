(function (angular) {
    'use strict';

    var app = angular.module('cricApp');
    app.controller('playController', constructor);

    constructor.$inject = [];

    function constructor() {
        this.message = 'Hello play!!!';
    }

})(window.angular);