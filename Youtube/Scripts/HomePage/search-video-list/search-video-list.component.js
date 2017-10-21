'use strict';

// Register `searchVideoList` component, along with its associated controller and template
angular.
    module('searchVideoList').
    component('searchVideoList', {
        // Note: The URL is relative to our `index.html` file
        templateUrl: '../Scripts/HomePage/search-video-list/search-video-list.template.html',
        controller: ['$http', function SearchVideoListController($http) {
            var self = this;

            document.title = "Youtube - Search";

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
