$(function () {
    var insideAjax = false;
    $(document).ajaxStart(function () {
        insideAjax = true;
        setTimeout(function () {
            if (insideAjax)
                $('#overlay').show();
        }, 150);
    });

    $(document).ajaxStop(function () {
        insideAjax = false;
        $('#overlay').hide();
        setTimeout(function () {

        });
    });

    $(document).ajaxError(function (event, xhr, options, exc) {
        alert('Error on comunication!');
    });

    $(document).ajaxComplete(function (event, xhr, options) {
        var respondedJSON = xhr.getResponseHeader('X-Responded-JSON');
        if (respondedJSON && JSON.parse(respondedJSON).status === 401)
            location.href = '/User/Login';
    });
});
