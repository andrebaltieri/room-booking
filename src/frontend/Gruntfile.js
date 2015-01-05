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
                        'bower_components/font-awesome/font-awesome.css',
                        'bower_components/bootswatch/paper/bootstrap.css'
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
                    'bower_components/angular-route/angular-route.js',
                    'bower_components/angular-cookie/angular-cookie.js',
                    'bower_components/angular-animate/angular-animate.js',
                    'bower_components/angular-bootstrap/ui-bootstrap-tpls.js'
                ],
                dest: 'wwwroot/assets/libs/scripts-bundle.min.js'
            }
        },
        copy: {
            main: {
                files: [
                    {
                        expand: true,
                        src: ['bower_components/font-awesome/fonts/*'],
                        dest: 'wwwroot/assets/fonts',
                        filter: 'isFile'
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