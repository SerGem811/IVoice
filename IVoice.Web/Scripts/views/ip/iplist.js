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

function OpenComments(url, id) {
    popupBootstrap('Comments', url, null, {type: 'main', pos: -1, id: id}, true, 'Close', performOk, false, '', null, '60%', null, true);
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

function postMainComment(obj) {
    var message = $(obj).val();
    $(obj).val('');
    var pos = -1;
    var type = '';
    if ($(obj).parent().attr('id') === 'comment-field-wrapper') {
        pos = -1;
        type = 'main'
    } else {
        pos = $(obj).parent().attr("id").replace("ip-comments-");
        type = 'ip';
    }
    var ipid = $(obj).attr("data-ipid");
    // ajax
    $.ajax({
        url: urlPostComment,
        data: {
            type: type,
            pos: pos,
            ipid: ipid,
            comment: message
        },
        type: 'POST',
        complete: function (request, status) {
            $.ajax({
                url: urlGetCommentByIp,
                data: {
                    type: 'main',
                    pos: -1,
                    id: ipid
                },
                type: 'POST',
                complete: function (request, status) {
                    $('#comment-list').html(request.responseText);
                    $('#comment-list').scrollTop(9999);
                }
            });
        }
    })
}

