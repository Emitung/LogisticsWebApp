(function () {
    'use strict';

    angular.module(appName).component("clientServiceEditModal", {
        bindings: {
            resolve: '<',
            close: '&',
            dismiss: '&'
        },
        templateUrl: "/Scripts/components/views/ClientServiceEditModal.html",
        controller: function (requestService, $scope, $window) {
            var vm = this;
            vm.$onInit = _init;
            vm.truckerModel = {};
            vm.clientModel = {};

            vm.edit = _edit;

            vm.closeMod = _closeMod;


            function _init() {
                vm.model = vm.resolve.items; //needs to have "vm." before "resolve" in order to work.

                if (vm.model.truckingCompanyName) {
                    $scope.truckingComp = true;
                    vm.truckerModel = vm.model;
                } else {
                    $scope.clientComp = true;
                    vm.clientModel = vm.model;
                }
            }


            function _edit(form) {
                if (vm.truckerModel.truckingCompanyName) {
                    requestService.ApiRequestService("PUT", "/api/TruckingCompanies/" + vm.truckerModel.id, vm.truckerModel)
                        .then(function (response) {
                            console.log("Edit trucking info success", response);
                            vm.truckerModel = {};
                            form.$setPristine();
                            form.$setUntouched();
                            vm.close();
                        })
                        .catch(function (err) {
                            console.log("Edit trucking info error", err)
                        });
                } else {
                    requestService.ApiRequestService("PUT", "/api/ClientCompanies/" + vm.clientModel.id, vm.clientModel)
                        .then(function (response) {
                            console.log("Edit client info success", response);
                            vm.clientModel = {};
                            form.$setPristine();
                            form.$setUntouched();
                            vm.close();
                        })
                        .catch(function (err) {
                            console.log("Edit client info error", err)
                        });
                }
            }

            function _closeMod() {
                vm.close();
            }
        }
    })
})();