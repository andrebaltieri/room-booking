(function(){
    'use strict';

    angular
        .module('room.booking')
        .directive('accountHeadBar', AccountHeadBar);

    function AccountHeadBar() {
        var directive = {
            templateUrl: 'app/shared/account-headbar/account-headbar-view.html',
            restrict: 'E'
        };
        return directive;
    }
})();