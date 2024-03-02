async function main() {

    ///admin nav bar transition click 
    var adminMenu = document.querySelector("#admin-menu");
    var adminMenuButton = document.querySelectorAll(".admin-menu-buttun-grow");

    adminMenuButton.forEach((Element) => {
        Element.addEventListener("click", () => {
            adminMenu.classList.toggle("min-width-admin");
        });
    });
    //admin add categury item request 
   
   
}
document.addEventListener("DOMContentLoaded", main);
