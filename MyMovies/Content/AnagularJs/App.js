/// <reference path="Libraries/angular.js" />
/// <reference path="Libraries/angular-route.js" />


'use strict';

// declare modules
var directives = angular.module("MyMovies.directives", []);

var services = angular.module("MyMovies.services", []);
var Controllers = angular.module('MyMovies.controllers', ['MyMovies.services']);
var MyMovies = angular.module("MyMovies", ['MyMovies.directives', 'MyMovies.services', 'MyMovies.controllers', 'ngRoute', function () {
}]);

MyMovies.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when("/AllMovies", {
        templateUrl: "/Html/viewAllMovies.html",
        controller: "MoviesController"
    }).
    when("/mainPage", {
        templateUrl: "/Html/mainPage.html",
    }).
    when("/ManageMovies", {
        templateUrl: "/Html/manageMovies.html",
        controller: "MoviesController"
    }).
    when("/updateMovie", {
        templateUrl: "/Html/updateMovie.html",
        controller: "MoviesController"
    }).
    when("/updateMovie/:id", {
        templateUrl: "/Html/updateMovie.html",
        controller: "MoviesController"
    }).
    when("/createNewMovie", {
        templateUrl: "/Html/createNewMovie.html",
        controller: "MoviesController"
    }).
    when("/deleteMovie", {
        templateUrl: "/Html/deleteMovie.html",
        controller: "MoviesController"
    }).
    when("/deleteMovie/:id", {
        templateUrl: "/Html/deleteMovie.html",
        controller: "MoviesController"
    }).
    when("/reviewMovie.html", {
        templateUrl: "/Html/reviewMovie.html",
        controller: "MoviesController"
    }).
    when("/reviewMovie.html/:movieid", {
        templateUrl: "/Html/reviewMovie.html",
        controller: "MoviesController"
    })


}]);