angular.module("app").controller('editProjectController',
    [
        '$scope', '$state', 'authService', 'stateManager', 'alertService', 'smoothScroll', '$rootScope', '$timeout', 'projectService', '$stateParams', 'objectService',
        function ($scope, $state, authService, stateManager, alertService, smoothScroll, $rootScope, $timeout, projectService, $stateParams, objectService) {
            $scope.images = [];
            $scope.tech = [];

            projectService.getProjectById($stateParams.projectId).then(function (result) {
                $scope.project = result.data;
                $scope.tech = $scope.project.ProjectTechnologies;
                $scope.images = $scope.project.ProjectImages;
                $scope.project.ProjectTechnologies = null;
                $scope.project.ProjectImages = null;
            },
                function (err) {
                    console.log(JSON.stringify(err));
                });

            $scope.removeTech = function (tech) {
                objectService.removeElementFromArray(tech, $scope.tech);
            }
            $scope.removeImage = function (image) {
                objectService.removeElementFromArray(image, $scope.images);
            }

            $scope.addTech = function (tech) {
                if ($scope.newTech.TechnologyName == null) {
                    return;
                } else if ($scope.newTech.TechnologyName.length === 0) {
                    return;
                } else {
                    $scope.tech.push($scope.newTech);
                    $scope.newTech = null;
                }
            }

            $scope.addImage = function (image) {
                if ($scope.newImage.featured) {
                    angular.forEach($scope.images,
                        function (image) {
                            image.Featured = false;
                        });
                }

                $scope.images.push($scope.newImage);

                $scope.newImage = {};
            }

            $scope.saveProject = function () {
                assembleProject();
                projectService.editProject($scope.project).then(function (result) {
                    alertService.success("Project has been updated!");
                    $state.go('app.viewProject', { projectId: $stateParams.projectId });
                },
                    function (err) {
                        alertService.error("Error updating project!");
                    });
            }

            function assembleProject() {
                angular.forEach($scope.tech,
                    function (item) {
                        item.ProjectId = $stateParams.projectId;
                    });
                angular.forEach($scope.images,
                    function (item) {
                        item.ProjectId = $stateParams.projectId;
                    });

                $scope.project.projectTechnologies = $scope.tech;
                $scope.project.projectImages = $scope.images;
            }
        }
    ]);