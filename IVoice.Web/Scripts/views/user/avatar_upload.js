$(function () {

    // Initialize the jQuery File Upload plugin
    $('#upload').fileupload({

        // This element will accept file drag/drop uploading
        dropZone: $('#upload'),

        // This function is called when a file is added to the queue;
        // either via the browse button, or via drag/drop:
        add: function (e, data) {
            
            // Automatically upload the file once it is added to the queue
            var jqXHR = data.submit();
        },

        progress: function (e, data) {
            
        },

        done: function (e, data) {
            $("#pinfo_avatar").attr("src", data.result);
        },

        fail: function (e, data) {
            alert("error");
        }
    });

    // Prevent the default action when a file is dropped on the window
    $(document).on('drop dragover', function (e) {
        e.preventDefault();
    });

});