'use strict';

angular.module('babyboard').controller('PlayerController', ['$scope', function ($scope) {
  $scope.init = function (player) {
    $scope.player = player;
  };
}]);
