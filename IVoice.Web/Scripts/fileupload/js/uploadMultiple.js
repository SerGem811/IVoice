function openFile(UniqueId, FileName) {
    window.open("/upload/" + UniqueId + "/" + FileName);
    return false;
}
function removeFile(UniqueId, FileName, element) {
    $.ajax({
        type: "POST",
        data: {
            UniqueId: UniqueId,
            FileName: FileName
        },
        url: '/forumtopic/deletefile',
        datatype: 'json',
        complete: function (result) {
            $(element).closest("tr").remove();
        }
    });


    return false;
}

$(function () {

    var tbl = $('#tblFileUpload');

    // Initialize the jQuery File Upload plugin
    $('#upload').fileupload({

        // This element will accept file drag/drop uploading
        dropZone: $('#upload'),

        // This function is called when a file is added to the queue;
        // either via the browse button, or via drag/drop:
        add: function (e, data) {

            var paramsTopenRem = '"' + $("#UniqueId").val() + '","' + data.originalFiles[0].name + '"';

            var tpl = $('<tr><td>' + data.originalFiles[0].name +
                        '        <div class="working"> <input type="text" value="0" data-width="48" data-height="48" data-fgColor="#0788a5" data-readOnly="1" data-bgColor="#3e4043" /><p></p><span></span></div> ' +
                        '    </td> ' +
                        '    <td class=""> ' +
                        '        <a href="#" onclick=\'openFile(' + paramsTopenRem + ');return false;\' class="secondary-link pull-left"><i class="fa fa-envelope-open"></i>&nbsp;open</a>' +
                        '        <a href="#" onclick=\'removeFile(' + paramsTopenRem + ', this);return false;\' class="secondary-link pull-right"><i class="fa fa-trash"></i>&nbsp;remove</a>' +
                        '    </td></tr>');

            
            // Append the file name and file size
            tpl.find('p').text(data.files[0].name)
                         .append('<i>' + formatFileSize(data.files[0].size) + '</i>');

            // Add the HTML to the UL element
            data.context = tpl.appendTo(tbl);

            // Initialize the knob plugin
            tpl.find('input').knob();

            // Listen for clicks on the cancel icon
            tpl.find('span').click(function () {

                if (tpl.hasClass('working')) {
                    jqXHR.abort();
                }

                tpl.fadeOut(function () {
                    tpl.remove();
                });

            });

            // Automatically upload the file once it is added to the queue
            var jqXHR = data.submit();
        },

        progress: function (e, data) {


            // Calculate the completion percentage of the upload
            var progress = parseInt(data.loaded / data.total * 100, 10);

            // Update the hidden input field and trigger a change
            // so that the jQuery knob plugin knows to update the dial
            data.context.find('input').val(progress).change();

            if (progress == 100) {
                data.context.find(".working").hide();
            }
        },

        done: function (e, data) {
            // check   
        },

        fail: function (e, data) {
            alert("error");
            // Something has gone wrong!
            data.context.addClass('error');
            console.log(e);
            console.log(data);
        }
    });

    // Prevent the default action when a file is dropped on the window
    $(document).on('drop dragover', function (e) {
        e.preventDefault();
    });

});