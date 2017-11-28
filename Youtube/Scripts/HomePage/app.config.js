'use strict';

angular.
    module('youtubeApp').
    config(['$locationProvider', '$routeProvider',
        function config($locationProvider, $routeProvider) {
            $locationProvider.hashPrefix('!');

            $routeProvider.
                when('/videos/:VideoID', {
                    template: '<play-video></play-video>'
                }).
                when('/playlists/:PlaylistID', {
                    template: '<search-video-list></search-video-list>'
                }).
                when('/search/:SearchQuery', {
                    template: '<search-video-list></search-video-list>'
                }).
                when('/search/', {
                    template: '<search-video-list></search-video-list>'
                }).
                when('/upload', {
                    template: '<upload-video></upload-video>'
                }).
                otherwise('/search/');
        }
    ]);
