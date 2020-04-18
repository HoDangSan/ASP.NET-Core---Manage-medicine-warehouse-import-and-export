var tableReceipt = tableReceipt || {};
var tableDetail = tableDetail || {};
var page = page || {};
var charts = charts || {};
var statisticalLiquidationAll = [];
var ctxWeek = document.getElementById('canvas').getContext('2d');
var ctxMonth = document.getElementById('canvasMonth').getContext('2d');
var ctxYear = document.getElementById('canvasYear').getContext('2d');

tableReceipt.Draw = function () {
    $.ajax({
        async: false,
        url: "/Liquidation/Get",
        type: "GET",
        dataType: "json",
        contentType: "application/json",
        success: function(data){
            loadReceipt(data);

            for (let i = 0; i < data.length; i++) {
                statisticalLiquidationAll.push(data[i]);
            }

            charts.draw();
        }
    });

    function loadReceipt(data) {
        var table = $("#receipt");
        $(table).empty();
        $.each(data,  function (index,value) {
            $(table).append(
                '<tr>' +
                '<td data-field="state" data-checkbox="true"></td>' +
                '<td data-field="name" data-editable="true">' + value.codeReceipt + '</td>' +
                '<td data-field="date" data-editable="true">' + value.dateCreate + '</td>' +
                '<td data-field="text" data-editable="true">' + value.proUserProfileName + '</td>' +
                '<td data-field="number" data-editable="true">' + value.totalPrice + '</td>' +
                '<td data-field="task" data-editable="true">' + value.isActive + '</td>' +
                '<td data-field="action" >' +
                '<a href="#" onclick="edit('+ value.id +')"><i class="fa fa-pencil-square-o">Chi tiết</i></a> |' +
                '<a href="#" onclick="deleteReceipt('+ value.id +')"><i class="fa fa-trash-o"> Xóa </i></a>' +
                '</td>' +
                '</tr>'
            );
        });
    }
};

function deleteReceipt(id) {
    var warning = $("#warning");
    $(warning).delay(200).fadeIn();

    $("#ok").on('click', function () {
        $.ajax({
            url: "/Liquidation/Delete/" + id,
            type: "DELETE",
            contentType: "application/json",
            dataType: "json",
            success: function () {
                tableReceipt.Draw();
                $(warning).hide();
            }
        });
        tableReceipt.Draw();
    });
    $("#no").on('click', function () {
        $(warning).hide();
    });
}

function edit(id){
    $("#popupDetails").show(300);

    $('#tabledetail').DataTable({
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

$('#btn-close').on('click', function () {
    $("#popupDetails").hide();
});

$('#btn-close-up').on('click', function () {
    $("#popupDetails").hide();
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
                if (dateofWeekNumber === i && data[i] == null) {
                    data.push(weeks[j].totalPrice);
                }
                else if (dateofWeekNumber === i && data[i] != null) {
                    data[i] += weeks[j].totalPrice;
                }
            }
            if (data[i] == null) {
                data.push(0);
            }
        }

        return data;
    }

    function getArrDataMonth(arr) {
        var data = [];

        // for very data flow date in month
        for (var j = 1; j <= 31; j++) {
            for (let i = 0; i < arr.length; i++) {
                var dateCreate = new Date(arr[i].dateCreate);
                var today = new Date();
                if (dateCreate.getDate() == j && dateCreate.getMonth() == today.getMonth() && dateCreate.getFullYear() == today.getFullYear()) {
                    if (data[j] == null) {
                        data.push(arr[i].totalPrice);
                    } else {
                        data[j] += arr[i].totalPrice;
                    }
                }
            }

            if (data[j] == null) {
                data.push(0);
            }
        }

        return data;
    }

    function getArrDataYear(arr) {
        var data = [];

        // for very data flow date in year
        for (var j = 1; j <= 12; j++) {
            for (let i = 0; i < arr.length; i++) {
                var dateCreate = new Date(arr[i].dateCreate);
                var today = new Date();
                if ((dateCreate.getMonth() + 1) == j && dateCreate.getFullYear() == today.getFullYear()) {
                    if (data[j] == null) {
                        data.push(arr[i].totalPrice);
                    } else {
                        data[j] += arr[i].totalPrice;
                    }
                }
            }

            if (data[j] == null) {
                data.push(0);
            }
        }

        return data;
    }

    var dataWeekLiquidation = getArrDataWeek(statisticalLiquidationAll);

    var dataMonthLiquidation = getArrDataMonth(statisticalLiquidationAll);

    var dataYearLiquidation = getArrDataYear(statisticalLiquidationAll);

    var myChart = new Chart(ctxWeek, {
        type: 'line',
        data: {
            labels: ["Chủ nhật", "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7"],
            datasets: [{
                data: dataWeekLiquidation,
                label: "Thanh lý",
                borderColor: "#3cba9f",
                fill: false
            }
            ]
        },
        options: {
            title: {
                display: true,
                text: 'Biểu đồ thanh lý tuần (đơn vị VNĐ)'
            }
        }
    });



    var myChartMonth = new Chart(ctxMonth, {
        type: 'line',
        data: {
            labels: ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"],
            datasets: [{
                data: dataMonthLiquidation,
                label: "Thanh lý",
                borderColor: "#3cba9f",
                fill: false
            }
            ]
        },
        options: {
            title: {
                display: true,
                text: 'Biểu đồ thanh lý tháng (đơn vị VNĐ)'
            }
        }
    });



    var myChartYear = new Chart(ctxYear, {
        type: 'line',
        data: {
            labels: ["tháng 1", "tháng 2", "tháng 3", "tháng 4", "tháng 5", "tháng 6", "tháng 7", "tháng 8", "tháng 9", "tháng 10", "tháng 11", "tháng 12",],
            datasets: [{
                data: dataYearLiquidation,
                label: "Thanh lý",
                borderColor: "#3cba9f",
                fill: false
            }
            ]
        },
        options: {
            title: {
                display: true,
                text: 'Biểu đồ thanh lý năm (đơn vị VNĐ)'
            }
        }
    });
}

page.init = function() {
    tableReceipt.Draw();
};

$(document).ready(function() {
    page.init();
});