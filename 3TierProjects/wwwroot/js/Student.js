function getbyID(EmpID) {
    debugger;
    $('#Name').css('border-color', 'lightgrey');
    $('#Email').css('border-color', 'lightgrey');
    $('#PhoneNo').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $('#Class').css('border-color', 'lightgrey');
    $('#StudentId').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Home/getbyID/" + EmpID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.id);
            $('#Name').val(result.name);
            $('#Email').val(result.email);
            $('#PhoneNo').val(result.phoneNo);
            $('#Address').val(result.address);
            $('#Class').val(result.class);
            $('#StudentId').val(result.studentId);

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


function Update() {
    debugger;
    var emp = {
        Id: $('#Id').val(),
        Name: $('#Name').val(),
        Email: $('#Email').val(),
        PhoneNo: $('#PhoneNo').val(),
        Address: $('#Address').val(),
        Class: $('#Class').val(),
        StudentId: $('#StudentId').val(),
    };
    $.ajax({
        url: "/Home/Update",
        data: emp,
        type: "POST",
        success: function (result) {
            ClosePopup();
            location.reload();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function ResetFormControl() {
    debugger;
    $('#Id').val("");
    $('#Name').val("");
    $('#Email').val("");
    $('#PhoneNo').val("");
    $('#Address').val("");
    $('#Class').val("");
    $('#StudentId').val("");
}

function ClosePopup() {
    debugger;
    ResetFormControl();
    $('#myModal').modal('hide');
}