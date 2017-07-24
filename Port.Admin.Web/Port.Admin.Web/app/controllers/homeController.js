'use strict';
app.controller('homeController', ['$scope', '$rootScope', '$state', 'githubService', 'projectService', 'alertService',
    function ($scope, $rootScope, $state, githubService, projectService, alertService) {
        $scope.portfolioCats = 0;
        $scope.$on("openCodeSnippet",
            function ($event) {
                $scope.portfolioCats = 5;
            });
        getProjects()
        $scope.viewPortItem = function (projectId) {
            $state.go('app.portfolioItem', { portfolioItemId: projectId });
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
        $scope.viewProject = function (projectId) {
            $state.go('app.viewProject', { projectId: projectId });
        }

        $scope.editProject = function (projectId) {
            $state.go('app.editProject', { projectId: projectId });
        }
        $scope.deleteProject = function (projectId) {
            projectService.deleteProject(projectId).then(function (result) {
                getProjects();
                alertService.success("Project Deleted!");
            },
                function (err) {
                    alertService.error("Error deleting project");
                    console.log(JSON.stringify(err));
                });
        }
        $scope.addProject = function () {
            $state.go('app.addProject', {});
        }

        function getProjects() {
            projectService.getAllProjects().then(function (result) {
                $scope.projects = result.data;
            },
                function (err) {
                    console.log(JSON.stringify(err));
                });
        }
    }]);