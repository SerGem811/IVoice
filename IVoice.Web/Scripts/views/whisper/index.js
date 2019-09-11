var tableSent = null;
var tableInbox = null;

function removeMail(Id, OperationType) {
    $.ajax({
        url: removeURL,
        data: {
            Id: Id
        },
        type: 'POST',
        complete: function (request, status) {
            if (request.responseJSON.Text == "TRUE") {
                if (OperationType == "INBOX")
                    tableInbox.ajax.reload()
                else
                    tableSent.ajax.reload()
            }
            else {
                // show error
            }
        }
    });
}


$(function () {
    tableInbox = $("#table_1")
        .DataTable({
            "iDisplayLength": 10,
            "sPaginationType": "full_numbers",
            responsive: true,
            select: false,
            processing: true,
            serverSide: true,
            paging: true,
            "bFilter": false,
            "bLengthChange": false,
            "ordering": false,
            ajax: {
                type: "POST",
                contentType: "application/json",
                url: getTableListURL,
                data: function (d) {
                    d.Type = "INBOX";
                    return JSON.stringify(d);
                }
            },
            "columns": [
                { "data": "Date" },
                { "data": "VoicerName" },
                { "data": "Message" },
                { "data": "" },
            ],
            "columnDefs": [
                {
                    "targets": 0,
                    "defaultContent": "",
                    className: "col-md-3",
                    render: function (data, type, row, param) {
                        return GetAllDateFromJSON(row.Date);
                    }
                },
                {
                    "targets": 1,
                    "defaultContent": "",
                    className: "col-md-3",
                    "data": null,
                    "render": function (data, type, row, param) {
                        return row.VoicerName;
                    }
                },
                {
                    "targets": 2,
                    "defaultContent": "",
                    className: "col-md-4",
                    "data": null,
                    "render": function (data, type, row, param) {
                        return row.Message;
                    }
                },
                {
                    "targets": 3,
                    "defaultContent": "",
                    className: "col-md-2",
                    "data": null,
                    "render": function (data, type, row, param) {
                        return '<a href="' + detailsURL + '/' + row.Id + '" class="secondary-link pull-left"><i class="fa fa-envelope-open"></i>&nbsp;open</a>' +
                            '<a href="#" class="secondary-link pull-right" onclick="removeMail(' + row.Id + ',\'inbox\')"><i class="fa fa-trash"></i>&nbsp;remove</a>';
                    }
                }
            ],
            "order": []
        });
    tableSent = $("#table_2")
        .DataTable({
            "iDisplayLength": 10,
            "sPaginationType": "full_numbers",
            responsive: true,
            select: false,
            processing: true,
            serverSide: true,
            paging: true,
            "bFilter": false,
            "bLengthChange": false,
            "ordering": false,
            ajax: {
                type: "POST",
                contentType: "application/json",
                url: getTableListURL,
                data: function (d) {
                    d.Type = "SENT";
                    return JSON.stringify(d);
                }
            },
            "columns": [
                { "data": "Date" },
                { "data": "VoicerName" },
                { "data": "Message" },
                { "data": "" },
            ],
            "columnDefs": [
                {
                    "targets": 0,
                    "defaultContent": "",
                    className: "col-md-3",
                    render: function (data, type, row, param) {
                        return GetAllDateFromJSON(row.Date);
                    }
                },
                {
                    "targets": 1,
                    "defaultContent": "",
                    className: "col-md-3",
                    "data": null,
                    "render": function (data, type, row, param) {
                        return row.VoicerName;
                    }
                },
                {
                    "targets": 2,
                    "defaultContent": "",
                    className: "col-md-4",
                    "data": null,
                    "render": function (data, type, row, param) {
                        return row.Message;
                    }
                },
                {
                    "targets": 3,
                    "defaultContent": "",
                    className: "col-md-2",
                    "data": null,
                    "render": function (data, type, row, param) {
                        return '<a href="' + detailsURL + '/' + row.Id + '" class="secondary-link pull-left"><i class="fa fa-envelope-open"></i>&nbsp;open</a>' +
                            '<a href="#" class="secondary-link pull-right" onclick="removeMail(' + row.Id + ',\'inbox\')"><i class="fa fa-trash"></i>&nbsp;remove</a>';
                    }
                }
            ],
            "order": []
        });
});