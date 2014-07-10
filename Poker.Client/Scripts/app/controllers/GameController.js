(function (ng, app) {

    function lobbyController($scope) {
        $scope.joinGame = ng.bind(this, this.joinGame);

        this.initializeServerConnection();
        return this;
    };

    lobbyController.prototype = {
        initializeServerConnection: function () {
            this.activeGame = $.connection.activeGame;
            this.activeGame.client.playerJoined = ng.bind(this, this.playerJoined);
        },
        joinGame: function () {
            this.activeGame.server.joinGame();
        },
        playerJoined: function () {
            console.log('player joined game');
        }
    };

    app.controller('lobbyController', lobbyController);

})(angular, angular.module('poker'));