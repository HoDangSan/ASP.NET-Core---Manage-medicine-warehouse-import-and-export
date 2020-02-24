var page = page || {};
var statisticalExport = [];
var statisticalImport = [];
var statisticalLiquidation = [];
var number = number || {};
var charts = charts || {};
var tableReceiptImport = tableReceiptImport || {};
var tableReceiptExport = tableReceiptExport || {};
var tableReceiptLiquidation = tableReceiptLiquidation || {};
var ctxWeek = document.getElementById('canvas').getContext('2d');
var ctxMonth = document.getElementById('canvasMonth').getContext('2d');
var ctxYear = document.getElementById('canvasYear').getContext('2d');
var statisticalExportAll = [];
var statisticalImportAll = [];
var statisticalLiquidationAll = [];

number.draw = function () {
    $.ajax({
        url: "/ExportDrug/Get",
        type: "GET",
        dataType: "json",
        contentType: "application/json",
        success: function (data) {
            var today = new Date();

            for (let i = 0; i < data.length; i++) {
                statisticalExportAll.push(data[i]);

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
                statisticalImportAll.push(data[i]);

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
                statisticalLiquidationAll.push(data[i]);

                var temp = new Date(data[i].dateCreate)
                if (temp.getDate() === today.getDate()
                    && temp.getMonth() === today.getMonth()
                    && temp.getYear() === today.getYear()) {
                    statisticalLiquidation.push(data[i]);
                }
            }

            $('#numberLiquidation').html(statisticalLiquidation.length);
            charts.draw();
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

    $('#btn-close-detailImport').on("click", function () { $('#popupDetailsImport').hide(); });
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

$('#btn-close-up-detailImport').on('click', function () {
    $("#popupDetailsImport").hide();
});

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

    $('#btn-close-detailExport').on("click", function () { $('#popupDetailsExport').hide(); });
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

    $('#btn-close-detailLiquidation').on("click", function () { $('#popupDetailsLiquidation').hide(); });
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

charts.draw = function () {

    function getArrDataWeek(arr) {
        var weeks = [];

        Date.prototype.getWeekNumber = function () {
            var d = new Date(Date.UTC(this.getFullYear(), this.getMonth(), this.getDate()));
            var dayNum = d.getUTCDay() || 7;
            d.setUTCDate(d.getUTCDate() + 4 - dayNum);
            var yearStart = new Date(Date.UTC(d.getUTCFullYear(), 0, 1));
            return Math.ceil((((d - yearStart) / 86400000) + 1) / 7)
        };

        var weekNumberToday = new Date().getWeekNumber();

        for (let i = 0; i < arr.length; i++) {
            var dateCreate = new Date(arr[i].dateCreate);
            var weekNumberDateCreate = dateCreate.getWeekNumber();
            if (weekNumberDateCreate === weekNumberToday) {
                weeks.push(arr[i]);
            }
        }


        var data = [];

        for (let i = 0; i < 7; i++) {
            for (let j = 0; j < weeks.length; j++) {
                var dateofWeek = new Date(weeks[j].dateCreate);
                var dateofWeekNumber = dateofWeek.getDay();
                if (dateofWeekNumber === i) {
                    data.push(weeks[j].totalPrice);
                }
            }
            if (data[i] == null) {
                data.push(0);
            }
        }

        return data;
    }

    var dataWeekImport = getArrDataWeek(statisticalImportAll);
    var dataWeekExport = getArrDataWeek(statisticalExportAll);
    var dataWeekLiquidation = getArrDataWeek(statisticalLiquidationAll);
    
    var myChart = new Chart(ctxWeek, {
        type: 'line',
        data: {
            labels: ["Chủ nhật", "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7"],
            datasets: [{
                data: dataWeekImport,
                label: "Nhập kho",
                borderColor: "#3e95cd",
                fill: false
            }, {
                data: [282, 350, 411, 502, 635, 809, 947],
                label: "Xuất kho",
                borderColor: "#8e5ea2",
                fill: false
            }, {
                data: [168, 170, 178, 190, 203, 276, 408],
                label: "Thanh lý",
                borderColor: "#3cba9f",
                fill: false
            }
            ]
        },
        options: {
            title: {
                display: true,
                text: 'Biểu đồ doanh thu tuần (đơn vị triệu VNĐ)'
            }
        }
    });

    var myChartMonth = new Chart(ctxMonth, {
        type: 'line',
        data: {
            labels: ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"],
            datasets: [{
                data: [86, 114, 106, 106, 107, 111, 133, 100, 87, 90, 86, 114, 106, 106, 107, 111, 133, 100, 87, 90, 86, 114, 106, 106, 107, 111, 133, 100, 87, 90, 100],
                label: "Nhập kho",
                borderColor: "#3e95cd",
                fill: false
            }, {
                data: [282, 350, 411, 502, 635, 809, 947, 800, 875, 787, 282, 350, 411, 502, 635, 809, 947, 800, 875, 787, 282, 350, 411, 502, 635, 809, 947, 800, 875, 787, 900],
                label: "Xuất kho",
                borderColor: "#8e5ea2",
                fill: false
            }, {
                data: [168, 170, 178, 190, 203, 276, 408, 500, 600, 565, 168, 170, 178, 190, 203, 276, 408, 500, 600, 565, 168, 170, 178, 190, 203, 276, 408, 500, 600, 565, 800],
                label: "Thanh lý",
                borderColor: "#3cba9f",
                fill: false
            }
            ]
        },
        options: {
            title: {
                display: true,
                text: 'Biểu đồ doanh thu tháng (đơn vị triệu VNĐ)'
            }
        }
    });

    var myChartYear = new Chart(ctxYear, {
        type: 'line',
        data: {
            labels: ["tháng 1", "tháng 2", "tháng 3", "tháng 4", "tháng 5", "tháng 6", "tháng 7", "tháng 8", "tháng 9", "tháng 10", "tháng 11", "tháng 12",],
            datasets: [{
                data: [86, 114, 106, 106, 107, 111, 133, 106, 106, 107, 111, 133],
                label: "Nhập kho",
                borderColor: "#3e95cd",
                fill: false
            }, {
                data: [282, 350, 411, 502, 635, 809, 947, 106, 106, 107, 111, 133],
                label: "Xuất kho",
                borderColor: "#8e5ea2",
                fill: false
            }, {
                data: [168, 170, 178, 190, 203, 276, 408, 106, 106, 107, 111, 133],
                label: "Thanh lý",
                borderColor: "#3cba9f",
                fill: false
            }
            ]
        },
        options: {
            title: {
                display: true,
                text: 'Biểu đồ doanh thu năm (đơn vị triệu VNĐ)'
            }
        }
    });
}

page.init = function () {
    number.draw();
    tableReceiptImport.draw();
    tableReceiptExport.draw();
    tableReceiptLiquidation.draw();
};
$(document).ready(function () {
    page.init();
});