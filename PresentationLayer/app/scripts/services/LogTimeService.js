'use strict';

angular.module('PresentationLayerApp')
    .service('LogTimeService', ['$http', 'System', 'CommonService', function LogTime($http, System, CommonService) {
        this.LogTime = function (projectID, taskID, dtActualStart, dtActualEnd, actualEffort) {
            var postData = {
                "ProjectID": projectID,
                "TaskID": taskID,
                "ActualStartDate": dtActualStart,
                "ActualEndDate": dtActualEnd,
                "ActualEffort": actualEffort
            }
            return $http({
                method: 'POST',
                url: System.apiUrl + 'api/TimeSheet',
                data: postData,
                headers: {'Authorization': 'Bearer ' + CommonService.getValue('token')}
            });
        }
    }]);
