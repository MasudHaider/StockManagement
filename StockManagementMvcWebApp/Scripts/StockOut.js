$(function() {
    $("#itemDropDownList").change(function() {
        $("#reorderLevelInputBox").val("");
        $("#availabilityInputBox").val("");

        var itemSelected = $("#itemDropDownList").val();
        var jsonData = { ItemId: itemSelected };

        $.ajax({
            type: "POST",
            url: '/Stock/GetItemsById',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(jsonData),
            dataType: "json",
            success: function(data) {
                $("#reorderLevelInputBox").val(data[0].ReorderLevel);
                $("#availabilityInputBox").val(data[0].Available);
            }

        });
        if (itemSelected == 0) {
            $("#reorderLevelInputBox").val("");
            $("#availabilityInputBox").val("");
        }
        return false;
        
        
    });
        
        $("#stockOutTable").hide();
        $('#addStockOut').click(function() {
            $("#stockOutTable").show();
            $('#tableBody').append('<tr><td>'+$("#").val()+'</td><td>'+$("#itemDropDownList").val()+'</td><td>'+$("#companyDropDownList").val()+'</td><td>'+$("#stockOutInputBox").val()+'</td></tr>');
            });
});



    
