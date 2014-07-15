(function (app, signalr) {

    function signalrService($rootScope, $q) {
        this.rootScope = $rootScope;
        this.q = $q;
        this.signalrConnection = signalr;
        this.connected = false;
    }

    signalrService.prototype = {
        connect: function () {
            var deferred = this.q.defer();
            var self = this;
            this.signalrConnection.hub.start().done(function () {
                deferred.resolve(self.signalrConnection);
            });

            return deferred.promise;
        },
        getProxy: function (name) {
            var deferred = this.q.defer();
            var self = this;
            this.signalrConnection[name].client._fakeHandler = function () { }; //before calling start you need at least one sub http://www.asp.net/signalr/overview/signalr-20/hubs-api/hubs-api-guide-javascript-client
            this.connect().then(function () {
                deferred.resolve(self.signalrConnection[name]);
            });
            return deferred.promise;
        }
    };

    app.service('signalrService', signalrService);

})(angular.module('poker'), $.connection);