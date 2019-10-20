
function postInnerComment(obj) {
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