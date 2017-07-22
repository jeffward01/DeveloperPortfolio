angular.module('app').factory('toastrService',
    function () {
        var toastrServiceFactory = {};

        var toastSuccess = function (message, title, position) {
            var p = "toast-top-center";
            if (position.toLowerCase() === "top-center") {
                p = "toast-top-center";
            } else if (position.toLowerCase() === "top-left") {
                p = "toast-top-left";
            } else if (position.toLowerCase() === "top-right") {
                p = "toast-top-left";
            } else if (position.toLowerCase() === "top-full") {
                p = "toast-top-full-width";
            } else if (position.toLowerCase() === "bottom-left") {
                p = "toast-bottom-left";
            } else if (position.toLowerCase() === "bottom-right") {
                p = "toast-bottom-right";
            } else if (position.toLowerCase() === "bottom-center") {
                p = "toast-bottom-center";
            } else if (position.toLowerCase() === "bottom-full") {
                p = "toast-bottom-full-width";
            }
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": false,
                "progressBar": false,
                "positionClass": p,
                "preventDuplicates": true,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr.success(message, title);
        }

        var toastInfo = function (message, title, position) {
            var p = "toast-top-center";
            if (position.toLowerCase() === "top-center") {
                p = "toast-top-center";
            } else if (position.toLowerCase() === "top-left") {
                p = "toast-top-left";
            } else if (position.toLowerCase() === "top-right") {
                p = "toast-top-left";
            } else if (position.toLowerCase() === "top-full") {
                p = "toast-top-full-width";
            } else if (position.toLowerCase() === "bottom-left") {
                p = "toast-bottom-left";
            } else if (position.toLowerCase() === "bottom-right") {
                p = "toast-bottom-right";
            } else if (position.toLowerCase() === "bottom-center") {
                p = "toast-bottom-center";
            } else if (position.toLowerCase() === "bottom-full") {
                p = "toast-bottom-full-width";
            }
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": false,
                "progressBar": false,
                "positionClass": p,
                "preventDuplicates": true,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr.info(message, title);
        }

        var toastWarning = function (message, title, position) {
            var p = "toast-top-center";
            if (position.toLowerCase() === "top-center") {
                p = "toast-top-center";
            } else if (position.toLowerCase() === "top-left") {
                p = "toast-top-left";
            } else if (position.toLowerCase() === "top-right") {
                p = "toast-top-left";
            } else if (position.toLowerCase() === "top-full") {
                p = "toast-top-full-width";
            } else if (position.toLowerCase() === "bottom-left") {
                p = "toast-bottom-left";
            } else if (position.toLowerCase() === "bottom-right") {
                p = "toast-bottom-right";
            } else if (position.toLowerCase() === "bottom-center") {
                p = "toast-bottom-center";
            } else if (position.toLowerCase() === "bottom-full") {
                p = "toast-bottom-full-width";
            }
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": false,
                "progressBar": false,
                "positionClass": p,
                "preventDuplicates": true,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr.warning(message, title);
        }

        var toastError = function (message, title, position) {
            var p = "toast-top-center";
            if (position.toLowerCase() === "top-center") {
                p = "toast-top-center";
            } else if (position.toLowerCase() === "top-left") {
                p = "toast-top-left";
            } else if (position.toLowerCase() === "top-right") {
                p = "toast-top-left";
            } else if (position.toLowerCase() === "top-full") {
                p = "toast-top-full-width";
            } else if (position.toLowerCase() === "bottom-left") {
                p = "toast-bottom-left";
            } else if (position.toLowerCase() === "bottom-right") {
                p = "toast-bottom-right";
            } else if (position.toLowerCase() === "bottom-center") {
                p = "toast-bottom-center";
            } else if (position.toLowerCase() === "bottom-full") {
                p = "toast-bottom-full-width";
            }
            toastr.options = {
                "closeButton": true,
                "debug": false,
                "newestOnTop": false,
                "progressBar": false,
                "positionClass": p,
                "preventDuplicates": true,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            toastr.error(message, title);
        }


        toastrServiceFactory.success = toastSuccess;
        toastrServiceFactory.info = toastInfo;
        toastrServiceFactory.warning = toastWarning;
        toastrServiceFactory.error = toastError;


        return toastrServiceFactory;
        //}]);
    });