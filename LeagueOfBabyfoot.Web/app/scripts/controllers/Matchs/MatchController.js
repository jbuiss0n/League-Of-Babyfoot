'use strict';

angular.module('babyboard').controller('MatchController', ['$scope', function ($scope) {

  var winScore;

  $scope.init = function (match) {
    $scope.match = match;
    winScore = Math.max(match.FirstTeamScore, match.SecondTeamScore);
  };

  $scope.isWinScore = function (score) {
    return winScore === score;
  };

  $scope.isLooseScore = function (score) {
    return !$scope.isWinScore(score);
  };
}]);
