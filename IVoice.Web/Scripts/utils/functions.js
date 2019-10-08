function GoToLink(active, UrlToGo) {
    if (active && UrlToGo !== '')
        window.open(UrlToGo);
}
function ToString(valore) {
    if (valore == null)
        return '';
    else return valore;
}
function pad(num) {
    num = num + '';
    return num.length < 2 ? '0' + num : num;
}
function GetAllDateFromJSON(JSON_Date) {
    if (JSON_Date) {
        var date = new Date(parseInt(JSON_Date.replace('/Date(', '')));
        return pad(date.getDate()) + '/' +
            pad(date.getMonth() + 1) + '/' +
            date.getFullYear() + ' - ' +
            pad(date.getHours()) + ':' +
            pad(date.getMinutes()) + ':' +
            pad(date.getSeconds());
    }
    else return '';
}

function formatFileSize(bytes) {
    if (typeof bytes !== 'number') {
        return '';
    }

    if (bytes >= 1000000000) {
        return (bytes / 1000000000).toFixed(2) + ' GB';
    }

    if (bytes >= 1000000) {
        return (bytes / 1000000).toFixed(2) + ' MB';
    }

    return (bytes / 1000).toFixed(2) + ' KB';
}


function popupBootstrap(title, urlContent, textContent, postArgs, showOkButton, okButtonText, callbackOkButton,
                            showCloseButton, closeButtonText, callbackCloseButton, modalWidth, callbackFinishAjax, setMaxHeightScreen) {

    if (urlContent) {
        $.post(urlContent, postArgs)
            .then(function (page) {
                $('.modalBootstrapShared div.modal-body').html(page);
                $('.modalBootstrapShared').modal('show');
            });
        
    } else {
        $('.modalBootstrapShared div.modal-body').html(textContent);
        $('.modalBootstrapShared').modal('show');
    }

    $('.modalBootstrapShared h5.modal-title').text(title);

    var modal = $('.modalBootstrapShared .modal-dialog');
    if (modalWidth) {
        modal.css('width', modalWidth);
    } else {
        modal.removeAttr('style');
    }

    var btnClose = $('.modalBootstrapShared div.modal-footer button#btnDismissBootstrapShared');
    if (showCloseButton) {
        btnClose.prop('value', closeButtonText);
        btnClose.text(closeButtonText);

        if (callbackCloseButton) {
            btnClose.unbind('click');
            btnClose.click(callbackCloseButton);
        }

        btnClose.show();
    }
    else {
        btnClose.hide();
    }

    var btnSave = $('.modalBootstrapShared div.modal-footer button#btnSuccessBootstrapShared');
    if (showOkButton) {
        btnSave.prop('value', okButtonText);
        btnSave.text(okButtonText);
        if (callbackOkButton) {
            btnSave.unbind('click');
            btnSave.click(callbackOkButton);
        }
        btnSave.show();
    } else {
        btnSave.hide();
    }

    if (setMaxHeightScreen == null || setMaxHeightScreen == false) {
        $('.modalBootstrapShared div.modal-body').css('height', '')
    } else {
        $('.modalBootstrapShared div.modal-body').css('heigh', 'calc(100vh - 200px)');
    }
    
    if (callbackFinishAjax)
        callbackFinishAjax();

}

function performOk() {
    $('.modalBootstrapShared').modal('hide');
}

function alertMessage(title, msg) {
    popupBootstrap(title, null, msg, {}, true, 'Ok', performOk, false, '', null, '30%', null, '30%');
}