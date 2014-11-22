var clickedCell;

$(".first").click(function () {
    clickedCell = $(this);
    showModal();
});

$(".even").click(function () {
    clickedCell = $(this);
    showModal();
});

$(".not-even").click(function () {
    clickedCell = $(this);
    showModal();
});

function showModal() {
    var cellText = clickedCell.text();

    if (cellText.match("Свободно")) {
        $("#reservationModal").modal('show');
    }
    else if (cellText.match("Заето")) {
        $("#cancelReservationModal").modal('show');
    }
}

$("#reservationButton").click(function () {
    var hour = clickedCell.find(".hiddenHourClass").val();
    var date = clickedCell.find(".hiddenDateClass").val();
    var name = $("#reservationName").val();
    var phone = $("#reservationPhone").val();

    $.ajax(
        {
            type: 'POST',
            url: "/playfield/reserveplayfield",
            data: {
                hour: hour,
                date: date,
                name: name,
                phone: phone
            },
            success: function(){
                alert("Success");
            }
        });
});

$("#confirmButton").click(function () {
    var hour = clickedCell.find(".hiddenHourClass").val();
    var date = clickedCell.find(".hiddenDateClass").val();

    $.ajax(
        {
            type: 'POST',
            url: "/playfield/cancelreservation",
            data: {
                hour: hour,
                date: date,
            },
            success: function () {
                alert("Success");
            }
        });


});