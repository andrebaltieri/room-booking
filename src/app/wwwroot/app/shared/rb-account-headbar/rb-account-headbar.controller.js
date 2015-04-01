(function () {
    'use strict';
    angular.module('room.booking.directives')
        .controller('AccountHeadBarController', AccountHeadBarController);

    AccountHeadBarController.$inject = ['$location', '$translate'];

    function AccountHeadBarController($location, $translate) {
        var accountHeadbar = this;

        /* Main Variables */
        accountHeadbar.title = 'Room Booking';

        activate();

        function activate() {
        }

        accountHeadbar.changeLanguage = function (key) {
            $translate.use(key);
        };
    }
})();