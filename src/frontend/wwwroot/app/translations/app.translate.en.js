(function () {
    'use strict';
    angular.module('room.booking')
        .config(function ($translateProvider) {
            $translateProvider.translations('en', {
                APP_SLOGAN: 'smart room scheduler',
                REGISTER: 'register',
                NAME: 'Name',
                EMAIL: 'E-mail',
                PASSWORD: 'Password',
                CONFIRM_PASSWORD: 'Confirm Password',
                INPUT_YOUR_NAME: 'Input your Name',
                INPUT_YOUR_EMAIL: 'Input your E-mail',
                INPUT_YOUR_PASSWORD: 'Input your Password',
                INPUT_YOUR_CONFIRM_PASSWORD: 'Confirm your Password',
                CONTINUE: 'Continue',
                LANGUAGE: 'Language',
                PORTUGUESE: 'Portuguese',
                ENGLISH: 'English',
                USER_INVALID_NAME: 'Name is invalid.'
            });
        });
})();