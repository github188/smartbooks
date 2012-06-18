$(function () {
    //全局选项卡
    $('#tab').tabs();

    //全局按钮
    //$('input:submit').button();

    //$('#alert').hide();
});

/*向页面注册表单验证全局*/
$("#form1").validate({
    errorPlacement: function (error, element) {
        error.appendTo(element.siblings("div:first"));
    }
});
//全选
function selectall(chkcontrol) {
    var chkall = chkcontrol;
    State = chkall.checked;
    elem = document.getElementsByTagName("input");
    for (i = 0; i < elem.length; i++) {
        if (elem[i].type == "checkbox" && elem[i] != chkall.id) {
            if (elem[i].checked != State) {
                elem[i].click();
            }
        }
    }
}
//返回上一页
function GoBack() {
    history.go(-1);
}