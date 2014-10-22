$(document).ready(function () {
    var stringToBeReplaced;
    var stuctureTableWidth;

    $('#structureTable tr').each(function () {
        $(this).css('text-align', 'center');
        $(this).css('color', 'white');
        $(this).css('vertical-align', 'middle');

        var td = $(this).find(".inner-table-holder")

        $(".inner-table").css('width', td.width());
        console.log(stuctureTableWidth);
    });

    $('#scheduleTableID tr').each(function () {
        var $td = $(this).find("td");
        var $tda = $td.find("a");
        var $tds = $(this).find("td").text();
        var checkForFalse = RegExp(/false/i);
     
        if ($tds.match(checkForFalse)) {
            $(this).css("position", "relative");
            $(this).css('background-color', 'green');
            $(this).css('border', '0px');
            $(this).css("text-align", "center");
            $(this).css('vertical-align', 'middle');
            
            $(this).html($(this).html().replace(/False/gi, function (match, tag) {
                return (tag === "a") ? match : "";
            }));
        
        }
        else if (!$tds.match(checkForFalse)) {
            $(this).css("position", "relative");
            $(this).css('background-color', 'red');
            $(this).css('border', '0px');
            $(this).css("text-align", "center");
            $(this).css('vertical-align', 'middle');

            $(this).html($(this).html().replace(/True/gi, function (match, tag) {
                return (tag === "a") ? match : "";
            }));
    
        }
    });

    
});