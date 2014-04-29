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

    var isIE11 = !!navigator.userAgent.match(/Trident.*rv\:11\./);

    if (isIE11) {
        $(".buttonInput").css('top', '-4px');
        $(".buttonInput").css('right', '52px');
    }else if(jQuery.browser.msie){
        $(".buttonInput").css('top', '-4px');
        $(".buttonInput").css('right', '52px');
    }else if (jQuery.browser.mozilla){
        $(".buttonInput").css('top', '0px');
    }
});
