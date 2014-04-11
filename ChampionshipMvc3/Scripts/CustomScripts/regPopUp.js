$(document).ready(function () {
    $("#regPlayer").on('click', function () {
        var url = $("#regPlayerModal").data('url');

        $.get(url, function (data) {
            $("#playerContainer").html(data);
        });
    });

    $("#regTeam").on('click', function () {
        var url = $("#regTeamModal").data('url');
        $.get(url, function (data) {
            $("#teamContainer").html(data);
        });
    });
});