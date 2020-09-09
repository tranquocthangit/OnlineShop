(function (app) {
    app.controller('productEditController', productEditController);

    productEditController.$inject = ['$scope', 'apiService', 'notificationService', '$state', '$stateParams', 'commonService'];

    function productEditController($scope, apiService, notificationService, $state, $stateParams, commonService) {
        $scope.product = {
            CreatedDate: new Date(),
            Status: true
        }

        $scope.UpdateProduct = UpdateProduct;
        $scope.GetSeoTitle = GetSeoTitle;
        $scope.moreImages = [];
        $scope.ChooseImage = ChooseImage;
        $scope.chooseMoreImages = chooseMoreImages;
        $scope.ckeditorOptions = {
            language: 'vi',
            height: '200px'
        }

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function loadProductDetail() {
            apiService.get('api/product/getbyid/' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
                $scope.moreImages = JSON.parse($scope.product.MoreImages); 
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function UpdateProduct() {
            $scope.product.MoreImages = JSON.stringify($scope.moreImages) 
            apiService.put('api/product/update', $scope.product, function (result) {
                notificationService.displaySuccess(result.data.Name + ' đã được cập nhật thành công.');
                $state.go('products');
            }, function () {
                notificationService.displayError('cập nhật không thành công.');
            });
        }

        function loadProductCategory() {
            apiService.get('api/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log('cannot get list parent');
            });
        }

        function ChooseImage() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                //load nhanh trong angularjs dùng $apply
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                });
            }
            finder.popup();
        }

        function chooseMoreImages() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                if ($scope.moreImages.indexOf(fileUrl) < 0) {
                    $scope.$apply(function () {
                        $scope.moreImages.push(fileUrl);
                    });
                }
            }
            finder.popup();
        }

        loadProductCategory();
        loadProductDetail();
    }
})(angular.module('onlineshop.products'))