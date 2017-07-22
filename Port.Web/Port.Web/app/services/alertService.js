angular.module('app')
    .factory('alertService', [
        '$http', '$q', 'toastrService',
        function ($http, $q, toastr) {


            var alertServiceFactory = {};

            var _test = function () {
                toastr.info('We are open today from 10 to 22', 'Information');
            };

            //update alerts: http://t4t5.github.io/sweetalert/

            var _success = function (message) {
                //toastr.options = {
                //    "closeButton": false,
                //    "debug": false,
                //    "newestOnTop": false,
                //    "progressBar": false,
                //    "positionClass": "toast-top-center",
                //    "preventDuplicates": true,
                //    "onclick": null,
                //    "showDuration": "300",
                //    "hideDuration": "1000",
                //    "timeOut": "5000",
                //    "extendedTimeOut": "1000",
                //    "showEasing": "swing",
                //    "hideEasing": "linear",
                //    "showMethod": "fadeIn",
                //    "hideMethod": "fadeOut"
                //}

                //toastr.success(message, title);
                sweetAlert("Success", message, "success");
            }

            _loginAlert = function (message) {
                swal({
                    title: "Welcome!",
                    text: message,
                    timer: 2000,
                    showConfirmButton: false,
                    type: 'success'
                });

            }

            var _warning = function (message, title) {
                toastr.warning(message, title);
            }
            var _info = function (message, title) {
                toastr.info(message, title);
            }
            var _error = function (message) {
                sweetAlert("Oops", message, "error");
            }

            var _loginError = function (message) {
                sweetAlert({
                    title: "Oops!",
                    text: message,
                    type: "error",
                    timer: 2000,
                    showConfirmButton: true,
                });
            }

            var _logoutMessage = function () {
                sweetAlert({
                    title: "Logged out!",
                    text: "You have been logged out!  Come back soon!",
                    type: "success",
                    timer: 2000,
                    showConfirmButton: false,
                });
            }

            var _successTimeout = function (message) {
                sweetAlert({
                    title: "Success",
                    text: message,
                    type: "success",
                    timer: 2000,
                    showConfirmButton: false,
                });
            }

            alertServiceFactory.successTimeout = _successTimeout;
            alertServiceFactory.logoutMessage = _logoutMessage;
            alertServiceFactory.loginError = _loginError;
            alertServiceFactory.loginAlert = _loginAlert;
            alertServiceFactory.test = _test;
            alertServiceFactory.info = _info;
            alertServiceFactory.warning = _warning;
            alertServiceFactory.success = _success;
            alertServiceFactory.error = _error;
            return alertServiceFactory;


        }
    ]);
