(function () {
    'use strict';
    angular
        .module('FooFightersApp')
        .service('albumsService', albumsService);
    albumsService.$inject = ['$http']; //, '$q', 'configSettings'];
    function albumsService($http) {
        //Read config settings
        //var baseUrl = configSettings.webApiBaseUrl;
        //var baseUrl = 'http://localhost:12730/';
        var baseUrl = 'http://ssnzfoofightersservice.azurewebsites.net/';
        this.getAlbums = function () {
            var url = baseUrl + 'api/Album/GetAlbums';
            console.log(url);
            return $http.get(url);
        };
        this.getAlbum = function (albumCode) {
            var url = baseUrl + 'api/Album/GetAlbum?AlbumCode=' + albumCode;
            console.log(url);
            return $http.get(url);
        };
    }
})();
//# sourceMappingURL=albumsService.js.map