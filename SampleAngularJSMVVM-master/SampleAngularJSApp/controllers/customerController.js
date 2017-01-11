(function () {
    "use strict";

    angular.module("sampleCustomers")
        .controller("CustomerController", ['$scope', 'WebApiService', 'CustomerCache', 'uiGridConstants', customerController]);


    function customerController($scope, webApiService, customerCache, uiGridConstants) {
        var vm = this;
        $scope.customerGridOptions = {};
        $scope.myCustomerSelections = [];
        vm.customers = [];
        $scope.customerEditVisible = true;
        vm.newCustomer = false;
        vm.message = '';
        vm.emptyCustomer = [{
            id: -1,
            firstName: '',
            middleName: '',
            lastName: '',
            address: '',
            city: '',
            state: '',
            postalCode: ''
        }];

        $scope.customerGridOptions = {
            multiSelect: false,
            enableColumnMenus: false,
            showFilter: false,
            enableSorting: false,
            onRegisterApi: function (gridApi) {
                $scope.customerGridApi = gridApi;
                gridApi.selection.on.rowSelectionChanged($scope, function (rows) {
                    var selectedItem = [];
                    selectedItem = gridApi.selection.getSelectedRows();

                    if (selectedItem.length > 0) {

                        $scope.myCustomerSelections = customerCache.getCurrentCustomer(selectedItem);
                        $scope.customerEditVisible = false;
                    }
                    else {
                        gridApi.selection.clearSelectedRows();
                        $scope.customerEditVisible = true;
                    }

                    vm.newCustomer = false;
                });
            },
            columnDefs: [
                        { field: 'firstName', displayName: 'First', width: 120 },
                        { field: 'middleName', displayName: 'M', width: 60 },
                        { field: 'lastName', displayName: 'Last', width: 160 }]
        };

        webApiService.query({ apiUrl: 'customers' }, function (data) {
            customerCache.setCustomerCache(data);
            vm.customers = customerCache.getCustomerCache();

            $scope.customerGridOptions = {
                enableHorizontalScroller: uiGridConstants.scrollbars.NEVER,
                data: vm.customers
            };
        }, function (error) {
            vm.message = 'Error in getting: ' + error.status + ', ' + error.statustext;
        });

        vm.displayUpdate = function () {
            $scope.customerGridApi.selection.clearSelectedRows();
            $scope.customerEditVisible = true;
            vm.newCustomer = false;

            webApiService.query({ apiUrl: 'customers' }, function (data) {
                customerCache.setCustomerCache(data);
                vm.customers = customerCache.getCustomerCache();

                $scope.customerGridOptions = {
                    enableHorizontalScroller: uiGridConstants.scrollbars.NEVER,
                    data: vm.customers
                };
            }, function (error) {
                vm.message = 'Error in getting: ' + error.status + ', ' + error.statustext;
            });
        };

        $scope.customerNewSelection = function () {
            $scope.customerEditVisible = false;
            vm.newCustomer = true;
            $scope.myCustomerSelections = [];
            $scope.myCustomerSelections.push(vm.emptyCustomer[0]);
        }

        $scope.customerDeleteSelection = function () {
            webApiService.delete({ apiUrl: 'customers', id: $scope.myCustomerSelections[0].id }).$promise.then(function (result) {

                $scope.message = result;
                vm.displayUpdate();

            }, function (error) {
                vm.message = 'Error in deleteing: ' + error.status + ', ' + error.statustext;
            });
        };

        $scope.customerSaveSelection = function () {
            if ($scope.myCustomerSelections[0].id == -1) {

                // Send to API to save data
                webApiService.save({ apiUrl: 'customers' }, $scope.myCustomerSelections[0]).$promise.then(function (result) {

                    $scope.message = result;
                    // Re-display grid with new data from table.
                    vm.displayUpdate();

                }, function (error) {
                    vm.message = 'Error in insert: ' + error.status + ', ' + error.statustext;
                });
            }
            else {
                webApiService.update({ apiUrl: 'customers', id: $scope.myCustomerSelections[0].id }, $scope.myCustomerSelections[0]).$promise.then(function (result) {

                    $scope.message = result;
                    vm.displayUpdate();

                }, function (error) {
                    vm.message = 'Error in update: ' + error.status + ', ' + error.statustext;
                });
            }
        };

        $scope.customerCancelSelection = function () {
            vm.displayUpdate();
        };
    }
}());