services.service("MyMovieService", ['$http', function ($http) {

    this.getMovies = function () {
        return $http({
            method: 'Get',
            url: "/API/Movies",
        });
    }

    this.saveMovie = function (movie) {
        return $http({
            method: 'POST',
            url: "/API/Movies",
            data: movie
        });
    }

    this.getMovie = function (Id) {
        return $http({
            method: 'Get',
            url: "/API/Movies/" + Id,
        });
    }

    this.updateMovie = function (movie) {
        return $http({
            method: 'PUT',
            url: "/API/Movies/" + movie.id,
            data: movie
        });
    }

    this.deleteMovie = function (movie) {
        return $http({
            method: 'Delete',
            url: "/API/Movies/" + movie.id,
            data: movie
        });
    }

    this.uploadFile = function (formdata) {
        var request = {
            method: 'POST',
            url: '/api/FileUpload/',
            data: formdata,
            headers: {
                'Content-Type': undefined
            }
        };
        // SEND THE FILES.
        $http(request)
            .success(function (d) {
            })
            .error(function () {
            });
    }
    //this.uploadFileToUrl = function (file, uploadUrl) {
    //    var fd = new FormData();
    //    fd.append('file', file);

    //    $http.post(uploadUrl, fd, {
    //        transformRequest: angular.identity,
    //        headers: { 'Content-Type': undefined }
    //    })

    //    .success(function (d) {
    //        alert(d)
    //    })

    //    .error(function () {
    //    });
    //}

}]);