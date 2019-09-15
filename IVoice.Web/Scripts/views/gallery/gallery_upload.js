$(function () {
    $('#upload').fileupload({

        dropZone: $('#upload'),

        add: function (e, data) {
            if ($('.toggle-gallery-cover').prop('checked') == true) {
                $('#type').val('cover');
            } 
            var jqXHR = data.submit();
        },

        progress: function (e, data) {
        },

        done: function (e, data) {
            // upload success
            location.reload();
        },

        fail: function (e, data) {
            alertMessage('Error', 'Error while uploading gallery');
        }
    });

    $(document).on('drop dragover', function (e) {
        e.preventDefault();
    });

    
})