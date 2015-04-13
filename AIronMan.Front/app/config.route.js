(function () {
    'use strict';

    var app = angular.module('app');

    // Collect the routes
    app.constant('routes', getRoutes());

    // Configure the routes and route resolvers
    app.config(['$routeProvider', 'routes', routeConfigurator]);
    function routeConfigurator($routeProvider, routes) {

        routes.forEach(function (r) {
            $routeProvider.when(r.url, r.config);
        });
        $routeProvider.otherwise({
            redirectTo: '/404',
            templateUrl: "app/views/error/404.html",
            controller: "PageCtrl"
        });
    }

    // Define the routes 
    function getRoutes() {
        return [
            {
                url: '/',
                config: {
                    templateUrl: "app/views/home.html",
                    controller: "PageCtrl",
                    title: 'dashboard',
                    settings: {
                        nav: 1,
                        content: '<i class="fa fa-dashboard"></i> Dashboard'
                    }
                }
            }, {
                url: '/login',
                config: {
                    title: 'admin',
                    controller: "loginController",
                    templateUrl: "/app/views/account/login.html",
                    settings: {
                        nav: 2,
                        content: '<i class="fa fa-lock"></i> Admin'
                    }
                }
            }, {
                url: '/about',
                config: {
                    title: 'about',
                    templateUrl: "app/views/about.html",
                    controller: "PageCtrl",
                    settings: {
                        nav: 3,
                        content: '<i class="fa fa-lock"></i> Admin'
                    }
                }
            }, {
                url: '/faq',
                config: {
                    title: 'faq',
                    templateUrl: "app/views/faq.html",
                    controller: "PageCtrl",
                    settings: {
                        nav: 4,
                        content: '<i class="fa fa-lock"></i> Admin'
                    }
                }
            }, {
                url: '/pricing',
                config: {
                    title: 'pricing',
                    templateUrl: "app/views/pricing.html",
                    controller: "PageCtrl",
                    settings: {
                        nav: 5,
                        content: '<i class="fa fa-lock"></i> Admin'
                    }
                }
            }, {
                url: '/admin',
                config: {
                    title: 'admin',
                    templateUrl: "app/admin/views/index.html",
                    controller: "PageCtrl",
                    settings: {
                        nav: 6,
                        content: '<i class="fa fa-lock"></i> Admin'
                    }
                }
            }, {
                url: '/contact',
                config: {
                    title: 'contact',
                    templateUrl: "app/views/contact.html",
                    controller: "PageCtrl",
                    settings: {
                        nav: 7,
                        content: '<i class="fa fa-lock"></i> Admin'
                    }
                }
            }, {
                url: '/blog',
                config: {
                    title: 'blog',
                    templateUrl: "app/views/blog.html",
                    controller: "BlogCtrl",
                    settings: {
                        nav: 8,
                        content: '<i class="fa fa-lock"></i> Admin'
                    }
                }
            }, {
                url: '/blog/post',
                config: {
                    title: 'posts',
                    templateUrl: "app/views/blog_item.html",
                    controller: "BlogCtrl",
                    settings: {
                        nav: 9,
                        content: '<i class="fa fa-lock"></i> Admin'
                    }
                }
            }
        ];
    }
})();