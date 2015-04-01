(function () {
    'use strict';
    angular.module('room.booking').controller('RegisterController', RegisterCtrl);

    RegisterCtrl.$inject = ['$location', '$translate'];

    function RegisterCtrl($location, $translate) {
        var register = this;

        register.user = {
            name: "",
            email: "",
            password: "",
            confirmPassword: ""
        };

        activate();

        function activate() {
        }

        register.submit = function () {
            console.log(register.user);
        }
    }
})();