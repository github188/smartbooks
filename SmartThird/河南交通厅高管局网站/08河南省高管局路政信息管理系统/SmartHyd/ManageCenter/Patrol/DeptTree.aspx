<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeptTree.aspx.cs" Inherits="SmartHyd.ManageCenter.Patrol.DeptTree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">
                    <tr>
                        <td valign="top">
                           <asp:TreeView ID="TreeViewAcceptUnit" runat="server" CssClass="treeViewStyle" ImageSet="BulletedList4"
                            ShowExpandCollapse="true" Width="300px" ShowCheckBoxes="All" ShowLines="True">
                            <HoverNodeStyle Font-Underline="True" ForeColor="#000000" />
                            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="#000000" HorizontalPadding="5px"
                                NodeSpacing="0px" VerticalPadding="0px" />
                            <ParentNodeStyle Font-Bold="False" />
                            <RootNodeStyle ImageUrl="~/Images/chart_organisation.png" />
                            <SelectedNodeStyle Font-Underline="True" ForeColor="#000000" HorizontalPadding="0px"
                                VerticalPadding="0px" BackColor="#0066CC" />
                        </asp:TreeView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
