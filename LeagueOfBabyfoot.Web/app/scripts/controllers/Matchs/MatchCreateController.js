'use strict';

angular.module('babyboard').controller('MatchCreateController', ['$scope', '$controller', 'MatchService', function ($scope, $controller, MatchService) {
  var modelstate;

  function initialize() {
    modelstate = { creating: false, saving: false };
    $scope.match = {};
  }

  initialize();

  var onCreate = function () {
    modelstate.creating = true;
  };

  var onSaved = function () {
    initialize();
    $scope.$emit('saved');
  };

  var createMatch = function () {
    MatchService.save({}, $scope.match, onSaved);
  };

  $scope.init = function () {
    $scope.$on('create', onCreate);
  };

  $scope.isCreating = function () {
    return modelstate.creating;
  };

  $scope.isSaving = function () {
    return modelstate.saving;
  };

  $scope.save = function () {
    modelstate.saving = true;
    createMatch();
  };

  $scope.cancel = function () {
    modelstate.creating = false;
  };
}]);
