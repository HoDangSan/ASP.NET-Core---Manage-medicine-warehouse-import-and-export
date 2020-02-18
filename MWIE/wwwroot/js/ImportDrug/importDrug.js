// Đối tượng thực thi
var importReceipt = importReceipt || {};
var drug = drug || {};
var user = user || {};
var receipt = receipt || {};
// Data

var importdetail = []; // show
// Các table
var drugtable;
var importReceiptTable;
// Tổng giá
var totalPrice = 0;
var userId = 0;

user.DrawUser = function() {
    $.ajax({
        url: "/ImportDrug/GetUser",
        type: "GET",
        dataType: "json",
        success: function(dataRespose) {
            var data = dataRespose.data;
            $("#userName").val(data.lastName + ' ' + data.firstName);
            $("#userAddress").val(data.address);
            $("#userEmail").val(data.email);
            $("#userSex").val(data.sex);
            $("#userPhone").val(data.phone);
            userId = data.id;
        }
    });
};

drug.DrawTable = function() {
    drugtable = $('#table1').DataTable({
        "destroy": true,
        "ajax": {
            "url": "/Drug/ListAll",
            "type": "GET",
            "dataType": "json"

        },
        "columns": [
            { "data": "name" },
            { "data": "unit" },
            { "data": "price" },
            { "data": "dateOfManufacture" },
            { "data": "expriryDate" },
            { "data": "groupDrugName" },
            { "data": "producerName" },
            { "data": "groupDrugId" },
            { "data": "producerId" },
            {
                "defaultContent":
                    '<div style="margin-bottom: 10px; margin-right: 10px"><button style="width: 50px;">Chọn</button></div>'
            }
        ]
    });

    drugtable.columns([7, 8]).visible(false, false);
    drugtable.columns.adjust().draw(false); // điều chỉnh và vẽ lại cột

    $('#table1').on('click',
        'button',
        function() {
            var data = drugtable.row($(this).parents('tr')).data();
            var mess = "#messNumber";
            var date = new Date();
            var time = date.getFullYear() +
                "-" +
                date.getMonth() +
                "-" +
                date.getDate();

            $(mess).empty();
            $(mess).hide();
            $(mess).append(
                '<div style="background-color: rgb(225, 225, 225);padding: 5px"><b>Số lượng nhập vào</b>' +
                '<span id="close" style="border-radius: 3px;-ms-border-radius: 3px;width: 24px; color: #bb0202; position: absolute; cursor: pointer; right: 7px; top: 8px; background-color: #bdbcbc;">' +
                'X' +
                '</span>' +
                '</div>');
            $(mess).append("<div style='text-align:left; padding: 5px;'>Tên thuốc: " +
                data.name +
                "<br>" +
                "Giá mới: <input id='priceDrug' min=1 value='" +
                data.price +
                "' type='number' style='width: 101px;height: 18px;border-radius: 4px;margin-left: 49px;background-color: #eff4f9;'/> &nbsp VNĐ<br />" +
                "Số lượng nhập: <input id='amountDrug' min=1 value='1' type='number' style='width: 70px;height: 18px;border-radius: 4px;margin-left: 5px;background-color: #eff4f9;'/>&ensp;" +
                data.unit +
                "<br />" +
                "Ngày sản xuất: <input id='dateOfManufacture' max='" +
                time +
                "' type='date' style='width: 143px;height: 25px;border-radius: 4px;margin-left: 7px;background-color: #eff4f9;' required/><br />" +
                "Hạn sử dụng: <input id='expriryDate' min='" +
                time +
                "' type='date'  style='width: 143px;height: 25px;border-radius: 4px;margin-left: 15px;background-color: #eff4f9;' required/><br />" +
                "<br>" +
                "<div style='text-align: center'><input id='btnAddToReceipt' type='button' value='Thêm vào phiếu' style='width:121px;margin-top: 13px;border-radius: 3px;'/></div>" +
                "</div>");
            $(mess).show(300);
            $("#close").on('click', function() { $(mess).hide(); });
            $("#btnAddToReceipt").on('click',
                function () {
                    var date_ini = new Date($('#dateOfManufacture').val()).getTime();
                    var date_end = new Date($('#expriryDate').val()).getTime();

                    if (isNaN(date_ini)) {
                        alert("Bạn chưa nhập ngày sản xuất.");
                    } else if (isNaN(date_end)) {
                        alert("bạn chưa nhập hạn sử dụng.")
                    } else if (date_ini >= date_end) {
                        alert("Hạn sử dụng phải lớn hơn ngày sản xuất");
                    } else {
                        // Lấy dữ liệu từ bảng drug 
                        var importdetailObj = {};
                        importdetailObj["id"] = data.id;
                        importdetailObj["name"] = data.name;
                        importdetailObj["price"] = $("#priceDrug").val();
                        importdetailObj["unit"] = data.unit;
                        importdetailObj["dateOfManufacture"] = $("#dateOfManufacture").val();
                        importdetailObj["expriryDate"] = $("#expriryDate").val();
                        importdetailObj["groupDrugId"] = data.groupDrugId;
                        importdetailObj["producerId"] = data.producerId;
                        importdetailObj["amount"] = parseInt($("#amountDrug").val());
                        importdetailObj["totalPrice"] =
                            parseInt(parseInt(importdetailObj["price"]) * parseInt(importdetailObj["amount"]));
                        importdetailObj["isActive"] = true;

                        // thêm 1 sp vào bảng chi tiết
                        var exist = false;
                        for (var i = 0; i < importdetail.length; i++) {
                            if (importdetail[i]["id"] === importdetailObj["id"]) {
                                importdetail[i]["amount"] += importdetailObj["amount"];
                                importdetail[i]["dateOfManufacture"] = $("#dateOfManufacture").val();
                                importdetail[i]["expriryDate"] = $("#expriryDate").val();
                                importdetail[i]["totalPrice"] += importdetailObj["totalPrice"];
                                totalPrice += importdetailObj["totalPrice"];
                                exist = true;
                            }
                        }

                        if (!exist) {
                            totalPrice += importdetailObj["totalPrice"];
                            importdetail.push(importdetailObj);
                        }
                        // Load lai TotalPrice hoa don
                        $("#totalPrice").val(totalPrice.toLocaleString() + " VNĐ");
                        // Load lại table chi tiết
                        importReceipt.DrawTable();
                        $(mess).hide();
                    }
                }
            );
        });
};

