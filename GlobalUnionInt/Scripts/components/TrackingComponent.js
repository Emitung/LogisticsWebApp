(function () {
    'use strict';

    angular.module(appName).component("trackingView", {
        bindings: {},
        templateUrl: "/Scripts/components/views/Tracking.html",
        controller: function (requestService, $scope, $window) {
            var vm = this;
            vm.$onInit = _init;
            vm.trackingNum;

            vm.enter = _enter;

            vm.webScraper1 = _webScraper1;
            vm.webScraper2 = _webScraper2;
            vm.webscraperResp1 = [];
            vm.webscraperResp2 = [];


            function _init() {
                console.log("Start up");

                
            }

            function _webScraper1(trackingNum) {
                requestService.ApiRequestService("GET", "/api/webscrapers/1/" + trackingNum)
                    .then(function (response) {
                        console.log("webscraper response 1", response);

                        for (var i = 0; i < response.length; i++) {
                            vm.webscraperResp1.push({ html: response[i] });
                        }

                        $scope.enterSearch = false;
                    })
                    .catch(function (err) {
                        console.log("Webscraper error 1", err);
                    })
            }

            function _webScraper2(trackingNum) {
                requestService.ApiRequestService("GET", "/api/webscrapers/2/" + trackingNum)
                    .then(function (response) {
                        console.log("webscraper response 2", response);

                        for (var i = 0; i < response.length; i++) {
                            vm.webscraperResp2.push({ html: response[i] });
                        }

                        $scope.enterSearch = false;
                    })
                    .catch(function (err) {
                        console.log("Webscraper error 2", err);
                    })
            }

            function _enter(trackingNum) {
                if (trackingNum != 0) {
                    $scope.enterSearch = true;

                    _webScraper1(trackingNum);
                    _webScraper2(trackingNum);
                }
            }
        }
    })
})();