var page = page || {};
var statisticalExport = [];
var statisticalImport = [];
var statisticalLiquidation = [];
var number = number || {};
var tableReceiptImport = tableReceiptImport || {};
var tableReceiptExport = tableReceiptExport || {};
var tableReceiptLiquidation = tableReceiptLiquidation || {};

number.draw = function () {
    $.ajax({
        url: "/ExportDrug/Get",
        type: "GET",
        dataType: "json",
        contentType: "application/json",
        success: function (data) {
            var today = new Date();

            for (let i = 0; i < data.length; i++) {
                var temp = new Date(data[i].dateCreate)
                if (temp.getDate() === today.getDate()
                    && temp.getMonth() === today.getMonth()
                    && temp.getYear() === today.getYear()) {
                    statisticalExport.push(data[i]);
                }
            }

            $('#numberExport').html(statisticalExport.length);
        }
    });

    $.ajax({
        url: "/ImportDrug/Get",
        type: "GET",
        dataType: "json",
        contentType: "application/json",
        success: function (data) {
            var today = new Date();

            for (let i = 0; i < data.length; i++){
                var temp = new Date(data[i].dateCreate)
                if (temp.getDate() === today.getDate()
                    && temp.getMonth() === today.getMonth()
                    && temp.getYear() === today.getYear()) {
                    statisticalImport.push(data[i]);
                }
            }

            $('#numberImport').html(statisticalImport.length);
        }
    });

    $.ajax({
        url: "/Liquidation/Get",
        type: "GET",
        dataType: "json",
        contentType: "application/json",
        success: function (data) {
            var today = new Date();

            for (let i = 0; i < data.length; i++) {
                var temp = new Date(data[i].dateCreate)
                if (temp.getDate() === today.getDate()
                    && temp.getMonth() === today.getMonth()
                    && temp.getYear() === today.getYear()) {
                    statisticalLiquidation.push(data[i]);
                }
            }

            $('#numberLiquidation').html(statisticalLiquidation.length);
        }
    });
}

// xử lý hiển thị những hóa đơn nhập hôm nay
tableReceiptImport.draw = function () {
    $('#receiptImportToday').on('click', function () {
        $('#popupReceiptImport').show(300);
        $('#tabledetailImport').DataTable({
            "destroy": true,
            "data": statisticalImport,
            "columns": [
                { "data": "codeReceipt" },
                { "data": "dateCreate" },
                { "data": "totalPrice" },
                { "data": "userProfileId" }
            ],
            "columnDefs": [{
                "targets": 4, "data": "id", "render": function (data, type, full, meta) {
                    return '<a href="#" onclick="detailImport(' + data + ')"><i class="fa fa-pencil-square-o">Chi tiết</i></a> |' +
                        '<a href="#" onclick="deleteReceiptImport(' + data + ')"><i class="fa fa-trash-o"> Xóa </i></a>';
                }
            }]
        });
    });
}

// xử lý hiển thị những hóa đơn xuất hôm nay
tableReceiptExport.draw = function () {
    $('#receiptExportToday').on('click', function () {
        $('#popupReceiptExport').show(300);
        $('#tabledetailExport').DataTable({
            "destroy": true,
            "data": statisticalExport,
            "columns": [
                { "data": "codeReceipt" },
                { "data": "dateCreate" },
                { "data": "totalPrice" },
                { "data": "userProfileId" },
            ],
            "columnDefs": [{
                "targets": 4, "data": "id", "render": function (data, type, full, meta) {
                    return '<a href="#" onclick="detailExport(' + data + ')"><i class="fa fa-pencil-square-o">Chi tiết</i></a> |' +
                        '<a href="#" onclick="deleteReceiptExport(' + data + ')"><i class="fa fa-trash-o"> Xóa </i></a>';
                }
            }]
        });
    });
}


// xử lý những hóa đơn thanh lý hôm nay
tableReceiptLiquidation.draw = function () {
    $('#receiptLiquidationToday').on('click', function () {
        $('#popupReceiptLiquidation').show(300);
        $('#tabledetailLiquidation').DataTable({
            "destroy": true,
            "data": statisticalLiquidation,
            "columns": [
                { "data": "codeReceipt" },
                { "data": "dateCreate" },
                { "data": "totalPrice" },
                { "data": "userProfileId" }
            ],
            "columnDefs": [{
                "targets": 4, "data": "id", "render": function (data, type, full, meta) {
                    return '<a href="#" onclick="detailLiquidation(' + data + ')"><i class="fa fa-pencil-square-o">Chi tiết</i></a> |' +
                        '<a href="#" onclick="deleteReceiptLiquidation(' + data + ')"><i class="fa fa-trash-o"> Xóa </i></a>';
                }
            }]
        });
    });
}

