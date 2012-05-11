<%@ Page Title="公文类型编辑" Language="C#" AutoEventWireup="true" MasterPageFile="~/ManageCenter/ManageCenter.Master" CodeBehind="OfficTypeEdit.aspx.cs" Inherits="SmartHyd.ManageCenter.OfficTypeEdit" %>

<%@ Register Src="~/ManageCenter/Ascx/OfficTypeEdit.ascx" TagName="OfficType" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:OfficType ID="OfficType1" runat="server" />
</asp:Content>
