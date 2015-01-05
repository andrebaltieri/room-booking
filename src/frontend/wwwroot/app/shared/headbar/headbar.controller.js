(function () {
    'use strict';
    angular.module('room.booking').controller('HeadBarController', HeadBarController);

    HeadBarController.$inject = ['$location'];

    function HeadBarController($location) {
        var headbar = this;
        headbar.title = 'Room Booking';

        activate();

        function activate() {
        }
    }
})();