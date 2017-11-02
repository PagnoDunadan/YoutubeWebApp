'use strict';

angular.
    module('core').
    filter('textLength', function () {
        return function (input, length) {
            if (input.length > length) {
                var trimmedString = input.substr(0, length);
                trimmedString = trimmedString.substr(0, Math.min(trimmedString.length, trimmedString.lastIndexOf(" ")))
                return trimmedString + " ...";
            }
            else return input;
        };
    });
