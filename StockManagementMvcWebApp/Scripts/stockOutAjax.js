
$(document).ready(function () {

    $("#stockOutTable").hide();
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
                $.each(data, function (key, value) {
                    $("#ItemId").append(
                        "<option value=" + value.Id +
                        ">" + value.Name + "</option>"
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

    
    var objectList = [];
    
    $('#addStockOut').click(function () {
        $.validator.unobtrusive.parse($("#stockForm"));
        $("#stockForm").validate();
        if ($("#stockForm").valid()) {
            $("#tableBody").empty();
            $("#stockOutTable").show();

            var CompanyId = $("#CompanyId").val();
            var CompanyName = $("#CompanyId :selected").text();
            var ItemId = $("#ItemId").val();
            var ItemName = $("#ItemId :selected").text();
            var ReorderLevel = $("#reorderLevelInputBox").val();
            var Available = $("#availabilityInputBox").val();
            var StockOutQuantity = $("#StockOutQuantity").val();

            var val = 1;
            for (var i in objectList) {
                if (objectList[i].CompanyId == CompanyId && objectList[i].ItemId == ItemId) {
                    objectList[i].StockOutQuantity =parseInt(objectList[i].StockOutQuantity) + parseInt(StockOutQuantity);
                    val = 0;
                    break;
                }
            }
            if (val) {
                objectList.push({
                    CompanyId: CompanyId,
                    CompanyName: CompanyName,
                    ItemId: ItemId,
                    ItemName : ItemName,
                    ReorderLevel: ReorderLevel,
                    Available: Available,
                    StockOutQuantity: StockOutQuantity
                });
            }
            
            var sl = 1;

            for (var i in objectList) {

                $('#tableBody').append('<tr><td>' + (sl++) + '</td><td>' +
                objectList[i].ItemName + '</td><td>' + objectList[i].CompanyName
                + '</td><td>' + objectList[i].StockOutQuantity + '</td></tr>');


            }

            

            console.log(objectList);

            $("#CompanyId").val(null);
            $("#ItemId").val(null);
            $("#reorderLevelInputBox").val(null);
            $("#availabilityInputBox").val(null);
            $("#StockOutQuantity").val(null);

        }
    });

    $("#damageStockOut").click(function() {
        var actionType = "damage";
        for (item in objectList) {
            objectList[item].ActionType = actionType;
        }
        
        $.ajax({
            type: "POST",
            url: "/Stock/StockOut_SaveAll",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(objectList),
            success: function (data) {
                /*console.log("ajax - 2");*/

                $("#stockOutTable").empty();
                $("#stockOutTable").hide();
                $("#message").text(data);


            }
        });
    });


    $("#lostStockOut").click(function () {
        var actionType = "lost";
        for (item in objectList) {
            objectList[item].ActionType = actionType;
        }
        $.ajax({
            type: "POST",
            url: "/Stock/StockOut_SaveAll",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(objectList),
            success: function (data) {
                /*console.log("ajax - 2");*/

                $("#stockOutTable").empty();
                $("#stockOutTable").hide();
                $("#message").text(data);


            }
        });
    });


    $("#sellStockOut").click(function () {
        var actionType = "sell";
        for (item in objectList) {
            objectList[item].ActionType = actionType;
        }
        $.ajax({
            type: "POST",
            url: "/Stock/StockOut_SaveAll",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(objectList),
            success: function (data) {
                /*console.log("ajax - 2");*/

                $("#stockOutTable").empty();
                $("#stockOutTable").hide();
                $("#message").text(data);


            }
        });
    });


});