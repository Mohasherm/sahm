//function responsive(maxWidth) {
//    if (maxWidth.matches) {
//        $('#btnOpen').show();
//        $('#btnClose').hide();
//        $('#mynavbarToggler').hide();


//    } else {
//        $('#btnOpen').hide();
//        $('#btnClose').hide();
//        $('#mynavbarToggler').show();
//    }

//    $('#btnOpen').click(() => {
//        $('#mynavbarToggler').show();
//        $('#btnClose').show();
//        $('#btnOpen').hide();
//    });

//    $('#btnClose').click(() => {
//        $('#mynavbarToggler').hide();
//        $('#btnOpen').show();
//        $('#btnClose').hide();
//    });
//}

//var maxWidth = window.matchMedia("(max-width: 640px)");

//responsive(maxWidth);
//maxWidth.addListener(responsive);


$(window).resize(function () {
    var $theWindowSize = $(this).width();
    if ($theWindowSize < 641) {
        $('#btnOpen').show();
        $('#btnClose').hide();
        $('#mynavbarToggler').hide();

    } else {
        $('#btnOpen').hide();
        $('#btnClose').hide();
        $('#mynavbarToggler').show();
    }
    $('#btnOpen').click(() => {
        $('#mynavbarToggler').show();
        $('#btnClose').show();
        $('#btnOpen').hide();
    });

    $('#btnClose').click(() => {
        $('#mynavbarToggler').hide();
        $('#btnOpen').show();
        $('#btnClose').hide();
    });
});



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


//const btnMenu = document.getElementById("btnOpen");

//btnMenu.addEventListener("click", (eo) => {
//    $('#mynavbarToggler').show();
//    $('#btnClose').show();
//    $('#btnOpen').hide();
//});
