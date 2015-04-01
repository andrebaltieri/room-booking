(function () {
    'use strict';

    angular
        .module('room.booking.directives')
        .directive('rbInputName', rbInputName);

    function rbInputName() {
        var directive = {
            templateUrl: 'app/shared/rb-input-name/rb-input-name.view.html',
            restrict: 'E',
            require: '^form',
            scope: {
                id: "@id",
                ngModel: "=ngModel"
            },
            link: link
        };
        return directive;

        function link(scope, el, attr, ctrl) {
            scope.form = ctrl;
        }
    }
})();