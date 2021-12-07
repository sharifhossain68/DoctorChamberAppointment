

app.controller('RegistrationController', function ($scope, $http) {


                      $scope.isFormValid = false;
                      $scope.message = null;
                      $scope.register = null;
                      $scope.submitted = false;


                      // object

                      $scope.register = {
                          UserName: '',
                          Email: '',
                          Password: '',
                          ConfirmPassword: '',
                          CountryId: '',

                          RoleId: ''

                      }

                      //validation

                      $scope.$watch('f2.$valid', function (newVal) {
                          $scope.isFormValid = newVal;
                      });


                      $scope.GetCountries = function () {

                          $http.get('/User/GetCountries')
                              .then(function (d) {
                                  $scope.Countries = {};
                                  $scope.Countries = d.data;
                                  for (var i in $scope.Countries) {
                                      console.log(typeof ($scope.Countries[i].CountryId));
                                  }
                              })

                      }

                      $scope.GetRoles = function () {

                          $http.get('/User/GetRoles')
                              .then(function (d) {
                                  $scope.Roles = {};
                                  $scope.Roles = d.data;
                              })

                      }

                      //Save Data

                      $scope.RegistrationDataInsert = function (data) {

                          $scope.message = '';
                          $scope.register = data;
                          console.log($scope.register);
                          $scope.submitted = true;

                          $http.post('/User/Registration', $scope.register)
                                .then(function (success) {
                                    alert("Successfully Resgistration");
                                }).error(function (e) {
                                    alert(e.message);
                                });
                      };






    })