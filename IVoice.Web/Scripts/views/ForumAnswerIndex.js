
function Refreshpage() {
    window.location.href = urlArea;
}

function onPostFunction(e) {
    if (e.responseJSON.Text != "FALSE") {
        Refreshpage();
    }
    else
        apriPopupBootstrap("Error", null, e.responseJSON.Text, {}, true, "Ok", false, "", null, null, '70%');
}





function returnLikeDislike(VoteObject, AnswerId) {
    if (VoteObject) {
        return "You voted: " + VoteObject.Vote + " on " + GetAllDateFromJSON(VoteObject.VoteDate);
    }
    else {
        return ' <div id="likediv"> <a href="#" onclick="PostLikeDislike(' + AnswerId + ', true, this)" class="text-small secondary-link"><i class="fa fa-thumbs-up"></i> Like</a>' +
            '                    <a href="#" onclick="PostLikeDislike(' + AnswerId + ', false, this)" class="text-small secondary-link padding-left-10"><i class="fa fa-thumbs-down"></i> Dislike</a> </div>';
    }
}

function returnAttachDiv(Attach) {
    if (Attach.length > 0) {
        var div = "<div class='attachDiv'>";


        for (var i = 0; i < Attach.length; i++) {
            div += "<a href='" + Attach[i].Path + "' target='_blank'><img src='" + Attach[i].Path + "'  /></a>";
        }


        return div + " </div>";
    }
    else return "";
}

function PostLikeDislike(AnswerId, Like, object) {
    var postParams = {
        AnswerId: AnswerId,
        UserId: LoggedUserId,
        Like: Like
    };
    $.ajax({
        url: PostLikeDislikeURL,
        data: postParams,
        type: 'POST',
        complete: function (request, status) {
            $(object).parent().html(
                "You voted: " + request.responseJSON.LikeVote + " on " + GetAllDateFromJSON(request.responseJSON.VoteDate)
            );
        }
    });
}



var SetViewPage = function () {
    $.ajax({
        url: SetViewPageURL,
        data: { TopicId: TopicId },
        type: 'POST',
        complete: function (request, status) {
        }
    });
};



$(document).ready(function () {

    setTimeout(SetViewPage, 1000);


    $("#submitForm").on("click", function (e) {
        $("#Answer").html(tinyMCE.activeEditor.getContent());

        $("#AnswerTopic").submit();
    });


    var table = $('.table-area')
        .DataTable(
            {
                "iDisplayLength": 10,
                "sPaginationType": "full_numbers",
                responsive: true,
                select: false,
                processing: true,
                serverSide: true,
                paging: true,
                "bFilter": false,
                "bLengthChange": false,
                "ordering": false,
                "autoWidth": false,
                ajax: {
                    type: "POST",
                    contentType: "application/json",
                    url: GetTableListURL,
                    data: function (d) {
                        d.TopicId = TopicId;
                        return JSON.stringify(d);
                    }
                },
                "columns": [
                    { "data": "TopicName" }
                ],
                "columnDefs": [
                    {
                        "targets": 0,
                        className: "",
                        render: function (data, type, row, param) {
                            return '    <div class="row margin-bottom-25 box-default twitter-background"> ' +
                                '       <div class="td-image col-md-2 text-center">' +
                                '           <img src="' + row.ImageURL + '" class="img-topic" /><br />' +
                                row.Voicer +
                                '           <br />' +
                                '           <span class="text-small">' + row.Posts + ' posts</span>' +
                                '       </div>' +
                                '       <div class="col-md-10">' +
                                '          <div class="text-topic col-md-12">' +
                                row.Answer +
                                '              <br /><br />' +
                                '              <div class="pull-left">' +
                                returnLikeDislike(row.Vote, row.AnswerId) +
                                '              </div>' +
                                '              <span class="text-small secondary-link pull-right">Answered ' + GetAllDateFromJSON(row.AnswerDate) + '</span>' +
                                '          </div>' +
                                returnAttachDiv(row.Attach) +
                                '       </div>' +
                                '   </div>';
                        }
                    }
                ],
                "order": []
            });

    tinymce.init({
        selector: 'textarea',
        height: 300,
        theme: 'modern',
        plugins: 'print preview searchreplace autolink directionality visualblocks visualchars fullscreen image link media template codesample table charmap hr pagebreak nonbreaking anchor toc insertdatetime advlist lists textcolor wordcount imagetools contextmenu colorpicker textpattern help',
        toolbar1: 'formatselect | bold italic strikethrough forecolor backcolor | link | alignleft aligncenter alignright alignjustify  | numlist bullist outdent indent  | removeformat  | fontsizeselect fontselect ',
        image_advtab: true,
        templates: [
            { title: 'Test template 1', content: 'Test 1' },
            { title: 'Test template 2', content: 'Test 2' }
        ],
        content_css: [
            '//fonts.googleapis.com/css?family=Lato:300,300i,400,400i',
            '//www.tinymce.com/css/codepen.min.css'
        ],
        //themes: "tundora"
        //theme_url: '/Content/custom/skin.min.css'


    });
});