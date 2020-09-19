(function (app) {
    app.controller('rootController', rootController);
    rootController.$inject = ['$state', 'authData', 'loginService', '$scope', 'authenticationService'];
    function rootController($state, authData, loginService, $scope, authenticationService) {

        $scope.isProductOpen = false;

        $scope.logOut = function () {
            loginService.logOut();
            $state.go('login');
        }
        $scope.authentication = authData.authenticationData;

        //authenticationService.validateRequest();

        $scope.toggleMenu = function (type) {
            switch (type) {
                case 'product':
                    $scope.isProductOpen = !$scope.isProductOpen;
                    break;
            }

            return false;
        }
    }
})(angular.module('onlineshop'));