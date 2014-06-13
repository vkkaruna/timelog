'use strict';

describe('Service: LogTime', function () {

  // load the service's module
  beforeEach(module('PresentationLayerApp'));

  // instantiate service
  var LogTime;
  beforeEach(inject(function (_LogTime_) {
    LogTime = _LogTime_;
  }));

  it('should do something', function () {
    expect(!!LogTime).toBe(true);
  });

});
