(function(){
    'use strict';
    angular.module('room.booking').config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                controller: 'RegisterCtrl',
                templateUrl: 'app/account/register/register.html'
            });
    });
})();