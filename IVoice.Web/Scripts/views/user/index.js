$(document).ready(function () {
    $('.toggle-options').bootstrapToggle({
        on: 'Enable',
        off: 'Disable'
    });
});

function onSaveAccountInfo(e) {
    popupBootstrap('Notice', null, 'Account infomation is updated', {}, true, 'Ok', performOk, false, '', null, '30%', null, false);
}

function onSavePersonalInfo(e) {
    popupBootstrap('Notice', null, 'Personal infomation is updated', {}, true, 'Ok', performOk, false, '', null, '30%', null, false);
}

function onSaveFavouriteInfo(e) {
    popupBootstrap('Notice', null, 'Favourite infomation is updated', {}, true, 'Ok', performOk, false, '', null, '30%', null, false);
}