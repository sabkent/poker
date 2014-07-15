(function(ng, app) {

    function gameService($rootScope, signalrService) {
        this.rootScope = $rootScope;
        this.signalrService = signalrService;

        var self = this;
        signalrService.getProxy('lobby').then(function (proxy) {
            self.lobbyProxy = proxy;
            self.lobbyProxy.on('onGameSummaryReceived', ng.bind(self, self.onGameSummaryReceived));
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
        }
    };

    app.service('gameService', gameService);

})(angular, angular.module('poker'));