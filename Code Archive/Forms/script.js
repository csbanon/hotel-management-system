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

        $scope.formats = ['dd-MMMM-yyyy', 'dd/MM/yyyy', 'dd.MM.yyyy', 'shortDate'];
        $scope.format = $scope.formats[0];

        $scope.dateCheck = function(date) 
        {
          revisedDate = new Date(date);
          return revisedDate.toDateString();
        }

        $scope.subTotalCalc = function(date1, date2) {
          var startDate1 = new Date(date1);
          var endDate1 = new Date(date2);
          var timeEst = endDate1.getTime() - startDate1.getTime();
          var daysEst = timeEst/(1000*3600*24);
          var subtotal = daysEst * 50.00;
          return subtotal.toFixed(2);
        }

        $scope.taxCalc = function(date1, date2) {
          var startDate1 = new Date(date1);
          var endDate1 = new Date(date2);
          var timeEst = endDate1.getTime() - startDate1.getTime();
          var daysEst = timeEst/(1000*3600*24);
          var subtotal = daysEst * 50.00;
          var tax = subtotal * 0.07;
          return tax.toFixed(2);
        }

        $scope.finCalc = function(date1, date2) {
          var startDate1 = new Date(date1);
          var endDate1 = new Date(date2);
          var timeEst = endDate1.getTime() - startDate1.getTime();
          var daysEst = timeEst/(1000*3600*24);
          var subtotal = daysEst * 50.00;
          var tax = subtotal * 0.07;
          var finTot = subtotal + tax;
          return finTot.toFixed(2);
        }





        $scope.submitForm = function(isValid) {
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
