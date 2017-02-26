(function (angular) {
    'use strict';

    var app = angular.module('cricApp');
    app.controller('matchController', constructor);

    constructor.$inject = ['$scope', '$routeParams'];

    function constructor($scope, $routeParams) {
        this.message = 'Hello match!!!';

        this.innigsResult = innigsResult;
        this.randomRanGenerator = randomRanGenerator;
        this.ballWiseShow = ballWiseShow;

        function innigsResult() {
            var allData = [
                { 'over': 0.1, 'run': 3 },
                { 'over': 0.2, 'run': 4 },
                { 'over': 0.2, 'run': 6 }
            ];
            return allData;
        }

        function randomRanGenerator() {
            return Math.floor(Math.random() * (6 - 0 + 1)) + 0;
        }

        function ballWiseShow() {
            $scope.over = $routeParams.over;
            $scope.run = $routeParams.run;

            var allData = innigsResult();
            allData.forEach(function(item) {
                if ((item.over === $scope.over) && (item.run === $scope.run)) {
                    return item;
                }
            });
          
        }
    }

})(window.angular);