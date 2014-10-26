var clickedCell;

$(".first").click(function () {
    clickedCell = $(this);
    $("#myModal").modal('show');
});

$(".even").click(function () {
    clickedCell = $(this);
    $("#myModal").modal('show');
});

$(".not-even").click(function () {
    clickedCell = $(this);
    $("#myModal").modal('show');
});

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