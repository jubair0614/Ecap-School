(function (angular) {
    'use strict';

    var app = angular.module('myApp');
    app.directive('customFooter', factory);

    factory.$inject = [];
    function factory() {

        function link(scope) {
            scope.hour = 0;
            scope.minute = 0;
            scope.second = 0;
            scope.amPm = 'PM';
            populateTime();

            function populateTime() {
                var date = new Date();
                scope.second = date.getSeconds();
                scope.minute = date.getMinutes();
                scope.hour = date.getHours();
            }
        }

        return {
            scope: {
                color: '=footerColor'
            },
            template: '<div ng-style="{color: color}"></div>',
            link: link
        }
    }

})(window.angular);