$(document).ready(function() {

    $("#itemSaveButton").click(function() {
        var CategoryId = $("#CategoryId").val();
        var CompanyId = $("#CompanyId").val();
        var Name = $("#Name").val();
        var ReorderLevel = $("#ReorderLevel").val();

        /*console.log(ReorderLevel);*/
        if (ReorderLevel == "") {
            ReorderLevel = 0;
            $("#ReorderLevel").val("0");
        }
            

        /*console.log(categoty + company + itemName + reloadLevel);*/

        var json = {
            CategoryId: CategoryId,
            CompanyId: CompanyId,
            Name: Name,
            ReorderLevel: ReorderLevel
        };

        $.validator.unobtrusive.parse($("#itemForm"));
        $("#itemForm").validate();
        if ($("#itemForm").valid()) {

            $.ajax({
                type: "POST",
                url: "/Item/Item_Save",
                contentType: "application/json; charset = utf-8",
                data: JSON.stringify(json),
                success:function(data) {
                    $("#message").text(data);
                }
            });

        } else {
            $("#message").text("");
        }
    });
});