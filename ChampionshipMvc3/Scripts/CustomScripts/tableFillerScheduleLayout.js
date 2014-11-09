$(document).ready(function () {
    var stringToBeReplaced;
    var stuctureTableWidth;

    $('.inner-table td').each(function () {
        var taken = $(this).html().match(/True/g);
        var free = $(this).html().match(/False/g);

        if (taken == "True") {
            $(this).css("background-color", "red");
            $(".to-be-changed").text("Заето")
        }

        if (free == "False") {
            $(".to-be-changed").text("Свободно")
        }
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