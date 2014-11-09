$(document).ready(function () {
    //Detecting Internet Explorer version 
    //if it is 11 there will be different kind of rules applied

    var rv = 0.0;
    var ua = navigator.userAgent;
    var re = new RegExp("Trident/.*rv:([0-9]{1,}[\.0-9]{0,})");
    if (re.exec(ua) != null)
        rv = parseFloat(RegExp.$1);
    //Position fix of the search button in mozilla, msie and msie ver. 11
    if (jQuery.browser.mozilla) {
        $(".textBoxInput").css('top', '0px');
        $(".buttonInput").css('top', '-2px');
        $(".buttonInput").css('right', '53px');
        $('.buttonInput input[type="submit"]:active').css('right', '45px');
        $('.buttonInput input[type="submit"]:active').css('width', '40px');
        $('.buttonInput input[type="submit"]:active').css('height', '48px');
        $('.buttonInput input[type="submit"]:active').css('top', '-1.5px');
        $('.buttonInput input[type="submit"]:active').css('right', '49.8px');
    }
});
