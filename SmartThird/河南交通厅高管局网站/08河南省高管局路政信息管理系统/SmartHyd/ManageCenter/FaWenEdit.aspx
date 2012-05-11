<%@ Page title="公文在线编辑" Language="C#" AutoEventWireup="true" MasterPageFile="~/ManageCenter/ManageCenter.Master" CodeBehind="FaWenEdit.aspx.cs" Inherits="SmartHyd.ManageCenter.FaWenEdit" %>

<%@ Register Src="~/ManageCenter/Ascx/FaWenEdit.ascx" TagName="FaWenEdit" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:FaWenEdit ID="OfficType1" runat="server" />
</asp:Content>
