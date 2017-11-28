'use strict';

angular.
    module('playVideo').
    component('playVideo', {
        templateUrl: '../Scripts/HomePage/play-video/play-video.template.html',
        controller: ['$http', '$routeParams', '$location', '$sce', function PlayVideoController($http, $routeParams, $location, $sce) {
            var self = this;

            document.title = "Youtube - Play Video";

            $http.get('/videos/find/' + $routeParams.VideoID).then(function (response) {
                console.log(response);
                self.video = response.data;
                document.title = self.video.VideoTitle + " - Youtube";
                self.video.VideoUrl = $sce.trustAsResourceUrl(self.video.VideoUrl.replace("watch?v=", "embed/"));
            });

            $http.get('/videos/').then(function (response) {
                self.videos = response.data;
            });

            $http.get('/playlists').then(function (response) {
                self.playlists = response.data;
            });

            self.search = function search() {
                $location.path('/search/' + self.searchExpression ? self.searchExpression : "");
            };
        }]
    });
