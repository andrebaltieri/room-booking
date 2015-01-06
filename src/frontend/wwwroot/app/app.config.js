(function () {
    'use strict';
    angular.module('room.booking')
        .constant("APP_SETTINGS", {
            "VERSION":"0.0.1",
            "CURR_ENV":"dev",
            "SERVICE_URL": "http://localhost:8080"
        })
        .config(function($translateProvider){
            $translateProvider.preferredLanguage('en');
        });
})();