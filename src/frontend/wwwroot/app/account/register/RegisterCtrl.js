(function () {
    'use strict';
    angular.module('room.booking').controller('RegisterCtrl', RegisterCtrl);
    RegisterCtrl.$inject = ['$location'];

    function RegisterCtrl($location) {
        var vm = this;
        vm.title = 'HomeCtrl';

        activate();

        function activate() {
        }
    }
})();