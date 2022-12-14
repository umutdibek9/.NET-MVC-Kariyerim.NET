

showsehirTipi()
hideimg()
function hideimg() {
    $("#x").hide();
}

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#blah').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}

$("#imgInp").change(function () {
    readURL(this);
    $("#x").show();
});

$("#_ilankaydet").click(() => {

    var sehirTipi = $("#sehirTipi :selected").val();
    setRequires(sehirTipi);

    if (!isAllowedFileType()) {
        alert("Hatalı resim tipi girdiniz! Girebileceğiniz resim tipleri:\n.png, .jpg, .jpeg");
        return false;
    }

});
function showsehirTipi() {
    var sehirTipi = $("#sehirTipi :selected").val();

        if (sehirTipi == "istanbul") {
            $("#ilceTipi").show();
            $("#ilceTipi2").hide();
        } else if (sehirTipi == "ankara") {
            $("#ilceTipi2").show();
            $("#ilceTipi").hide();
    }

}




function isAllowedFileType() {
    var fileInput = document.getElementById("fileInput");
    if (fileInput.files.length == 0) return true;
    var filePath = fileInput.value;
    var result = false;

    var allowedExtensions = [".jpg", ".jpeg", ".png"];

    allowedExtensions.forEach(element => {
        var patt = new RegExp(element);
        if (patt.exec(filePath) !== null) result = true;
    });

    return result;
}

function setRequires(sehirTipi) {
    $("#myselect2").attr("required", false);
    $("#myselect3").attr("required", false);

    if (sehirTipi == "istanbul") {
        $("#myselect2").attr("required", true);
    }
    if (sehirTipi == "ankara") {
        $("#myselect3").attr("required", true);
    }
}