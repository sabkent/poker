(function (app, signalr) {

    function signalrService() {
        this.signalrConnection = signalr;
        this.connect();
    }

    signalrService.prototype = {
        connect: function () {
            this.signalrConnection.hub.start(function () {
                console.log('hub started in sercvice');
            }).fail(function () {
                console.log('hub failed to start');
            });
        },
        getProxy: function (name) {
            return this.signalrConnection[name];
        }
    };

    app.service('signalrService', signalrService);

})(angular.module('poker'), $.connection);