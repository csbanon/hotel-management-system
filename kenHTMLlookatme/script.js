// Code goes here
(function() {

    var app = angular.module('form', ['ui.bootstrap']);
  
    app.controller('FormController', ['$http', '$scope', '$window',
      function($http, $scope, $window) {
  
        $scope.master = {};


        // Datepicker
        $scope.monthOptions = [01, 02, 03, 
          04, 05, 06, 07, 
          08, 09, 10, 
          11, 12];



        $scope.yearOptions = [2020,2021,2022,2023,2024,2025,2026,2027,2028,2029,2030];

        $scope.open = function($event) {
          $event.preventDefault();
          $event.stopPropagation();
  
          $scope.opened1 = true;
          $scope.opened2 = false;
        };
  
        $scope.open2 = function($event) {
          $event.preventDefault();
          $event.stopPropagation();
  
          $scope.opened1 = false;
          $scope.opened2 = true;
        };
  
        $scope.clear = function() {
          $scope.dt = null;
          $scope.dt2 = null;
        };
  
        $scope.toggleMin = function() {
          $scope.minDate = $scope.minDate ? null : new Date();
        };
        $scope.toggleMin(); 
        $scope.dateOptions = {
          formatYear: 'yy',
          startingDay: 1
        };

        $scope.submitForm = function(isValid, user) {

          $scope.master = angular.copy(user);

            if(isValid) {
                alert("Date 1: " + $scope.user.startDate + "\nDate 2: " + $scope.user.endDate);
            }
        }
      }
      // Datepicker submission End


    ]);
  
    app.controller('PanelController', function() {
      this.tab = 1;
  
      this.selectTab = function(setTab) {
        this.tab = setTab;
        if (setTab === 2) {
          $scope.message = false;
        }
      };
  
      this.isSelected = function(checkTab) {
        return this.tab == checkTab;
  
      };
    });
  })();