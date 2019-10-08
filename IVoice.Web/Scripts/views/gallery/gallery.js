var selectedGallery = null;


function OpenFolder(Id, MediaType, UserId) {
    if (MediaType.toUpperCase() == "FOLDER") {
        window.location.href = gallery_path + "?UserId=" + UserId + "&AlbumId=" + Id;
    } else {
        window.open(view_path + "/" + Id, "_blank");
    }
}
function onAlbumCreated(e) {
    if (e != null && e.responseJSON.Text != "FALSE") {
        location.reload();
    } else {
        alertMessage('Notice', 'Something went wrong with create album');
    }
}
function onAlbumFailed(e) {
    alertMessage('Notice', 'Something went wrong with create album');
}

$(document).on('ready', function () {
    $('.toggle-gallery').bootstrapToggle({
        on: 'Open',
        off: 'Private',
        style:'w-100-force'
    });

    $('.toggle-gallery-cover').bootstrapToggle({
        on: 'Cover',
        off: 'Gallery'
    });

    $('.toggle-gallery').change(function (e) {
        event.stopPropagation();

        $.ajax({
            url: 'SetVisibility',
            data: {
                Id: $(this).attr("data-val"),
                Type: $(this).attr("data-type"),
                Visibility: ($(this).prop('checked')) ? "PUBLIC" : "PRIVATE"
            },
            type: 'POST',
            complete: function (request, status) {
                if (request.responseJSON.Text == "TRUE") {

                } else {
                    alert("Something went wrong");
                }
            }
        });
        return false;
    });
});


$(".pointer-hand").on("click", function (e) {
    //event.stopPropagation();
    selectedGallery = { id: $(this).attr("data-val"), type: $(this).attr("data-type") };
})

$("#PopupMedia a").on("click", function (e) {
    //event.stopPropagation();

    var postData = {
        op: $(this).attr("data-type"),
        toId: $(this).attr("data-id"),
        id: selectedGallery.id,
        type: selectedGallery.type
    };

    if (postData.id != postData.toId) {
        $.ajax({
            url: media_path,
            data: postData,
            type: 'POST',
            complete: function (request, status) {
                if (request.responseJSON.Text == "TRUE") {
                    //alert("Gallery moved");
                    //$("#media-" + selectedGallery.id).remove();
                    location.reload();
                } else {
                    alert("Something went wrong on moving gallery");
                }
                selectedGallery = null;
            }
        })
    } else {
        alert("This is same folder");
    }
});

    