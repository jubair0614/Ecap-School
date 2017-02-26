(function (angular) {
    'use strict';

    function initApp() {
        angular.bootstrap(document, ['cricApp']);
    }

    document.addEventListener('DOMContentLoaded', initApp, false);

})(window.angular);