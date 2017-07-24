angular.module("app").controller('viewProjectController',
    [
        '$scope', '$state', 'authService', 'stateManager', 'alertService', 'smoothScroll', '$rootScope', '$timeout', 'projectService', '$stateParams',
        function ($scope, $state, authService, stateManager, alertService, smoothScroll, $rootScope, $timeout, projectService, $stateParams) {
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

            $scope.editProject = function(id) {
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
                    function(image) {
                        if (!image.FeaturedImage) {
                            $scope.images.push(image);
                        } else {
                            $scope.featuredImage = image;
                        }
                    });
             
            }

     
        }
    ]);