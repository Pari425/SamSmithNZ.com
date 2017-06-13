(function () {
    'use strict';
    angular
        .module('SteamApp')
        .controller('layoutController', layoutController);
    layoutController.$inject = ['$scope', '$http', 'friendsService', 'playerService'];
    function layoutController($scope, $http, friendsService, playerService) {
        //console.log("here!");
        $scope.friends = [];
        var onError = function (data) {
            //errorHandlerService.errorHandler(data);
            console.log("Error!!");
            console.log(data);
        };
        var onGetFriendsEventComplete = function (response) {
            $scope.friends = response.data;
        };
        var onGetPlayerEventComplete = function (response) {
            $scope.player = response.data;
        };
        var steamId = getUrlParameter('SteamId');
        if (steamId == '' || steamId == null) {
            steamId = '76561197971691578';
            //console.log("Steam Id not found");
        }
        friendsService.getFriends(steamId).then(onGetFriendsEventComplete, onError);
        playerService.getPlayer(steamId).then(onGetPlayerEventComplete, onError);
    }
    function getUrlParameter(param) {
        var sPageURL = (window.location.search.substring(1));
        var sURLVariables = sPageURL.split(/[&||?]/);
        var res;
        for (var i = 0; i < sURLVariables.length; i += 1) {
            var paramName = sURLVariables[i], sParameterName = (paramName || '').split('=');
            //console.log(sParameterName[0].toLowerCase() + ' : ' + param.toLowerCase());
            if (sParameterName[0].toLowerCase() === param.toLowerCase()) {
                res = sParameterName[1];
                //console.log(sParameterName[0] + ' : ' + sParameterName[1]);
            }
        }
        return res;
    }
})();
//# sourceMappingURL=layoutController.js.map