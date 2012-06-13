<%@ Page Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" Title="Untitled Page" %>
<%@ Import Namespace="RoadEntity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="contact_weizhi"><a href="index.aspx">首页</a> >> 联系我们</div>

<div style=" margin-top:20px; margin-left:30px; height:300px;">
   <div style=" height:30px; line-height:30px; font-size:14px; font-weight:bold;">联系方式</div>
   <div style="height:30px; line-height:30px; font-size:14px; margin-left:20px;">
       <%
        RoadDepart depart = (RoadDepart)Session["roadinfo"];   
	 %>
        单位负责人：<%=depart.RD_Manager %><br />
        联系电话：<%=depart.RD_Phone %><br />
        单位传真：<%=depart.RD_Fax %><br />
        电子信箱：<%=depart.RD_Email %><br />
        邮政编码：<%=depart.RD_PostCode %><br />
        举报电话：<%=depart.RD_Report %><br />
        单位地址：<%=depart.RD_Address %>
   </div>
</div>

</asp:Content>

