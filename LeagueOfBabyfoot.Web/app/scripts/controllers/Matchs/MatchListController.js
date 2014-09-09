'use strict';

angular.module('babyboard').controller('MatchListController', ['$scope', 'MatchService', function ($scope, MatchService) {

  $scope.init = function (options) {
    MatchService.query(options, function (matchs) {
      $scope.matchs = matchs;
    });
  };
  
}]);
