'use strict';

angular.module('babyboard').factory('MatchService', ['$resource', function ($resource) {
  return $resource(window.API_URL + '/matchs/:id');
}]);