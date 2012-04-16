<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StationMgr.aspx.cs" Inherits="management_StationMgr" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>�շ�վ��Ϣ����-����ʡ��ͨ���������ٹ�·������շѹ�����վ��̨����ϵͳ</title>
    <link href="style/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div id="box_mar2">
    
    <div id="nav_mgr">
        <div class="left"><img src="images/tb.gif" width="14" height="14" align="absmiddle" />�շ�վ�б�</div>
        <div class="right"><img src="images/add.gif" width="10" height="10" align="absmiddle" /><a href="AddStation.aspx">���</a></div>
    </div>
    
    <div class="search_mgr mar_t2">
     �շ�վ���ƣ�
        <asp:TextBox ID="txtName" runat="server" Width="140px"></asp:TextBox>
     �������У�
        <asp:DropDownList ID="ddlCity" runat="server" Width="130px">
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" CssClass="btn_search" OnClick="Button1_Click" />
    </div>
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="TS_Name" HeaderText="�շ�վ����" />
                <asp:BoundField DataField="TS_Manager" HeaderText="������"  ItemStyle-Width="12%" />
                <asp:BoundField DataField="TS_Phone" HeaderText="��ϵ�绰" ItemStyle-Width="12%" />
                <asp:BoundField DataField="CI_Name" HeaderText="��������" ItemStyle-Width="12%" />
                
                  <asp:TemplateField>
                         <HeaderTemplate>
                            LOGO����
                         </HeaderTemplate>
                         <ItemTemplate>
                             <a href='LogoView.aspx?tsid=<%#DataBinder.Eval(Container.DataItem,"TS_ID") %>' target="_blank">Ԥ��</a> | 
                             <a href='EditLogo.aspx?tsid=<%#DataBinder.Eval(Container.DataItem,"TS_ID") %>'>�༭</a>
                         </ItemTemplate>
                         <ItemStyle Width="12%" />
                  </asp:TemplateField>
                
                
                   <asp:TemplateField>
                         <HeaderTemplate>
                            �༭
                         </HeaderTemplate>
                         <ItemTemplate>
                             <a href='EditStation.aspx?tsid=<%#DataBinder.Eval(Container.DataItem,"TS_ID") %>'><img src="images/edit.gif" /></a>
                         </ItemTemplate>
                         <ItemStyle Width="12%" />
                    </asp:TemplateField>
                     
                
                
                   <asp:TemplateField>
                         <ItemTemplate>
                            <asp:ImageButton ID="del" runat="server" ImageUrl="~/management/images/delete13.gif"   CommandName="delRecord" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"TS_ID") %>' OnClientClick="return confirm('��ȷ��Ҫɾ���ü�¼��')" />
                         </ItemTemplate>
                         <HeaderTemplate>
                             ɾ��
                         </HeaderTemplate>
                         <ItemStyle Width="12%" />
                    </asp:TemplateField>
                
                
            </Columns>
            <RowStyle CssClass="GridViewRowStyle" />
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            <HeaderStyle CssClass="GridViewHeaderStyle" />
        </asp:GridView>
        
        <div class="gridviewpage">
         <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="��%CurrentPageIndex%ҳ����%PageCount%ҳ��ÿҳ%PageSize%��" FirstPageText="��ҳ" LastPageText="βҳ" NextPageText="��һҳ" PageIndexBoxType="DropDownList" PageSize="25" PrevPageText="��һҳ" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="ҳ" TextBeforePageIndexBox="ת��" OnPageChanged="AspNetPager1_PageChanged">
        </webdiyer:AspNetPager>
        </div>
    
    </div>
    </form>
</body>
</html>
