angular.module("app").controller('addProjectController',
    [
        '$scope', '$state', 'authService', 'stateManager', 'alertService', 'smoothScroll', '$rootScope', '$timeout', 'objectService', 'projectService', 
        function ($scope, $state, authService, stateManager, alertService, smoothScroll, $rootScope, $timeout, objectService, projectService) {
            $scope.technologiesToAdd = [];
            $scope.imagesToAdd = [];
            $scope.newProject = {};

            $scope.addImage = function (image) {
                if ($scope.newImage.FeaturedImage) {
                    angular.forEach($scope.imagesToAdd,
                        function (image) {
                            image.FeaturedImage = false;
                        });
                }

                $scope.imagesToAdd.push($scope.newImage);

                $scope.newImage = {};
            }


            $scope.submitProject = function () {
                if (countFeaturedImages() !== 1) {
                    alertService.error("Only one featured image is allowed.  Please try again");
                } else {
                    var project = assembleProject();
                    projectService.createProject(project).then(function (result) {
                        clearProject();
                        alertService.success("Project has been added!");
                        $state.go("app.home", {});
                    },
                        function (err) {
                            console.log(JSON.stringify(err));
                            alertService.error("Error adding Project.  Please try again");
                        });
                }
            }

            $scope.addTech = function (tech) {
                if ($scope.newTech.technologyName == null) {
                    return;
                } else if ($scope.newTech.technologyName.length === 0) {
                    return;
                } else {
                    $scope.technologiesToAdd.push($scope.newTech);
                    $scope.newTech = null;
                }
            }

            $scope.removeTech = function (tech) {
                objectService.removeElementFromArray(tech, $scope.technologiesToAdd);
            }
            $scope.removeImage = function (image) {
                objectService.removeElementFromArray(image, $scope.imagesToAdd);
            }

            function assembleProject() {
                $scope.newProject.projectTechnologies = $scope.technologiesToAdd;
                $scope.newProject.projectImages = $scope.imagesToAdd;
                return $scope.newProject;
            }

            function clearProject() {
                $scope.newProject = {};
                $scope.projectImages = [];
                $scope.projectTechnologies = [];
            }
            function countFeaturedImages() {
                var count = 0;
                angular.forEach($scope.imagesToAdd,
                    function (image) {
                        if (image.FeaturedImage) {
                            count++;
                        }
                    });
                return count;
            }
        }
    ]);