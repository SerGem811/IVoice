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

function SurfIP(itemId, currentObject, type) {
    $.ajax({
        url: urlSurf,
        data: { IpId: itemId },
        type: 'POST',
        complete: function (request, status) {
            if (request.responseJSON == "Failed") {
                alertMessage('Notice', 'Something went wrong');
            } else {
                console.log(request);
                if (type == 1) {
                    $(currentObject).html('<i class="fa fa-star"></i>&nbsp;' + request.responseJSON + '&nbsp;You SURFs');
                    $(currentObject).attr('onclick', 'SurfIP(' + itemId + ', this, 2)');
                } else if(type == 2) {
                    $(currentObject).html('<i class="far fa-star"></i>&nbsp;' + request.responseJSON + '&nbsp;SURFs');
                    $(currentObject).attr('onclick', 'SurfIP(' + itemId + ', this, 1)');
                }
                
            }
        }
    });
}

function onSpreadSucess() {
    performOk();

}