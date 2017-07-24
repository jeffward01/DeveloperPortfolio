angular.module('app')
    .factory('projectService', [
        '$http', '$q', 'serviceUrl',
        function ($http, $q, serviceUrl) {
            var projectServiceFactory = {};

            var _createProject = function (project) {
                var deferred = $q.defer();
                $http.post(serviceUrl + "api/Project/CreateProject", project).then(function (result) {
                        deferred.resolve(result);
                    },
                    function (err) {
                        deferred.reject(err);
                    });
                return deferred.promise;
            }

            var _editProject = function (project) {
                var deferred = $q.defer();
                $http.post(serviceUrl + "api/Project/EditProject", project).then(function (result) {
                        deferred.resolve(result);
                    },
                    function (err) {
                        deferred.reject(err);
                    });
                return deferred.promise;
            }

            var _deleteProject = function (projectId) {
                var deferred = $q.defer();
                $http.post(serviceUrl + "api/Project/DeleteProject/" + projectId).then(function (result) {
                        deferred.resolve(result);
                    },
                    function (err) {
                        deferred.reject(err);
                    });
                return deferred.promise;
            }


            var _getProjectbyId = function (projectId) {
                var deferred = $q.defer();
                $http.get(serviceUrl + "api/Project/GetProjectbyId/" + projectId).then(function (result) {
                        deferred.resolve(result);
                    },
                    function (err) {
                        deferred.reject(err);
                    });
                return deferred.promise;
            }

            var _getAllProjects = function () {
                var deferred = $q.defer();
                $http.get(serviceUrl + "api/Project/GetAllProjects").then(function (result) {
                        deferred.resolve(result);
                    },
                    function (err) {
                        deferred.reject(err);
                    });
                return deferred.promise;
            }

            var _getAllFeaturedProjects = function () {
                var deferred = $q.defer();
                $http.get(serviceUrl + "api/Project/GetAllFeaturedProjects").then(function (result) {
                        deferred.resolve(result);
                    },
                    function (err) {
                        deferred.reject(err);
                    });
                return deferred.promise;
            }

            var _getAllUnFeaturedProjects = function () {
                var deferred = $q.defer();
                $http.get(serviceUrl + "api/Project/GetAllUnFeaturedProjects").then(function (result) {
                        deferred.resolve(result);
                    },
                    function (err) {
                        deferred.reject(err);
                    });
                return deferred.promise;
            }

            var _getAllBlockchainProjects = function () {
                var deferred = $q.defer();
                $http.get(serviceUrl + "api/Project/GetAllBlockchainProjects").then(function (result) {
                        deferred.resolve(result);
                    },
                    function (err) {
                        deferred.reject(err);
                    });
                return deferred.promise;
            }
            var _sendEmail = function (email) {
                var deferred = $q.defer();
                $http.post(serviceUrl + "api/Email/SendEmail", email).then(function (result) {
                        deferred.resolve(result);
                    },
                    function (err) {
                        deferred.reject(err);
                    });
                return deferred.promise;
            }
            projectServiceFactory.getAllBlochckainProjects = _getAllBlockchainProjects;
            projectServiceFactory.sendEmail = _sendEmail;
            projectServiceFactory.createProject = _createProject;
            projectServiceFactory.editProject = _editProject;
            projectServiceFactory.deleteProject = _deleteProject;
            projectServiceFactory.getProjectById = _getProjectbyId;
            projectServiceFactory.getAllProjects = _getAllProjects;
            projectServiceFactory.getAllUnFeaturedProjects = _getAllUnFeaturedProjects;
            projectServiceFactory.getAllFeaturedProjects = _getAllFeaturedProjects;

            return projectServiceFactory;
        }
    ]);