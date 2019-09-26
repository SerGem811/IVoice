var item_type = "";
var color_type = "";
var selectedObject = null;
var lastTiny = null;
var eIndex = 1;
var popupColor = $('#color-picker');

$('#ipcreator-board-area').on('click', function (e) {

});

$('#creator-panel-shape').on('click', function () {
    addBox(false, '', null, 'square', true);
});

$('#creator-panel-file').on('click', function () {
    item_type = "item_image";
    $('#file_upload_creator').click();
});

$('#creator-panel-media').on('click', function () {

});

$('#creator-panel-image').on('click', function () {

});

$('.context-menu-one').on('click', function (e) {
    
});

$('#creator-panel-text').on('click', function () {
    addBox(false, 'Double click on me!', { 'background-color': '#999'}, 'dblclick-text', true)
    bindDblClickToDiv();
});

$('#creator-panel-url').on('click', function () {

});

$('#creator-background-clear').on('click', function () {
    $('#ipcreator-board').css('background-color', '#fff');
    $('#ipcreator-board').css('background-image', '');
});

$('#creator-background-image').on('click', function () {
    item_type = "back_image";
    $('#file_upload_creator').click();
});

$('#creator-background-color').on('click', function () {
    item_type = 'back_color';
    popupColor.click();
});

$('#creator-background-url').on('click', function () {
});

$('#creator-ip-comment').on('click', function () {

});

$('#creator-ip-save').on('click', function () {
    if (id != -1) {
        var style = $('#ipcreator-board').attr('style');
        var body = $('#ipcreator-board').html();

        body = body.trim();
        if (style == undefined) {
            style = '';
        }

        $('[name="_body"]').attr('value', body);
        $('[name="_style"').attr('value', style);

        $('#modalData').submit();
    } else {
        popupBootstrap("Save IP", optionURL, null, { Id: -1 }, true, 'Spread', ProceedSave, true, 'Cancel', performOk, "60%");
    }
});

function onCompleteUpdateIP() {
    window.location = detailURL;
}

function onFailedUpdateIP() {
    alertMessage('Error', 'Something went wrong while update IP');
}

$('#creator-ip-cancel').on('click', function () {
    popupBootstrap('Close IP', null, 'Are you sure to close IP creator? All data will be lose', {}, true, 'Close IP', closeIPPage, true, 'Cancel', performOk, '50%');
});

$('#file_upload_creator').change(function (e) {
    var file = null;
    file = e.originalEvent.target.files[0];
    var model = new FormData();
    model.append("file", file);
    model.append("guid", guid);
    $.ajax({
        url: urlUploadIPImage,
        type: 'POST',
        dataType: 'json',
        contentType: false,
        cache: false,
        contentType: false,
        processData: false,
        data: model,
        complete: function (e) {
            if (e.responseJSON == 'Failed' || e.responseJSON == '') {
                alertMessage('Error', 'Something went wrong with upload');
            } else {
                if (item_type == 'item_image') {
                    $('#ipcreator-board-area').append('<img class="resize-drag context-menu-one ip-image" src=' + e.responseText + '">');
                } else if (item_type == 'back_image') {
                    $('#ipcreator-board').css('background-color', '');
                    $('#ipcreator-board').css('background-image', 'url(' + e.responseText + ')');
                }
            }
            $('#file_upload_creator').prop('value', '');
        }
    });
})

function closeIPPage() {
    window.location.href = detailURL;
}

function ProceedSave() {
           
}

function dragMoveListener(event) {
    var target = event.target,
        // keep the dragged position in the data-x/data-y attributes
        x = (parseFloat(target.getAttribute('data-x')) || 0) + event.dx,
        y = (parseFloat(target.getAttribute('data-y')) || 0) + event.dy;

    // translate the element
    target.style.webkitTransform =
        target.style.transform =
        'translate(' + x + 'px, ' + y + 'px)';

    // update the posiion attributes
    target.setAttribute('data-x', x);
    target.setAttribute('data-y', y);
}



function selectedObjectHasClass(className) {
    return $(selectedObject).hasClass(className);
}

window.dragMoveListener = dragMoveListener;

interact('.resize-drag')
    .draggable({
        onmove: dragMoveListener,
        restrict: {
            restriction: 'parent',
            elementRect: { top: 0, left: 0, bottom: 1, right: 1 }
        },
        inertia: true,
    })
    .resizable({
        edges: { left: true, right: true, bottom: true, top: true },
        restrictSize: {
            min: { width: 100, height: 100 }
        },
        inertia: false,
    })
    .on('resizemove', function (event) {
        var target = event.target,
            x = (parseFloat(target.getAttribute('data-x')) || 0),
            y = (parseFloat(target.getAttribute('data-y')) || 0);

        target.style.width = event.rect.width + 'px';
        target.style.height = event.rect.height + 'px';

        x += event.deltaRect.left;
        y += event.deltaRect.top;

        target.style.webkitTransform = target.style.transform = 'translate(' + x + 'px, ' + y + 'px)';

        target.setAttribute('data-x', x);
        target.setAttribute('data-y', y);
    });

