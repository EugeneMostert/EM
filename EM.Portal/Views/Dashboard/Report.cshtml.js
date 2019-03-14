$(function () {
    $('#reportForm').submit(function (data) {
                
        //$.post("/Dashboard/GetReports",
        //    {},
        var formData = new FormData(this);
        console.log(formData);
        $.ajax({
            url: '@Url.Action("GetReports", "Dashboard")',
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            data: formData,
            datatype: 'json',
            success: function (result) {
                console.log(result)
                //if (result) {
                //    var result = JSON.stringify(data, undefined, 4);
                //    //console.log(result);
                //    //console.log(data);
                //    $('#result').text(result);
                //}
            },
            error: function (error) {
                console.log(error);
                $('#result').html(error);
            }
        });
    });
});