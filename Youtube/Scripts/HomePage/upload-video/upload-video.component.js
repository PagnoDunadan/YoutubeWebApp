'use strict';

angular.
    module('uploadVideo').
    component('uploadVideo', {
        templateUrl: '../Scripts/HomePage/upload-video/upload-video.template.html',
        controller: ['$http', '$routeParams', '$location', function UploadVideoController($http, $routeParams, $location) {
            var self = this;

            document.title = "Youtube - Upload";

            self.search = function search() {
                $location.path('/search/' + self.searchExpression ? self.searchExpression : "");
            };

            self.upload = function upload() {
                var newVideoUploadDateJson = new Date(self.newVideoUploadDate);
                var newVideo = {
                    VideoTitle: self.newVideoTitle,
                    VideoUrl: self.newVideoUrl,
                    VideoUploader: self.newVideoUploader,
                    VideoUploadDate: newVideoUploadDateJson,
                    VideoViews: self.newVideoViews,
                    VideoDuration: self.newVideoDuration,
                    VideoThumbnail: self.newVideoThumbnail,
                    VideoDescription: self.newVideoDescription
                }
                console.log(newVideo);
                $http.post('/videos/create', newVideo).then(function (response) {
                    console.log(response);
                    if (response.data == "Success!") {
                        $location.path('/recommended');
                    }
                });
            };
        }]
    });
