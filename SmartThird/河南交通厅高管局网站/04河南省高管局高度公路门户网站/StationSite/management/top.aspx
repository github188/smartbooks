<%@ Page Language="C#" AutoEventWireup="true" CodeFile="top.aspx.cs" Inherits="management_top" %>
<%@ Import Namespace="StationModel" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>ͷ������-����ʡ��ͨ���������ٹ�·������շѹ�����վ��̨����ϵͳ</title>
    <link href="style/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="top">
     <div class="left"></div>
     <div class="right">
       <div class="top_menu">
       <%
           UserInfo info = (UserInfo)Session["StationUser"];
           string strRemark = info.U_TollStation == null ? "ϵͳ����Ա" : info.U_TollStation.TS_Name;
       %>
        <%=info.U_LoginName %>&nbsp;[<%=strRemark %>]
        <span class="mar_l5 mar_r5">|</span>
        <a href="EditPwd.aspx" target="MainFrame">�޸�����</a>
        <span class="mar_l5 mar_r5">|</span>
        <a href="loginout.aspx" target="_top" class=" mar_r20">�˳�ϵͳ</a>
       </div>
     </div>
    </div>
    </form>
</body>
</html>
