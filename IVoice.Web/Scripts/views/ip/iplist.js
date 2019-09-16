function spreadIp(itemId) {
    alert('SpreadIP');
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
    alert('Add EP');
}

function SurfIP(itemId, currentObject) {
    alert('Surf');
}