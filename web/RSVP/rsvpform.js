// define angular module/app
    var formApp = angular.module('formApp', []);

    // create angular controller and pass in $scope and $http
    formApp.controller("formAppController", function ($scope, $http) {       
         // create a blank object to hold our form information
        // $scope will allow this to pass between controller and view
        $scope.formData = {};
        $scope.processData={};
        
        // process the form
        $scope.processForm = function() {
            $scope.processData=$scope.formData;
            $http({
            method  : 'POST',
            url     : 'http://test.rinita-stephan.com/api/RSVP',
            data    : $scope.formData,  // pass in data as strings
            headers : { 'Content-Type': 'application/json' }  // set the headers so angular passing info as form data (not request payload)
            }).success(function(data) {
                console.log(data);
                if (data===""){
                    $scope.success =true;
                }
                else {
                    $scope.fail = true;
                }
             }); 
        };
    });
    
    
