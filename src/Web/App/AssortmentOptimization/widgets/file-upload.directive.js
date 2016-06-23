(function(){
	'use strict';

	angular
		.module('AssortmentOptimization.Widgets')
		.directive('aoFileuploadChange', fileUploadChange)
		.directive('aoFileuploadChange2', fileUploadChange2);

	function fileUploadChange(){
		var directive = {
			restrict: 'EA',
			link: function(scope, element, attrs){
				element.bind('change', function(event){
					var files = event.target.files;
					scope.$apply(function(){
						if (files.length > 0){
							scope.isFileChosen = true;
						}
						else{
							scope.isFileChosen = false;
						}
					});
				});
			},
			//initialize shared scope 
			controller: ['$scope', function($scope){
					$scope.isFileChosen = false;		
					$scope.isFileChosen2 = false;
					$scope.disableCreateSecondFile = false;
				}]
		};
		return directive;
	}

	function fileUploadChange2(){
		var directive = {
			restrict: 'EA',
			link: function(scope, element, attrs){
				element.bind('change', function(event){
					var files = event.target.files;
					scope.$apply(function(){
						if (files.length > 0){
							scope.isFileChosen2 = true;
							scope.disableCreateSecondFile = false;
						}
						else{
							scope.isFileChosen2 = false;
							scope.disableCreateSecondFile = true;
						}
					});
				});
			}
		};
		return directive;
	}

})();
