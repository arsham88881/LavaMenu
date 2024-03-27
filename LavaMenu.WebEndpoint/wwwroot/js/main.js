


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
            `<td>${status}</td>`,
            `<td> <button type="button" class="btn activate-categury btn-danger">${statusBtn}</button> </td>`,
            `<td> <button type="button" class="btn btn-warning">تصحیح</button> </td>`,
            `<td> <button type="button" class="btn btn-danger">حذف</button> </td>`
        ].join(''));

        $(".activate-categury").on("click", function () {

            var id = $(this).parent().parent().attr("data-id");
            var datas = new FormData();
            datas.append("ID", id);
            
            const changeCateguryStatusUrl = `/categury/ChangeStatus`;

            var request = $.ajax({
                url: changeCateguryStatusUrl,
                type: "GET",
                //headers: heading,
                processData: false,
                contentType: false,
                //contentType: "multipart/form-data",
                data: datas,
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

        $("#TbodyCateguryAdmin").append(TableRow);
    }

}
/// list categuries on admin panel
function GetAllCateguryAdminPanel() {

    const GetAllCateguryUrl = "/categury/showallcategury";

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
    $('#addCategurySubmit').on("click", async function () {
        //e.preventDefault();

        const categuryUrl = "/categury/AddCategury";
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

                console.log(result);
                appendLiveAlert(result.type, result.message);

                //if (result.isSuccess) {
                //    setTimeout(() => {
                //        window.location.href = "/admin/Categury";
                //    }, 2500);
                //}
            },
            error: function (xhr, status, strmessage) {
                console.log(`status request:  ${status} , str message: ${strmessage}`);
            }
        });
        addCateguryRequest.done(function () { })
    });
    /// show all categury in admin layout

    //$("#manageCategurybtn").on("click", GetAllCateguryAdminPanel);
})


