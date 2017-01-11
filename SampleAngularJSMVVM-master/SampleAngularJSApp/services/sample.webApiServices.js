(function () {
    "use strict";

    angular
        .module("sample.services")
        .factory("WebApiService", ["$resource", "appSettings", webApiService])

    function webApiService($resource, appSettings) {
        return $resource(appSettings.serverPath + '/api/:apiUrl/:id', { apiUri: '@apiUrl', id: '@id' },
            {
                'get': {
                    method: 'GET', isArray: true 
                },
                'query': {
                    method: 'GET', isArray: true
                },
                'save': {
                    method: 'POST'
                },
                'update': {
                    method: 'PUT'
                },
                'delete': {
                    method: 'DELETE'
                }
            });
    }
})();