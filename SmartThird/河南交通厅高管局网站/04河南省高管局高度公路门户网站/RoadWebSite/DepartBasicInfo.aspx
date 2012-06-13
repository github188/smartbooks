<%@ Page Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="DepartBasicInfo.aspx.cs"
    Inherits="DepartBasicInfo" %>

<%@ Import Namespace="RoadEntity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="main">
        <div class="contact_weizhi">
            <a href="index.aspx">首页</a> >> 单位信息</div>
        <%
            RoadDepart depart = (RoadDepart)Session["roadinfo"];   
        %>
        <!--简介-->
        <p class="jianjie_biaoti">
            单位基本信息</p>
        <div id="jianjie_tab">
            <table width="698" cellspacing="1" cellpadding="1" style="margin: 0 auto;">
                <tr>
                    <td colspan="4" align="center" style="font-size: 14px; font-weight: bold;">
                        <%=depart.RD_Name %>
                    </td>
                </tr>
                <tr>
                    <th width="77">
                        单位负责人
                    </th>
                    <td width="224">
                        <%=depart.RD_Manager %>
                    </td>
                    <th width="80">
                        联系电话
                    </th>
                    <td width="302">
                        <%=depart.RD_Phone %>
                    </td>
                </tr>
                <tr>
                    <th>
                        单位传真
                    </th>
                    <td>
                        <%=depart.RD_Fax %>
                    </td>
                    <th>
                        电子邮件
                    </th>
                    <td>
                        <%=depart.RD_Email %>
                    </td>
                </tr>
                <tr>
                    <th>
                        邮政编码
                    </th>
                    <td>
                        <%=depart.RD_PostCode %>
                    </td>
                    <th>
                        所属地区
                    </th>
                    <td>
                        <%=depart.RD_PostCode %>
                    </td>
                </tr>
                <tr>
                    <th>
                        举报电话
                    </th>
                    <td colspan="3">
                        <%=depart.RD_Report %>
                    </td>
                </tr>
                <tr>
                    <th>
                        荣誉称号
                    </th>
                    <td colspan="3">
                        <%=depart.RD_Honour %>
                    </td>
                </tr>
                <tr>
                    <th>
                        单位地址
                    </th>
                    <td colspan="3">
                        <%=depart.RD_Address %>
                    </td>
                </tr>
            </table>
        </div>
        <p class="jianjie_biaoti">
            单位简介</p>
        <div style="margin: 10px 15px;">
            <p class="left bor mar_r5">
                <a href="RoadPhoto/<%=depart.RD_MainPhoto %>" rel="lightbox[photo]" title="<%=depart.RD_Name %>形象照片">
                    <img src="RoadPhoto/<%=depart.RD_ViewPhoto %>" width="150" height="120" alt='<%=depart.RD_Name %>形象照片' /></a></p>
            <%=depart.RD_Remark %>
        </div>
    </div>
</asp:Content>