receipt.Draw = function() {
    var date = new Date();
    var time = date.getFullYear() +
        "-" +
        ( date.getMonth() + 1) +
        "-" +
        date.getDate() +
        " " +
        date.getHours() +
        ":" +
        date.getMinutes() +
        ":" +
        date.getSeconds();
    $("#dateCreate").val(time);
};

importReceipt.DrawTable = function() {
    importReceiptTable = $("#tableDetail").DataTable({
        "destroy": true, // Có cái này mới reload đc ... 
        "data": importdetail,
        "columns": [
            { "data": "name" },
            { "data": "price" },
            { "data": "expriryDate" },
            { "data": "groupDrugId" },
            { "data": "producerId" },
            { "data": "amount" },
            { "data": "totalPrice" },
            {
                "defaultContent":
                    '<button style="width: 39px;margin: 10px; border-radius:3px; background-color: #cacaca;color: #d40000;cursor: pointer;">Xóa</button>'
            }
        ]
    });
};

$('#tableDetail').on('click',
    'button',
    function() {
        var data = importReceiptTable.row($(this).parents('tr')).data();
        for (var i = 0; i < importdetail.length; i++) {
            if (importdetail[i]["id"] === data.id) {
                totalPrice -= importdetail[i]["totalPrice"];
                $("#totalPrice").val(totalPrice + " VNĐ");
                // Xóa sp trong detail và vẽ lại
                importdetail.splice(i, 1);
                importReceipt.DrawTable();
            }
        }
    }
);

$("#btn-popup-drug").on("click", drug.DrawTable());

drug.initGroupDrug = function() {
    $.ajax({
        url: '/GroupDrug/GetGroupDrugs',
        method: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        success: function(data) {
            $('#addDrugGroupDrugId').empty();
            $.each(data,
                function(index, value) {
                    $('#addDrugGroupDrugId')
                        .append("<option value = " + value.id + ">" + value.name + "</option>");
                });
        }
    });
};

drug.initProducer = function() {
    $.ajax({
        url: '/Producer/GetProducers',
        method: 'GET',
        dataType: 'json',
        contentType: 'application/json',
        success: function(data) {
            $('#addDrugProducerId').empty();
            $.each(data,
                function(index, value) {
                    $('#addDrugProducerId')
                        .append("<option value = " + value.id + ">" + value.name + "</option>");
                });
        }
    });
};

