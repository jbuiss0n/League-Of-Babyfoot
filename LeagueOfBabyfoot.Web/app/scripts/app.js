'use strict';

angular
  .module('babyboard', [
    'ngResource',
    'ngSanitize',
    'ngRoute',
    'ui.bootstrap'
  ])
  .config(function ($routeProvider) {
    $routeProvider
      .when('/', {
        templateUrl: 'views/main.html',
        controller: 'MainController'
      })
      .when('/matchs', {
        templateUrl: 'views/matchs/index.html',
        controller: 'MatchIndexController'
      })
      .otherwise({
        redirectTo: '/'
      });
  });
