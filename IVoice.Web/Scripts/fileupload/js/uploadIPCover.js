var finishedCover = false;
 
function reloadCoverFileUpload() {
    // Initialize the jQuery File Upload plugin
    $('#tabCover').fileupload({

        // This element will accept file drag/drop uploading
        dropZone: $('#uploadCover'),

        // This function is called when a file is added to the queue;
        // either via the browse button, or via drag/drop:
        add: function (e, data) {
        
          

            var timeoutImageAvatar = setTimeout(function () {
                if (finishedCover) {
                    $("#CoverImg").attr("src", "/upload/covers/" + uid + "_" + data.originalFiles[0].name);
                    finishedCover = false;
                    clearTimeout(timeoutImageAvatar);
                }
            }, 1000);

          

            // Automatically upload the file once it is added to the queue
            var jqXHR = data.submit();
        },

        progress: function (e, data) {


            // Calculate the completion percentage of the upload
            var progress = parseInt(data.loaded / data.total * 100, 10);

            // Update the hidden input field and trigger a change
            // so that the jQuery knob plugin knows to update the dial
            //data.context.find('input').val(progress).change();

            if (progress == 100) {
                finishedCover = true;
                //data.context.hide();
            }
        },

        fail: function (e, data) {
            // Something has gone wrong!
            data.context.addClass('error');
        }

    });


    // Prevent the default action when a file is dropped on the window
    $(document).on('drop dragover', function (e) {
        e.preventDefault();
    });
     
}

// Helper function that formats the file sizes
function formatFileSize(bytes) {
    if (typeof bytes !== 'number') {
        return '';
    }

    if (bytes >= 1000000000) {
        return (bytes / 1000000000).toFixed(2) + ' GB';
    }

    if (bytes >= 1000000) {
        return (bytes / 1000000).toFixed(2) + ' MB';
    }

    return (bytes / 1000).toFixed(2) + ' KB';
}