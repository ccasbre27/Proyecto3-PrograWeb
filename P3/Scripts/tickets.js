
var sectionSelected = null;

$(document).ready(function () {
    LoadSectionInformation(1);
});



function LoadSectionInformation(selectedId) {

    $.ajax({
        url: '/Home/GetSection',
        type: "GET",
        dataType: "JSON",
        data: { id: selectedId },
        success: function (section) {

            $('#lblPriceSection').text(section.Price);
            $('#lblAvailableSeats').text(section.QuantitySeatsAvailable);
            $('#lblSeatsSold').text(section.QuantitySeatsSold);

            sectionSelected = section;

            LoadTotal();

        },
        error: function (error) {
            sectionSelected = null;
        }

    });
}

function LoadTotal() {
    if (sectionSelected != null) {
        var price = parseInt(sectionSelected.Price);
        var selectedSeats = $('#QuantityToBuy').val();
        var total = price * selectedSeats;

        $('#lblPriceOfSeatsSelected').text(total);
    }
    else {
        $('#lblPriceOfSeatsSelected').text("Debe seleccionar una sección");
    }
}

