'use strict';

// Register `searchVideoList` component, along with its associated controller and template
angular.
    module('searchVideoList').
    component('searchVideoList', {
        // Note: The URL is relative to our `index.html` file
        templateUrl: '../Scripts/HomePage/search-video-list/search-video-list.template.html',
        controller: ['$http', '$routeParams', '$location', function SearchVideoListController($http, $routeParams, $location) {
            var self = this;

            document.title = "Youtube - Search";

            self.searchExpression = $routeParams.SearchQuery;

            self.videoInPlaylists = new Array();
            self.videoNotInPlaylists = new Array();

            self.search = function search() {
                $location.path('/search/'+self.searchExpression);
            };

            self.editVideo = function editVideo(ID, Title, Url, Uploader, UploadDate, Views, Duration, Thumbnail, Description) {
                //var editVideoUploadDateJson = new Date("01.01.1970. 00:00:00");
                var editVideoUploadDateJson = new Date(UploadDate);
                var editVideo = {
                    VideoID: ID,
                    VideoTitle: Title,
                    VideoUrl: Url,
                    VideoUploader: Uploader,
                    VideoUploadDate: editVideoUploadDateJson,
                    VideoViews: Views,
                    VideoDuration: Duration,
                    VideoThumbnail: Thumbnail,
                    VideoDescription: Description
                }
                console.log(editVideo);
                $http.post('/videos/edit/'+ID, editVideo).then(function (response) {
                    console.log(response);
                });
            };

            self.addVideoPlaylist = function updateVideoPlaylist(video, playlist) {
                if (playlist != undefined) {
                    console.log(video);
                    console.log(playlist);
                    $http.post('/Videos/PlaylistAdd/' + video.VideoID, playlist).then(function (response) {
                        console.log(response);
                        var diff = self.playlists;

                        for (var i = 0; i < response.data.length; i++) {
                            diff = diff.filter(function (el) {
                                return el.PlaylistID !== response.data[i].PlaylistID;
                            });
                        }

                        console.log(diff);
                        self.videoInPlaylists[video.VideoID] = response.data;
                        self.videoNotInPlaylists[video.VideoID] = diff;
                        //self.izlets.push(response.data);
                    });
                };
            };

            self.deleteVideoPlaylist = function deleteVideoPlaylist(video, playlist) {
                console.log(video);
                console.log(playlist);
                $http.post('/Videos/PlaylistDelete/' + video.VideoID, playlist).then(function (response) {
                    console.log(response);
                    var diff = self.playlists;

                    for (var i = 0; i < response.data.length; i++) {
                        diff = diff.filter(function (el) {
                            return el.PlaylistID !== response.data[i].PlaylistID;
                        });
                    }

                    console.log(diff);
                    self.videoInPlaylists[video.VideoID] = response.data;
                    self.videoNotInPlaylists[video.VideoID] = diff;
                    //self.izlets.push(response.data);
                });
            };

            self.getPlaylistsForVideo = function getPlaylistsForVideo(VideoID) {
                $http.get('/Videos/PlaylistsFor/' + VideoID).then(function (response) {
                    console.log(response.data);
                    console.log(self.playlists);
                    var diff = self.playlists;

                    for (var i = 0; i < response.data.length; i++) {
                        diff = diff.filter(function (el) {
                            return el.PlaylistID !== response.data[i].PlaylistID;
                        });
                    }

                    console.log(diff);
                    self.videoInPlaylists[VideoID] = response.data;
                    self.videoNotInPlaylists[VideoID] = diff;
                });
            };

            $http.get('/search/'+$routeParams.SearchQuery).then(function (response) {
                console.log(response);
                self.videos = response.data;
            });
            $http.get('/playlists').then(function (response) {
                console.log(response);
                self.playlists = response.data;
            });
        }]
    });
