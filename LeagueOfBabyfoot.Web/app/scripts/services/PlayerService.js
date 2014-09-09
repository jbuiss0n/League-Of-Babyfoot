'use strict';

angular.module('babyboard').factory('PlayerService', ['$resource', function ($resource) {
  return $resource(window.API_URL + '/players/:id');
}]);