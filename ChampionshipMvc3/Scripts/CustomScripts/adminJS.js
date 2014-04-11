$(document).ready(function () {
    $(".approveButtonClass").on('click', approvePlayer);

    function approvePlayer() {
        var playerJsID = $(this).data('assigned-id');

        $.ajax({
            url: "/Admin/ApprovePlayer",
            type: "POST",
            cache: false,
            data: { playerID: playerJsID },
            success: function () { alert("Player approved") },
            error: function () { alert("error has occured"); }
        });
    }
});