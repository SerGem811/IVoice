function redirectToBase() {
    window.location.href = 'Index';
}
function onPostFunction(e) {
    if (e.responseJSON.Text != 'FALSE') {
        //apriPopupBootstrap('Message Sent', null, 'The message has been sent', {}, true, 'Ok', false, 'Ok', redirectToBase, redirectToBase, '70%');
        alertMessage('Notice', 'The message has been sent');
        redirectToBase();
    }
    else {
        //apriPopupBootstrap('Error', null, e.responseJSON.Text, {}, true, 'Ok', false, '', null, null, '70%');
        alertMessage('Notice', e.responseJSON.Text);
    }
}

$(document).ready(function () {
    $('.table').DataTable({
        searching: false,
        ordering: true,
        'bLengthChange': false,
        paging: false
    });

    $('#submitForm').on('click', function (e) {
        $('#_message').html(tinyMCE.activeEditor.getContent());

        $('#CreateWhisper').submit();
    });


    tinymce.init({
        selector: 'textarea',
        height: 500,
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
    });
});