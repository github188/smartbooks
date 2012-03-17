
/**/
$(document).ready(function () {
    /*设置整体框架自动调整宽度和高度*/
    sizechange();

    /*导航菜单特效*/
    menuload();
});

/*窗口大小改变事件*/
$(this).resize(function () {
    sizechange();
});

/*导航菜单特效*/
function menuload() {    
    $(".menuitem").children(".menuelement").hide();
    $(".menuitem:first").children(".menuelement").show();
    $(".menuitem").click(function () {
        $(this).children(".menuelement")
        .slideDown(200).show().end()
        .siblings().children(".menuelement").slideUp(200).hide();
    });
}

/*设置整体框架自动调整宽度和高度*/
function sizechange() {
    var height = $(document.body).height();
    var width = $(document.body).width();
    $("#content").css("height", height - 85);
    $("#left").css("height", height - 87);
    $("#right").css("width", width - 188).css("height", height - 92);
    $("#handerright").css("width", width - 248);
}