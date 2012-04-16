<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ArticleMgr.aspx.cs" Inherits="management_ArticleMgr" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title><%=((DataTable)ViewState["dtType"]).Rows[0]["T_Name"]%>��Ϣ����-·����վ��̨����ϵͳ</title>
    <link href="style/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="box_mr2">
    
          <div id="nav_mgr">
           <div class="left"><img src="images/tb.gif" width="14" height="14" align="absmiddle" />·����̬&nbsp;&nbsp;>>&nbsp;&nbsp;<%=((DataTable)ViewState["dtType"]).Rows[0]["T_Name"]%>��Ϣ����</div>
           <div class=" right"><img src="images/001.gif" width="14" height="14" align="absmiddle"/><a href="<%=((DataTable)ViewState["dtType"]).Rows[0]["T_AddURL"]%>">�������</a></div>
        </div>
        
        
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="N_Title" HeaderText="���±���" />
                <asp:BoundField DataField="N_From" HeaderText="������Դ" >
                    <ItemStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="T_Name" HeaderText="��������" >
                    <ItemStyle Width="80px" />
                </asp:BoundField>
                <asp:BoundField DataField="N_Date" HeaderText="��������" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="False" >
                    <ItemStyle Width="80px" />
                </asp:BoundField>
                
                  <asp:TemplateField>
                         <HeaderTemplate>
                            Ԥ��
                         </HeaderTemplate>
                         <ItemTemplate>
                             <a href='OverView.aspx?nid=<%#DataBinder.Eval(Container.DataItem,"N_ID") %>' target="_blank"><img src="images/gif-0072.gif" /></a>
                         </ItemTemplate>
                         <ItemStyle Width="60px" />
                  </asp:TemplateField>
                
                
                   <asp:TemplateField>
                         <HeaderTemplate>
                            �༭
                         </HeaderTemplate>
                         <ItemTemplate>
                             <a href='<%#DataBinder.Eval(Container.DataItem,"T_EditURL") %>&nid=<%#DataBinder.Eval(Container.DataItem,"N_ID") %>'><img src="images/edit.gif" /></a>
                         </ItemTemplate>
                         <ItemStyle Width="60px" />
                    </asp:TemplateField>
                     
                
                
                   <asp:TemplateField>
                         <ItemTemplate>
                            <asp:ImageButton ID="del" runat="server" ImageUrl="~/management/images/delete13.gif"   CommandName="delRecord" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"N_ID") %>' OnClientClick="return confirm('��ȷ��Ҫɾ���ü�¼��')" />
                         </ItemTemplate>
                         <HeaderTemplate>
                             ɾ��
                         </HeaderTemplate>
                         <ItemStyle Width="60px" />
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