/* xự kiện đóng những bảng hóa đơn */
$('#btn-close-up-import').on('click', function () { $('#popupReceiptImport').hide(); })
$('#btn-close-import').on('click', function () { $('#popupReceiptImport').hide(); })

$('#btn-close-up-export').on('click', function () { $('#popupReceiptExport').hide(); })
$('#btn-close-export').on('click', function () { $('#popupReceiptExport').hide(); })

$('#btn-close-up-liquidation').on('click', function () { $('#popupReceiptLiquidation').hide(); })
$('#btn-close-liquidation').on('click', function () { $('#popupReceiptLiquidation').hide(); })

// xử lý chi tiết hóa đơn nhập
function detailImport(id) {
    $("#popupDetailsImport").show(300);

    $('#tabledetailImportDrug').DataTable({
        "destroy": true,
        "ajax": {
            "url": "/ImportDrug/GetDetail/" + id,
            "type": "GET",
            "dataType": "json"

        },
        "columns": [
            { "data": "drugName" },
            { "data": "price" },
            { "data": "amount" },
            { "data": "dateOfManufacture" },
            { "data": "expriryDate" },
            { "data": "totalPrice" }
        ]
    });
}

function deleteReceiptImport(id) {
    var warning = $("#warningImport");
    $(warning).show(300);

    $("#okImport").on('click', function () {
        $.ajax({
            url: "/ImportDrug/Delete/" + id,
            type: "DELETE",
            contentType: "application/json",
            dataType: "json",
            success: function () {
                $(warning).hide()
                location.reload()
            }
        });
    });

    $("#noImport").on('click', function () {
        $(warning).hide();
    });
}
// xử lý chi tiết hóa đơn xuất
function detailExport(id) {
    $("#popupDetailsExport").show(300);

    $('#tabledetailExportDrug').DataTable({
        "destroy": true,
        "ajax": {
            "url": "/ExportDrug/GetDetail/" + id,
            "type": "GET",
            "dataType": "json"

        },
        "columns": [
            { "data": "drugName" },
            { "data": "price" },
            { "data": "amount" },
            { "data": "dateOfManufacture" },
            { "data": "expriryDate" },
            { "data": "totalPrice" }
        ]
    });
}

function deleteReceiptExport(id) {
    var warning = $("#warningExport");
    $(warning).show(300);

    $("#okExport").on('click', function () {
        $.ajax({
            url: "/ExportDrug/Delete/" + id,
            type: "DELETE",
            contentType: "application/json",
            dataType: "json",
            success: function () {
                $(warning).hide()
                location.reload()
            }
        });
    });

    $("#noExport").on('click', function () {
        $(warning).hide();
    });
}

$('#btn-close-up-detailExport').on('click', function () {
    $("#popupDetailsExport").hide();
});

$('#btn-close-detailExport').on('click', function () {
    $("#popupDetailsExport").hide();
});
// xử lý chi tiết hóa đơn thanh lý
function detailLiquidation(id) {
    $("#popupDetailsLiquidation").show(300);

    $('#tabledetailLiquidationDrug').DataTable({
        "destroy": true,
        "ajax": {
            "url": "/Liquidation/GetDetail/" + id,
            "type": "GET",
            "dataType": "json"

        },
        "columns": [
            { "data": "drugName" },
            { "data": "price" },
            { "data": "amount" },
            { "data": "dateOfManufacture" },
            { "data": "expriryDate" },
            { "data": "totalPrice" }
        ]
    });
}

function deleteReceiptLiquidation(id) {
    var warning = $("#warningLiquidation");
    $(warning).show(300);

    $("#okLiquidation").on('click', function () {
        $.ajax({
            url: "/Liquidation/Delete/" + id,
            type: "DELETE",
            contentType: "application/json",
            dataType: "json",
            success: function () {
                $(warning).hide()
                location.reload()
            }
        });
    });

    $("#noLiquidation").on('click', function () {
        $(warning).hide();
    });
}

$('#btn-close-up-detailLiquidation').on('click', function () {
    $("#popupDetailsLiquidation").hide();
});

$('#btn-close-detailLiquidation').on('click', function () {
    $("#popupDetailsLiquidation").hide();
});

page.init = function () {
    number.draw();
    tableReceiptImport.draw();
    tableReceiptExport.draw();
    tableReceiptLiquidation.draw();
};
$(document).ready(function () {
    page.init();
});