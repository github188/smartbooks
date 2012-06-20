<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnitCenter.aspx.cs" Inherits="SmartHyd.ManageCenter.UserManager.UnitCenter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
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
                <table border="0" cellpadding="0" cellspacing="0" width="100%"  height="100%" >
                    <tr>
                        <td align="left" style="height:22px; background-color:#ffffff; border-bottom:4px double #F09B17;">
                            &nbsp;<asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/Images/addUnit.png" 
                                onclick="btnAdd_Click" />
                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/Images/editUnit.png" 
                                onclick="btnEdit_Click" />
                            <asp:ImageButton ID="btnDelete" runat="server" 
                                ImageUrl="~/Images/deleteUnit.png" OnClientClick="return confirm( '你确定要删除该单位？')" onclick="btnDelete_Click" />
&nbsp;&nbsp;
                        &nbsp;
                        &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:HiddenField ID="hfdUnitCode" runat="server" />
                            <asp:HiddenField ID="hfdUnitName" runat="server" />

                            <asp:TreeView ID="TreeViewAcceptUnit" 
                                runat="server" CssClass="treeViewStyle" ImageSet="BulletedList4" 
                                ShowExpandCollapse="true" Width="300px" 
                                onselectednodechanged="TreeViewAcceptUnit_SelectedNodeChanged" 
                                ontreenodecheckchanged="TreeViewAcceptUnit_TreeNodeCheckChanged" 
                                ShowCheckBoxes="All" ShowLines="True">
                            <HoverNodeStyle Font-Underline="True" ForeColor="#000000" />
                            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="#000000" 
                                HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
                            <ParentNodeStyle Font-Bold="False" />
                            <RootNodeStyle ImageUrl="~/Images/chart_organisation.png" />
                            <SelectedNodeStyle Font-Underline="True" ForeColor="#000000" 
                                HorizontalPadding="0px" VerticalPadding="0px" BackColor="#0066CC" />
                            </asp:TreeView>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
