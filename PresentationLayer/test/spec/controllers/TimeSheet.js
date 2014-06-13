'use strict';

describe('Controller: TimeSheetCtrl', function () {

  // load the controller's module
  beforeEach(module('PresentationLayerApp'));

  var TimeSheetCtrl,
    scope;

  // Initialize the controller and a mock scope
  beforeEach(inject(function ($controller, $rootScope) {
    scope = $rootScope.$new();
    TimeSheetCtrl = $controller('TimeSheetCtrl', {
      $scope: scope
    });
  }));

  it('should attach a list of awesomeThings to the scope', function () {
    expect(scope.awesomeThings.length).toBe(3);
  });
});
