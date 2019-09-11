var finishedAvatarUpload = false;

$(function () {
    // Initialize the jQuery File Upload plugin
    $('#tabAttachements').fileupload({

        // This element will accept file drag/drop uploading
        dropZone: $('#uploadFile'),

        // This function is called when a file is added to the queue;
        // either via the browse button, or via drag/drop:
        add: function (e, data) {

            var timeoutImageAvatar = setTimeout(function () {
                if (finishedAvatarUpload) {
                    var imgURL = "/upload/ip/" + uid + "_" + data.originalFiles[0].name;

                    if (imageUploadPos == "back_upload") {
                        $(".body-content").css("background-image", "url('" + imgURL + "')");
                        $(".body-content").css("background-position", "center");
                        $(".body-content").css("background-repeat", "no-repeat");
                        $(".body-content").css("background-size", "100% 100%");
                    }
                    else {
                        $(".body-content").append('<div class="context-menu-one circle resize-drag"><img class="iframeIP-full" src="' + imgURL + '"> </div> ');
                    }

                    clearTimeout(timeoutImageAvatar);
                }
            }, 1500);

            // Automatically upload the file once it is added to the queue
            var jqXHR = data.submit();
        },

        progress: function (e, data) {
            // Calculate the completion percentage of the upload
            var progress = parseInt(data.loaded / data.total * 100, 10);


            if (progress == 100) {
                finishedAvatarUpload = true;
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

});