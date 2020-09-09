(function (app) {
    app.controller('productAddController', productAddController);

    productAddController.$inject = ['$scope', 'apiService', 'notificationService', '$state', 'commonService'];

    function productAddController($scope, apiService, notificationService, $state, commonService) {
        $scope.product = {
            CreatedDate: new Date(),
            Status: true
        }

        $scope.ChooseImage = ChooseImage;
        $scope.GetSeoTitle = GetSeoTitle;
        $scope.AddProduct = AddProduct;
        $scope.moreImages = [];
        $scope.chooseMoreImages = chooseMoreImages;

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        $scope.ckeditorOptions = {
            language: 'vi',
            height:'200px'
        }

        function AddProduct() {
            $scope.product.MoreImages = JSON.stringify($scope.moreImages) 
            apiService.post('api/product/create', $scope.product, function (result) {
                notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                $state.go('products');
            }, function () {
                notificationService.displayError('Thêm mới không thành công.');
            });
        }

        function loadProductCategory() {
            apiService.get('api/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log('cannot get list product category');
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
    }
})(angular.module('onlineshop.products'));