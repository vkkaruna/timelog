'use strict';

angular.module('PresentationLayerApp')
    .service('CommonService', ['$http', 'System', '$window', '$location', function CommonService($http, System, $window, $location) {

        this.GetProjects = function () {

            return $http({
                method: 'GET',
                url: System.apiUrl + 'api/Project',
                params: '',
                headers: {'Authorization': 'Bearer ' + this.getValue('token')}
            });
        };

        this.Get = function (restPath) {

            return $http({
                method: 'GET',
                url: System.apiUrl + restPath,
                params: '',
                headers: {'Authorization': 'Bearer ' + this.getValue('token')}
            });
        };

        this.AuthenticateUser = function (userName, password) {

            return $http({
                method: 'POST',
                url: System.apiUrl + 'Token',
                data: 'grant_type=password&username=' + encodeURIComponent(userName) + '&password=' + encodeURIComponent(password),
                headers: {'Content-Type': 'application/x-www-form-urlencoded'}
            });
        };

        this.Logout = function (token) {
            return $http({
                method: 'POST',
                url: System.apiUrl + 'api/Account/Logout',
                headers: {'Authorization': 'Bearer ' + this.getValue('token')}
            });
        };

        this.GetUserInfo = function (token) {
            return $http({
                method: 'GET',
                url: System.apiUrl + 'api/Account/UserInfo',
                headers: {'Authorization': 'Bearer ' + this.getValue('token')}
            });
        };

        this.navigateTo = function (path) {
            $location.url(path);
        };
        this.getValue = function (key) {
            return $window.sessionStorage.getItem(key);
        };

        this.storeValue = function (key, value) {
            $window.sessionStorage.setItem(key, value);
        };

        this.removeValue = function (key) {
            $window.sessionStorage.removeItem(key);
        };
    }]);
