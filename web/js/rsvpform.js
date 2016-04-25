/* global angular */
// define angular module/app
    var formApp = angular.module('formApp', ['sticky']);

    // create angular controller and pass in $scope and $http
    formApp.controller("formAppController", function ($scope, $http) {       
         // create a blank object to hold our form information
        // $scope will allow this to pass between controller and view
        $scope.formData = {};
        $scope.processData={};
		
		// define submit button disabled variable to prevent spam clicks on form submission
		$scope.buttonDisabled = false;
        
        // process the form
        $scope.processForm = function() {
			$scope.buttonDisabled = true;
            $scope.processData=$scope.formData;
            $http({
            method  : 'POST',
            url     : 'http://api.rinita-stephan.com/api/RSVP',
            data    : $scope.formData,  // pass in data as strings
            headers : { 'Content-Type': 'application/json' }  // set the headers so angular passing info as form data (not request payload)
            }).then(function successCallback(response) {
                    console.log(response);
                    $scope.success = true;
					$scope.buttonDisabled = false;
                }, function errorCallback(response) {
                    console.log(response);
                    $scope.fail = true;
					$scope.buttonDisabled = false;
            });
        };
    });
    
    
