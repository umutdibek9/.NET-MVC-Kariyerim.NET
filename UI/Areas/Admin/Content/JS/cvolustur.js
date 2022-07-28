hideilceTipi();


var alphabet = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"];


$("#yerSayisi").change(() => {
    var selected = $("#yerSayisi").val();
    var str;

    $("#secenekler").empty();
    for (let i = 0; i < parseInt(selected); i++) {
        str =
            `
            <p><textarea  id=`+ i + i + ` rows=" 1"  style="width: 10%;resize:none"></textarea> <p/>
            <p><textarea id=` + i + ` rows=" 4"   style="width: 100%;"></textarea> <p/>
            `;
        $("#secenekler").append(str);
    }
});

$("#_ilankaydet").click(() => {

    var result = {
        YerD: []
    };

    var result2 = {
        YerS: []
    };
    var selected = $("#yerSayisi").val();
    for (var i = 0; i < parseInt(selected); i++) {

        if (!$("#secenekler #" + i + i).val() == "") {
            result2.YerS.push($("#secenekler #" + i + i).val());
        }
        else {

        }

        if (!$("#secenekler #" + i).val() == "")
            result.YerD.push($("#secenekler #" + i).val());
        else {
            alert("Boş şık olamaz!");
            return false
        }
    }
    $("#secenekSonuc").val(JSON.stringify(result));

    $("#secenekSonuc2").val(JSON.stringify(result2));
});
function showsehirTipi() {
    var sehirTipi = $("#sehirTipi :selected").val();
    hideilceTipi();

    if (sehirTipi == "istanbul") {
        $("#ilceTipi").show();
    } else if (sehirTipi == "ankara") {
        $("#ilceTipi2").show();
    }
}

function hideilceTipi() {
    $("#ilceTipi").hide();
    $("#ilceTipi2").hide();
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