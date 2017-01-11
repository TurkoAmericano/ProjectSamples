(function () {
    "use strict";

    angular
    .module("sample.services")
    .factory("CustomerCache", ['$state', customerCacheFactory])

    function customerCacheFactory($state) {
        var customerCache = [];
        var isCached = false;
        var currentCustomer = [];
        var displayCustomer = [];

        var setCustomerCache = function (customercache) {
            customerCache = [];
            customerCache = angular.copy(customercache);

            var displayItem = '';
            displayCustomer = [];
            for (var i = 0; i < customerCache.length; i++) {
                displayCustomer.push({
                    firstName: customercache[i].firstName,
                    middleName: customercache[i].middleName,
                    lastName: customercache[i].lastName,
                });
            }

            isCached = true;
        };

        var getCustomerCache = function () {
            return customerCache;
        };

        var getCurrentCustomer = function (item) {
            currentCustomer = [];

            if (item.length > 0) {
                for (var i = 0; i < customerCache.length; i++) {
                    if (customerCache[i].id == item[0].id) {
                        currentCustomer.push(customerCache[i]);
                    }
                }
            }

            return currentCustomer;
        };

        var getDisplayCustomer = function () {
            return displayCustomer;
        };

        var getCustomers = function (item) {
            return customerCache;
        };

        return {
            setCustomerCache: setCustomerCache,
            getCustomerCache: getCustomerCache,
            getCurrentCustomer: getCurrentCustomer,
            getDisplayCustomer: getDisplayCustomer,
            getCustomers: getCustomers
        };
    }
})();