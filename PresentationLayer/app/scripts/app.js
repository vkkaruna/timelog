'use strict';

angular.module('PresentationLayerApp', ['ngRoute', 'ui.bootstrap', 'ngGrid', 'angular-growl'])
    .config(['$routeProvider', 'growlProvider', '$httpProvider', function ($routeProvider, growlProvider, $httpProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'views/main.html',
                controller: 'MainCtrl'
            })
            .when('/logtime', {
                templateUrl: 'views/logtime.html',
                controller: 'LogTimeCtrl'
            })
            .when('/timesheet', {
                templateUrl: 'views/timesheet.html',
                controller: 'TimeSheetCtrl'
            })
            .otherwise({
                redirectTo: '/'
            });
        growlProvider.globalTimeToLive(4000);
        delete $httpProvider.defaults.headers.common['X-Requested-With'];
    }])
    .value('System', {
        apiUrl: 'http://localhost:60251/'
    })
    .run(['$rootScope', '$location', 'CommonService',
        function ($rootScope, $location, CommonService) {
            // register listener to watch route changes
            $rootScope.$on('$routeChangeStart', function (event, next, current) {
                if (!CommonService.getValue('token')) {
                    // not going to #login, we should redirect now
                    $location.url("/");
                    $rootScope.showLogout = false;
                }
                else {
                    $rootScope.showLogout = true;
                }
            });
        }
    ]);
