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

$(document).on("click", "#btnAdd", function () {
    var sendingUrl = $("#btnAdd").attr("data-action");
    var method = $("#btnAdd").attr("data-method");
    var frmId = "#" + $("#btnAdd").attr("data-form-id");
    if (method === "post") {
        var sendingData = $(frmId).serialize();
        $.post(sendingUrl, sendingData, function (op) {
            if (op.success.toString() == "true") {
                $("#myModal").modal('hide');
                SuccessMessage(op.message);
                BindGrid();
                RefSearchGrid();
            }
            else {
                ErrorMessage(op.message);
            }
        });
    }
});
$(document).on("click", "#btnAddNew", function () {
    var sendingUrl = $("#btnAddNew").attr("data-action");
    var container = $("#btnAddNew").attr("data-container");
    var modal = $("#btnAddNew").attr("data-modal");
    $.get(sendingUrl, null, function (rd) {
        $("#" + container).html(rd);
        $("#" + modal).modal('show');
    });
});

$(document).on("keyup", "#CategoryName", function () {
    BindGrid();
});

$(document).on("change", "#ParentId", function () {
    BindGrid();
});

$(document).on("click", "#btnDelete", function () {
    if (confirm("Are You Sure ?")) {
        var sendingUrl = $("#btnDelete").attr("data-action");
        var method = $("#btnDelete").attr("data-method");
        var id = $("#btnDelete").attr("data-id");
        if (method === "post") {
            var sendingData = "id=" + id;
            $.post(sendingUrl, sendingData, function (op) {
                if (op.success.toString() == "true") {
                    var rowId = "#tr_" + id;
                    $(rowId).slideUp(500);
                    SuccessMessage(op.message);
                    BindGrid();
                }
                else {
                    ErrorMessage(op.message);
                }
            });
        }
    }
});