﻿(function () {
    'use strict';

    angular
        .module('MandMCounterApp')
        .service('mandMCounterService', mandMCounterService);
    mandMCounterService.$inject = ['$http'];

    function mandMCounterService($http) {//, $q, configSettings) {
        //Read config settings
        //var baseUrl = configSettings.webApiBaseUrl;
        var baseUrl = 'https://mandmcounterservice.azurewebsites.net/';

        this.getDataForUnit = function (unit, quantity) {
            let url: string = baseUrl + 'api/MandMCounter/GetDataForUnit?unit=' + unit + '&quantity=' + quantity;
            //console.log(url);
            return $http.get(url);
        };

        this.getDataForRectangle = function (unit, height, width, length) {
            let url: string = baseUrl + 'api/MandMCounter/GetDataForRectangle?unit=' + unit + '&height=' + height + '&width=' + width + '&length=' + length;
            console.log(url);
            return $http.get(url);
        };

        this.getDataForCylinder = function (unit, height, radius) {
            let url: string = baseUrl + 'api/MandMCounter/GetDataForCylinder?unit=' + unit + '&height=' + height + '&radius=' + radius;
            console.log(url);
            return $http.get(url);
        };

    }
})();