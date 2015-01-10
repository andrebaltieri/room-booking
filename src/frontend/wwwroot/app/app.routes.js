(function(){
    'use strict';
    angular.module('room.booking').config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                controller: 'RegisterController',
                controllerAs: 'register',
                templateUrl: 'app/components/account/register/register.html'
            });
    });
})();