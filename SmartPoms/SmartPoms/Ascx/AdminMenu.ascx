<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminMenu.ascx.cs" Inherits="SmartPoms.Ascx.AdminMenu" %>

<% 
    SmartPoms.BLL.BASE_MODULE bll = new SmartPoms.BLL.BASE_MODULE();
    System.Data.DataTable model = bll.GetModuleTypeList("").Tables[0];
    string weburl = ConfigurationManager.AppSettings["WebUrl"];
    foreach (System.Data.DataRow row in model.Rows) {
%>
<div class="menuitem">
    <span class="menutitle"><%=row["ModuleTypeName"]%></span>
    <%
        System.Data.DataTable subModel = bll.GetModuleList(string.Format("ModuleTypeID={0}", row["ModuleTypeID"].ToString())).Tables[0];        
        foreach(System.Data.DataRow subRow in subModel.Rows){
    %>
    <div class="menuelement">
        <img class="meunico" src='<%= weburl + subRow["ModuleICO"] %>' alt='<%=subRow["ModuleDescription"] %>' />
        <a class="menulink" href='<%= weburl + subRow["ModuleURL"] %>'><%=subRow["ModuleName"] %></a>
    </div>
    <%
        }
    %>
</div>
<%
    }
%>

