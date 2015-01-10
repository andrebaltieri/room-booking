(function(){
    'use strict';

    angular
        .module('room.booking')
        .directive('inputName', inputName);

    function inputName() {
        var directive = {
            templateUrl: 'app/shared/input-name/input-name.view.html',
            restrict: 'E',
            scope: {
                model: '@model',
                id: "@id",
                form: "@form"
            }
        };
        return directive;
    }
})();