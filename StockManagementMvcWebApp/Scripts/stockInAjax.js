
$(document).ready(function() {

    $("#CompanyId").change(function () {
        $("#reorderLevelInputBox").val(null);
        $("#availabilityInputBox").val(null);

        var companyId = $("#CompanyId").val();
        var json = { companyId: companyId };
        $("#ItemId").empty();
        $.ajax({
            type: "POST",
            url: "/Stock/GetItemsByCompanyId",
            contentType: "application/json; charset = utf-8",
            data: JSON.stringify(json),
            success: function (data) {
                
                $("#ItemId").append(
                        "<option value=0>--Select Item--</option>"
                    );
                /*console.log(data);*/
                $.each(data, function(key, value) {
                    $("#ItemId").append(
                        "<option value="+value.Id +
                        ">"+ value.Name+"</option>"
                    );
                });

            }
    });

    });


    

    $("#ItemId").change(function () {
        var itemId = $("#ItemId").val();

        console.log(itemId);
        var json = { itemId: itemId };

        $.ajax({
            type: "POST",
            url: "/Stock/GetItemsById",
            contentType: "application/json; charset = utf-8",
            data: JSON.stringify(json),
            success: function (data) {

                $("#reorderLevelInputBox").val(data[0].ReorderLevel);
                $("#availabilityInputBox").val(data[0].Available);
            }
        });

    });





    

    $("#saveStockIn").click(function () {
        /*        console.log("ajax - 1");*/

        var CompanyId = $("#CompanyId").val();
        var ItemId = $("#ItemId").val();
        var ReorderLevel = $("#reorderLevelInputBox").val();
        var Available = $("#availabilityInputBox").val();
        var StockInQuantity = $("#StockInQuantity").val();
        console.log(ReorderLevel);
        console.log(StockInQuantity);


        var json = {
            CompanyId: CompanyId,
            ItemId: ItemId,
            ReorderLevel: ReorderLevel,
            Available: Available,
            StockInQuantity: StockInQuantity
        };

        $.validator.unobtrusive.parse($("#stockForm"));
        $("#stockForm").validate();
        if ($("#stockForm").valid()) {
            $.ajax({
                type: "POST",
                url: "/Stock/StockIn_Save",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(json),
                success: function (data) {
                    /*console.log("ajax - 2");*/
 

                    $("#message").text(data);

                    $("#CompanyId").val(null);
                    $("#ItemId").val(null);
                    $("#reorderLevelInputBox").val(null);
                    $("#availabilityInputBox").val(null);
                    $("#StockInQuantity").val(null);

                }
            });
        } else {
            $("#message").text("");
        }

    });


});