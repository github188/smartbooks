<%@ Page Language="C#" MasterPageFile="adminBack.master" AutoEventWireup="true" CodeFile="adminLeft.aspx.cs"
    Inherits="menber_adminLeft" Title="功能导航--网络舆情监控平台" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        body
        {
            margin: 0px;
            padding: 0px;
        }
        #jq-page-menu
        {
            width: 147px;
            height: 95%;
            line-height: 23px;
            margin: 0px;
            padding: 0px;
            text-align: center;
            font-size: 12px;
            color: black;
            cursor: pointer;
        }
        #jq-page-menu span
        {
            width: 147px;
            height: 23px;
            float: left;
            background-image: url("images/main_34.gif");
        }
        #jq-page-menu a
        {
            width: 147px;
            height: 23px;
            float: left;
            display:none;
        }
        #jq-page-menuversion
        {
            width: 147px;
            height: 23px;
            line-height: 23px;
            margin: 0px;
            padding: 0px;
            text-align: center;
            font-size: 12px;
            color: black;
            background-image: url("images/main_69.gif");
            float: left;
        }
    </style>
    <script language="javascript" type="text/jscript">
        $(document).ready(function () {
            $("#jq-page-menu").children("div").click(function () {
                $(this).children("a").mouseover(function () {
                    $(this).css("background", "D5F4FE");
                }).mouseout(function () {
                    $(this).css("background", "");
                }).stop().show()
                .fadeTo("fast", 0.7).fadeTo("fast", 1).end().siblings().children("a").hide();
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="jq-page-menu">
        <%
            string[] roles = Session["role"].ToString().Split(',');
            System.Collections.Generic.List<SmartPoms.Entity.BASE_ROLE> base_role = new System.Collections.Generic.List<SmartPoms.Entity.BASE_ROLE>();
            System.Collections.Generic.List<int> itemId = new System.Collections.Generic.List<int>();
            foreach (string c in roles) {
                itemId.Add(Convert.ToInt32(c));
            }
            SmartPoms.ServiceInterfaces.IMenuService menuService = Smart.ServiceFactory.ComponentFactory<SmartPoms.ServiceInterfaces.IMenuService>.GetBLLPlugin();
            base_role = menuService.GetUserMenu(itemId);
            foreach (SmartPoms.Entity.BASE_ROLE r in base_role) {
                if (r.ROLEIDPARENT == 0) {
        %>
        <div><span><%=r.ROLENAME%></span>
        <%
                foreach (SmartPoms.Entity.BASE_ROLE s in base_role) {
                    if (r.ROLEID == s.ROLEIDPARENT) {
        %>
                        <a href='<%=s.LINK %>' target="rightframe"><%=s.ROLENAME%></a>
        <% } }%>
        </div>
        <% } } %>
        <div id="jq-page-menuversion">
            版本:V1.0.0.0</div>
    </div>
</asp:Content>
