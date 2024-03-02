alert("my code is run");
const sendDataAddCategury = document.getElementById("sendDataAddCategury");
var result;
sendDataAddCategury.addEventListener("click", () => {
    var result =
         fetch("/api/Categury", {
            method: "post",
            headers: {
                "accept": "application/json",
                "content-type": "application/json"
            },
            body: JSON.stringify({
                Name: document.getElementById("Name").value,
                Image: document.getElementById("Image").value
            })
        }).then(Response => Response.json());
    console.log(result);
});