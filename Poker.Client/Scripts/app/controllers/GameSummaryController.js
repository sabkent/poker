(function(ng, app) {

    function gameSummaryController($scope, $routeParams, $location, gameService) {
        this.scope = $scope;
        this.location = $location;
        this.gameService = gameService;
        $scope.buyIn = ng.bind(this, this.buyIn);
        $scope.$parent.$on('gameSummaryReceived', ng.bind(this, this.onGameSummaryReceived));
        $scope.$parent.$on('playerJoinedGame', ng.bind(this, this.playerJoinedGame));
        
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
            this.gameService.requestBuyIn(gameId);
        },
        playerJoinedGame: function (e, gamePlayer) {
            console.log('player joined');
            this.location.path('/game/' + gamePlayer.GameId);
            this.scope.$apply();
        }
    };

    app.controller('gameSummaryController', gameSummaryController);

})(angular, angular.module('poker'));