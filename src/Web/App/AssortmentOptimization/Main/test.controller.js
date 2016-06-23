(function () {
    'use strict';

    angular
        .module('AssortmentOptimization.Main')
        .controller('testController', testController);

    testController.$inject = ['$timeout', '$location', 'userService'];

    function testController($timeout, $location, userService) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'Test';

        activate();

        function activate() {
            //logger.success(config.appTitle + ' loaded!', null);
        }
    }
})();