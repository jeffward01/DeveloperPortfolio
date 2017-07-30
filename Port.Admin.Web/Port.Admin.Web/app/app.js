var app = angular.module('app',
    ['ui.router', 'LocalStorageModule', 'ui.bootstrap', 'ngSanitize', 'angularSpinner', 'smoothScroll', 'angular-loading-bar','angular-svg-round-progressbar', 'angularUtils.directives.dirPagination'])

    .config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
           $urlRouterProvider.otherwise('app/home');

        //States
        $stateProvider.state('app',
            {
                url: '/app',
                templateUrl: 'app/views/app.html',
                controller: 'appController',
                data: {
                    displayName: 'App'
                }
            })
            .state('app.home',
            {
                url: '/home',
                templateUrl: 'app/views/home.html',
                controller: 'homeController',
                data: {
                    displayName: 'Home'
                }
            })
            .state('app.portfolioItem',
            {
                url: '/portfolioItem/:portfolioItemId',
                templateUrl: 'app/views/portfolioItem.html',
                controller: 'portfolioItemController',
                data: {
                    displayName: 'Portfolio Item',
                    portfolioItemId: null
                }
            })
            .state('app.addProject',
            {
                url: '/addProject',
                templateUrl: 'app/views/addProject.html',
                controller: 'addProjectController',
                data: {
                    displayName: 'Add Project'
                }
            })
            .state('app.editProject',
            {
                url: '/editProject/:projectId',
                templateUrl: 'app/views/editProject.html',
                controller: 'editProjectController',
                data: {
                    displayName: 'Edit Project',
                    projectId: null
                }
            })
            .state('app.viewProject',
                {
                    url: '/viewProject/:projectId',
                    templateUrl: 'app/views/viewProject.html',
                    controller: 'viewProjectController',
                    data: {
                        displayName: 'View Project',
                        projectId: null
                    }
                });

        // if none of the above states are matched, use this as the fallback
        //  $urlRouterProvider.otherwise('/app/landingPage');
    }]);

//app.value('serviceUrl', 'http://port.service/');
app.value('serviceUrl', 'http://portfolioapi.jeffward-portfolio.com/');

app.directive('security', ['$compile', 'localStorageService', '$timeout', function ($compile, localStorageService, $timeout) {
    return {
        link: function (scope, element, attrs) {
            var userInfo = localStorageService.get('authorizationData');
            if (userInfo != null) {
                var allowedActions = userInfo.contactActions;
                var actions = attrs.actions.split(',');
                var counter = 0;
                angular.forEach(allowedActions, function (allowedAction) {
                    angular.forEach(actions, function (action) {
                        if (allowedAction.name == action) {
                            counter++;
                        }
                    });
                });
                if (counter == 0) {
                    $(element).remove();
                }
            } else {
                $(element).remove();
            }
        }
    }
}]);

app.run(function () {
});

angular.module('app').filter('cut', function () {
    return function (value, wordwise, max, tail) {
        if (!value) return '';

        max = parseInt(max, 10);
        if (!max) return value;
        if (value.length <= max) return value;

        value = value.substr(0, max);
        if (wordwise) {
            var lastspace = value.lastIndexOf(' ');
            if (lastspace !== -1) {
                //Also remove . and , so its gives a cleaner result.
                if (value.charAt(lastspace - 1) === '.' || value.charAt(lastspace - 1) === ',') {
                    lastspace = lastspace - 1;
                }
                value = value.substr(0, lastspace);
            }
        }

        return value + (tail || ' …');
    };
});