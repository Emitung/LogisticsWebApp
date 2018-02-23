(function () {

    angular.module(appName).factory("authService", AuthService);
    AuthService.$inject = ["$http", "$q", "localStorageService"];
    function AuthService($http, $q, localStorageService) {

        var authServiceObj = {
            login: _login,
            logout: _logout
        }
        return authServiceObj;

        function _login(loginData) {
            var encoded = window.btoa(loginData.userName + ":" + loginData.password);
            var deferred = $q.defer();

            $http({
                method: "POST",
                dataType: "json",
                url: "/api/auths/login",
                headers: {
                    "Authorization": "Basic " + encoded,
                    "Content-Type": "application/x-www-form-urlencoded",
                    "Access-Control-Allow-Origin": "*"
                }
            }).then(function (response) {
                localStorageService.set("authorizationData", {
                    token: response.headers("Token"),
                    tokenExpires: response.headers("TokenExpires")
                });
                deferred.resolve(response);
            })
                .catch(function (err) {
                    deferred.reject(err);
                })

            return deferred.promise;
        }

        function _logout() {
            return localStorageService.remove("authorizationData");
        }
    }
})();