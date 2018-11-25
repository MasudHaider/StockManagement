

$(document).ready(function () {

    $("#categotyViewTable").hide();

    $("#categorySaveButton").click(function () {
        /*        console.log("ajax - 1");*/
        
        var CategoryName = $("#CategoryName").val();
        var json = { CategoryName: CategoryName };

        $.validator.unobtrusive.parse($("#categoryForm"));
        $("#categoryForm").validate();
        if ($("#categoryForm").valid()) {
            $.ajax({
                type: "POST",
                url: "/Category/Category_Save",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(json),
                success: function(data) {
                    /*console.log("ajax - 2");*/
                    $("#categotyViewTable").show();
                    $("#categotyViewTableBody").empty();

                    /*console.log(data.data);*/
                    var num = 1;
                    $.each(data.data, function(key, value) {
                        $("#categotyViewTableBody").append('<tr>' + '<td>' + (num++) + '<td>' + value.CategoryName + '</td>' + '</tr>');
                    });

                    $("#message").text(data.mess);

                }
            });
        } else {
            $("#message").text("");
        }

    });
});