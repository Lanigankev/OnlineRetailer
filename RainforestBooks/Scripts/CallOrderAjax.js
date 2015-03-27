$(document).ready(function viewOrders() {
    var url = "http://localhost:52915/CallOrdersJSON.svc/GetCustomerOrders";
    $.ajax({
        url: url,
        type: "GET",
        success: function (data) {
            var returnedData = data;
            console.log("Ajax call succeeded! :D");
            console.log(returnedData);

            var numberOfObjects = returnedData.length;
            var htmlTable = [];
            htmlTable.push("<table class='table table-striped'>");
            htmlTable.push("<tr>");
            htmlTable.push("<th>Last Name</th>")
            htmlTable.push("<th>First Name</th>")
            htmlTable.push("<th>Email</th>")
            htmlTable.push("<th>No. of Items</th>")
            htmlTable.push("<th>Order Id</th>")
            htmlTable.push("<th>Total Cost</th>")
            htmlTable.push("</tr>");

            for (i = 0; i < numberOfObjects; i++) {
                // console.log(returnedData[i].id);
                htmlTable.push("<tr>");

                htmlTable.push("<td>" + returnedData[i].ThisCustomer.LastName + "</td>");
                htmlTable.push("<td>" + returnedData[i].ThisCustomer.FirstName + "</td>");
                htmlTable.push("<td>" + returnedData[i].ThisCustomer.Email + "</td>");
                htmlTable.push("<td>" + returnedData[i].ThisOrder.TotalNoItems + "</td>");
                htmlTable.push("<td>" + returnedData[i].ThisOrder.OrderId + "</td>");
                htmlTable.push("<td>" + parseFloat(returnedData[i].ThisOrder.TotalOrderCost.toFixed(2)) + "</td>");
     
                htmlTable.push("</tr>");
            }
            htmlTable.push("</table>");
            $('#orderTable').append(htmlTable.join(" "));


        },
        error: function (xhr) {
            console.log("Ajax call failed :'(");
            console.log(xhr);
        }
    });
});
