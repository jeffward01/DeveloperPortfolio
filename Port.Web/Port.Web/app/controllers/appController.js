angular.module("app").controller('appController',
    [
        '$scope', '$state', 'authService', 'stateManager', 'alertService', 'smoothScroll', '$rootScope', '$timeout', '$http',
        function ($scope, $state, authService, stateManager, alertService, smoothScroll, $rootScope, $timeout, $http) {
            //This needs to update upon login, do a $scope.$on???

            checkAuthentication();

            $scope.scrollToSkills = function () {
                // Using defaults
                var element = document.getElementById('skills');
                var options = {
                    duration: 700,
                    easing: 'easeInOutQuad', //originally it was 'easeInQuad'
                    offset: 120
                }
                smoothScroll(element, options);
            }

            $scope.goToHome = function () {
                $state.go('app.home', {});
                $timeout(function () {
                    scroll('page-top');
                },
                    350);
            }

            $scope.goToSnippet = function () {
                $state.go('app.home', {});
                $timeout(function () {
                    scroll('portfolio');
                },
                    350);
                $rootScope.$broadcast('openCodeSnippet');
            }

            $scope.goToSkills = function () {
                $state.go('app.home', {});
                $timeout(function () {
                    scroll('skills');
                },
                    350);
            };

            $scope.gotoAbout = function () {
                $state.go('app.home', {});
                $timeout(function () {
                    scroll('aboutMe');
                },
                    350);
            };

            $scope.goToFeaturedProjects = function () {
                $state.go('app.home', {});
                $timeout(function () {
                    scroll('featuredProjects');
                },
                    350);
            };

            $scope.goToContact = function () {
                $state.go('app.home', {});
                $timeout(function () {
                    scroll('contact');
                },
                    350);
            };

            $scope.goToPortfolio = function () {
                $state.go('app.home', {});
                $timeout(function () {
                    scroll('portfolio');
                },
                    350);
            };

            $scope.goToProfile = function () {
                setToggleProfile();
                //stateManager.goToMyProfile(authService.getNootUserId());
                stateManager.goToMyProfile(1);
            }

            function checkAuthentication() {
                $scope.isAuth = authService.mockCheckAuthentication();
                var authData = authService.getAuthentication();

                if (authData != null) {
                    $scope.username = authData.username;
                }
            }

            function scroll(elementId) {
                // Using defaults
                var element = document.getElementById(elementId);
                var options = {
                    duration: 700,
                    easing: 'easeInOutQuad', //originally it was 'easeInQuad'
                }
                $timeout(function () {
                    smoothScroll(element, options);
                },
                    100);
            }
        }]);