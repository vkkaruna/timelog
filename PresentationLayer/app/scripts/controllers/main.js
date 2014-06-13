'use strict';

angular.module('PresentationLayerApp')
    .controller('MainCtrl', ['$rootScope', '$scope', 'CommonService', 'growl',
        function ($rootScope, $scope, CommonService, growl) {
            $scope.awesomeThings = [
                'HTML5 Boilerplate',
                'AngularJS',
                'Karma'
            ];

            $scope.AuthenticateUser = function () {
                CommonService.AuthenticateUser($scope.userName, $scope.password)
                    .success(function (result) {
                        CommonService.storeValue('token', result.access_token);
                        CommonService.storeValue('userName', result.userName);
                        growl.addSuccessMessage('Login successful!')

                        CommonService.GetUserInfo(result.access_token)
                            .success(function (result) {
                                if (result.IsClient) {
                                    CommonService.navigateTo('timesheet');
                                }
                                else {
                                    CommonService.navigateTo('logtime')
                                }
                            })
                            .error(function (err) {
                                console.error(err);
                                growl.addErrorMessage('Unable to retrieve user information.')
                            })
                    })
                    .error(function (err) {
                        console.error(err);
                        growl.addErrorMessage('Invalid username or password.')
                    })
            };

            $scope.Logout = function () {
                CommonService.Logout(CommonService.getValue('token'))
                    .success(function (result) {
                        CommonService.removeValue('token');
                        CommonService.removeValue('userName');
                        growl.addWarnMessage('Logout successful! Please close this window.')
                        CommonService.navigateTo('/');
                    })
                    .error(function (err) {
                        console.error(err);
                        growl.addErrorMessage('Unable to logout.')
                    })
            }

        }]);
