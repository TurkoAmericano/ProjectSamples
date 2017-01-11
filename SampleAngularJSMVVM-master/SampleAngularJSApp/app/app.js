(function () {
    "use strict";

    var app = angular.module('sampleCustomers', ['sample.services', 'ui.router', 'ui.grid', 'ui.grid.selection']);

    app.config(['$urlRouterProvider', '$stateProvider',
        function ($urlRouterProvider, $stateProvider) {
            $urlRouterProvider.otherwise('/');

            $stateProvider
            .state('home', {
                url: '/',
                templateUrl: 'app/views/mainView.html'
            })
            .state('EditCustomer', {
                url: '/editcustomer/:id',
                templateUrl: 'app/views/customerView.html',
                controller: 'CustomerController as vm'
            })
        }
    ]);
}());