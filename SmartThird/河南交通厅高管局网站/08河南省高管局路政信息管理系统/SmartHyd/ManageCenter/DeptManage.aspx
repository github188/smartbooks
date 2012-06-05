<%@ Page Language="C#" Title="部门管理" AutoEventWireup="true" MasterPageFile="~/ManageCenter/ManageCenter.Master" CodeBehind="DeptManage.aspx.cs" Inherits="SmartHyd.ManageCenter.DeptManage" %>

<%@ Register Src="~/ManageCenter/Ascx/DeptManage.ascx" TagName="DeptManage" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    function childDept(deptid) {
        alert("dddd");
       // SmartHyd.ManageCenter.DeptManage.depturl(deptid);
     }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:DeptManage ID="DeptManage1" runat="server" />
</asp:Content>
