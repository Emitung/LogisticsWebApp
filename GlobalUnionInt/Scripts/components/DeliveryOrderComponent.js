(function () {
    'use strict';

    angular.module(appName).component("deliveryOrder", {
        bindings: {},
        templateUrl: "/Scripts/components/views/DeliveryOrder.html",
        controller: function () {
            var vm = this;
            vm.$onInit = _init;


            function _init() {
                console.log("Start up");
            }
        }
    })
})();