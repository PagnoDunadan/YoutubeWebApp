'use strict';

angular.
    module('searchVideoList').
    component('searchVideoList', {
        templateUrl: '../Scripts/HomePage/search-video-list/search-video-list.template.html',
        controller: ['$http', '$routeParams', '$location', function SearchVideoListController($http, $routeParams, $location) {
            var self = this;

            self.searchExpression = $routeParams.SearchQuery ? $routeParams.SearchQuery : "";
            self.playlistExpression = $routeParams.PlaylistID ? $routeParams.PlaylistID : "";
            self.videoInPlaylists = new Array();
            self.videoNotInPlaylists = new Array();

            if (self.playlistExpression) {
                $http.get('/playlists/videosfor/' + self.playlistExpression).then(function (response) {
                    self.videos = response.data;
                });

                $http.get('/playlists').then(function (response) {
                    document.title = response.data[self.playlistExpression - 1].PlaylistName + " - Youtube";
                    self.playlists = response.data;
                });
            }
            else {
                document.title = self.searchExpression ? (self.searchExpression + " - Youtube") : "Youtube";

                $http.get('/search/' + (self.searchExpression ? self.searchExpression : "undefined")).then(function (response) {
                    self.videos = response.data;
                });

                $http.get('/playlists').then(function (response) {
                    self.playlists = response.data;
                });
            }

            self.search = function search() {
                $location.path('/search/' + self.searchExpression);
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

                $http.post('/videos/edit/' + ID, editVideo).then(function (response) {
                });
            };

            self.getPlaylistsForVideo = function getPlaylistsForVideo(VideoID) {
                $http.get('/Videos/PlaylistsFor/' + VideoID).then(function (response) {
                    var diff = self.playlists;

                    for (var i = 0; i < response.data.length; i++) {
                        diff = diff.filter(function (el) {
                            return el.PlaylistID !== response.data[i].PlaylistID;
                        });
                    }

                    self.videoInPlaylists[VideoID] = response.data;
                    self.videoNotInPlaylists[VideoID] = diff;
                });
            };

            self.addVideoPlaylist = function updateVideoPlaylist(video, playlist) {
                if (playlist != undefined) {
                    $http.post('/Videos/PlaylistAdd/' + video.VideoID, playlist).then(function (response) {
                        var diff = self.playlists;

                        for (var i = 0; i < response.data.length; i++) {
                            diff = diff.filter(function (el) {
                                return el.PlaylistID !== response.data[i].PlaylistID;
                            });
                        }

                        self.videoInPlaylists[video.VideoID] = response.data;
                        self.videoNotInPlaylists[video.VideoID] = diff;
                    });
                };
            };

            self.deleteVideoPlaylist = function deleteVideoPlaylist(video, playlist) {
                $http.post('/Videos/PlaylistDelete/' + video.VideoID, playlist).then(function (response) {
                    var diff = self.playlists;

                    for (var i = 0; i < response.data.length; i++) {
                        diff = diff.filter(function (el) {
                            return el.PlaylistID !== response.data[i].PlaylistID;
                        });
                    }

                    self.videoInPlaylists[video.VideoID] = response.data;
                    self.videoNotInPlaylists[video.VideoID] = diff;
                });
            };

            self.createPlaylist = function createPlaylist(name) {
                var playlist = {
                    PlaylistName: name,
                }
                $http.post('/playlists/create/', playlist).then(function (response) {
                    self.playlists.push(response.data);
                });
            };

            self.updatePlaylist = function updatePlaylist(ID, name) {
                var playlist = {
                    PlaylistID: ID,
                    PlaylistName: name,
                }
                $http.post('/playlists/edit/' + ID, playlist).then(function (response) {
                    for (var i = 0; i < self.playlists.length; i++) {
                        if (self.playlists[i].PlaylistID == response.data.PlaylistID) {
                            self.playlists[i].PlaylistName = response.data.PlaylistName;
                            break;
                        }
                    }
                });
            };

            self.deletePlaylist = function deletePlaylist(PlaylistID) {
                $http.post('/playlists/delete/' + PlaylistID).then(function (response) {
                    self.playlists = self.playlists.filter(function (el) {
                        return el.PlaylistID !== response.data;
                    });
                });
            };
        }]
    });