interact('.draggable')
    .draggable({
        inertia: false,
        restrict: {
            restriction: 'parent',
            endOnly: true,
            elementRect: {top:0, left:0, bottom:1, right:1}
        },
        autoScroll: true,

        onmove: dragMoveListener,

        onend: function (event) {

        }
    })

$.contextMenu({
    selector: '.context-menu-one',
    build: function ($trigger, e) {
        selectObject = $trigger[0];
        item_type = 'contextmenu';

        var dynamicItems = {
            'link': { name: 'Add link', icon: 'add' },
            'front': { name: 'Bring Front'},
            'back': { name: 'Send Back'},
            'seperator-01' : '----- Images -----',
            'shapes': {
                name: 'Shapes',
                'items': {
                    'change-color': { name: 'Change color' },
                    'transparentback': { name: 'Transparent background', icon: 'left' },
                    'seperator-02': '----- Images -----',
                    'shapes-circle': { name: 'Circle' },
                    'shapes-square': { name: 'Square' },
                    'shapes-trapezoid': { name: 'Trapezoid' },
                    'shapes-triangle-up': { name: 'Triangle up' },
                    'shapes-triangle-down': { name: 'Triangle down' },
                    'shapes-triangle-left': { name: 'Triangle left' },
                    'shapes-triangle-right': { name: 'Triangle right' },
                }
            },
            'seperator-03': '----- Editor -----',
            'edit': {
                name: 'Image editor',
                items: {
                    'edit-befunky': { name: 'BeFunky' },
                    'edit-lunapic': { name: 'Lunapic' },
                    'edit-photopea': { name: 'Photopea' },
                    'edit-moviemaker': { name: 'Moviemaker' },
                    'edit-in': { name: 'Built-in' },
                },
                icon: 'edit'
            },

            'filter': {
                name: 'Image filters',
                items: {
                    'filter-no': { name: 'Remove filter', icon: (selectedObjectHasClass('filter-no') ? 'check' : '') },
                    'filter-gray': { name: 'Grayscale', icon: (selectedObjectHasClass('filter-gray') ? 'check' : '') },
                    'filter-blur': { name: 'Blur', icon: (selectedObjectHasClass('filter-blur') ? 'check' : '') },
                    'filter-brightness': { name: 'Brightness', icon: (selectedObjectHasClass('filter-brightness') ? 'check' : '') },
                    'filter-contrast': { name: 'Contrast', icon: (selectedObjectHasClass('filter-contrast') ? 'check' : '') },
                    'filter-huerotate': { name: 'Huerottate', icon: (selectedObjectHasClass('filter-huerotate') ? 'check' : '') },
                    'filter-invert': { name: 'Invert', icon: (selectedObjectHasClass('filter-invert') ? 'check' : '') },
                    'filter-opacity': { name: 'Opacity', icon: (selectedObjectHasClass('filter-opacity') ? 'check' : '') },
                    'filter-saturate': { name: 'Saturate', icon: (selectedObjectHasClass('filter-saturate') ? 'check' : '') },
                    'filter-sepia': { name: 'Sepia', icon: (selectedObjectHasClass('filter-sepia') ? 'check' : '') },
                    'filter-shadow': { name: 'Shadow', icon: (selectedObjectHasClass('filter-shadow') ? 'check' : '') },
                },
                icon: 'edit'
            },
            'seperator-04': '----- Videos -----',
            'fixvideo': { name: 'Fix video', icon: 'right' },
            'seperator-05': '-----------',
            'delete': { name: 'Delete', icon: 'delete' }
        };

        return {
            callback: function (key, options) {
                var item = options.$trigger[0];
                var index = $(item).css('z-index');
                if (!$.isNumeric(index))
                    index = 0;

                if (key == 'delete') {
                    item.remove();
                } else if (key == 'deleteIPComment') {
                    $(item).parent().remove();
                } else if (key == 'back') {
                    if (index > 10) {
                        $(item).css('z-index', --index);
                    }
                } else if (key == 'front') {
                    $(item).css('z-index', ++index);
                } else if (key == 'titleIpComment') {

                } else if (key == 'fixvideo') {

                } else if (key == 'link') {

                } else if (key == 'transparentback') {
                    $(item).css('background-color', 'inherit');
                } else if (key == 'change-color') {
                    item_type = 'object';
                    selectedObject = $(item);
                    popupColor.click();
                    
                } else if (key == 'addtext') {

                } else if (key.indexOf('shapes-') == 0) {
                    $(item).removeClass('circle trapezoid parallelogram triangle-up triangle-down triangle-left triangle-down resize-drag draggable');
                    $(item).css('width', '')
                        .css('height', '')
                        .css('border-bottom', '')
                        .css('border-left', '')
                        .css('border-right', '')
                        .css('border-top', '')
                        .css('background-color', '');

                    if (key.indexOf('circle') > 0) {
                        $(item).addClass('circle resize-drag');
                        $(item).css('width', '100px');
                        $(item).css('height', '100px');
                    } else if (key.indexOf('square') > 0) {
                        $(item).addClass('square resize-drag');
                        $(item).css('width', '100px');
                        $(item).css('height', '100px');
                    } else if (key.indexOf('trapezoid') > 0) {
                        $(item).addClass('trapzoid draggable');
                    } else if (key.indexOf('triangle-up') > 0) {
                        $(item).addClass('triangle-up draggable');
                    } else if (key.indexOf('triangle-down') > 0) {
                        $(item).addClass('triangle-down draggable');
                    } else if (key.indexOf('triangle-left') > 0) {
                        $(item).addClass('triangle-left draggable');
                    } else if (key.indexOf('triangle-right') > 0) {
                        $(item).addClass('triangle-right draggable');
                    }
                } else if (key.indexOf('edit') == 0) {
                    if (key.indexOf('lunapic') > 0) {
                        window.open('https://www110.lunapic.com/editor/?action=quick-upload', '_blank');
                    } else if (key.indexOf('photopea') > 0) {
                        window.open('https://www.photopea.com/', '_blank');
                    } else if (key.indexOf('moviemaker') > 0) {
                        window.open('https://moviemakeronline.com/', '_blank');
                    } else if (key.indexOf('befunky') > 0) {
                        window.open('https://www.befunky.com/', '_blank');
                    }
                } else if (key.indexOf('filter') == 0) {
                    $(item).removeClass('filter-no filter-gray filter-blur filter-brightness filter-contrast filter-huerotate filter-invert filter-opacity  filter-saturate filter-sepia filter-shadow');
                    $(item).addClass(key);
                }
            },
            items: dynamicItems
        };
    }
});

