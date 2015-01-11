(function(){
    'use strict';

    angular
        .module('room.booking.directives')
        .directive('rbAccountHeadBar', RbAccountHeadBar);

    function RbAccountHeadBar() {
        var directive = {
            templateUrl: 'app/shared/rb-account-headbar/rb-account-headbar.view.html',
            restrict: 'E',
            link: link,
            controller: 'AccountHeadBarController',
            controllerAs: 'vm'
        };
        return directive;

        function link(scope, el, attr, ctrl) {

        }
    }
})();