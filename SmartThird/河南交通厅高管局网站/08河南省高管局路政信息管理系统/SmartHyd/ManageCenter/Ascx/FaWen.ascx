<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FaWen.ascx.cs" Inherits="SmartHyd.ManageCenter.Ascx.FaWen" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<div id="tab">
 <ul>
        <li><a href="#tabs-1">发文管理</a></li>
        <li><a href="#tabs-2">公文拟稿</a></li>
    </ul>
    <!--发文管理开始-->
    <div id="tabs-1">
        <table class="table">
            <asp:Repeater ID="fawenList" runat="server">
                <HeaderTemplate>
                    <thead>
                        <tr>
                         <th>
                                <asp:CheckBox ID="CheckBox1" runat="server" Text="全选"  />
                            </th>
                            <th>
                                标题
                            </th>
                             <th>
                                文号
                            </th>
                             <th>
                                类型
                            </th>
                            <th>
                                操作
                            </th>
                        </tr>
                    </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tbody>
                        <tr>
                        <td>
                            <asp:CheckBox ID="CheckBox1" runat="server"/>
                        </td>
                            <td>
                                <%# Eval("F_TITLE")%>
                            </td>
                            <td> <%# Eval("F_NUMBER")%></td>
                            <td><%# Eval("F_TYPE")%></td>
                            <td>
                               <a href="<%# Eval("FID")%>">编辑</a>   <a href="<%# Eval("FID")%>">删除</a> 
                                                           </td>
                        </tr>
                    </tbody>
                </ItemTemplate>
                <FooterTemplate>
                    <tfoot>
                        <tr>
                            <td colspan="2">
                                分页
                            </td>
                        </tr>
                    </tfoot>
                </FooterTemplate>
            </asp:Repeater>
        </table>
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页"
            FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="TextBox"
            PrevPageText="上一页" ShowCustomInfoSection="Right" ShowPageIndexBox="Auto" SubmitButtonText="Go"
            TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到">
        </webdiyer:AspNetPager>
    </div>
    <!--发文管理结束-->
    <!--公文拟稿开始-->
    <div id="tabs-2">
       <div id="content">

	<form name="form1">
	<h1 align="center">河南省交通运输厅高速公路管理局</h1>
    
<table class="TableList red" align="center" width="700">
	<tr>
		<td class="red" align="center">发文字号</td>
		<td class="red">
            <asp:TextBox ID="txNumber" runat="server"></asp:TextBox></td>
           
		<%--<td class="red" align="center">密级</td>
		<td class="red"><input type="text" name="secret" class="field" size=20
			value=""></td>--%>
	</tr>
    <tr>
    <td>发文类型</td>
    <td><asp:DropDownList ID="Dr_F_type" runat="server">
               </asp:DropDownList>
           </td>
           </tr>
	<tr>
		<td class="red" align="center">发文标题</td>
		<td class="red" colspan=3> <asp:TextBox ID="txTitle" runat="server"></asp:TextBox></td>
	</tr>
	<tr>
		<td class="red" align="center">主题词</td>
		<td class="red" colspan=3>
            <asp:TextBox ID="TxContent" runat="server" Height="140px" TextMode="MultiLine" 
                Width="215px"></asp:TextBox></td>
	</tr>
	<tr>
		<td class="red" align="center">主办单位</td>
		<td class="red">
            <asp:TextBox ID="txOrgan" runat="server"></asp:TextBox></td>
		<%--<td class="red" align="center">缓急程度</td>
		<td class="red"><input type="text" name="priority" class="field"
			size=20 value=""></td>--%>
	</tr>
	<tr>
		<td class="red" align="center">主送</td>
		<td class="red" colspan=3>&nbsp;</td>
	</tr>
    	<tr>
		<td class="red" align="center">
           附件</td>
		<td class="red" colspan=3>
            <asp:FileUpload ID="FileUpload1" runat="server" /></td>
	</tr>
	<tr>
		<td class="red" align="center">
            <asp:Button ID="Button2" runat="server" Text="发送" onclick="Button2_Click" /></td>
		<td class="red" colspan=3>
            <asp:Button ID="Button1" runat="server" Text="保存" onclick="Button1_Click" /></td>
	</tr>
</table>        	<input type="hidden" name="sid" id="sid" value="5003">
	</form>
</div>
    </div>
    <!--公文拟稿结束-->
</div>