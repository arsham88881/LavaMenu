
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

$(document).ready(function () {

    $('#addCateguryForm').on("submit", async function (e) {
        e.preventDefault();

        const categuryUrl = "/categury/AddCategury";
        const ImgAddCategury = document.querySelector('#Image');

        var formdata = new FormData();
        formdata.append("Image", ImgAddCategury.files[0]);
        formdata.append("name", $('#Name').val());

        var addCateguryRequest = $.ajax({
            url: categuryUrl,
            type: "POST",
            contentType: false,
            processData: false,
            data: formdata,
            success: function (result) {

                console.log(result);
                appendLiveAlert(result.type, result.message);

                if (result.isSuccess) {
                    setTimeout(() => {
                        window.location.href = "/admin/Categury";
                    }, 2500);
                }
            },
            error: function (xhr, status, strmessage) {
                console.log(`status request:  ${status} , str message: ${strmessage}`);
            }
        });
        addCateguryRequest.done(function () { })
    });

})