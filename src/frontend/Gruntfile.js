module.exports = function (grunt) {
    grunt.initConfig({
        bower: {
            install: {
                options: {
                    targetDir: "bower_components",
                    layout: "byComponent",
                    cleanTargetDir: false
                }
            }
        },
        cssmin: {
            sitecss: {
                files: {
                    'wwwroot/assets/css/styles-bundle.min.css': [
                        'custom_components/css/styles.css',
                        'bower_components/bootswatch/paper/bootstrap.css'
                    ],
                    'wwwroot/assets/fonts/font-awesome/css/font-awesome.min.css': [
                        'bower_components/font-awesome/css/font-awesome.css'
                    ],
                    'wwwroot/assets/css/account.min.css': [
                        'custom_components/css/account.css'
                    ]
                }
            }
        },
        uglify: {
            options: {
                compress: true
            },
            applib: {
                src: [
                    'bower_components/angular/angular.js',
                    'bower_components/angular-translate/angular-translate.js',
                    'bower_components/angular-route/angular-route.js',
                    'bower_components/angular-cookie/angular-cookie.js',
                    'bower_components/angular-animate/angular-animate.js',
                    'bower_components/angular-bootstrap/ui-bootstrap-tpls.js',
                ],
                dest: 'wwwroot/assets/libs/scripts-bundle.min.js'
            }
        },
        copy: {
            main: {
                files: [
                    {
                        expand: true,
                        cwd: 'bower_components/font-awesome/fonts/',
                        src: '**',
                        dest: 'wwwroot/assets/fonts/font-awesome/fonts',
                        flatten: true,
                        filter: 'isFile',
                    }
                ]
            }
        }
    });

    grunt.registerTask("default", ["bower:install"]);
    grunt.loadNpmTasks("grunt-bower-task");
    grunt.loadNpmTasks("grunt-contrib-cssmin");
    grunt.loadNpmTasks("grunt-contrib-uglify");
    grunt.loadNpmTasks("grunt-contrib-copy");
};