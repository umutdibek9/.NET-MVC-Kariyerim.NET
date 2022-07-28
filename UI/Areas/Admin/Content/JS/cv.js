hideTable();
$("#_ilankaydet").click(() => {

    var sehirTipi = $("#sehirTipi :selected").val();
    setRequires(sehirTipi);

    if (!isAllowedFileType()) {
        alert("Hatalı resim tipi girdiniz! Girebileceğiniz resim tipleri:\n.png, .jpg, .jpeg");
        return false;
    }
    var result = {
        YerS: []
    };

    var result2 = {
        YerD: []
    };
    var selected = $("#yerSayisi").val();
    for (var i = 0; i < parseInt(selected); i++) {

        if (!$("#secenekler #" + i + i).val() == "") {
            result2.YerD.push($("#secenekler #" + i + i).val());
        }
        else {

        }

        if (!$("#secenekler #" + i).val() == "")
            result.YerS.push($("#secenekler #" + i).val());
        else {
            alert("Boş şık olamaz!");
            return false
        }
    }
    $("#secenekSonuc").val(JSON.stringify(result));

    $("#secenekSonuc2").val(JSON.stringify(result2));
});
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