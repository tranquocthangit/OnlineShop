/// <reference path="../../../assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('onlineshop.product_categories', ['onlineshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('productcategories', {
            url: '/productcategories',
            templateUrl: '/app/components/product_categories/productCategoryListView.html',
            controller: "productCategoryListController"
        });
    }
})();