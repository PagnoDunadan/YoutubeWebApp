'use strict';

// Define the `youtubeApp` module
angular.module('youtubeApp', [
    'ngRoute',
    // ...which depends on the `playlistVideoList` module
    'playlistVideoList',
    'searchVideoList',
    'recommendedVideoList'
]);
