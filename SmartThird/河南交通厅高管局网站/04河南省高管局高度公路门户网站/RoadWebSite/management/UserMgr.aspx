<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserMgr.aspx.cs" Inherits="management_UserMgr" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>�û��б�-·����վ��̨����ϵͳ</title>
    <link href="style/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="box_mr2">
    
        <div id="nav_mgr">
           <div class="left"><img src="images/tb.gif" width="14" height="14" align="absmiddle" />·����λ�û�����&nbsp;&nbsp;>>&nbsp;&nbsp;�û��б�</div>
           <div class=" right"><img src="images/001.gif" width="14" height="14" align="absmiddle"/><a href="AddUser.aspx">����û�</a></div>
        </div>
        
        
        <div class="search_mgr mar_t2">
     ��·����λ��ѯ��
        <asp:TextBox ID="txtName" runat="server" Width="180px"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" CssClass="btn_search" OnClick="btnSearch_Click" />
    </div>
    
    
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="U_LoginName" HeaderText="�û���"  >
                    <ItemStyle Width="18%" />
                </asp:BoundField>
                <asp:TemplateField>
                         <ItemTemplate>
                             <asp:Label ID="Label1" runat="server" Text='<%# CommonFunction.Decrypt(DataBinder.Eval(Container.DataItem, "U_LoginPwd").ToString(),"roadkey")%>'></asp:Label>
                         </ItemTemplate>
                         <HeaderTemplate>
                             ����
                         </HeaderTemplate>
                         <ItemStyle Width="15%" />
                    </asp:TemplateField>
                <asp:BoundField DataField="U_TrueName" HeaderText="��ʵ����">
                    <ItemStyle Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="U_Phone" HeaderText="��ϵ�绰" >
                    <ItemStyle Width="15%" />
                </asp:BoundField>
                <asp:BoundField DataField="RD_Name" HeaderText="������λ" >
                </asp:BoundField>
                   <asp:TemplateField>
                         <ItemTemplate>
                            <asp:ImageButton ID="del" runat="server" ImageUrl="~/management/images/delete13.gif"   CommandName="delRecord" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"U_ID") %>' OnClientClick="return confirm('��ȷ��Ҫɾ���ü�¼��')" />
                         </ItemTemplate>
                         <HeaderTemplate>
                             ɾ��
                         </HeaderTemplate>
                         <ItemStyle Width="15%" />
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
