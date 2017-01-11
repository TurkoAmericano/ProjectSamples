(function () {
    "use strict";

    angular
        .module("sample.services", ["ngResource"])
        .constant("appSettings",
        {
            serverPath: "http://localhost:50515/"
        });
})();