(function () {
    'use strict';
    angular.module('room.booking.directives').controller('HeadBarController', HeadBarController);

    HeadBarController.$inject = ['$location'];

    function HeadBarController($location) {
        var headbar = this;

        /* Main Variables */
        headbar.title = 'Room Booking';
        headbar.isAuthenticated = false;

        activate();

        function activate() {
        }
    }
})();