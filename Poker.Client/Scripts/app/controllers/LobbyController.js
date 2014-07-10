(function (ng, app) {
    function lobbyController($scope, lobbyService) {
        this.lobbyService = lobbyService;
        
        $scope.joinGame = ng.bind(this, this.joinGame);
        $scope.refreshGames = ng.bind(this, this.refreshGames);

        $scope.games = [];
        this.scope = $scope;
        this.scope.$parent.$on('gamesAvailable', ng.bind(this, this))
        
        
        return this;
    };

    lobbyController.prototype = {
        
        refreshGames: function () {
            this.lobbyService.checkGames();
        },
        joinGame: function () {
            
        },
        gamesAvailable : function(games) {
            
        }
    };

    app.controller('lobbyController', lobbyController);

})(angular, angular.module('poker'));

//http://sravi-kiran.blogspot.co.uk/2013/09/ABetterWayOfUsingAspNetSignalRWithAngularJs.html