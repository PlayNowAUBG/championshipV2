$(document).ready(function () {
if(jQuery.browser.msie){
        $(".buttonInput").css('top', '-4px');
        $(".buttonInput").css('right', '52px');
    }else if (jQuery.browser.mozilla){
        $(".buttonInput").css('top', '0px');
    }
});
