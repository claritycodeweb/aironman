/**
 * IronMan Web CMS config
 * @author Rafał Pisarczyk <rafalpisarczyk@gmail.com>
 */

/**
 * Main
 */
var serviceBase = 'http://localhost/AIronMan.Api/';
var app = angular.module('ironmanApp', [
  'ngRoute',
  'LocalStorageModule',
  'angular-loading-bar'
]);

app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});

var routeConfig = function ($routeProvider, $httpProvider, $locationProvider) {

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

    //$locationProvider.baseHref = "/AIronMan.Web/";
    //use the HTML5 History API
    //$locationProvider.html5Mode(true);
    //$locationProvider.hashPrefix('!');

}

routeConfig.$inject = ['$routeProvider', '$httpProvider', '$locationProvider'];
app.config(routeConfig);

/**
 * Controls all other Pages
 */
app.controller('PageCtrl', function (/* $scope, $location, $http */) {
    console.log("Page Controller reporting for duty.");

    // Activates the Carousel
    $('.carousel').carousel({
        interval: 5000
    });

    // Activates Tooltips for Social Links
    $('.tooltip-social').tooltip({
        selector: "a[data-toggle=tooltip]"
    });
});
