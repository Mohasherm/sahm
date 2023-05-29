
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

//function btnOpen_Click() {
//    document.querySelector(".mycollapse").style.display = "block";
//    document.querySelector(".btnOpen").style.display = "none";
//    document.querySelector(".btnClose").style.display = "block";
//}

//function btnClose_Click() {
//    document.querySelector(".mycollapse").style.display = "none";
//    document.querySelector(".btnOpen").style.display = "block";
//    document.querySelector(".btnClose").style.display = "none";
//}


//function checkMediaQuery() {
//    // If the inner width of the window is greater then 768px
//    if (window.innerWidth <= 640) {
        
       
//    }
//    else {

//    }
//}

//// Add a listener for when the window resizes
//window.addEventListener('resize', checkMediaQuery);