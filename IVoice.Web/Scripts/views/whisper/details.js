function openFile(UniqueId, FileName) {
    window.open("/upload/" + UniqueId + "/" + FileName);
    return false;
}

$(document).ready(function () {
    $('.table').DataTable({
        searching: false,
        ordering: true,
        "bLengthChange": false,
        paging: false
    });

});