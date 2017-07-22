var app = angular.module('app',
    ['ui.router', 'LocalStorageModule', 'angular-loading-bar', 'ui.bootstrap', 'ngSanitize', 'angularSpinner', 'smoothScroll', 'angular-svg-round-progressbar', 'angularUtils.directives.dirPagination'])


    .config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
       //   $urlRouterProvider.otherwise('app/home');

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
            });


        // if none of the above states are matched, use this as the fallback
        //  $urlRouterProvider.otherwise('/app/landingPage');
    }]);

app.value('serviceUrl', 'http://localhost:63085');

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

