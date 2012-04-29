/// <reference path="Jquery.doc.js"/>
$(function () {
    var x = 10;
    var y = 10;
    // 左侧菜单效果
    $('.Menu').click(function () {
        var $NowMenu = $(this).next('.MenuNote');
        $('.MenuNote').hide(400, function () { });
        if ($NowMenu.is(":visible")) {
            $NowMenu.hide(300, function () { });
        } else {
            $NowMenu.show(500, function () { });
        }
    });

    $("tbody>tr:even").css("background", "#F0F0E8");
    $("tbody>tr").mouseover(function () {
        $(this).css("background", "#DAE9FB");
    });
    $("tbody>tr").mouseout(function () {
        $("tbody>tr:even").css("background", "#F0F0E8");
        $("tbody>tr:odd").css("background", "");
    });

    $("#BtnClassSave").click(function () {
        if ($.trim($("#txtClassName").val()).length == 0) {
            alert("类别名称不能为空...");
            $("#txtClassName").focus();
            return false;
        }
    });
    $(".DelClass").click(function () {
        if (confirm("确定删除该信息？该信息下的所有相关信息都将删除！")) {
            return true;
        }
        return false;
    })
    $("#BtnAllSelect").click(function () {
        if ($("#BtnAllSelect").val() == "全选") {
            $("#BtnAllSelect").val("反选");
            $("[name=CheckMes]:checkbox").attr("checked", true);
        }
        else {
            $("#BtnAllSelect").val("全选");
            $("[name=CheckMes]:checkbox").each(function () {
                //$(this).attr("checked", !$(this).attr("checked"));
                this.checked = !this.checked;
            })
        }
    })
    $("#BtnAllDel").click(function () {
        if (confirm("你确定删除所有选中的信息？")) {
            var checkValue = "";
            $("[name=CheckMes]:checkbox:checked").each(function () {
                if ($.trim($(this).val()).length > 0) {
                    checkValue += "," + $.trim($(this).val());
                }
            })
            if (checkValue.length == 0) {
                alert("你没有选择任何信息，请先选中要删除的信息！");
                return false;
            }
            else {
                $("#HSelectID").val(checkValue.substr(1));
            }
            return true;
        }
        else {
            return false;
        }
    })
    $("td.TIP").mouseover(function (e) {
        this.myTitle = this.title;
        this.title = "";
        var toolTip = "<div id='tooltip'>" + this.myTitle + "</div>";
        $("body").append(toolTip);
        $("#tooltip").css({
            "position": "absolute",
            "padding": "5px",
            "background": "#F0F0E8",
            "border": "1px gray solid",
            "top": (e.pageY + y) + "px",
            "left": (e.pageX + x) + "px"
        }).show(200);
    }).mouseout(function () {
        this.title = this.myTitle;
        $("#tooltip").remove();
    }).mousemove(function (e) {
        $("#tooltip").css({
            "background": "#F0F0E8",
            "padding": "5px",
            "border": "1px gray solid",
            "top": (e.pageY + y) + "px",
            "left": (e.pageX + x) + "px"
        })
    })
    $("#BtnProSave").click(function () {
        if ($("#DDLProClass").val() == null) {
            alert("你还未添加产品的分类信息，无法添加产品...");
            location.href = "M_EditProductClass.aspx";
            return false;
        } else if ($.trim($("#txtProName").val()).length == 0) {
            alert("请填写产品名称信息...");
            $("#txtProName").focus();
            return false;
        } else if ($.trim($("#HImageName").val()) == "noImage.gif") {
            if (!confirm("检测到你没有上传产品图片，你确定不需要上传图片吗？")) {
                $("#UploadImg").click();
                return false;
            }
        }
        if (FCKeditorAPI.GetInstance("txtProNote").GetXHTML().length == 0) {
            if (!confirm("检测到你没有填写任何产品介绍信息，你确定不需要简介信息吗？")) {
                FCKeditorAPI.GetInstance('txtProNote').Focus();
                return false;
            }
        }
    })

    $("#BtnNewsSave").click(function () {
        if ($("#DDLProClass").val() == null) {
            alert("你还未添加资讯的分类信息，无法添加资讯...");
            location.href = "M_EditNewsClass.aspx";
            return false;
        } else if ($.trim($("#txtProName").val()).length == 0) {
            alert("请填写资讯的标题信息...");
            $("#txtProName").focus();
            return false;
        } else if (FCKeditorAPI.GetInstance("txtProNote").GetXHTML().length == 0) {
            if (!confirm("检测到你没有填写任何信息内容，你确定不填写资讯内容吗？")) {
                FCKeditorAPI.GetInstance('txtProNote').Focus();
                return false;
            }
        }
    })
    $("#BtnUpLoad").click(function () {
        if ($.trim($("#UploadImg").val()).length == 0) {
            alert("请先选择要上传的图片...");
            $("#UploadImg").click();
            return false;
        }
    })
    $("#BtnAddPro").click(function () {
        location.href = "M_EditProductInfo.aspx";
    })
    $(".SeeImg").mouseover(function (e) {
        var toolTip = "<div id='tooltip'><img src=../UpLoad/image/Small/" + this.alt + "/></div>";
        $("body").append(toolTip);
        $("#tooltip").css({
            "position": "absolute",
            "padding": "5px",
            "background": "#F0F0E8",
            "border": "1px gray solid",
            "top": (e.pageY + y) + "px",
            "left": (e.pageX + x) + "px"
        }).show(200);
    }).mouseout(function () {
        $("#tooltip").remove();
    }).mousemove(function (e) {
        $("#tooltip").css({
            "background": "#F0F0E8",
            "padding": "5px",
            "border": "1px gray solid",
            "top": (e.pageY + y) + "px",
            "left": (e.pageX + x) + "px"
        })
    })

    $("#BtnLinkSave").click(function () {
        if ($.trim($("#txtWebLinkTitle").val()).length == 0) {
            alert("链接名称不能为空...");
            $("#txtWebLinkTitle").focus();
            return false;
        }
        else if (($.trim($("#txtWebLinkUrl").val()).length == 0) || ($("#txtWebLinkUrl").val() == "http://")) {
            alert("链接网址不能为空...");
            $("#txtWebLinkUrl").focus();
            return false;
        }
        if ($.trim($("#txtWebLinkImage").val()).length == 0) {
            if (!confirm("你确定不链接图片吗？")) {
                $("#txtWebLinkImage").focus();
                return false;
            }
        }
    })
    $(".SeeLinkImage").mouseover(function (e) {
        var toolTip = "<div id='tooltip'><img src=" + this.myTitle + " /></div>";
        $("body").append(toolTip);
        $("#tooltip").css({
            "position": "absolute",
            "padding": "5px",
            "background": "#F0F0E8",
            "border": "1px gray solid",
            "top": (e.pageY + y) + "px",
            "left": (e.pageX + x) + "px"
        }).show(200);
    }).mouseout(function () {
        $("#tooltip").remove();
    }).mousemove(function (e) {
        $("#tooltip").css({
            "background": "#F0F0E8",
            "padding": "5px",
            "border": "1px gray solid",
            "top": (e.pageY + y) + "px",
            "left": (e.pageX + x) + "px"
        })
    })
    $("#BtnLeaveSave").click(function () {
        if ($.trim($("#txtReBackNote").val()).length == 0) {
            alert("你可以选择不回复，但不允许回复空信息...");
            $("#txtReBackNote").focus();
            return false;
        }
    })

    $("#BtnPass").click(function () {
        if ($.trim($("#txtPass").val()).length == 0) {
            alert("解锁码不能为空，请认真对待！！");
            $("#txtPass").focus();
            return false;
        }
        if ($.trim($("#txtCheck").val()).length == 0) {
            alert("验证码不能为空，请认真对待！！");
            $("#txtCheck").focus();
            return false;
        }
    })
    $("#BtnUpdatePass").click(function () {
        if ($.trim($("#txtOldPass").val()).length == 0) {
            alert("原密码不能为空！！");
            $("#txtOldPass").focus();
            return false;
        }
        if ($.trim($("#txtNewPass").val()).length == 0) {
            alert("新密码不能为空！！");
            $("#txtNewPass").focus();
            return false;
        }
        if ($.trim($("#txtCheckPass").val()).length == 0) {
            alert("确认密码不能为空！！");
            $("#txtCheckPass").focus();
            return false;
        }
        if ($.trim($("#txtCheckPass").val()) != $.trim($("#txtNewPass").val())) {
            alert("确认密码与原密码不符，请重新输入确认密码！！");
            $("#txtCheckPass").focus();
            $("#txtCheckPass").val("");
            return false;
        }
    })
    $("#txtProNote").keyup(function () {
        if ($.trim($("#txtProNote").val()).length > 500) {
            $("#txtProNote").val($("#txtProNote").val().substring(0, 499));
        }
    })

    $("#BtnBringSave").click(function () {
        if ($.trim($("#txtProName").val()).length == 0) {
            alert("请填写发布标题...");
            $("#txtProName").focus();
            return false;
        } else if ($.trim($("#HImageName").val()) == "noImage.gif") {
            if (!confirm("检测到你没有上传图片，你确定不需要上传图片吗？")) {
                $("#UploadImg").click();
                return false;
            }
        } else if ($.trim($("#txtProNote").val()).length == 0) {
            alert("简介信息请务必填写...");
            $("#txtProNote").focus();
            return false;
        }
        return true;
    })
});