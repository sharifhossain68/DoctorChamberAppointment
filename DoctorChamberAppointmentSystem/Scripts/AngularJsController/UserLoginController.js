
app.controller('UserLoginController', function ($scope, LoginService, $window) {
    $scope.IsLogedIn = false;
    $scope.Message = '';
    $scope.Submitted = false;
    $scope.IsFormValid = false;

    $scope.LoginData = {
        UserName: '',
        Password: ''
    };

       
    $scope.$watch('f1.$valid', function (newVal) {
        $scope.IsFormValid = newVal;
    });

    $scope.Login = function () {
        $scope.Submitted = true;
        if ($scope.IsFormValid) {
           
            LoginService.Login($scope.LoginData).then(function (d) {
                if(d.data=="Admin")
                {
                   
                    console.log(d.data)
                    $window.location.href = '/Admin/Index/' + d.data;
                }

            
            });
        }
    };

})
.factory('LoginService', function ($http) {
    var fac = {};
    fac.Login = function (d) {
        return $http({
            url:'/User/Login',
            method: 'POST',
            data: JSON.stringify(d),
            headers: { 'content-type': 'application/json' }
        });
    };
    return fac;
});  