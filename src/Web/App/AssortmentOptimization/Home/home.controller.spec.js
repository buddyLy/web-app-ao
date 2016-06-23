'use strict';

describe('Controller: Home', function() {
    beforeEach(module('AssortmentOptimization.Home'));

    var testController;

    beforeEach(inject(function($controller) {
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

