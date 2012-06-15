<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReplySource.aspx.cs" Inherits="SmartHyd.ManageCenter.Official.ReplySource" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>回复发文</title>
    <link href="../../Css/contentPanel.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js"></script>
    <script src="../../Scripts/kindeditor-4.0.5/kindeditor-min.js" type="text/javascript"></script>
    <script src="../../Scripts/kindeditor-4.0.5/lang/zh_CN.js" type="text/javascript"></script>
    <script type="text/javascript">
        /*编辑器*/
        KindEditor.ready(function (K) {
            /*发文内容*/
            var editor = K.create('textarea[id="txtContent"]', {
                items: ['source', '|', 'undo', 'redo', '|', 'cut', 'copy',
                            'paste', 'plainpaste', 'wordpaste'],
                width: "99%",
                height: "260px"
            });
        });


        var MAXFILES = 5;        //文件计数器         
        var fileCount = 0;
        function addAttach(noAlert) {
            if (fileCount >= MAXFILES && !noAlert) { alert("最多只能添加" + MAXFILES + "个附件！"); return; }

            var fileSectionDiv = document.getElementById("files");
            var fileItemDiv = document.createElement("div");
            fileCount++;
            var content = "<input type='file' onchange='return addAttach(true);' name='fileUpload'" + fileCount + "> <a href='#' onclick='return delAttach(\"" + fileCount + "\")' class='delete_attach' >移除附件</a>";
            fileItemDiv.id = "fileItemDiv" + fileCount;
            fileItemDiv.innerHTML = content;
            fileSectionDiv.appendChild(fileItemDiv);
            return false;
        }

        function delAttach(fileIndex) {
            var fileSectionDiv = document.getElementById("files");
            var fileItemDiv = document.getElementById("fileItemDiv" + fileIndex);
            fileSectionDiv.removeChild(fileItemDiv);
            fileCount--;
            return false;
        } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 100%">
        <tr>
            <td style="height: 24px;">
                <div id="menu">
                    <div class="OperateNote">
                        <span id="buttons">
                            <img src="../../Images/branch.png" border="0" />当前位置：公文管理 > 发文回复 </span>
                    </div>
                    <div class="ReturnPreview">
            <span id="buttons1" onclick="javascript:history.go(-1);">
                <img src="../../Images/back.png" alt="" border="0" />返回上一页面</span></div>
                </div>
            </td>
        </tr>
    </table>
    <table class="TableBlock" width="100%" align="center" cellpadding="0" cellspacing="0">
        <tbody>

            <tr>
                <td nowrap="nowrap" class="TableData">
                    发文标题:
                </td>
                <td class="TableData">
                    <asp:HiddenField ID="hidSrcCode" runat="server" Value="-1" />
                    <asp:HyperLink ID="hnkSourceTitle" runat="server">查看原文</asp:HyperLink>
                </td>
            </tr>

            <tr>
                <td nowrap="nowrap" class="TableData">
                    回复标题:
                </td>
                <td class="TableData" style="width: 100%;">                    
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="input" Width="99%" MaxLength="80">
                    </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td nowrap="nowrap" class="TableData">
                    回复正文:
                </td>
                <td class="TableData">
                    <asp:TextBox ID="txtContent" runat="server" Width="100%" TextMode="MultiLine" Height="300"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td nowrap="nowrap" class="TableData">
                    附件文档:
                </td>
                <td class="TableData">
                    <a id="addAttach_a" onclick="return addAttach(false);" href="#" class="add_attach">添加附件</a>
                    <div id="files">
                    </div>
                </td>
            </tr>
            <tr>
                <td nowrap="nowrap" class="TableData">
                    高级选项:
                </td>
                <td class="TableData">
                    <asp:CheckBox ID="chkSMSAlert" runat="server" Text="短信提醒"/>
                </td>
            </tr>
            <!--操作按钮-->
            <tr class="TableControl" align="center">
                <td colspan="3" nowrap="nowrap">
                    <asp:Button ID="btnSubmit" runat="server" Text="回复" CssClass="Button" 
                        onclick="btnSubmit_Click"  />
                    <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="Button" 
                        onclick="btnCancel_Click"  />
                </td>
            </tr>
        </tbody>
    </table>
    <asp:Literal ID="litmsg" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
