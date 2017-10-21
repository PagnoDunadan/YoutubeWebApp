'use strict';

// Register `recommendedVideoList` component, along with its associated controller and template
angular.
    module('recommendedVideoList').
    component('recommendedVideoList', {
        // Note: The URL is relative to our `index.html` file
        templateUrl: '../Scripts/HomePage/recommended-video-list/recommended-video-list.template.html',
        controller: ['$http', function RecommendedVideoListController($http) {
            var self = this;

            document.title = "Youtube - Recommended";

            $http.get('/videos').then(function (response) {
                console.log(response);
                self.videos = response.data;
            });
            $http.get('/playlists').then(function (response) {
                console.log(response);
                self.playlists = response.data;
            });
        }]
    });
