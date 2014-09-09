'use strict';

angular.module('babyboard').controller('PlayerListController', ['$scope', 'PlayerService', function ($scope, PlayerService) {

  $scope.init = function (options) {
    PlayerService.query(options, function (players) {
      $scope.players = players;
    });
  };
  
}]);
