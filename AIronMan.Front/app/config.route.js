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
                    templateUrl: 'app/dashboard/dashboard.html',
                    title: 'dashboard',
                    settings: {
                        nav: 1,
                        content: '<i class="fa fa-dashboard"></i> Dashboard'
                    }
                }
            }, {
                url: '/sites',
                config: {
                    title: 'sites',
                    templateUrl: "app/sites/sites.html",
                    controller: "PageCtrl",
                    settings: {
                        nav: 2,
                        content: '<i class="fa fa-lock"></i> Sites'
                    }
                }
            }, {
                url: '/settings',
                config: {
                    title: 'settings',
                    templateUrl: "app/views/settings.html",
                    controller: "PageCtrl",
                    settings: {
                        nav: 3,
                        content: '<i class="fa fa-lock"></i> Settings'
                    }
                }
            }, {
                url: '/pricing',
                config: {
                    title: 'pricing',
                    templateUrl: "app/views/pricing.html",
                    controller: "PageCtrl",
                    settings: {
                        nav: 4,
                        content: '<i class="fa fa-lock"></i> Pricing'
                    }
                }
            }, {
                url: '/contact',
                config: {
                    title: 'contact',
                    templateUrl: "app/views/contact.html",
                    controller: "PageCtrl",
                    settings: {
                        nav: 5,
                        content: '<i class="fa fa-lock"></i> Contact'
                    }
                }
            }, {
                url: '/blog',
                config: {
                    title: 'blog',
                    templateUrl: "app/views/blog.html",
                    controller: "BlogCtrl",
                    settings: {
                        nav: 6,
                        content: '<i class="fa fa-lock"></i> Blog'
                    }
                }
            }, {
                url: '/blog/post',
                config: {
                    title: 'posts',
                    templateUrl: "app/views/blog_item.html",
                    controller: "BlogCtrl",
                    settings: {
                        nav: 7,
                        content: '<i class="fa fa-lock"></i> Posts'
                    }
                }
            }, {
                url: '/admin',
                config: {
                    title: 'admin',
                    templateUrl: 'app/admin/admin.html',
                    settings: {
                        nav: 8,
                        content: '<i class="fa fa-lock"></i> Admin'
                    }
                }
            }
        ];
    }
})();