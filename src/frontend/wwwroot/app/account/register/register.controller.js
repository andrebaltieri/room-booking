(function () {
    'use strict';
    angular.module('room.booking').controller('RegisterController', RegisterCtrl);

    RegisterCtrl.$inject = ['$location'];

    function RegisterCtrl($location) {
        var register = this;
        register.title = 'Registre-se';

        activate();

        function activate() {
        }
    }
})();