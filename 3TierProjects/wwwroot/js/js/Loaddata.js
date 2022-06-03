$('#loaddata').click(function () {

    $('#loading-div-background').show();

    Promise.resolve($.ajax({
        type: "GET",
        url: '/Home/GetData',
        contentType: false,
        processData: false
    })).then(function (result) {
        if (result) {
            $('#loading-div-background').hide();
            $("#tableheader").show()
            var row = "";
            $.each(result, function (index, item) {
                row += "<tr><td><input type='checkbox'id='chk_"
                    + item + "'/></td><td>" + item + "</td><td>"
                    + item + "</td><td>" + item + "</td><td>" + item
                    + "</td><td>" + item + "</td></tr> ";
            });
            $("#tablebody").html(row);
        }
    }).catch(function (e) {
        console.log(e);
    });
});