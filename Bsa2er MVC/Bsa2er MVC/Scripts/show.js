<<<<<<< HEAD
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
=======
﻿$("#myi").hide();
function showForm(event) {
    if (event.target.value == "3")
       {
        $("#myi").show();
        
 
       }
       else
       {
          $("#myi").hide();
       }
} 

////////code for qualifications
function changeselectvalue() {

    if ($("#selectlist").val() == "3") {
        var x = $("#textinput").val();
        console.log(x);
        $("#selectlist").empty().append(`<option selected="selected" value="${x}">اخري</option>`);

    }

}
>>>>>>> e0abc7c2adf31cd335a69456af0cfb6d4c5da870
