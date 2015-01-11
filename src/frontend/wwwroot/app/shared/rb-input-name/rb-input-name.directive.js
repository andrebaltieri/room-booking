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
                id: "@id"
            },
            link: link,
            controller: 'InputNameController',
            controllerAs: 'vm'
        };
        return directive;

        function link(scope, el, attr, ctrl) {
            scope.form = ctrl;
            scope.modelName = attr.ngModel;
        }
    }
})();