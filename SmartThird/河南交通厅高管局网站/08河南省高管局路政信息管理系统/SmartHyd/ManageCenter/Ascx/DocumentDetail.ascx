<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DocumentDetail.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.DocumentDetail" %>

<%
    int id = Convert.ToInt32(Request.QueryString["id"].ToString());
    System.Data.DataTable dt = new System.Data.DataTable();
    SmartHyd.BLL.BASE_ARTICLE bll = new SmartHyd.BLL.BASE_ARTICLE();
    dt = bll.GetDetail(id);
%>

<div id="tab">
    <ul id="menu">
        <li><a href="#tabs-1">公文详情查看</a></li>
    </ul>
    <!--详细信息开始-->
    <div id="tabs-1">
        <span class="big3">公文详情</span>
        <table class="TableList" width="961">
            <tbody>
                <!--首选行-->
                <tr class="TableHeader">                    
                    <td width="798" colspan="2" style="text-align: left; padding-left: 6px;">
                        <%=dt.Rows[0]["dptname"].ToString()%>
                    </td>
                </tr>
                
                <!--标题行-->
                <tr class="TableControl">
                    <td width="163" align="center">
                        <%=dt.Rows[0]["status"].ToString()%>
                    </td>
                    <td width="798">
                        <span style="float: left;">
                            发表于：<%=dt.Rows[0]["TIMESTAMP"].ToString()%>
                        </span>
                        <span style="float: right; margin: 0px 6px 0px 6px;">
                            分值:<%=dt.Rows[0]["score"].ToString()%>
                        </span>
                    </td>
                </tr>
                <!--内容框-->
                <tr>
                    <td valign="top" width="163" style="background-color: #E7F0FB;">
                        <img style="width: 111px; height: 122px; margin: 10px 20px 10px 20px; padding: 6px;
                            background-color: #FFFFFF;" src="../../Images/user-ico.jpg" />
                        <table style="color: #444; height: 20px;">
                            <tr>
                                <td colspan="2" align="center">
                                    <%=dt.Rows[0]["username"].ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    工作证号:
                                </td>
                                <td>
                                    <%=dt.Rows[0]["jobnumber"].ToString()%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    联系电话:
                                </td>
                                <td>
                                    <%=dt.Rows[0]["phone"].ToString()%>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="758" valign="top" style="padding: 20px; overflow: hidden;">
                        <h2><%=dt.Rows[0]["title"].ToString()%></h2>
                        <h5><%=dt.Rows[0]["sendcode"].ToString()%></h5>
                        <p><%=dt.Rows[0]["content"].ToString()%></p>
                        <div style="color: #002D93; float:left; border:1px #4686C6 solid; padding:5px; margin:10px;">
                            <h4>
                                <a href='<%=dt.Rows[0]["annex"].ToString()%>'>
                                    <%="附件: "+dt.Rows[0]["title"].ToString()%>
                                </a>
                            </h4>
                        </div>
                    </td>
                </tr>

                <!--操作栏-->
                <tr class="TableControl">
                    <td nowrap="nowrap" width="163" align="center">
                        <a href="#">发送消息</a> <a href="#">发送邮件</a>
                    </td>
                    <td width="798">
                        <asp:Button ID="btnReply" runat="server" Text="回复" CssClass="BigButtonA" />
                        <asp:Button ID="btnEdit" runat="server" Text="编辑" CssClass="BigButtonA" />
                        <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="BigButtonA" />
                    </td>
                </tr>
                <tr style="height: 6px;">
                </tr>
            </tbody>
        </table>
    </div>
    <!--详细信息结束-->
</div>