$("#addDrugSaveAndClose").on('click',
    function () {
        var date_ini = new Date($('#addDrugDateOfManufacture').val()).getTime();
        var date_end = new Date($('#addDrugExpriryDate').val()).getTime();

        if (isNaN(date_ini)) {
            alert("Bạn chưa nhập ngày sản xuất.");
        } else if (isNaN(date_end)) {
            alert("bạn chưa nhập hạn sử dụng.")
        } else if (date_ini >= date_end) {
            alert("Hạn sử dụng phải lớn hơn ngày sản xuất");
        } else {
            var drugObj = {}
            drugObj["id"] = 1;
            drugObj["name"] = $("#addDrugName").val();
            drugObj["unit"] = $("#addDrugUnit").val();
            drugObj["amount"] = $("#addDrugAmount").val();
            drugObj["price"] = $("#addDrugPrice").val();
            drugObj["dateOfManufacture"] = $("#addDrugDateOfManufacture").val();
            drugObj["expriryDate"] = $("#addDrugExpriryDate").val();
            drugObj["isActive"] = true;
            drugObj["producerId"] = $("#addDrugProducerId").val();
            drugObj["groupDrugId"] = $("#addDrugGroupDrugId").val();
            drugObj["totalPrice"] =
                parseInt(parseInt(drugObj["price"]) * parseInt(drugObj["amount"]));
            importdetail.push(drugObj);

            totalPrice += drugObj["totalPrice"];
            // Load lai TotalPrice hoa don
            $("#totalPrice").val(totalPrice.toLocaleString() + " VNĐ");
            // Load lại table chi tiết
            importReceipt.DrawTable();
        }
    }
);

$("#createReceiptImport").on('click',
    function() {
        var valid = true;
        if ( $("#idReceipt").val() === "") {
            valid = false;
        }
        
        if (valid){
            var importObj = {};
            importObj["CodeReceipt"] = $("#idReceipt").val();
            importObj["DateCreate"] = $("#dateCreate").val();
            importObj["TotalPrice"] = totalPrice;
            importObj["IsActive"] = true;
            importObj["UserProfileId"] = userId;
            var detailReceiptImports = [];
            for (var i = 0; i < importdetail.length; i++) {
                var obj = {}
                obj["Amount"] = importdetail[i]["amount"];
                obj["TotalPrice"] = importdetail[i]["totalPrice"];
                var objDrug = {}
                objDrug["unit"] = importdetail[i]["unit"];
                objDrug["amount"] = importdetail[i]["amount"];
                objDrug["price"] = importdetail[i]["price"];
                objDrug["name"] = importdetail[i]["name"];
                objDrug["dateOfManufacture"] = importdetail[i]["dateOfManufacture"];
                objDrug["expriryDate"] = importdetail[i]["expriryDate"];
                objDrug["producerId"] = importdetail[i]["producerId"];
                objDrug["groupDrugId"] = importdetail[i]["groupDrugId"];
                objDrug["isActive"] = importdetail[i]["isActive"];
                obj["Drug"] = objDrug;
                detailReceiptImports.push(obj);
            }
    
            importObj["DetailReceiptImports"] = detailReceiptImports;
    
            $.ajax({
                url: "/ImportDrug/CreateReceiptImport",
                type: "POST",
                dataType: "json",
                contentType: 'application/json',
                processData: true,
                cache: false,
                data: JSON.stringify(importObj)
            });
            $("#mess").delay(1000).fadeIn();
            $("#btnmess").on('click',
                function() {
                    $("#mess").hide(500);
                    setTimeout(function(){ location.reload(true); }, 600);
    
                }
            );
        } else {
            var mess2 = $("#mess2");
            
            $("#red").css("color","red");   
            $(mess2).empty();
            $(mess2).append(
                '<div style="background-color: red;padding: 5px"><b>Cảnh báo</b>' +
                '<span id="close" style="border-radius: 3px;-ms-border-radius: 3px;width: 18px; color: black; position: absolute; cursor: pointer; right: 0px; top: 5px; background-color: red;">' +
                'X' +
                '</span>' +
                '</div>');
            $(mess2).append("<div style='text-align:left; padding: 5px;background-color: #cac0c0'>" +
                "Số lô không được để trống" +
                "</div>");
            $(mess2).show(100);
            $("#close").on('click', function() { $(mess2).hide(); });
        }
    }
);

drug.init = function() {
    importReceipt.DrawTable();
    user.DrawUser();
    receipt.Draw();
    $('#addDrugProducerId').select2({
        placeholder: "Tìm nhà cung cấp",
        allowClear: true
    });

    $('#addDrugGroupDrugId').select2({
        placeholder: "Tìm nhóm thuốc",
        allowClear: true
    });

    drug.initGroupDrug();
    drug.initProducer();
};

$(document).ready(function() {
    drug.init();
});