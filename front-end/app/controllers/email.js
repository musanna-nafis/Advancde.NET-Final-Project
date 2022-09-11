app.controller("email",function($scope,ajax){
    $scope.submit=function(){
      
      ajax.post("https://localhost:44388/api/financemanager/sendemail",$scope.post,success,error);
      function success(response){
   
                alert("Email Sent");     
      }
      function error(error){
         
                alert("Error!");
      }
  };

});