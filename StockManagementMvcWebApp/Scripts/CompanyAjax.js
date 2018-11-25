

$(document).ready(function () {

    $("#companyViewTable").hide();

    $("#companySaveButton").click(function () {
        /*        console.log("ajax - 1");*/

        var CompanyName = $("#CompanyName").val();
        var json = { CompanyName: CompanyName };

        $.validator.unobtrusive.parse($("#companyForm"));
        $("#companyForm").validate();
        if ($("#companyForm").valid()) {
            $.ajax({
                type: "POST",
                url: "/Company/Company_Save",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(json),
                success: function (data) {
                    /*console.log("ajax - 2");*/
                    $("#companyViewTable").show();
                    $("#companyViewTableBody").empty();

                    /*console.log(data.data);*/
                    var num = 1;
                    $.each(data.data, function (key, value) {
                        $("#companyViewTableBody").append('<tr>' + '<td>' + (num++) + '<td>' + value.CompanyName + '</td>' + '</tr>');
                    });

                    $("#message").text(data.mess);

                }
            });
        } else {
            $("#message").text("");
        }

    });
});