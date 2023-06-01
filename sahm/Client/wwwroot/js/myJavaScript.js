
const MyElement = document.getElementById("app");

function ChangeLanguage(rtl) {
    if (rtl) {

        MyElement.dir = "rtl";
        MyElement.lang = "en-us";
    }
    else {

        MyElement.dir = "ltr";
        MyElement.lang = "ar-sy";
    }
}


function removeModal() {
    const modal = document.querySelector(".modal-backdrop.show");

    if (modal) {
        modal.remove();
    }
}
