var app = angular.module("myApp", ["ngRoute"]);
app.config(["$routeProvider","$locationProvider",function($routeProvider,$locationProvider) {

    $routeProvider
    
    .when("/get/:id", {
        templateUrl : "views/pages/get.html",
        controller: 'get'
    })
    
    .when("/create/", {
        templateUrl : "views/pages/create.html",
        controller: 'create'
    })
    .when("/email", {
        templateUrl : "views/pages/email.html",
        controller: 'email'
    })
   
    .otherwise({
        redirectTo:"/"
    });
      //$locationProvider.html5Mode(true);
      //$locationProvider.hashPrefix('');
      //if(window.history && window.history.pushState){
      //$locationProvider.html5Mode(true);
  //}

}]);
