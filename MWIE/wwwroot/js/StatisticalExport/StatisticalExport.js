var tableReceipt = tableReceipt || {};
var tableDetail = tableDetail || {};
var page = page || {};

tableReceipt.Draw = function () {
    $.ajax({
        url: "/ExportDrug/Get",
        type: "GET",
        dataType: "json",
        contentType: "application/json",
        success: function(data){
            loadReceipt(data);
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
                '<td data-field="text" data-editable="true">' + value.userProfileId + '</td>' +
                '<td data-field="number" data-editable="true">' + value.totalPrice + '</td>' +
                '<td data-field="task" data-editable="true">' + ((value.isPay)?"Đã thanh toán" : "Chưa thanh toán") + '</td>' +
                '<td data-field="task" data-editable="true">' + ((value.isActive)? "Đang hoạt động" : "Đã khóa") + '</td>' +
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
            url: "/ExportDrug/Delete/" + id,
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

$('#btn-close').on('click', function () {
    $("#popupDetails").hide();
});

$('#btn-close-up').on('click', function () {
    $("#popupDetails").hide();
});

page.init = function() {
    tableReceipt.Draw();
};

$(document).ready(function() {
    page.init();
});