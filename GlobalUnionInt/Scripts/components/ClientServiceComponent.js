(function () {
    'use strict';

    angular.module(appName).component("clientService", {
        bindings: {},
        templateUrl: "/Scripts/components/views/ClientService.html",
        controller: function (requestService, $scope, $window, $uibModal) {
            var vm = this;
            vm.$onInit = _init;
            vm.stateList = [];
            vm.truckerList = [];
            vm.clientList = [];

            vm.submit = _submit;
            vm.truckerModel = {};
            vm.clientModel = {};

            vm.edit = _edit;

            vm.delete = _delete;


            function _init() {
                requestService.ApiRequestService("GET", "/api/StateProvinces")
                    .then(function (response) {
                        console.log("State Provinces", response);
                        vm.stateList = response;
                    })
                    .catch(function (err) {
                        console.log("State Provinces error", err);
                    });

                requestService.ApiRequestService("GET", "/api/TruckingCompanies")
                    .then(function (response) {
                        console.log("Get trucking info success", response);
                        vm.truckerList = response;
                    })
                    .catch(function (err) {
                        console.log("Get trucking info error", err);
                    });

                requestService.ApiRequestService("GET", "/api/ClientCompanies")
                    .then(function (response) {
                        console.log("Get client info success", response);
                        vm.clientList = response;
                    })
                    .catch(function (err) {
                        console.log("Get client info error", err);
                    });
            }

            function _submit(form) {
                if (vm.truckerModel.truckingCompanyName) {
                    requestService.ApiRequestService("POST", "/api/TruckingCompanies", vm.truckerModel)
                        .then(function (response) {
                            console.log("Post trucking info success", response);
                            
                            vm.truckerModel = {};
                            form.$setPristine();
                            form.$setUntouched();
                            _init();

                            swal({
                                title: "Success!",
                                text: "New Contact Added!",
                                type: "success",
                                timer: 2000,
                                showConfirmButton: false
                            });
                        })
                        .catch(function (err) {
                            console.log("Post trucking info error", err)
                        });
                } else {
                    requestService.ApiRequestService("POST", "/api/ClientCompanies", vm.clientModel)
                        .then(function (response) {
                            console.log("Post client info success", response);
                            
                            vm.clientModel = {};
                            form.$setPristine();
                            form.$setUntouched();
                            _init();

                            swal({
                                title: "Success!",
                                text: "New Contact Added!",
                                type: "success",
                                timer: 2000,
                                showConfirmButton: false
                            });
                        })
                        .catch(function (err) {
                            console.log("Post client info error", err);
                        });
                }
            }

            function _edit(itm) {
                if (itm.truckingCompanyName) {


                    var modalInstance = $uibModal.open({
                        animation: true,
                        component: 'clientServiceEditModal',
                        size: 'md',
                        resolve: {
                            items: itm
                        }
                    });

                    modalInstance.result.then(function () {
                        _init();
                        $scope.tabindex = 1;
                    }, function () {
                        _init();
                    });
                } else {

                    var modalInstance = $uibModal.open({
                        animation: true,
                        component: 'clientServiceEditModal',
                        size: 'md',
                        resolve: {
                            items: itm
                        }
                    });

                    modalInstance.result.then(function () {
                        _init();
                        $scope.tabindex = 2;
                    }, function () {
                        _init();
                    });
                }
            }

            function _delete(itm) {
                if (itm.truckingCompanyName) {
                    swal({
                        title: "Delete?",
                        text: "Are you sure you want to delete " + itm.truckingCompanyName + " ?",
                        type: "warning",
                        showCancelButton: true,
                        confirmButtonClass: "btn-danger",
                        confirmButtonText: "Yes, delete it!",
                        closeOnConfirm: false
                    },
                        function () {
                            requestService.ApiRequestService("DELETE", "/api/TruckingCompanies/" + itm.id)
                                .then(function (response) {
                                    console.log("Delete trucking info success", response);
                                    _init();
                                    $scope.tabindex = 1;
                                })
                                .catch(function (err) {
                                    console.log("Delete trucking info error", err)
                                });
                        });

                } else {
                    swal({
                        title: "Delete?",
                        text: "Are you sure you want to delete " + itm.clientCompanyName + " ?",
                        type: "warning",
                        showCancelButton: true,
                        confirmButtonClass: "btn-danger",
                        confirmButtonText: "Yes, delete it!",
                        closeOnConfirm: false
                    },
                        function () {
                            requestService.ApiRequestService("DELETE", "/api/ClientCompanies/" + itm.id)
                                .then(function (response) {
                                    console.log("Delete client info success", response);
                                    _init();
                                    $scope.tabindex = 2;
                                })
                                .catch(function (err) {
                                    console.log("Delete client info error", err);
                                });
                        });
                }
            }
        }
    })
})();