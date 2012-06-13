<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserEdit.aspx.cs" Inherits="SmartHyd.ManageCenter.UserManager.UserEdit" %>

<%@ Register src="~/Ascx/Department.ascx" tagname="Department" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户信息编辑</title>
    <style type="text/css">
        body
        {
        	margin:0px;
        	padding:0px;
        	font-size:12px;
        	font-family:微软雅黑;
        }
        .title{
	        font-weight:bold;
	        text-align:right;
	        height:27px;
	        line-height:27px;
	        width:100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
    <div style="height:26px; line-height:26px; border-bottom:4px double #F09B17;">
        &nbsp;<asp:Label ID="LabName" runat="server" Text=""></asp:Label>
    </div>
    <div style="height:30px;"></div>
    <div style="width:400px; margin:auto; height:auto; border:4px double #045185;">
        <table width="350px" border="0" cellspacing="0" cellpadding="0" style="font-size:12px; margin:auto;">
          <tr>
            <td class="title">用户名：</td> 
            <td>
                <asp:TextBox ID="txtUserName" runat="server" 
                            CssClass="input {required:true,minlength:5,maxlength:12}" 
                    Width="230px" Height="24px"></asp:TextBox>*
            </td>
          </tr>
          <tr>
            <td class="title">密码：</td>
            <td><asp:TextBox ID="txtPassword" runat="server" 
                            CssClass="input {required:true,minlength:5,maxlength:12}" 
                    Width="230px" Height="24px"></asp:TextBox>*</td>
          </tr>
          <tr>
            <td class="title">真实姓名：</td>
            <td><asp:TextBox ID="TxtRealName" runat="server" 
                            CssClass="input {required:true,minlength:3,maxlength:12}" 
                    Width="230px" Height="24px"></asp:TextBox>*</td>
          </tr>
          <tr>
            <td class="title">工作证号：</td>
            <td>
                <asp:TextBox ID="txtJOBNUMBER" runat="server" Width="230px" Height="24px"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td class="title">所在单位：</td>
            <td><asp:TextBox ID="txtUnit" runat="server" Width="230px" ReadOnly="true" Height="24px"></asp:TextBox></td>
          </tr>
          <tr>
            <td class="title">手机号码：</td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server" Width="230px" Height="24px"></asp:TextBox>*
            </td>
          </tr>
          <tr>
            <td class="title">信息备注：</td>
            <td rowspan="4">
                <asp:TextBox ID="txtRemark" runat="server" CssClass="input" Height="100px" 
                    TextMode="MultiLine" Width="230px"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td class="title">&nbsp;</td>
          </tr>
            <tr>
            <td class="title">&nbsp;</td>
          </tr>
            <tr>
            <td class="title">&nbsp;</td>
          </tr>
            <tr>
            <td class="title">&nbsp;</td>
            <td align="center">
                <asp:Button ID="btnSubmit" runat="server" Width="80px" Text="提交" CssClass="BigButtonA" 
                            onclick="btnSubmit_Click" />&nbsp;
                        <input id="btnBakc" type="button" value="返回" style="width:80px;" onclick="javascript:history.go(-1);" /></td>
          </tr>
        </table>
    </div>
    <asp:HiddenField ID="hfdUnitId" runat="server" />
            </ContentTemplate>
    </asp:UpdatePanel>
    <%--<table  width="100%" align="center">            
            <tbody>
                <!--标题栏-->
                <tr class="TableHeader">
                    <td colspan="4" style="height:24px; line-height:24px; border-bottom:4px double #F09B17;">
                        
                       
                    </td>
                    
                </tr>

                <!--部门、账号-->
                <tr>
                    <td nowrap="nowrap" class="TableData" width="70">用户账号:</td>
                    <td nowrap="nowrap" class="TableData" style="width:325px;">
                        
                        <div class="validate ui-state-highlight ui-corner-all " style="border: none;"></div>
                    </td>
                    <td nowrap="nowrap" class="TableData" width="70">真实姓名:</td>
                    <td nowrap="nowrap" class="TableData" style="width:325px;">
                        
                        <div class="validate ui-state-highlight ui-corner-all " style="border: none;"></div>
                    </td>
                </tr>

                <!--密码、性别-->
                <tr>
                    <td nowrap="nowrap" class="TableData" width="70">用户密码:</td>
                    <td nowrap="nowrap" class="TableData" style="width:325px;">
                        
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;"></div>
                    </td>
                    <td nowrap="nowrap" class="TableData" width="70">所属单位:</td>
                    <td nowrap="nowrap" class="TableData" style="width:325px;">
                        <uc1:Department ID="Department1" runat="server" />
                    </td>
                   
                </tr>

                <!--生日、学历-->
                <tr>
                 <td nowrap="nowrap" class="TableData" width="70">用户性别:</td>
                    <td nowrap="nowrap" class="TableData" style="width:325px;">
                        <asp:DropDownList ID="ddlSex" runat="server" CssClass="input">
                            <asp:ListItem Text="男" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="女" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td nowrap="nowrap" class="TableData" width="70">出生年月:</td>
                    <td nowrap="nowrap" class="TableData" style="width:325px;">
                        <asp:TextBox ID="txtBIRTHDAY" runat="server" 
                            CssClass="input {required:true}">
                        </asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;"></div>
                    </td>
                  
                </tr>

                <!--政治面貌、身份证号-->
                <tr>
                    <td nowrap="nowrap" class="TableData" width="70">政治面貌:</td>
                    <td nowrap="nowrap" class="TableData" >
                        <asp:TextBox ID="txtFACE" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;"></div>
                    </td>
                    <td nowrap="nowrap" class="TableData" width="70">身份证号:</td>
                    <td nowrap="nowrap" class="TableData" >
                        <asp:TextBox ID="txtIDNUMBER" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;"></div>
                    </td>
                </tr>

                <!--工作证号、所学专业-->
                <tr>
                    <td nowrap="nowrap" class="TableData" width="70">工作证号:</td>
                    <td nowrap="nowrap" class="TableData" >
                        
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;"></div>
                    </td>
                    <td nowrap="nowrap" class="TableData" width="70">所学专业:</td>
                    <td nowrap="nowrap" class="TableData" >
                        <asp:TextBox ID="txtPROF" runat="server" CssClass="input {required:true}"></asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all"  style="border:none;"></div>
                    </td>
                </tr>

                <!--联系方式、备注信息-->
                <tr>
                    <td nowrap="nowrap" class="TableData" width="70">联系方式:</td>
                    <td nowrap="nowrap" class="TableData" >
                        
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;"></div>
                    </td>
                    <td nowrap="nowrap" class="TableData" width="70">备注信息:</td>
                    <td nowrap="nowrap" class="TableData" >
                        
                    </td>
                </tr>

                <!--用户照片-->
                <tr>
                  <td nowrap="nowrap" class="TableData" width="70">最高学历:</td>
                    <td nowrap="nowrap" class="TableData" style="width:325px;">
                        <asp:TextBox ID="txtDEGREE" runat="server" 
                            CssClass="input {required:true}" Text="本科">
                        </asp:TextBox>
                        <div class="validate ui-state-highlight ui-corner-all" style="border: none;"></div>
                    </td>
                    <td nowrap="nowrap" class="TableData" width="70">用户照片</td>
                    <td nowrap="nowrap" class="TableData">
                        <asp:FileUpload ID="fileupPhoto" runat="server" />
                    </td>
                </tr>

                <!--按钮栏-->
                <tr class="TableControl" align="center">
                    <td colspan="4" nowrap="nowrap">
                        
                    </td>
                </tr>
            </tbody>
        </table>
--%>
    </form>
</body>
</html>
