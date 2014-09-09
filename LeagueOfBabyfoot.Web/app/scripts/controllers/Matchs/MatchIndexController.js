'use strict';

angular.module('babyboard').controller('MatchIndexController', ['$scope', function ($scope) {
  $scope.init = function () {

  };

  $scope.createMatch = function () {
    $scope.$broadcast('create');
  };

}]);
