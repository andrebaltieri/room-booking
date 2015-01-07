(function () {
    'use strict';
    angular.module('room.booking').controller('RegisterController', RegisterCtrl);

    RegisterCtrl.$inject = ['$location', '$translate', 'APP_SETTINGS'];

    function RegisterCtrl($location, $translate, APP_SETTINGS) {
        var register = this;
        register.info = 'Serviço rodando em ' + APP_SETTINGS.SERVICE_URL;

        activate();

        function activate() {}
    }
})();