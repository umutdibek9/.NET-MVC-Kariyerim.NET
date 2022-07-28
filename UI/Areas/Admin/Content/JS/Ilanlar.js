hideTable();

$("#id").click(() => {

    
        alert("İlan siliniyor");
        

});

function hideTable() {

    $("#myTable").show();
    $("#myTable2").hide();
    $("#myTable3").hide();

    $("#myTable4").hide();

    $("#myTable5").hide();


}
$("#aktif").click(() => {
    $("#myTable").show();
    $("#myTable2").hide();
    $("#myTable3").hide();

    $("#myTable4").hide();

    $("#myTable5").hide();


});

$("#kaldirilmis").click(() => {
    $("#myTable2").show();
    $("#myTable").hide();
    $("#myTable3").hide();

    $("#myTable4").hide();

    $("#myTable5").hide();

});


$(document).ready(function () {

    $('.nav-link').on("click", function () {

        $('.nav-link').removeClass('active');

        $(this).addClass('active');
    });
});