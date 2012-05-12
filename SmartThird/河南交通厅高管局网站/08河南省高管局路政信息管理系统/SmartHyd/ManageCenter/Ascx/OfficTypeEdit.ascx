﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OfficTypeEdit.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.OfficTypeEdit" %>
<div id="divedit">
<table border="0" width="100%" cellspacing="0" cellpadding="3" class="edit">
    <thead>
        <tr>
            <th colspan="3">
                编辑公文类型
            </th>
        </tr>
    </thead>
    <tbody>
    <tr>
        <td nowrap="nowrap" class="TableContent" align="center">
            公文类型名称
        </td>
        <td>
            <asp:HiddenField ID="hidPrimary" runat="server" Value="-1" />
            <asp:TextBox ID="TxtTypeName" runat="server" CssClass="input{required:true}"></asp:TextBox>
                <div class="validate ui-state-highlight ui-corner-all"  style="border:none;"></div>
        </td>
       
    </tr>
    <tr>
        <td nowrap="nowrap" class="TableContent" align="center">
            所属分类
        </td>
        <td>
            <select id="category" name="category" class="BigSelect" runat="server">
                <option value="1">行政</option>
                <option value="2">其他</option>
            </select>
        </td>
    </tr>
    <tr>
        <td nowrap="nowrap" class="TableContent" align="center">
            默认文号前缀
        </td>
        <td class="TableData">
            <asp:TextBox ID="TxtPrefix" runat="server" CssClass="input"></asp:TextBox>
        </td>
      
    </tr>
    <tr>
         <td nowrap="nowrap" class="TableContent" align="center">
            默认文号后缀
        </td>
        <td class="TableData">
            <asp:TextBox ID="TxtSuffix" runat="server" CssClass="input"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td nowrap="nowrap"  class="TableContent" align="center">
            文字说明:
        </td>
        <td class="TableData" colspan="3">
            <asp:TextBox ID="TxtDescribe" runat="server" CssClass="input" Height="44px" TextMode="MultiLine"
                Width="419px"></asp:TextBox>
        </td>
    </tr>
    <tr align="center" class="TableControl">
        <td colspan="4" nowrap="nowrap">
            <input type="hidden" name="tid" value="" />
            <asp:Button ID="BtnEdit" runat="server" Text="修改" onclick="BtnEdit_Click" />
            <asp:Button ID="BtnBack" runat="server" Text="返回" onclick="BtnBack_Click" />
        
        </td>
    </tr>
    </tbody>
</table>
</div>