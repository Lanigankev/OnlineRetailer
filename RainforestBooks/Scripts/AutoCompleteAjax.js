$(document).ready(function () {
    var url = "/AjaxCompleteSrv.svc";
    $.ajax({
        serviceUrl: url,
        success: $('#autocomplete').autocomplete({
            serviceUrl: '/AjaxCompleteSrv.svc/CompleteSearch',
            onSelect: function (suggestion) {
                alert('You selected: ' + suggestion.value + ', ' + suggestion.data);
            

                console.log("Ajax call succeeded! :D");

            },
            error: function (xhr) {
                console.log("Ajax call failed :'(");
                console.log(xhr);
            }
        })});
});
