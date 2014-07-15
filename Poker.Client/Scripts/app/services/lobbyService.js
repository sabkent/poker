(function(ng, app, signalr) {

    function lobbyService($rootScope, signalrService) {
        this.rootScope = $rootScope;
        this.signalrService = signalrService;
        
        var self = this;
        signalrService.getProxy('lobby').then(function (proxy) {
            self.lobbyProxy = proxy;
            proxy.on('gamesAvailable', ng.bind(self, self.gamesAvailable));
            proxy.server.checkAvailableGames();
        });
    };

    lobbyService.prototype = {
        checkGames: function () {
            this.lobbyProxy.server.checkAvailableGames();
        },
        gamesAvailable: function (games) {
            this.rootScope.$emit('gamesAvailable', games);
        }
    };

    app.service('lobbyService', lobbyService);

})(angular, angular.module('poker'), $.connection);