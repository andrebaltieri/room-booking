(function () {
    'use strict';
    angular.module('room.booking.directives').controller('InputEmailController', InputEmailController);

    InputEmailController.$inject = ['$location'];

    function InputEmailController($location) {
        var inputemail = this;

        activate();

        function activate() {
        }

        inputemail.blur = function(){
            console.log('Blurring');
        }
    }
})();