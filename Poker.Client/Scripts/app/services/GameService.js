(function(ng, app) {

    function gameService($rootScope, $location, signalrService) {
        this.rootScope = $rootScope;
        this.location = $location;
        this.signalrService = signalrService;

        var self = this;
        signalrService.getProxy('lobby').then(function (proxy) {
            self.lobbyProxy = proxy;
            self.lobbyProxy.on('onGameSummaryReceived', ng.bind(self, self.onGameSummaryReceived));
            self.lobbyProxy.on('playerJoinedGame', ng.bind(self, self.onPlayerJoinedGame));
        });
    }

    gameService.prototype = {
        requestSummary: function (gameId) {
            this.signalrService.getProxy('lobby').then(function(proxy) {
                proxy.server.requestGameSummary(gameId);
            });
        },
        onGameSummaryReceived: function (gameSummary) {
            this.rootScope.$emit('gameSummaryReceived', gameSummary);
        },
        requestBuyIn: function (gameId) {
            this.signalrService.getProxy('lobby').then(function (proxy) {
                proxy.server.requestBuyIn(gameId);
            });
        },
        onPlayerJoinedGame: function (gamePlayer) {
            this.rootScope.$emit('playerJoinedGame', gamePlayer);
        }
    };

    app.service('gameService', gameService);

})(angular, angular.module('poker'));