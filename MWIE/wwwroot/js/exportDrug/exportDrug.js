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
            { "data": "amount" },
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

    drugtable.columns([8, 9]).visible(false, false);
    drugtable.columns.adjust().draw(false); // điều chỉnh và vẽ lại cột
    $("#table1").on('click','input', function () {
        var data = drugtable.row($(this).parents('tr')).data();
        $.ajax({
            url: "/Drug/DeleteDrug/"+data.id,
            type: "DELETE",
            dataType: 'json',
            contentType: 'application/json'
        });
        drug.DrawTable();
    });
    $("#table1").on('click',
        'button',
        function() {
            var data = drugtable.row($(this).parents('tr')).data();
            var mess = "#messNumber";
            var date = new Date();
            var time = date.getFullYear() +
                "-" +
                date.getMonth() +
                "-" +
                date.getDay();

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
                "Giá" + data.price +
                "<br>Ngày sản xuất: "+ data.dateOfManufacture +
                "<br>Hạn sử dụng: " + data.expriryDate +
                "<br>Số lượng xuất ra: <input id='amountDrug' min=1 max='"+ data.amount +"' value='"+data.amount+"' type='number' style='width: 70px;height: 18px;border-radius: 4px;margin-left: 5px;background-color: #eff4f9;'/>&ensp;" +
                data.unit +
                "<br />" +
                "<div style='text-align: center'><input id='btnAddToReceipt' type='button' value='Thêm vào phiếu' style='width:121px;margin-top: 13px;border-radius: 3px;'/></div>" +
                "</div>");
            $(mess).show(300);
            $("#close").on('click', function() { $(mess).hide(); });
            $("#btnAddToReceipt").on('click',
                function() {
                    // Lấy dữ liệu từ bảng drug 
                    var importdetailObj = {};
                    importdetailObj["id"] = data.id;
                    importdetailObj["name"] = data.name;
                    importdetailObj["price"] = data.price;
                    importdetailObj["unit"] = data.unit;
                    importdetailObj["dateOfManufacture"] = data.dateOfManufacture;
                    importdetailObj["expriryDate"] = data.expriryDate;
                    importdetailObj["groupDrugId"] = data.groupDrugId;
                    importdetailObj["producerId"] = data.producerId;
                    importdetailObj["amount"] = parseInt($("#amountDrug").val());
                    importdetailObj["totalPrice"] = parseInt(parseInt(importdetailObj["price"]) * parseInt(importdetailObj["amount"]));
                    importdetailObj["isActive"] = true;
                    
                    // thêm 1 sp vào bảng chi tiết
                    var exist = true;
                    for (var i = 0; i < importdetail.length; i++) {
                        if (importdetail[i]["id"] === importdetailObj["id"]) {
                            importdetail[i]["amount"] += importdetailObj["amount"];
                            importdetail[i]["totalPrice"] += importdetailObj["totalPrice"];
                            totalPrice += importdetailObj["totalPrice"];
                            exist = false;
                        }
                    }

                    if (exist) {
                        totalPrice += importdetailObj["totalPrice"];
                        importdetail.push(importdetailObj);
                    }
                    
                    var drugEdit = {};
                    drugEdit["id"] = data.id;
                    drugEdit["name"] = data.name;
                    drugEdit["price"] = data.price;
                    drugEdit["unit"] = data.unit;
                    drugEdit["dateOfManufacture"] = data.dateOfManufacture;
                    drugEdit["expriryDate"] = data.expriryDate;
                    drugEdit["groupDrugId"] = data.groupDrugId;
                    drugEdit["producerId"] = data.producerId;
                    drugEdit["amount"] = parseInt(parseInt(data.amount) - parseInt(importdetailObj["amount"]));
                    drugEdit["isActive"] = (parseInt(drugEdit["amount"]) == 0) ? false : true;
                    $.ajax({
                        url: "/Drug/EditDrug",
                        type: "PUT",        
                        contentType: "application/json",
                        dataType: "json",
                        data: JSON.stringify(drugEdit)
                    });
                    drug.DrawTable();
                    // Load lai TotalPrice hoa don
                    $("#totalPrice").val(totalPrice.toLocaleString() + " VNĐ");
                    // Load lại table chi tiết
                    importReceipt.DrawTable();
                    $(mess).hide();
                }
            );
        });
};

receipt.Draw = function() {
    var date = new Date();
    var time = date.getFullYear() +
        "-" +
        date.getMonth() +
        "-" +
        date.getDay() +
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
        var drugEdit = {};
        drugEdit["id"] = data.id;
        drugEdit["name"] = data.name;
        drugEdit["price"] = data.price;
        drugEdit["unit"] = data.unit;
        drugEdit["dateOfManufacture"] = data.dateOfManufacture;
        drugEdit["expriryDate"] = data.expriryDate;
        drugEdit["groupDrugId"] = data.groupDrugId;
        drugEdit["producerId"] = data.producerId;
        drugEdit["isActive"] = true;
        $.getJSON(
            "/Drug/Get/" + data.id,
            function (DrugDatarepose) {
                var dt = DrugDatarepose.data;
                drugEdit["amount"] = dt.amount + data.amount;
                $.ajax({
                    url: "/Drug/EditDrug",
                    type: "PUT",
                    contentType: "application/json",
                    dataType: "json",
                    data: JSON.stringify(drugEdit)
                });
                totalPrice -= data.totalPrice;
                $("#totalPrice").val(totalPrice + " VNĐ");
                drug.DrawTable();
            }
        );
        for (var i = 0; i < importdetail.length; i++) {
            if (importdetail[i]["id"] === data.id) {
                // Xóa sp trong detail và vẽ lại
                importdetail.splice(i, 1);
                importReceipt.DrawTable();
            }
        }
    }
);

$("#btn-popup-drug").on("click", drug.DrawTable());


$("#createReceiptImport").on('click',
    function() {
        var valid = true;
        if ( $("#idReceipt").val() === "") {
            valid = false;
        }

        if (valid){
            var importObj = {};
            importObj["codeReceipt"] = $("#idReceipt").val();
            importObj["dateCreate"] = $("#dateCreate").val();
            importObj["totalPrice"] = totalPrice;
            importObj["isPay"] = ($('#isPay').is(":checked")) ? true : false;
            importObj["isActive"] = true;
            importObj["userProfileId"] = userId;
            var detailReceiptExports = [];
            for (var i = 0; i < importdetail.length; i++) {
                var obj = {};
                obj["amount"] = importdetail[i]["amount"];
                obj["amountRemaining"] = importdetail[i]["amount"];
                obj["totalPrice"] = importdetail[i]["totalPrice"];
                obj["drugId"] = importdetail[i]["id"];
                detailReceiptExports.push(obj);
            }
    
            importObj["detailReceiptExports"] = detailReceiptExports;
    
            $.ajax({
                url: "/ExportDrug/CreateReceiptExport",
                type: "POST",
                dataType: "json",
                contentType: 'application/json',
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
};

$(document).ready(function() {
    drug.init();
});