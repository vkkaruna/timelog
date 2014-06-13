'use strict';

describe('Controller: LogTimeCtrl', function () {

  // load the controller's module
  beforeEach(module('PresentationLayerApp'));

  var LogTimeCtrl,
    scope;

  // Initialize the controller and a mock scope
  beforeEach(inject(function ($controller, $rootScope) {
    scope = $rootScope.$new();
    LogTimeCtrl = $controller('LogTimeCtrl', {
      $scope: scope
    });
  }));

  it('should attach a list of awesomeThings to the scope', function () {
    expect(scope.awesomeThings.length).toBe(3);
  });
});
