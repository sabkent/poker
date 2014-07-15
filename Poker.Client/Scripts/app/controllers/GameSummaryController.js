(function(ng, app) {

    function gameSummaryController($scope, $routeParams, gameService) {
        this.scope = $scope;
        this.gameService = gameService;
        $scope.buyIn = ng.bind(this, this.buyIn);
        $scope.$parent.$on('gameSummaryReceived', ng.bind(this, this.onGameSummaryReceived));
        
        this.getSummary($routeParams.id);
    };

    gameSummaryController.prototype = {
        onGameSummaryReceived : function(e, gameSummary) {
            this.scope.game = gameSummary;
            this.scope.$apply();
        },
        getSummary: function (gameId) {
            this.gameService.requestSummary(gameId);
        },
        buyIn: function (gameId) {
            
        }
    };

    app.controller('gameSummaryController', gameSummaryController);

})(angular, angular.module('poker'));