function main() {

    const addCateguryForm = document.querySelector('#addCateguryForm');
    const ImgAddCategury = document.querySelector('#Image');
    const NameAddCategury = document.querySelector('#Name');
    const LiveAlertContainer = document.querySelector('#liveAlertPlaceholder');

    addCateguryForm.addEventListener("submit", async (e) => {
        e.preventDefault();
        var formdata = new FormData();

        formdata.append("Image", ImgAddCategury.files[0]);
        formdata.append("name", NameAddCategury.value);

        const url = "/categury";
        var result = await (await fetch(url, {
            method: "post",
            body: formdata
        })).json();
        console.log(result);

        appendLiveAlert(result.Type, result.message);

        setTimeout(() => {
            window.location.href = "/admin";
        },2500);
    

    });
    function appendLiveAlert(type, message) {
        const wrapper = document.createElement('div')
        wrapper.innerHTML = [
            `<div class="alert alert-${type} alert-dismissible" role="alert">`,
            `   <div>${message}</div>`,
            '   <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>',
            '</div>'
        ].join('')

        LiveAlertContainer.append(wrapper)
    }

}
document.addEventListener("DOMContentLoaded", main);
