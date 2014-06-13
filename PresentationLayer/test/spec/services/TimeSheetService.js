'use strict';

describe('Service: TimeSheetService', function () {

  // load the service's module
  beforeEach(module('PresentationLayerApp'));

  // instantiate service
  var TimeSheetService;
  beforeEach(inject(function (_TimeSheetService_) {
    TimeSheetService = _TimeSheetService_;
  }));

  it('should do something', function () {
    expect(!!TimeSheetService).toBe(true);
  });

});
