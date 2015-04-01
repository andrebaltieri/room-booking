(function(){
    'use strict';

    angular
        .module('room.booking.directives')
        .directive('rbHeadBar', RbHeadBar);

    function RbHeadBar() {
        var directive = {
            templateUrl: 'app/shared/rb-headbar/rb-headbar.view.html',
            restrict: 'E',
            link: link,
            controller: 'HeadBarController',
            controllerAs: 'vm'
        };
        return directive;

        function link(scope, el, attr, ctrl) {

        }
    }
})();