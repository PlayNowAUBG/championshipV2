$(document).ready(function () {
    var $lat;
    var $long;

    $('#playFieldOwnerTable tr').each(function () {
        $lat = parseFloat($("#item_Lat").val());
        $long = parseFloat($("#item_Long").val());
    });
    function initialize() {
        var myLatlng = new google.maps.LatLng($lat, $long);
        var mapOptions = {
            zoom: 4,
            center: myLatlng
        }
        var map = new google.maps.Map(document.getElementById('map_canvas'), mapOptions);

        var marker = new google.maps.Marker({
            position: myLatlng,
            map: map,
        });
    }

    google.maps.event.addDomListener(window, 'load', initialize);

});
