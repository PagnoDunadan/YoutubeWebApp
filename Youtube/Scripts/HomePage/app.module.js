'use strict';

// Define the `youtubeApp` module
angular.module('youtubeApp', [
    'ngRoute',
    'core',
    'uploadVideo',
    // ...which depends on the `playlistVideoList` module
    'playlistVideoList',
    'searchVideoList',
    'recommendedVideoList'
]);
