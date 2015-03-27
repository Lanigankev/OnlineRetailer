$(document).ready(function () {
    var url = "http://localhost:52915/CallOrdersJSON.svc/GetCustomerOrders";
    $.ajax({
        url: url,
        type: "GET",
        success: function (data) {
            var returnedData = data;
            console.log("Ajax call succeeded! :D");
            console.log(returnedData);
        },
        error: function (xhr) {
            console.log("Ajax call failed :'(");
            console.log(xhr);
        }
    });
});
