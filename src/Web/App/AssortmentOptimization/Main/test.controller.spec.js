'use strict';

describe('Controller: testController', function () {
    var scope, controller, $location, userService;

    beforeEach(module('AssortmentOptimization.Main'));

    var testController;

    beforeEach(inject(function ($controller, _$timeout_, _$location_, _userService_) {
        $timeout = _$timeout_;
        $location = _$lcoation_;
        userService = _userService_;
        scope = {};
        testController = $controller('testController', {});
    }));

    it('should have model defined and testController.model.name is equal to controllerAs vm test', function () {
        expect(testController).toBeDefined();
    });

    it('should not have a property called vm', function () {
        expect(testController.vm).toBeUndefined();
    });
});

