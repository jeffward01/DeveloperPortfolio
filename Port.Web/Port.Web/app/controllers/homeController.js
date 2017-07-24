'use strict';
app.controller('homeController', ['$scope', '$rootScope', '$state', 'githubService', 'projectService', 'alertService',function ($scope, $rootScope, $state, githubService, projectService, alertService) {
    $scope.portfolioCats = 0;
    $scope.blockchainProjects = [];
    $scope.generalProjects = [];

    $scope.$on("openCodeSnippet",
        function ($event) {
            $scope.portfolioCats = 5;
        });

    projectService.getAllFeaturedProjects().then(function (result) {
        $scope.featuredProjects = result.data;
    },
        function (err) {
            console.log("error: " + JSON.stringify(err));
        });

    projectService.getAllProjects().then(function (result) {
        $scope.projects = result.data;
        seperateProjects($scope.projects);
    },
        function (err) {
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
    $scope.sendEmail = function () {
        projectService.sendEmail($scope.email).then(function(result) {
            alertService.success("Email has been sent!");
                $scope.email = {};
            },
            function(err) {
                alertService.error("Error sending Email");
            });
    }
    function seperateProjects(projects) {
        angular.forEach(projects,
            function (project) {
                if (project.BlockchainProject) {
                    $scope.blockchainProjects.push(project);
                } else {
                    $scope.generalProjects.push(project);
                }
            });
    }



    (function () {
        var $ = (function (elm) {
                return document.querySelector(elm);
            }),
            Stars = function () {
                var num = (Math.min(window.innerWidth, window.innerHeight) / Math.max(window.innerWidth, window.innerHeight)) * 750, //Math.abs(window.innerWidth - window.innerHeight),
                    makeStar = function () {
                        return {
                            radius: Math.random() * (3 - .5) + .5,
                            pos: {
                                x: Math.random() * c.width,
                                y: Math.random() * c.height
                            },
                            moveTo: {
                                x: Math.random() * c.width,
                                y: Math.random() * c.height
                            },
                            bigger: ~~(Math.random() * 2),
                            speed: Math.random() * (c.width / c.height / 40)
                        }
                    },
                    stars = [],
                    draw = function (star) {
                        ctx.fillStyle = "#fff";
                        ctx.beginPath();
                        ctx.arc(star.pos.x, star.pos.y, star.radius, 0, Math.PI * 2);
                        ctx.fill();
                        if (star.bigger) {
                            star.radius += .01;
                            if (star.radius >= 3) star.bigger = false;
                        } else {
                            star.radius -= .01;
                            if (star.radius <= .3) star.bigger = true;
                        }
                        if (
                            star.moveTo.x >= star.pos.x - 5 &&
                                star.moveTo.x <= star.pos.x + 5
                        ) {
                            star.moveTo.x = Math.random() * c.width;
                        }
                        else if (star.moveTo.x < star.pos.x) star.pos.x -= star.speed;
                        else if (star.moveTo.x > star.pos.x) star.pos.x += star.speed;
                        if (
                            star.moveTo.y >= star.pos.y - 5 &&
                                star.moveTo.y <= star.pos.y + 5
                        ) {
                            star.moveTo.y = Math.random() * c.height;
                        }
                        else if (star.moveTo.y < star.pos.y) star.pos.y -= star.speed;
                        else if (star.moveTo.y > star.pos.y) star.pos.y += star.speed;

                        for (var i = 0; i < stars.length; i++) {
                            if (
                                star != stars[i] &&
                                    Math.sqrt(
                                        (star.pos.x - stars[i].pos.x) * (star.pos.x - stars[i].pos.x) +
                                        (star.pos.y - stars[i].pos.y) * (star.pos.y - stars[i].pos.y)
                                    ) < 50
                            ) {
                                ctx.beginPath();
                                ctx.moveTo(star.pos.x, star.pos.y);
                                ctx.lineTo(stars[i].pos.x, stars[i].pos.y);
                                ctx.closePath();
                                ctx.strokeStyle = "#fff";
                                ctx.lineWidth = .025;
                                ctx.stroke();
                            }
                        }
                    }
                return {
                    init: function () {
                        for (var i = 0; i < num; i++) {
                            stars.push(new makeStar());
                        }
                    },
                    move: function () {
                        setInterval(function () {
                            ctx.clearRect(0, 0, c.width, c.height);
                            background();
                            for (var i = 0; i < stars.length; i++) {
                                draw(stars[i]);
                            }
                        }, 1);
                    }
                }
            }
        c = $("#sky"),
            background = function () {
                var grdnt = ctx.createLinearGradient(0, 0, 0, c.height);
                grdnt.addColorStop(0, "#000");
                grdnt.addColorStop(.5, "#135288");
                grdnt.addColorStop(1, "#0C5663");
                ctx.fillStyle = grdnt;
                ctx.fillRect(0, 0, c.width, c.height);
            },
            sky = new Stars();

        c.width = window.innerWidth;
        c.height = window.innerHeight;

        var ctx = c.getContext("2d");

        sky.init();
        background();
        sky.move();
        window.addEventListener("resize", function () {
            c.width = window.innerWidth;
            c.height = window.innerHeight;
        }, true);
    }());
}]);