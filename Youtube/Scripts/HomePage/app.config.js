'use strict';

angular.
    module('youtubeApp').
    config(['$locationProvider', '$routeProvider',
        function config($locationProvider, $routeProvider) {
            $locationProvider.hashPrefix('!');

            $routeProvider.
                when('/playlists/:PlaylistID', {
                    template: '<playlist-video-list></playlist-video-list>'
                }).
                when('/search/:SearchQuery', {
                    template: '<search-video-list></search-video-list>'
                }).
                when('/recommended', {
                    template: '<recommended-video-list></recommended-video-list>'
                }).
                otherwise('/recommended');
        }
    ]);
