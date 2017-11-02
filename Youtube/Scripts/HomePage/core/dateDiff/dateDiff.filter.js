'use strict';

angular.
    module('core').
    filter('dateDiff', function () {
        return function (date) {
            var dateDifference = Date.now() - date;
            if (dateDifference > 2 * 31556952000) {
                return Math.floor(dateDifference / 31556952000) + " years ago";
            }
            else if (dateDifference > 31556952000) {
                return "1 year ago";
            }
            else if (dateDifference > 2 * 2629746000) {
                return Math.floor(dateDifference % 31556952000 / 2629746000) + " months ago";
            }
            else if (dateDifference > 2629746000) {
                return "1 month ago";
            }
            else if (dateDifference > 2 * 604800000) {
                return Math.floor(dateDifference % 31556952000 % 2629746000 / 604800000) + " weeks ago";
            }
            else if (dateDifference > 604800000) {
                return "1 week ago";
            }
            else if (dateDifference > 2 * 86400000) {
                return Math.floor(dateDifference % 31556952000 % 2629746000 % 604800000 / 86400000) + " days ago";
            }
            else if (dateDifference > 86400000) {
                return "1 day ago";
            }
            else if (dateDifference > 2 * 3600000) {
                return Math.floor(dateDifference % 31556952000 % 2629746000 % 604800000 % 86400000 / 3600000) + " hours ago";
            }
            else if (dateDifference > 3600000) {
                return "1 hour ago";
            }
            else if (dateDifference > 2 * 60000) {
                return Math.floor(dateDifference % 31556952000 % 2629746000 % 604800000 % 86400000 % 3600000 / 60000) + " minutes ago";
            }
            else if (dateDifference > 60000) {
                return "1 minute ago";
            }
            else if (dateDifference > 2 * 1000) {
                return Math.floor(dateDifference % 31556952000 % 2629746000 % 604800000 % 86400000 % 3600000 % 60000 / 1000) + " seconds ago";
            }
            else {
                return "1 second ago";
            }
        };
    });
