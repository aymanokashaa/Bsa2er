function showForm(event) {
    if (event.target.value =="")
       {
        $("#myi").show();
        document.getElementById("quali").name = "";
        document.getElementById("copyquali").name = "Qualifications";
       }
       else
       {
        $("#myi").hide();
        document.getElementById("quali").name = "Qualifications";
        document.getElementById("copyquali").name = "";
    }  
             }
