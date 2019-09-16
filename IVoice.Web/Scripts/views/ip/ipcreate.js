var upload_type = "";
var color_type = "";

$('#creator-panel-shape').on('click', function () {
    popupBootstrap('Test', null, null, 'AddShape clicked', true, 'Ok', null, false, null, null, '50%', null, null);
});

$('#creator-panel-file').on('click', function () {
    upload_type = "panel";
    $('#file_upload_creator').click();
});

$('#creator-panel-media').on('click', function () {

});

$('#creator-panel-image').on('click', function () {

});

$('#creator-panel-text').on('click', function () {

});

$('#creator-panel-url').on('click', function () {

});

$('#creator-background-clear').on('click', function () {
    $('#ipcreator-board').css('background-color', '#fff');
    $('#ipcreator-board').css('background-image', '');
});

$('#creator-background-color').on('click', function () {

});

$('#creator-background-image').on('click', function () {
    upload_type = "background";
    $('#file_upload_creator').click();
});

$('#creator-background-url').on('click', function () {

});

$('#creator-ip-comment').on('click', function () {

});

$('#creator-ip-save').on('click', function () {
    popupBootstrap("Save IP", optionURL, null, {Id:-1}, true, 'Spread', ProceedSave,  true, 'Cancel', performOk, "60%");
});

$('#creator-ip-cancel').on('click', function () {
    popupBootstrap('Close IP', null, 'Are you sure to close IP creator? All data will be lose', {}, true, 'Close IP', closeIPPage, true, 'Cancel', performOk, '50%');
});

$('#file_upload_creator').change(function (e) {
    var file = null;
    file = e.originalEvent.target.files[0];
    var model = new FormData();
    model.append("file", file);
    model.append("guid", guid);
    $.ajax({
        url: urlUploadIPImage,
        type: 'POST',
        dataType: 'json',
        contentType: false,
        cache: false,
        contentType: false,
        processData: false,
        data: model,
        complete: function (e) {
            if (e.responseJSON == 'Failed' || e.responseJSON == '') {
                alertMessage('Error', 'Something went wrong with upload');
            } else {
                if (upload_type == 'panel') {

                } else if (upload_type == 'background') {
                    $('#ipcreator-board').css('background-color', '');
                    $('#ipcreator-board').css('background-image', 'url(' + e.responseText + ')');

                }
            }
        }
    });
})

$(document).ready(function () {
    const pickr = new Pickr({
        el: '.col-picker',
        default: '#4A4A4A',
        component: {
            preview: true,
            opacity: false,
            hue: true,
            interaction: {
                hex: true,
                rgba: false,
                hsva: false,
                hsla: false,
                input: true,
                clear: false,
                save: true
            }
        },

        onChange(hsva, instance) {
            

        },

        onSave(hsva, instance) {

        }
    });


});

function closeIPPage() {
    window.location.href = detailURL;
}

function ProceedSave() {
       
}