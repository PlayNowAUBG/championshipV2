$(document).ready(function () {

    var myLatlng = new google.maps.LatLng(42.011574, 23.092546);
    var mapOptions = {
        zoom: 16,
        center: myLatlng
    }
    var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
    var marker = new google.maps.Marker({
        position: myLatlng,
        map: map,
        title: 'Риа Спорт'
    });
});
