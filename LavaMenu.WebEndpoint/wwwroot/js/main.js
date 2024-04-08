


///alert in adminLayout page
function appendLiveAlert(type, message) {
    const wrapper = $('<div> </div>');

    wrapper.html([
        `<div class="alert alert-${type} alert-dismissible" role="alert">`,
        `   <div>${message}</div>`,
        '   <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>',
        '</div>'
    ].join(''));

    $('#liveAlertPlaceholder').append(wrapper);
}
/// create list categury item
function createCateguryItemAdminPanel(result) {

    for (let i = 0; i < result.length; i++) {

        const TableRow = $("<tr> </tr>");

        TableRow.attr("data-id", result[i].categuryId);

        var status = result[i].isAvailable === true ? "فعال" : "غیر‌فعال";
        var statusBtn = status === "فعال" ? "غیر‌فعال" : "فعال";
        TableRow.html([
            `<th scope="row">${i + 1}</th>`,
            `<td>‌ <img src="/${result[i].srcCategury}" alt="${result[i].categuryName}" width="100" height="100"> </td>`,
            `<td>${result[i].categuryName}</td>`,
            `<td class="categuryStatus">${status}</td>`,
            `<td> <button type="button" class="btn activate-categury btn-danger">${statusBtn}</button> </td>`,
            `<td> <button type="button" class="btn btn-warning edit-categury">تصحیح</button> </td>`,
            `<td> <button type="button" class="btn btn-danger">حذف</button> </td>`
        ].join(''));
        $("#TbodyCateguryAdmin").append(TableRow);

        $(TableRow).on("click", "button.activate-categury", function () {

            var id = $(this).parent().parent().attr("data-id");

            const changeCateguryStatusUrl = `/api/categury/ChangeStatus?id=${id}`;

            var request = $.ajax({
                url: changeCateguryStatusUrl,
                type: "GET",
                success: function (result) {
                    if (result) {
                        GetAllCateguryAdminPanel();
                    }
                },
                error: function (xhr, status, strMessage) {
                    console.log(`status request:  ${status} , str message: ${strMessage}`);
                }

            });
            request.done(function () { });
        })

        $(TableRow).on("click", "button.edit-categury", function () {

            var id = $(this).parent().parent().attr("data-id");

            const EditCateguryUrl = `/api/categury/GetSingleCategury?id=${id}`;

            var request = $.ajax({
                url: EditCateguryUrl,
                type: "GET",
                success: function (result) {
                    if (result) {
                        console.log(result);
                        $("#EditCateguryTitle").val(result.categuryName);
                        $("#EditCategurySubmit").attr("data-Id", result.categuryId)
                        $("#EditCateguryBtnModal").modal("show");
                    }
                },
                error: function (xhr, status, strMessage) {
                    console.log(`status request:  ${status} , str message: ${strMessage}`);
                }

            });
            request.done(function () { });
        })
    }

}
/// activate categury function 

/// list categuries on admin panel
function GetAllCateguryAdminPanel() {

    const GetAllCateguryUrl = "/api/categury/GetAllCategury";
    $("#TbodyCateguryAdmin").empty();
    var request = $.ajax({
        url: GetAllCateguryUrl,
        type: "GET",
        processData: false,
        contentType: false,
        success: function (result) {
            console.log(result);
            createCateguryItemAdminPanel(result)
        },
        error: function (xhr, status, strMessage) {
            console.log(`status request:  ${status} , str message: ${strMessage}`);
        },
    });
    request.done(function (xhr, status, message) { })
}


$(document).ready(function () {

    /// add categury concept
    $('#addCategurySubmit').on("submit", async function (e) {
        e.preventDefault();

        const categuryUrl = "/api/categury/AddCategury";
        const ImgAddCategury = document.querySelector('#AddCateguryImage');

        var formdata = new FormData();
        formdata.append("Image", ImgAddCategury.files[0]);
        formdata.append("name", $('#addCateguryTitle').val());

        var addCateguryRequest = $.ajax({
            url: categuryUrl,
            type: "POST",
            contentType: false,
            processData: false,
            data: formdata,
            success: function (result) {

                // console.log(result);
                appendLiveAlert(result.type, result.message);

                if (result.isSuccess) {
                    setTimeout(() => {
                        GetAllCateguryAdminPanel();
                    }, 2500);
                }
            },
            error: function (xhr, status, strmessage) {
                console.log(`status request:  ${status} , str message: ${strmessage}`);
            }
        });
        addCateguryRequest.done(function () { })
    });
    $('#EditCategurySubmit').on("submit", async function (e) {
        e.preventDefault();

        var id = $('#EditCategurySubmit').attr("data-Id");
        var name = $('#EditCateguryTitle').val();
        const EditcateguryUrl = `/api/Categury/EditCategury?id=${id}&name=${name}`;
        
        const ImgEditCategury = document.querySelector("#EditCateguryImage").files[0];

        var input = new FormData();
        input.append("Image", ImgEditCategury)

        var EditCateguryRequest = $.ajax({
            type: "PUT",
            url: EditcateguryUrl,
            contentType: false,
            processData: false,
            enctype: "multipart/form-data",
            data: input,
            success: function (result) {

                console.log(result);

                appendLiveAlert(result.type, result.message);

                if (result.isSuccess) {
                    GetAllCateguryAdminPanel();
                }
            },
            error: function (xhr, status, strmessage) {
                console.log(`status request:  ${status} , str message: ${strmessage} `);
                console.log(xhr);
            }
        });
        EditCateguryRequest.done(function () { })
    });

})


