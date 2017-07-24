'use strict';
app.controller('portfolioItemController', ['$scope', '$rootScope', '$state', 'smoothScroll', '$timeout',function ($scope, $rootScope, $state, smoothScroll,$timeout) {


    scroll('portfolioItem');
    

    

    function scroll(elementId) {
        // Using defaults
        var element = document.getElementById(elementId);
        var options = {
            duration: 700,
            easing: 'easeInOutQuad', //originally it was 'easeInQuad'

        }
        smoothScroll(element, options);
        $timeout(function() {
            document.getElementById("contactTab").classList.remove("active");
            document.getElementById("aboutTab").classList.remove("active");
            document.getElementById("featuredProjectTab").classList.remove("active");

            document.getElementById("skillTab").classList.remove("active");

            document.getElementById("aboutTab").classList.remove("active");

            document.getElementById("portfolioTab").classList.remove("active");


            },
            100);

    }


}]);


