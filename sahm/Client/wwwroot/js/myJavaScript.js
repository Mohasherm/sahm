const mobileScreen = window.matchMedia("(max-width: 990px )");
function xxx() {
    $(".dashboard-nav-dropdown-toggle").click(function () {
        $(this).closest(".dashboard-nav-dropdown")
            .toggleClass("show")
            .find(".dashboard-nav-dropdown")
            .removeClass("show");
        $(this).parent()
            .siblings()
            .removeClass("show");
    });
    $(".menu-toggle").click(function () {
        if (mobileScreen.matches) {
            $(".dashboard-nav").toggleClass("mobile-show");
        } else {
            $(".dashboard").toggleClass("dashboard-compact");
        }
    });
}

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



//function hideModal() {
//    document.querySelector(".show").remove();
//}