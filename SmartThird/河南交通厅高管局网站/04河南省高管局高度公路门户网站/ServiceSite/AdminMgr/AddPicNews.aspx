<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddPicNews.aspx.cs" Inherits="AdminMgr_AddPicNews"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加图片新闻</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        fieldset
        {
            border: 1px solid #448CCB;
            width: 770px;
            margin: auto;
        }
        legend
        {
            font-size: 12px;
            color: #448CCB;
        }
    </style>
    <script type="text/javascript" src="../Script/jquery-1.6.2.js"></script>
    <script type="text/javascript" src="../Script/kindeditor-4.0.5/kindeditor-min.js"></script>
    <script type="text/javascript" src="../Script/kindeditor-4.0.5/lang/zh_CN.js"></script>
    <script src="../Script/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            var editor;
            KindEditor.ready(function (K) {
                editor = K.create('textarea[name="t_contents"]', {
                    items: ['source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'cut', 'copy',
                            'paste', 'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
                            'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent',
                            'subscript', 'superscript', 'clearhtml', 'quickformat', 'selectall', '|', 'fullscreen', '/',
                            'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
                            'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', '|', 'image',
                            'flash', 'media', 'insertfile', 'table', 'hr', 'emoticons', 'map', 'code', 'pagebreak',
                            'link', 'unlink', '|'],
                    width: "100%",
                    height: "350px",
                    resizeMode: 1,
                    uploadJson: '../api/upload_json.ashx',
                    fileManagerJson: '../api/file_manager_json.ashx',
                    allowFileManager: true
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="righttopnavbg">
        编辑图片新闻</div>
    <div class="divContent">
        <fieldset>
            <legend>编辑图片新闻</legend>
            <table width="750px" border="0" align="center" cellpadding="3" cellspacing="0" bordercolor="#B8C9D6"
                style="border-collapse: collapse">
                <tr>
                    <td width="120" height="30" align="right">
                        新闻标题：
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTitle" runat="server" Width="524px" CssClass="InputBorderStyle"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle"
                            ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td width="120" height="30" align="right">
                        发布日期：
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtdate" runat="server" CssClass="InputBorderStyle" Width="200px"
                            onFocus="WdatePicker({dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="30" align="right">
                        图片上传：
                    </td>
                    <td width="344">
                        <asp:FileUpload ID="FileUploadImg" runat="server" Width="331px" CssClass="InputBorderStyle" />
                    </td>
                    <td width="278">
                        <asp:Image ID="ImgNews" runat="server" Width="150px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="height: 340px">
                        新闻简介：
                    </td>
                    <td colspan="2" style="height: 340px">
                        <textarea name="t_contents"><%=ViewState["strContent"]%></textarea>
                        <%-- <textarea name="t_contents" style="display: none" class="TextAreaStyle"><%= ViewState["strContent"]%></textarea>
                        <iframe name="eWEditor" src="edithtml/ewebeditor.htm?id=t_contents&style=blue" frameborder="0"
                            scrolling="no" width="100%" height="300" id="IFRAME1"></iframe>--%>
                    </td>
                </tr>
                <tr>
                    <td height="30">
                        &nbsp;
                    </td>
                    <td colspan="2">
                        <asp:ImageButton ID="btnSaveImage" runat="server" ImageUrl="~/AdminMgr/images/btnupload.jpg"
                            OnClick="btnSaveImage_Click" />
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td height="40" colspan="3">
                        &nbsp;新闻图片上传：上传的图片要能够展示新闻要点，图片宽高比例为4:3、最佳宽度为600像素，支持gif,jpg图片格式，为了保证前台页面的正常显示，至少要添加1条图片新闻。
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    </form>
</body>
</html>
