<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OverView.aspx.cs" Inherits="management_OverView" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="RoadService" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
   <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
   <title>文章预览-路政网站后台管理系统</title>
   <link href="../style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <%
            DataTable dt = NewsInfoService.Get_NewsView(Convert.ToInt32(Request.QueryString["nid"]));
            string strType = dt.Rows[0]["T_Name"].ToString();
            string strTID=dt.Rows[0]["T_ID"].ToString();
            string strTitle = dt.Rows[0]["N_Title"].ToString();
            string strFrom = dt.Rows[0]["N_From"].ToString();
            string strDate = PubClass.Tool.Get_ShortDate(dt.Rows[0]["N_Date"].ToString());
            string strContent = dt.Rows[0]["N_Content"].ToString();
         %>
        <div class="pages">
          <div id="NewsContent">
        	<h1><%=strTitle %></h1>
            <div class="page_date">信息来源【<%=strFrom %>】&nbsp;&nbsp;&nbsp;&nbsp;<%=strDate %></div>
            <div class="page_con"><%=strContent %></div>
            <%
                if (dt.Rows[0]["N_ImgPath"].ToString().Trim() != "") { 
                %>
                <div style=" margin:5px; text-align:center;"><img src="../NewsImg/<%=dt.Rows[0]["N_ImgPath"] %>"  alt="<%=strTitle %>"/></div>
                <%
                }
            %>
            
          </div>
        </div>
   </div>
    </form>
</body>
</html>
