$(function() {
    //$("#companyDropDownList").change(function() {
    //    $("#itemDropDownList").empty();
    //    var companyId = $("#companyDropDownList").val();
    //    var jasonData = { compId: companyId };

    //    $.ajax({
    //        type: "POST",
    //        url: '/Stock/GetItemsByCompanyId',
    //        contentType: "application/json; charset=utf-8",
    //        data: JSON.stringify(jasonData),
    //        dataType: "json",
    //        success: function(data) {
    //            $("#itemDropDownList").append('<option value=0>--Select an item--</option>');
    //            $.each(data, function(key, value) {
    //                $("#itemDropDownList").append('<option value=' + value.ItemId + '>' + value.ItemName + '</option>');
    //            });
    //        }
    //    });
    //});

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


//    function ResetValue() {
//        $("#itemDropDownList").empty();
//        $("#companyDropDownList").empty();
//        $("#reorderLevelInputBox").val("");
//        $("#availabilityInputBox").val("");
//        $("#stockInInputBox").val("");
//    }

//    $(document).ready(function() {
//        $("#saveStockIn").click(function() {
//            var url = "@Url.Action("StockInSave","Sto")";
//            debugger;
//            var stockData = {
//                CompanyId: $.trim($("#companyDropDownList").val()),
//                ItemId: $.trim($("#itemDropDownList").val()),
//                StockIn: $.trim($("#stockInInputBox").val())
//            };
//            $.post(url, { StockData: stockData }, function(data) {
//                debugger;
//                if (data != 0 && data > 0) {
//                    var url = "@Url.Action("SaveAvailable", "Home")";
//                    var availableData = {
//                        Available: $.trim($("#availabilityInputBox").val() + $.trim($("#stockInInputBox").val()))
//                    };
//                    $.post(url, { items: availableData }, function(result) {
//                        debugger;
//                        if (result == true) {
//                            alert("All two tables saved successfully");
//                            ResetValue();
//                        }
//                    });
//                }
//            });
//        });
//    });

    //})
})