﻿$(document).ready(function () {
    $('.toggle-options').bootstrapToggle({
        on: 'On',
        off: 'Off'
    });
});

function onSaveAccountInfo(e) {
    popupBootstrap('Notice', null, 'Account infomation is updated', {}, true, 'Ok', performOk, false, '', null, '30%', null, '30%');
}

function onSavePersonalInfo(e) {
    popupBootstrap('Notice', null, 'Personal infomation is updated', {}, true, 'Ok', performOk, false, '', null, '30%', null, '30%');
}

function onSaveFavouriteInfo(e) {
    popupBootstrap('Notice', null, 'Favourite infomation is updated', {}, true, 'Ok', performOk, false, '', null, '30%', null, '30%');
}