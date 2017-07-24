angular.module('app').factory('githubService',
    function (serviceUrl, $http,$q) {
        var githubUserServiceFactory = {};

        var _getUserInfo = function () {
            var url = serviceUrl + "api/githubInfo/getUserInfo";
            var deferred = $q.defer();
            $http.get(url).then(function (result) {
                deferred.resolve(result);
            },
                function (err) {
                    deferred.reject(err);
                });
            return deferred.promise;
        };

        var _getUserRepos = function () {
            var url = serviceUrl + "api/githubInfo/userRepos";
            var deferred = $q.defer();
            $http.get(url).then(function (result) {
                deferred.resolve(result);
            },
                function (err) {
                    deferred.reject(err);
                });
            return deferred.promise;
        };

        var _getUserStarredRepos = function () {
            var url = serviceUrl + "api/githubInfo/userStarredRepos";
            var deferred = $q.defer();
            $http.get(url).then(function (result) {
                deferred.resolve(result);
            },
                function (err) {
                    deferred.reject(err);
                });
            return deferred.promise;
        };




        githubUserServiceFactory.getUserInfo = _getUserInfo;
        githubUserServiceFactory.getUserRepos = _getUserRepos;
        githubUserServiceFactory.getUserStarredRepos = _getUserStarredRepos;

        return githubUserServiceFactory;
    });