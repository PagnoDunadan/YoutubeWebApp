'use strict';

// Register `playlistVideoList` component, along with its associated controller and template
angular.
    module('playlistVideoList').
    component('playlistVideoList', {
        // Note: The URL is relative to our `index.html` file
        templateUrl: '../Scripts/HomePage/playlist-video-list/playlist-video-list.template.html',
        controller: ['$http', function PlaylistVideoListController($http) {
            var self = this;

            document.title = "Youtube - Videos";

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
