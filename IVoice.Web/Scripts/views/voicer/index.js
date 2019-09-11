
function cmdConnection(element, id, func) {
    var e = window.event;
    if (e !== undefined) {
        if (e.preventDefault) {
            e.preventDefault();
        } else {
            e.returnValue = false;
        }
    }

    $.ajax({
        url: urlCommand,
        data: { VoicerID: id, Func: func },
        type: 'POST',
        complete: function (request, status) {
            popupBootstrap('Notice', null, 'Request sent', {}, true, 'Ok', afterCmd, false, '', null, '30%', null, '30%');
        }
    })
}

$(document).on('ready', function () {
    $('.toggle-options').bootstrapToggle({
        on: 'On',
        off: 'Off'
    });
});

function afterCmd() {
    performOk();
    location.reload();
}