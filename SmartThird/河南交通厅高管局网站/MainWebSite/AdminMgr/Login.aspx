<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="AdminMgr_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>河南省交通运输厅高速公路管理局-网站后台管理系统登录</title>
    <style type="text/css">
  body,form,p,div,img,span{
	                  font-family:"Times New Roman", Times, serif;
					  font-size:12px;
					  color:#000;
					  border:none;
					  margin:0px;
					  padding:0px;
	                 }
  .body_bg{ background:#032236;}
  #box{ width:100%; height:462px; background:url(images/body_bg.jpg) repeat-x; overflow:hidden;}
  #login{margin:0 auto;
		 width:650px;
		 height:343px;
		 background:url(images/main_bg.jpg) no-repeat;
		 overflow:hidden;
		 margin-top:119px;
	    }
  #login .left{  float:left;
                 width:327px;
				 height:343px;
				 overflow:hidden;
				 padding-left:195px;
				 }
  #login .right{  float:left;
                 width:109px;;
				 height:343px;
				 overflow:hidden;
				 }
	.input_name{ display:block;
	             width:243px; 
	             height:22px;
				 line-height:22px;
				 background:url(images/input_bg.jpg) no-repeat;
				 padding-left:22px;
				 border: medium none;
				 margin-top:212px;
				 }
	.input_pwd{  display:block;
	             width:243px; 
	             height:22px;
				 line-height:22px;
				 background:url(images/input_bg.jpg) no-repeat;
				 padding-left:22px;
				 border: medium none;
				 margin-top:18px;
		        }
	.input_code{
		         width:93px; 
	             height:22px;
				 line-height:22px;
				 background:url(images/code_bg.jpg) no-repeat;
				 padding-left:22px;
				 overflow:hidden;
				 border: medium none;
				 margin-top:18px;
		        }
	.btn_submit{ margin-top:200px;}
</style>
    <script type="text/javascript">
        function CheckToSubmit(){
           if(Trim(document.getElementById("txtName").value)==""){
            alert("请输入用户名");
            return false;
           }
           if(document.getElementById("txtPwd").value==""){
            alert("请输入密码");
            return false;
           }
           if(Trim(document.getElementById("txtCode").value)==""){
            alert("请输入验证码");
            return false;
           }
           return true;
        }
        function Trim(str) {
           var reg = /^\s+|\s+$/g;
           return str.replace(reg, "");
        }
    </script>
</head>
<body class="body_bg">
    <form id="form1" runat="server">
<div id="box">
     <div id="login">
        <div class="left">
            <asp:TextBox ID="txtName" runat="server"  CssClass="input_name" ></asp:TextBox>
            <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"  CssClass="input_pwd"></asp:TextBox>
            <asp:TextBox ID="txtCode" runat="server"  CssClass="input_code"></asp:TextBox><img src="../CheckCode.aspx"   align="absmiddle"   style="margin-left:25px; margin-top:18px;"/>
        </div>
        
        <div class="right">
        <asp:ImageButton ID="btnLogin" runat="server" Height="114px" ImageUrl="~/AdminMgr/images/btn.jpg" Width="109px" OnClick="btnLogin_Click" OnClientClick="return CheckToSubmit();" CssClass="btn_submit" />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </div>
         
    </div>
  </div>
  
</form>
</body>
</html>
