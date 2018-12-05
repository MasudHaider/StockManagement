


$(document).ready(function () {
    $("#itemsSummaryTable").hide();

    var json = "";
    var companies;
    $.ajax({
        type: "POST",
        url: "/Company/GetAllCompanies",
        contentType: "application/json; charset = utf-8",
        data: JSON.stringify(json),
        success: function (data) {
            companies = data;
            console.log(companies);
        }

        /*console.log(json);*/


    });

    
    

    $("#searchItemButton").click(function () {
        $("#tableBody").empty();
        $("#itemsSummaryTable").show();

        var CompanyId = $("#CompanyId").val();
        var CategoryId = $("#CategoryId").val();
        
        var json = {
            CompanyId: CompanyId,
            CategoryId: CategoryId
        };
        /*console.log(json);*/

        $.ajax({
            type: "POST",
            url: "/Item/ItemSearchView",
            contentType: "application/json; charset = utf-8",
            data: JSON.stringify(json),
            success:function(data) {


                var sl = 1;
                for (var i in data) {
                    var companyName="";
                    for (var VAR in companies) {
                        if (companies[VAR].CompanyId == data[i].CompanyId) {
                            companyName = companies[VAR].CompanyName;
                            /*console.log(companyName);*/
                        }
                    }
                    $("#tableBody").append("<tr><td>" + (sl++) + "</td><td>" + data[i].Name + "</td><td>" + companyName + "</td><td>" + data[i].Available + "</td><td>" + data[i].ReorderLevel + "</td></tr>");
                };
                }
               
                /*console.log(json);*/
            

        });
    });
});