var appName = "MvcBlank";//global variable

(function (AppName) {

    //to initialize application:
    var app = angular.module(AppName, ["LocalStorageModule", "ui.bootstrap", "ngSanitize"]);//"[]" = "array of dependecies" -> (inject toastrs or uib in the global level).

    app.factory("authInterceptorService", AuthInterceptorService);
    AuthInterceptorService.$inject = ["$q", "$location", "localStorageService", "$window"];
    function AuthInterceptorService($q, $location, localStorageService, $window) {

        var ais = {
            request: _request,
            responseError: _responseError
        }
        return ais;

        function _request(config) {
            config.headers = config.headers || {}; // =>"if config.headers exists, assign config.headers else create new object."
            var authData = localStorageService.get("authorizationData");
            if (authData)
                config.headers.Token = authData.token;

            return config;
        }

        function _responseError(rejection) {
            if (rejection.status === 401)
                $window.location.href = "/";

            return $q.reject(rejection);
        }
    }

    app.config(function ($httpProvider) {
        $httpProvider.interceptors.push("authInterceptorService");
    })

})(appName);

