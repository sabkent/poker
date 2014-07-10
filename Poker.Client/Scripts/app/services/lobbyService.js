(function(ng, app) {

    function lobbyService($rootScope, signalrService) {
        this.rootScope = $rootScope;
        this.lobbyProxy = signalrService.getProxy('lobby');
        this.lobbyProxy.client.gamesAvailable = ng.bind(this, this.gamesAvailable);
    };

    lobbyService.prototype = {
        checkGames: function() {
            this.lobbyProxy.server.checkAvailableGames();
        },
        gamesAvailable: function(games) {
            this.rootScope.$emit('gamesAvailable', games);
        }
    };

    app.service('lobbyService', lobbyService);

})(angular, angular.module('poker'));