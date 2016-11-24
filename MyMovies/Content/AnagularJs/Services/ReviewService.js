services.service("ReviewService", ['$http', function ($http) {

    this.getReview = function (movieid) {
        return $http({
            method: 'Get',
            url: "/api/Review/" + movieid,
        });
    }

    this.saveReview = function (review) {
        return $http({
            method: 'POST',
            url: "/api/Review",
            data: review
        });
    }

}]);