app.controller("get",function($scope,$http,$routeParams){
    $http.get("https://localhost:44388/api/financemanager/leaverequest/"+$routeParams.id).
   
  then(function(resp){
    $scope.post = resp.data;
  });
  
});