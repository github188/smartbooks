<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewNewsInfo.aspx.cs" Inherits="AdminMgr_ViewNewsInfo" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title><%=((DataTable)ViewState["dtNews"]).Rows[0]["N_Title"]%>-����ʡ��ͨ���������ٹ�·�����</title>
     <link href="style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="580" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top:10px; margin-bottom:10px;">
  <tr>
    <td><h1 style="font-size:14px; text-align:center; margin-top:20px; font-weight:bold; color:#F90;"><%=((DataTable)ViewState["dtNews"]).Rows[0]["N_Title"]%></h1></td>
  </tr>
  <tr>
    <td><p style="color:#999; text-align:center; padding-bottom:10px; border-bottom:1px #54a6d0 dashed; line-height:22px;">������Դ��<%=((DataTable)ViewState["dtNews"]).Rows[0]["N_From"]%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    �������ڣ�<%=PubClass.Tool.Get_ShortDate(((DataTable)ViewState["dtNews"]).Rows[0]["N_Time"].ToString())%></p></td>
  </tr>
  <tr>
    <td> <%
                        if (((DataTable)ViewState["dtNews"]).Rows[0]["N_PicIco"].ToString()=="ͼƬ����")
                        {
                          %>
                          <p style="text-align:center"><img src="../newsimages/<%=((DataTable)ViewState["dtNews"]).Rows[0]["N_ImgPath"] %>"  alt="<%=((DataTable)ViewState["dtNews"]).Rows[0]["N_Title"] %>"/></p>
                          <%
                        }
                         %>
                  <p style="line-height:22px;margin-top:10px;min-height:300px; "> <%=((DataTable)ViewState["dtNews"]).Rows[0]["N_Content"] %></p></td>
  </tr>
</table>
    </form>
</body>
</html>
