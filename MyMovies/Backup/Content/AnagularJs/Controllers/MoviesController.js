Controllers.controller("MoviesController", ['$scope', 'MyMovieService', function ($scope, MyMovieService) {

    if (window.location.href.indexOf("ManageMovies") > -1 || window.location.href.indexOf("AllMovies") > -1) {
        loadMovies();
    }

    $scope.movie = "";
    $scope.movies = [];

    function loadMovies() {
        MyMovieService.getMovies().then(function (response) {
            $scope.movies = response.data;
            if ($scope.movies.length == 0 && window.location.href.indexOf("AllMovies") > -1) {
                $scope.msg = "There are no movies in the database please add it from the manage movie pages";
            }
        });
    }

    if (GetQueryStringByParameter("Id") != (null || "")) {
        MyMovieService.getMovie(GetQueryStringByParameter("Id")).then(function (response) {
            $scope.movie = response.data;
        });
    }
    else if (GetQueryStringByParameter("movieId") != (null || "")) {
        MyMovieService.getMovie(GetQueryStringByParameter("movieId")).then(function (response) {
            $scope.movie = response.data;
        });
    }

    var formdata = new FormData();
    $scope.getTheFiles = function ($files) {
        angular.forEach($files, function (value, key) {
            formdata.append(key, value);
            $scope.movie.imagesrc = value.name;
        });
    };

    $scope.InsertMovie = function () {
        MyMovieService.saveMovie($scope.movie).then(function (response) {
            redirect(response);
            MyMovieService.uploadFile(formdata).then(function (innerResponse) {

            });
        });
    }

    $scope.updateMovie = function () {
       
        MyMovieService.updateMovie($scope.movie).then(function (response) {
            redirect(response);
            MyMovieService.uploadFile(formdata).then(function (innerResponse) {
            });
        });
    }

    $scope.deleteMovie = function () {
        MyMovieService.deleteMovie($scope.movie).then(function (response) {
            redirect(response);
        });
    }

    $scope.cancel = function () {
        window.location.href = "/Html/index.html#/ManageMovies";
    }

    function redirect(response) {
        if (response.data = "true") {
            alert("Operation Successfull");
            window.location.href = "/Html/index.html#/ManageMovies";
        }
        else {
            alert("Operation not Successfull");
            window.location.href = "/Html/index.html#/ManageMovies";
        }
    }

    $("#file1").click(function () {

    });
    
    // Give the Querystring value using Javascript 
    function GetQueryStringByParameter(name) {
        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location);
        return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    }

    $scope.review = "";

}]);