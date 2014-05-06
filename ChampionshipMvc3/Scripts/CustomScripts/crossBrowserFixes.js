$(document).ready(function () {
    //Detecting Internet Explorer version 
    //if it is 11 there will be different kind of rules applied

    var rv = 0.0;
    var ua = navigator.userAgent;
    var re = new RegExp("Trident/.*rv:([0-9]{1,}[\.0-9]{0,})");
    if (re.exec(ua) != null)
        rv = parseFloat(RegExp.$1);

    //Position fix of the search button in mozilla, msie and msie ver. 11
    if (jQuery.browser.msie) {
        $(".buttonInput").css('top', '-4.2px');
        $(".buttonInput").css('right', '52px');
    }

    if (rv == 11) {
        $(".buttonInput").css('top', '-5px');
        $(".buttonInput").css('right', '51.4px');
    }

    if (jQuery.browser.mozilla) {
        $(".textBoxInput").css('top', '0px');
        $(".buttonInput").css('top', '-4px');
        $(".buttonInput").css('right', '45px');
        $(".buttonInput").css('width', '40px');
        $(".buttonInput").css('height', '48px');
        $(".buttonInput:active").css('right', '45px');
        $(".buttonInput:active").css('width', '40px');
        $(".buttonInput:active").css('height', '48px');
        $(".buttonInput:active").css('top', '-1.5px');
        $(".buttonInput:active").css('right', '49.8px');
    }

    //Depth of button push fix in msie
});
