<%@ Page Language="C#" MasterPageFile="~/menber/adminBack.master" AutoEventWireup="true" CodeFile="adminCenter.aspx.cs" Inherits="menber_adminCenter" Title="页面内容--智慧校园管理平台" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            overflow: hidden;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td width="8" bgcolor="#353c44">
                &nbsp;
            </td>
            <td width="147" valign="top">
                <iframe height="100%" width="100%" border="0" frameborder="0" src="adminLeft.aspx">
                </iframe>
            </td>
            <td width="10" bgcolor="#add2da">
                &nbsp;
            </td>
            <td valign="top">
                <iframe height="100%" width="100%" border="0" frameborder="0" src="adminRight.aspx">
                </iframe>
            </td>
            <td width="8" bgcolor="#353c44">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>