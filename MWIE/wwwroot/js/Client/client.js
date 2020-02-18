var page = page || {};
var client = client || {};

client.drawTable = function () {
    var clientTable = $("#table").DataTable({
        destroy: true,
        ajax: {
            url: "Client/ListAll",
            type: "GET",
            DataTable: "json"
        },
        columns: [
            { data: "name" },
            { data: "address" },
            { data: "email" },
            {data: "phone"}
        ],
        columnDefs: [{
            "targets": 4, "data": "id", "render": function (data, type, full, meta) {
                return '<a href="#" onclick="edit(' + data + ')"><i class="fa fa-pencil-square-o">Sửa</i></a> |' +
                    '<a href="#" onclick="deleteClient(' + data + ')"><i class="fa fa-trash-o"> Xóa </i></a>';
            }
        }]

    });
}

$('#addClient').on('click', function () {
    $('#popup-add').show(300);

    $('#btn-add').on('click', function () {
        var clientOjb = {};
        clientOjb.name = $('#nameAdd').val();
        clientOjb.address = $('#addressAdd').val();
        clientOjb.email = $('#emailAdd').val();
        clientOjb.phone = $('#phoneAdd').val();
        clientOjb.isActive = true;

        $.ajax({
            url: "Client/Add",
            type: "POST",
            contentType: "application/json",
            datatype: "json",
            data: JSON.stringify(clientOjb),
            success: function () {
                $('#popup-add').hide(300);
                location.reload();
            }
        });
    });

    $('#btn-close-up-add').on('click', function () { $('#popup-add').hide(300); })
});

function edit(id) {
    $('#popup-edit').show(300);
    $.ajax({
        url: "Client/Get/" + id,
        type: "GET",
        datatype: "json",
        contentType: "application/json",
        success: function (dataRespose) {
            var data = dataRespose.data;
            $('#idEdit').val(data.id);
            $('#nameEdit').val(data.name);
            $('#addressEdit').val(data.address);
            $('#emailEdit').val(data.email);
            $('#phoneEdit').val(data.phone);
            $('#isActiveEdit').val(data.isActive);
        }
    });

    $('#btn-edit').on('click', function () {
        var clientOjb = {};
        clientOjb.id = $('#idEdit').val();
        clientOjb.name = $('#nameEdit').val();
        clientOjb.address = $('#addressEdit').val();
        clientOjb.email = $('#emailEdit').val();
        clientOjb.phone = $('#phoneEdit').val();

        $.ajax({
            url: "Client/Edit",
            type: "PUT",
            contentType: "application/json",
            datatype: "json",
            data: JSON.stringify(clientOjb),
            success: function () {
                $('#popup-edit').hide(300);
                location.reload();
            }
        });
    });

    $('#btn-close-up-edit').on('click', function () { $('#popup-edit').hide(300); })
}

function deleteClient (id){
    var warning = $("#warning");
    $(warning).show(300);

    $("#ok").on('click', function () {
        $.ajax({
            url: "/Client/Delete/" + id,
            type: "DELETE",
            contentType: "application/json",
            dataType: "json",
            success: function () {
                $(warning).hide();
                location.reload();
            }
        });
    });

    $("#no").on('click', function () {
        $(warning).hide();
    });
}


page.init = function () {
    client.drawTable();
}

$(document).ready(function () {
    page.init();
});
