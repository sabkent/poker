(function (ng, app) {

    function gameController($scope) {
        this.scope = $scope;
        $scope.bet = 0;

        this.scope.placeBet = ng.bind(this, this.placeBet);
    };

    gameController.prototype = {
       placeBet : function() {
           console.log('place bet ' + this.scope.bet);
       }
    };

    app.controller('gameController', gameController);

})(angular, angular.module('poker'));