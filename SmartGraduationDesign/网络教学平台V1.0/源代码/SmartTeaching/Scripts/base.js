$(function () {
    $('#tabs').tabs();

    $('input:submit').button();

    var editor;
    KindEditor.ready(function (K) {
        editor = K.create('textarea[name="txtContent"]', {
            items: ['source', 'justifyleft', 'justifycenter', 'justifyright',
                            'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent',
                            'subscript', 'superscript', 'clearhtml', 'quickformat', 'selectall', '|', 'fullscreen', '/',
                            'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
                            'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat'],
            width: "90%",
            height: "380px"
        });
    });
    //隐藏登录面板
    $('#userinfopanel').hide().end();
    //导航菜单
    $('#navmenu').accordion({
        autoHeight: true,
        navigation: true
    });
    /*
    //登录
    $('#ctl00_btnSubmit').click(function () {
    var user = $('#ctl00_txtusername').attr('value');
    var pwd = $('#ctl00_txtpwd').attr('value');
    if (user == '' || pwd == '') {
    $('#dialog').text('用户名或密码不能为空').dialog({
    title: '提示',
    buttons: [{
    text: '确定',
    click: function () { $(this).dialog("close"); }
    }],
    show: 'slide'
    });
    return false;
    }
    $('#loginpanel').hide().end();
    $('#userpanel').show().end();
    return true;
    });
    //重置
    $('#ctl00_btnCancel').click(function () {
    $('#ctl00_txtusername').attr('value', '');
    $('#ctl00_txtpwd').attr('value', '');
    return false;
    });
    //退出登录
    $('#loginout').click(function () {
    $('#loginpanel').show().end();
    $('#userpanel').hide().end();
    $.cookie('username', '');
    return false;
    });

    //校验cookie
    var cookieUserName = $.cookie('username');
    if (cookieUserName == '') {
    $('#loginpanel').show().end();
    $('#userpanel').hide().end();
    }
    else {
    $('#username').text($.cookie('username'));
    $('#usermsg').text('0');
    $('#loginpanel').hide().end();
    $('#userpanel').show().end();
    }

    

    //用户信息面板
    $('#userinfopanel').accordion({
    autoHeight: false,
    navigation: true
    });
    */
});