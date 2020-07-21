$("#myi").hide();
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
        $("#selectlist").empty().append(`<option selected="selected" value="${x}">اخر</option>`);

    }

}