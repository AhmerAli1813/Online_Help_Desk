$(document).ready(function () {
    $("#FacilityId").on("change", function () {
        console.log("heloo facility");
        var selectedValue = $(this).val();
        $.ajax({
            url: "http://localhost:5238/admin/Tickets/GetAssigeners",
            type: "GET",
            data: { id: selectedValue },
            success: function (data) {
                var secondSelect = $("#AssignerId");
                secondSelect.empty();
                $.each(data, function (index, item) {
                    secondSelect.append($('<option>', {
                        value: item.id,
                        text: item.name
                    }));
                });
            }
        });
    });
});