function addBox(onlyDraggable, html, plainCssObject, CssClass, addDimensions) {
    var css = 'resize-drag';
    if (onlyDraggable)
        css = 'draggable';

    var d = document.createElement('div');

    $(d).addClass(css + ' context-menu-one' + (CssClass ? ' ' + CssClass : ''))
        .html(html)
        .attr('id', 'box' + eIndex);

    if (addDimensions)
        $(d).css('height', '220px')
            .css('width', '220px');

    if (plainCssObject)
        $(d).css(plainCssObject);

    $(d).addClass('zIndex-default');
    $(d).appendTo('#ipcreator-board-area');

    eIndex++;
}

function bindDblClickToDiv() {
    $('.dblclick-text').unbind('dblclick');
    $('.dblclick-text').on('dblclick', function (e) {
        item_type = 'Textbox';
        selectedObject = $(this);
        OpenMCEBox($(this).html());
    })
}

function SaveMCEContent() {
    for(var i = 0 ; i < lastTiny.length; i++) {
        if (!lastTiny[i].isNoDirty) {
            $(selectedObject).html(lastTiny[i].getContent());
        }
    }
    performOk();
}

function OpenMCEBox(htmlContent) {
    popupBootstrap('Edit box text', null, '<textarea class="txttiny">' + htmlContent + '</textarea>', {}, true, 'Save', SaveMCEContent, true, 'Cancel', performOk, '70%', null, '70%');
    setTimeout(function () { loadTinyMCE(); }, 250);
}

function loadTinyMCE() {
    tinymce.init({
        selector: 'textarea',
        height: 400,
        theme: 'modern',
        plugins: 'print preview searchreplace autolink directionality visualblocks visualchars fullscreen image link media template codesample table charmap hr pagebreak nonbreaking anchor toc insertdatetime advlist lists textcolor wordcount imagetools contextmenu colorpicker textpattern help',
        toolbar1: 'formatselect | bold italic strikethrough forecolor backcolor | link | alignleft aligncenter alignright alignjustify  | numlist bullist outdent indent  | removeformat  | fontsizeselect fontselect ',
        image_advtab: true,
        templates: [
            { title: 'Test template 1', content: 'Test 1' },
            { title: 'Test template 2', content: 'Test 2' }
        ],
        content_css: [
            
        ]
    }).then(function (editors) {
        lastTiny = editors;
    });
}


$(document).ready(function () {
    
});

$('#color-picker').on('change', function () {
    var color = this.value.toString();
    if (item_type == 'back_color') {
        $('#ipcreator-board').css('background-color', color);
        $('#ipcreator-board').css('background-image', '');
    } else if (item_type == 'object') {

        if ($(selectedObject).hasClass("trapezoid")) {
            $(selectedObject).css("border-bottom", "50px solid " + color);
        }
        else if ($(selectedObject).hasClass("trapezoid") || $(selectedObject).hasClass("triangle-up")) {
            $(selectedObject).css("border-bottom", "50px solid " + color);
        }
        else if ($(selectedObject).hasClass("triangle-down")) {
            $(selectedObject).css("border-top", "50px solid " + color);
        }
        else if ($(selectedObject).hasClass("triangle-left")) {
            $(selectedObject).css("border-right", "50px solid " + color);
        }
        else if ($(selectedObject).hasClass("triangle-right")) {
            $(selectedObject).css("border-left", "50px solid " + color);
        }
        else
            $(selectedObject).css("background-color", color);
    }
});


document.addEventListener('click', function (event) {
    var element = event.target;
    if (element.hasClass('draggable') || element.hasClass('resize-drag')) {

    }
});