(function () {
    'use strict';
    angular.module('room.booking').controller('RegisterController', RegisterCtrl);

    RegisterCtrl.$inject = ['$location', 'APP_SETTINGS'];

    function RegisterCtrl($location, APP_SETTINGS) {
        var register = this;
        register.title = 'Registre-se ' + APP_SETTINGS.SERVICE_URL;

        activate();

        function activate() {}
    }
})();