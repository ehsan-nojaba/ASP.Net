function SuccessMessage(SuccessTxt) {
    Swal.fire({
        icon: 'success',
        title: 'وضعیت ثبت',
        text: SuccessTxt,
    });
}
function ErrorMessage(ErrorTxt) {
    Swal.fire({
        icon: 'error',
        title: 'خطا',
        text: ErrorTxt,
    });
}

$(document).on("click", "#btnAddNew", function () {
    var action = $(this).attr("data-action");
    var modal = $(this).attr("data-model");
    var container = $(this).attr("data-container");
    $.get(action, null, function (rd) {
        $("#" + container).html(rd);
        $("#" + modal).modal('show');
    });
});
$(document).on("click", "#btnAdd", function () {
    var action = $(this).attr("data-action");
    var method = $(this).attr("data-method");
    var frmId = "#" + $(this).attr("data-form-id");
    if (method === "post") {
        var data = $(frmId).serialize();
        $.post(action, data, function (op) {
            if (op.success.toString() == "true") {
                $("#myModal").modal('hide');
                SuccessMessage(op.message);
                BindGrid();
            }
            else {
                ErrorMessage(op.message);
            }
        });
    }
});
$(document).on("keyup", "#AreaName", function () {
    BindGrid();
})
