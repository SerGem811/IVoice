$(function () { });
var table = $('.table-area')
    .DataTable(
        {
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
                url: GetTableListURL,
                data: function (d) {
                    d.AreaId = areaIdSearch;
                    return JSON.stringify(d);
                }
            },
            "columns": [
                { "data": "TopicName" },
                { "data": "Replies" },
                { "data": "Views" }
            ],
            "columnDefs": [
                {
                    "targets": 0,
                    className: "col-md-4",
                    render: function (data, type, row, param) {
                        return '<div class="height-all pull-left"><i class="fa fa-list-ul secondary-link margin-10"></i></div>' +
                            '<div class="height-all margin-left-10 pull-left">' +
                            '    <a href="' + row.TopicURL + '">' + row.TopicName + '</a><br />' +
                            '    <span class="text-small">Started by ' + row.Voicer + ' on ' + GetAllDateFromJSON(row.TopicDate) + '</span>' +
                            '</div>';
                    }
                },
                {
                    "targets": 1,
                    "data": null,
                    "render": function (data, type, row, param) {
                        return row.Replies + '<br /> <span class="text-small">Replies</span>';
                    }
                },
                {
                    "targets": 2,
                    "data": null,
                    "render": function (data, type, row, param) {
                        return row.Views + '<br /> <span class="text-small">Views</span>';
                    }
                }
            ],
            "order": []
        });

