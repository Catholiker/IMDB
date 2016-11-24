Controllers.controller("ReviewController", ['$scope', 'ReviewService', function ($scope, ReviewService) {

    $scope.review = "";

    if (GetQueryStringByParameter("movieid") != (null || "")) {
        ReviewService.getReview(GetQueryStringByParameter("movieid")).then(function (response) {
            if (response.data != (null || "")) {
                $scope.review = response.data;
                //$('element').each(function () {
                //    $('input[type=radio]', this).get(3).checked = true;
                //});
            }
            $scope.review.movieId = GetQueryStringByParameter("movieid");
        });
    }

    $scope.saveReview = function () {
        console.log($scope.review.rating);
        ReviewService.saveReview($scope.review).then(function (response) {
            redirect(response);
        });
    }

    $scope.cancel = function () {
        window.location.href = "/Html/index.html#/AllMovies";
    }

    function redirect(response) {
        if (response.data = "true") {
            window.location.href = "/Html/index.html#/AllMovies";
            alert("Operation Successfully");
        }
        else {
            alert("Operation not Successfully");
        }
    }

    // Give the Querystring value using Javascript 
    function GetQueryStringByParameter(name) {
        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location);
        return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    }

    $('.radio').change(
           function () {
               $(".reviewrating").val(this.value);
               $scope.review.rating = this.value;
           }
         );
       
}]);