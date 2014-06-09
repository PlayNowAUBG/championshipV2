$(document).ready(function () {
    var $lat = 0;
    var $long = 0;
    var rowCounter = 0;
    var changeID = "map_canvas";
    var destArrayLat = [];
    var destArrayLong = [];

    function initialize() {

        $('#playFieldOwnerTable tr').each(function () {

            $(this).find('input').each(function () {
                if ($(this).attr("id") == "item_Long") {
                    $lat = parseFloat($(this).val());
                    destArrayLat.push(parseFloat($(this).val()));
                }
                console.log('foo');
                if ($(this).attr("id") == "item_Lat") {
                    $long = parseFloat($(this).val());
                    destArrayLong.push(parseFloat($(this).val()));
                }

            });
        });

    $('#playFieldOwnerTable tr').each(function () {

        $(this).find('div').each(function () {
            if ($(this).attr("id") == "map_canvas") {

                $(this).attr("id", "map_canvas" + rowCounter);
                $(this).css("border", "solid");
                $(this).css("border-width", "4px");
                $(this).css("border-color", "#808080");
                $(this).css("width", "200px");
                $(this).css("height", "150px");
                $(this).css("margin", "0 auto");

            $lat = destArrayLat[rowCounter];
            $long = destArrayLong[rowCounter];

            var myLatlng = new google.maps.LatLng($long, $lat);
            var mapOptions = {
                zoom: 15,
                center: myLatlng
            }
                      
            var map = new google.maps.Map(document.getElementById("map_canvas" + rowCounter), mapOptions);
            console.log(destArrayLat[0]);
            rowCounter = rowCounter + 1;
            var marker = new google.maps.Marker({
                position: myLatlng,
                map: map,
            });
            };
        });
        });
    }

    google.maps.event.addDomListener(window, 'load', initialize);
});
