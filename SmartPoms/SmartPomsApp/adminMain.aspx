﻿<%@ Page Language="C#" MasterPageFile="adminBack.master" AutoEventWireup="true" CodeFile="adminMain.aspx.cs" Inherits="adminMain" Title="管理中心--网络舆情监控平台" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <frameset rows="127,*,11" frameborder="no" border="0" framespacing="0">
      <frame src="adminTop.aspx" name="topFrame" scrolling="No" noresize="noresize" id="topFrame" />
      <frame src="adminCenter.aspx" name="mainFrame" id="mainFrame" />
      <frame src="adminDown.aspx" name="bottomFrame" scrolling="No" noresize="noresize" id="bottomFrame" />
    </frameset>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>