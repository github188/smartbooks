<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnitEdit.aspx.cs" Inherits="SmartHyd.ManageCenter.UserManager.UnitEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .BigButtonA
        {
            height: 21px;
        }
        body
        {
        	margin:0px;
        	padding:0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
               <table width="400" cellpadding="0" cellspacing="0" border="0" align="center" style="font-size:12px; font-family:微软雅黑;">
                    <tbody>
                        <!--首选行-->
                        <tr class="TableHeader">
                            <td colspan="2" style="font-weight:bold; height:24px; line-height:24px;color:#ffffff; background-color:#045185">
                               &nbsp;部门信息编辑
                            </td>
                        </tr>
                        <!--部门名称-->
                        <tr>
                            <td nowrap="nowrap" style="height:24px;"> 部门名称:</td>
                            <td>
                                <asp:TextBox ID="TxtDeptName" runat="server"  Width="300">
                                </asp:TextBox>
                                
                                
                            </td>
                        </tr>
               
                        <!--部门描述-->
                        <tr>
                            <td nowrap="nowrap" class="TableData">
                                部门描述:
                            </td>
                            <td class="TableData">
                                <asp:TextBox ID="txtDptinfo" runat="server"   Height="81px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                
                            </td>
                        </tr>

                        <!--按钮栏-->
                        <tr class="TableControl" style="height:24px;" align="center">
                            <td colspan="2" nowrap="nowrap">
                                <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
                                <asp:Button ID="btnSubmit" runat="server" Text="保&nbsp;存" Width="80px" CssClass="BigButtonA" 
                                    onclick="btnSubmit_Click" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
