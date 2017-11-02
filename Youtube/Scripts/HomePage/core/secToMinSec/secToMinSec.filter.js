'use strict';

angular.
    module('core').
    filter('secToMinSec', function () {
        return function (input) {
            var minutes = Math.floor(input / 60);
            var seconds = input % 60;
            return minutes + ":" + seconds;
        };
    });
