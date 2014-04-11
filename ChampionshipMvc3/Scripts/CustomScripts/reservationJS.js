$(document).ready(function(){

    var selectedHourId;
    var selectedHourInterval;
    var selectedDayId;
    var selectedScheduleId;

    $(".reservationAnchor").click(function () {
        selectedHourInterval = $(this).data('rowid');
        selectedHourId = $(this).data('assigned-id');
        selectedDayId = $(this).data('details');
        selectedScheduleId = $(this).data('options');
    })


    $(".reservationButton").click(function () {
        var url = "/Playfield/ReservePlayfield";
        var retUrl = "/Home/Index"
        var posting = $.post(url, { hourInterval: selectedHourInterval, hourId: selectedHourId, dayId: selectedDayId })
        
        posting.done(function () {
            window.location = "/Playfield/SuccessReservation";
        })
    });

});