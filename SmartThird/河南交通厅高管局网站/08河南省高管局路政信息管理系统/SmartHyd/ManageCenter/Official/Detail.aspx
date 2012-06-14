<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="SmartHyd.ManageCenter.Official.Detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>公文详情</title>
    <link href="../../Css/contentPanel.css" rel="stylesheet" type="text/css" />
    <link href="../../Css/patrol.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Scripts/jquery-ui-1.8.18.custom/js/jquery-1.7.1.min.js"></script>
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
                            <img src="../../Images/branch.png" border="0" />当前位置：公文管理 > 公文详情 </span>
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
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <%
                                SmartHyd.BLL.BASE_ARTICLE bll = new SmartHyd.BLL.BASE_ARTICLE();
                                SmartHyd.Entity.BASE_ARTICLE mdoel = new SmartHyd.Entity.BASE_ARTICLE();                                
                                int id = 0;
                                if (Request.QueryString["id"] != null) {
                                    id = Convert.ToInt32(Request.QueryString["id"].ToString());
                                }
                                mdoel = bll.GetEntity(id);                                
                            %>
                            <table class="TableList" width="100%">
                                <tbody>
                                    <!--首选行-->
                                    <tr class="TableHeader">
                                        <td width="798" style="text-align: left; padding-left: 6px;">
                                            <%=mdoel.TITLE %>
                                        </td>
                                    </tr>
                                    <!--标题行-->
                                    <tr class="TableControl">                                       
                                        <td width="798">
                                            <span style="float: left;">
                                                <%=mdoel.SENDCODE %>
                                            </span>
                                            <span style="float: left; margin-left:20px;">创建时间：
                                                <%=mdoel.TIMESTAMP.ToLongDateString() + mdoel.TIMESTAMP.ToLongTimeString()%>
                                            </span>
                                            <span style="float: right; margin: 0px 6px 0px 6px;">分值:
                                                <%=mdoel.SCORE%>
                                            </span>
                                        </td>
                                    </tr>
                                    <!--内容框-->
                                    <tr>                                        
                                        <td width="758" valign="top" style="padding: 20px; overflow: hidden;">
                                            <p><%=mdoel.CONTENT %></p>
                                            <div style="color: #002D93; float: left; border: 1px #4686C6 solid;margin: 10px; padding:4px;">
                                                <%
                                                    SmartHyd.BLL.BASE_ARTICLE_ANNEX bllAnnex = new SmartHyd.BLL.BASE_ARTICLE_ANNEX();
                                                    string[] annex = mdoel.ANNEX.Split(',');
                                                    for (int i = 0; i < annex.Length-1; i++) {
                                                        SmartHyd.Entity.BASE_ARTICLE_ANNEX annexModel = new SmartHyd.Entity.BASE_ARTICLE_ANNEX();
                                                        annexModel = bllAnnex.GetModel(Convert.ToInt32(annex[i].ToString())); 
                                                %>
                                                    <a href='<%= Request.Url.Authority+"/"+annexModel.SERVERPATH + annexModel.SERVERNAME + annexModel.EXTENSION %>'>
                                                    <%=annexModel.SOURCENAME%></a><br />
                                                <%
                                                    } 
                                                %>
                                            </div>
                                        </td>
                                    </tr>
                                    <!--操作栏-->
                                    <tr class="TableControl">
                                        <td width="798">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </tbody>
    </table>
    <asp:Literal ID="litmsg" Visible="false" runat="server"></asp:Literal>
    </form>
</body>
</html>
