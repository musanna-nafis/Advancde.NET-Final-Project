app.controller("create",function($scope,ajax){
  $scope.submit=function(){
    
    ajax.post("https://localhost:44388/api/financemanager/leaverequest/new/1",$scope.post,success,error);
    function success(response){
 
              alert("Added");     
    }
    function error(error){
       
              alert("Error!");
    }
};

});