$(document).ready(function() {
    $("#FromDate").datepicker({
        weekStart: 6,
        format: "yyyy-mm-dd",
        daysOfWeekHighlighted: "5,6",
        autoclose: true
    });
    $("#ToDate").datepicker({
        weekStart: 6,
        format: "yyyy-mm-dd",
        daysOfWeekHighlighted: "5,6",
        autoclose: true
    });

    $("#salesViewTable").hide();
    console.log("hello1");
    $("#saleViewButton").click(function() {
        var fromDate = $("#FromDate").val();
        var toDate = $("#ToDate").val();
        
       /* console.log("hello2");
        console.log(fromDate + toDate);*/
        var json = {
            fromDate: fromDate,
            toDate: toDate
        };
        console.log("hello3");
        $.validator.unobtrusive.parse($("#salesViewForm"));
        $("#salesViewForm").validate();
        if ($("#salesViewForm").valid()) {
            console.log("hello4");
            $.ajax({
                type: "POST",
                url: "/Sales/GetSalesBetweenDate",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(json),
                success:function(data) {

                    $("#TableBody").empty();
                    $("#salesViewTable").show();
                    var sl = 1;
                    for (var VAR in data) {
                        $("#TableBody").append("<tr><td>" + (sl++) + "</td><td>" + data[VAR].ItemName + "</td><td>" + data[VAR].Quantity + "</td></tr>");

                    }

                    console.log(data);
                }
            });
        }
});
});