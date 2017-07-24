'use strict';
app.controller('portfolioItemController', ['$scope', '$rootScope', '$state', 'smoothScroll', '$timeout', 'projectService', '$stateParams', function ($scope, $rootScope, $state, smoothScroll, $timeout, projectService, $stateParams) {


    scroll('portfolioItem');
    

    $scope.images = [];
    $scope.featuredImage = {};
    $scope.tech = [];
    projectService.getProjectById($stateParams.projectId).then(function (result) {
            $scope.project = result.data;
            getImages($scope.project);
            getTech($scope.project);
        },
        function (err) {
            console.log(JSON.stringify(err));
        });

    $scope.edit = function () {
        $state.go('app.editProject',
            {
                projectId: $stateParams.projectId
            });
    }

    $scope.editProject = function (id) {
        $state.go('app.editProject', { projectId: id });
    }



    $scope.getLimits = function (array) {
        return [
            Math.floor($scope.tech.length / 2) + 1,
            -Math.floor($scope.tech.length / 2)
        ];
    };

    function getTech(project) {
        $scope.tech = project.ProjectTechnologies;
    }
    function getImages(project) {

        angular.forEach(project.ProjectImages,
            function (image) {
                if (!image.FeaturedImage) {
                    $scope.images.push(image);
                } else {
                    $scope.featuredImage = image;
                }
            });

    }



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


