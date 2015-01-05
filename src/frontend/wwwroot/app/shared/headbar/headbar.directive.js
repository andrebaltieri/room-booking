(function(){
    'use strict';

    angular
        .module('room.booking')
        .directive('headBar', HeadBar);

    function HeadBar() {
        var directive = {
            templateUrl: 'app/shared/headbar/headbar.html',
            restrict: 'E'
        };
        return directive;
    }
})();