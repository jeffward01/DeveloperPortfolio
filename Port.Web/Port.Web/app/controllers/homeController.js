'use strict';
app.controller('homeController', ['$scope', '$rootScope', '$state', 'githubService', 'projectService', function ($scope, $rootScope, $state, githubService, projectService) {
    $scope.portfolioCats = 0;
    $scope.$on("openCodeSnippet",
        function ($event) {
            $scope.portfolioCats = 5;
        });

    projectService.getAllFeaturedProjects().then(function(result) {
        $scope.featuredProjects = result.data;
        },
        function(err) {
            console.log("error: " + JSON.stringify(err));
        });

    $scope.viewPortItem = function (projectId) {
        $state.go('app.portfolioItem', { projectId: projectId });
    }

    githubService.getUserInfo().then(function (result) {
        $scope.userInfo = result.data;
    },
        function (err) {
            console.log(JSON.stringify(err));
        });

    githubService.getUserStarredRepos().then(function (result) {
        $scope.userStarredRepos = result.data;
    },
        function (err) {
            console.log(JSON.stringify(err));
        });

    githubService.getUserRepos().then(function (result) {
        $scope.userRepos = result.data;
    },
        function (err) {
            console.log(JSON.stringify(err));
        });

    $scope.test = function () {
        alert("Test");
    }
}]);