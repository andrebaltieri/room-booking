(function () {
    'use strict';

    angular
        .module('room.booking.directives')
        .directive('rbInputEmail', rbInputEmail);

    function rbInputEmail() {
        var directive = {
            templateUrl: 'app/shared/rb-input-email/rb-input-email.view.html',
            restrict: 'E',
            require: '^form',
            scope: {
                id: "@id",
                ngModel: "=ngModel"
            },
            link: link,
            controller: 'InputEmailController',
            controllerAs: 'inputemail'
        };
        return directive;

        function link(scope, el, attr, ctrl) {
            scope.form = ctrl;
        }
    }
})();