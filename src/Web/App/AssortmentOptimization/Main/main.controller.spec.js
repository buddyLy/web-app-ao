'use strict';

describe('Controller: Main', function () {
    var scope;
    
    beforeEach(module('AssortmentOptimization.Main'));

    var Main;

    beforeEach(inject(function ($controller) {
        scope = {};
        Main = $controller('Main', {});
    }));

    it('should have model defined and testController.model.name is equal to controllerAs vm test', function () {
        expect(Main).toBeDefined();
    });

    it('should not have a property called vm', function () {
        expect(Main.vm).toBeUndefined();
    });
});

