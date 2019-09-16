function spreadIp(itemId) {

    popupBootstrap("Spread IP", urlSpread, null, { IPId: itemId }, true, "Spread", onSpreadSucess, true, "Cancel", performOk, '50%', null, '50%');
}

function LikeDislikeIP(type, itemId, currentObject, like, dislike) {
    $.ajax({
        url: urlLikeDislike,
        data: { IpId: itemId, Type: type },
        type: 'POST',
        complete: function (request, status) {
            if (request.responseJSON == 'Failed') {
                alertMessage('Something went wrong');
            } else {
                $(currentObject).parent().html(request.responseJSON);
            }
        }
    });
}

function OpenComments(itemId) {
    alert('Comments');
}

function AddEP(itemId, currentObject) {
    $.ajax({
        url: urlAddEP,
        data: { IpId: itemId },
        type: 'POST',
        complete: function (request, status) {
            if (request.responseJSON == "Failed") {
                alertMessage('Notice', 'You have no Point');
            } else {
                $(currentObject).html('<i class="fa fa-hand-point-up"></i>&nbsp;' + request.responseJSON + '&nbsp;EP Points');
            }
        }
    });
}

function SurfIP(itemId, currentObject) {
    alert('Surf');
}

function onSpreadSucess() {
    performOk();

}