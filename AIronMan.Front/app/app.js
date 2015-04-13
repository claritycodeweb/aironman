/**
 * IronMan Web CMS config
 * @author Rafał Pisarczyk <rafalpisarczyk@gmail.com>
 */

/**
 * Main
 */
/*
var serviceBase = 'http://localhost/AIronMan.Api/';
var app = angular.module('ironmanApp', [
  'ngRoute',
  'LocalStorageModule',
  'angular-loading-bar'
]);

app.constant('ngSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});

app.config(function ($routeProvider, $httpProvider, $locationProvider) {
    $routeProvider
    // Home
    .when("/", {
        templateUrl: "app/views/home.html",
        controller: "PageCtrl"
    })
    .when("/login", {
        controller: "loginController",
        templateUrl: "/app/views/account/login.html"
    })
    // Pages
    .when("/about", {
        templateUrl: "app/views/about.html",
        controller: "PageCtrl"
    })
    .when("/faq", {
        templateUrl: "app/views/faq.html",
        controller: "PageCtrl"
    })
    .when("/pricing", {
        templateUrl: "app/views/pricing.html",
        controller: "PageCtrl"
    })
    .when("/services", {
        templateUrl: "app/views/services.html",
        controller: "PageCtrl"
    })
    .when("/contact", {
        templateUrl: "app/views/contact.html",
        controller: "PageCtrl"
    })
    // Blog
    .when("/blog", {
        templateUrl: "app/views/blog.html",
        controller: "BlogCtrl"
    })
    .when("/blog/post", {
        templateUrl: "app/views/blog_item.html",
        controller: "BlogCtrl"
    })
    // else 404
    .otherwise("/404", {
        templateUrl: "app/views/error/404.html",
        controller: "PageCtrl"
    });
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('httpResponseInterceptorService');
});


app.controller('PageCtrl', function () {
    console.log("Page Controller reporting for duty.");


    $('.carousel').carousel({
        interval: 5000
    });


    $('.tooltip-social').tooltip({
        selector: "a[data-toggle=tooltip]"
    });
});
*/

(function () {
    'use strict';

    var app = angular.module('app', [
        // Angular modules 
        'ngAnimate',        // animations
        'ngRoute',          // routing
        'ngSanitize',       // sanitizes html bindings (ex: sidebar.js)

        'LocalStorageModule',
        'angular-loading-bar',

        // Custom modules 
        //'common',           // common functions, logger, spinner
        //'common.bootstrap', // bootstrap dialog wrapper functions

        // 3rd Party Modules
        'ui.bootstrap'      // ui-bootstrap (ex: carousel, pagination, dialog)
    ]);

    // Handle routing errors and success events
    app.run(['$route', function ($route) {
        // Include $route to kick start the router.
    }]);
})();