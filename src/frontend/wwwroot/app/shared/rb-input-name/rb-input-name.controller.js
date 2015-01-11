(function () {
    'use strict';
    angular.module('room.booking.directives').controller('InputNameController', InputNameController);

    InputNameController.$inject = ['$translate'];

    function InputNameController($translate) {
        var inputname = this;

        activate();

        function activate() {
        }
    }
})();