'use strict';

angular.module('babyboard').controller('MatchMembersController', ['$scope', function ($scope) {
  $scope.init = function (members) {
    $scope.members = members;
  };
}]);
