'use strict';

angular.module('PresentationLayerApp')
    .service('TimeSheetService', ['CommonService', function TimeSheetService(CommonService) {
        this.GetTimeSheets = function (projectID) {
            return CommonService.Get('api/TimeSheet/Project?projectID=' + projectID)
        }
    }]);
