<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Security.aspx.cs" Inherits="SmartHyd.ManageCenter.Security.Security" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>应急安全</title>
    <style type="text/css">
        body
        {
        	margin:0px;
        	padding:0px;
        	font-size:12px;
        }
        .input_bor1{ border:1px solid #cccccc;}
        
        /*左侧菜单*/
        .list_nav a,.list_nav_hover a{ color:#FFF;}
        .list_nav{ display:block;background:url(../Imgs/btn_a.jpg) no-repeat; color:#FFF; width:220px; height:30px; text-indent:3em; font-weight:bold; line-height:30px; overflow:hidden;}
        .list_nav a:hover,.list_nav_hover{ display:block; background:url(../Imgs/btn_hover.jpg) no-repeat; width:220px; height:30px; color:#FFF; width:220px; height:30px; text-indent:3em; font-weight:bold; line-height:30px; overflow:hidden;}
        #list_nav_li1 ul,#list_nav_li2 ul,#list_nav_li3 ul,#list_nav_li4 ul,#list_nav_li5 ul,#list_nav_li6 ul,#list_nav_li7 ul{ background:#131a48; width:218px; overflow:hidden; margin-left:1px;}
        #list_nav_li1 ul a,#list_nav_li2 ul a,#list_nav_li3 ul a,#list_nav_li4 ul a,#list_nav_li5 ul a,#list_nav_li6 ul a,#list_nav_li7 ul a{ color:#CCC;}
        #list_nav_li1 ul li ,#list_nav_li2 ul li,#list_nav_li3 ul li,#list_nav_li4 ul li,#list_nav_li5 ul li,#list_nav_li6 ul li,#list_nav_li7 ul li{ margin-left:10px; _margin-left:7px; width:60px; float:left; margin-top:5px; }

        
        /*地图查询*/
        #map_menu{ width:100%;background:url(../../Images/list_bg.jpg) repeat-x; overflow:hidden; }
        #map_menu .menu_def{ display:block; float:left; width:65px; height:23px; line-height:23px; text-align:center; text-decoration:none; color:#FFF; background:url(../../Images/list.jpg) no-repeat;}
        #map_menu .menu_hov{ display:block; float:left; width:65px; height:23px; line-height:23px; text-align:center; text-decoration:none; color:#000; background:url(../../Images/list_a.jpg) no-repeat;}


    </style>
    <script type="text/javascript">
        function MapSearch() {
            alert("基础数据整合中……");
        }
        function ExchangeMenu(p) {
            if (p == 1) {
                document.getElementById("content1").style.display = "block";
                document.getElementById("content2").style.display = "none";
                document.getElementById("btn_menu1").className = "menu_hov";
                document.getElementById("btn_menu2").className = "menu_def";
            } else if (p == 2) {
                document.getElementById("content1").style.display = "none";
                document.getElementById("content2").style.display = "block";
                document.getElementById("btn_menu1").className = "menu_def";
                document.getElementById("btn_menu2").className = "menu_hov";
            }
        }
    </script>
</head>
<body scroll="no">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
           
    <div>
    <table border="0" cellpadding="0" cellspacing="0" style=" width:100%; height:100%;font-size:12px;">
        <tr>
            <td width="218px" valign="top">
                <div id="map_menu">
             <a href="javascript:ExchangeMenu(1);" id="btn_menu1" class="menu_hov">模糊查询</a>
             <a href="javascript:ExchangeMenu(2);" id="btn_menu2" class="menu_def">精确查询</a>
        </div>
        <div id="content1" style="display:block;">
               <table width="216" border="0" cellpadding="0" cellspacing="0" style="font-size:12px;">
                  <tr>
                    <td height="25" align="center">
                       <asp:RadioButton ID="rdoStorage" runat="server" GroupName="sea_action" Text="查询仓库" Checked="true" />
                       <asp:RadioButton ID="rdoSquad" runat="server" GroupName="sea_action" Text="查询队伍"/>
                    </td>
                      
                  </tr>
                  <tr>
                    <td height="20">&nbsp<asp:RadioButton ID="rdoUnit" runat="server" Text="按单位查询：" GroupName="searchstype" 
               Checked="true" AutoPostBack="True" 
               oncheckedchanged="rdo_Unit_Way_CheckedChanged"/>
                    </td>
                  </tr>
                  <tr>
                    <td height="22" align="center"><asp:DropDownList ID="ddlUnit" runat="server" Width="210px"></asp:DropDownList>
                    </td>
                  </tr>
                  <tr>
                    <td height="20">&nbsp;<asp:RadioButton ID="rdoWay" runat="server" Text="按路线查询：" GroupName="searchstype" 
               AutoPostBack="True" oncheckedchanged="rdo_Unit_Way_CheckedChanged" />
                    </td>
                  </tr>
                  <tr>
                    <td height="22" align="center">
                        <asp:DropDownList ID="ddlWay" 
                            runat="server"  Width="210px" Enabled="False"></asp:DropDownList></td>
                  </tr>
                  <tr>
                    <td height="20">&nbsp;所属地市：
                    </td>
                  </tr>
                  <tr>
                    <td height="22" align="center"><asp:DropDownList ID="ddlCity" runat="server"  
                            Width="210px" AutoPostBack="True" 
                            onselectedindexchanged="ddlCity_SelectedIndexChanged"></asp:DropDownList></td>
                  </tr>
                  <tr>
                    <td height="20">&nbsp;所属区县：
                    </td>
                  </tr>
                  <tr>
                    <td height="22" align="center"><asp:DropDownList ID="ddlDistrict" runat="server"  Width="210px"></asp:DropDownList></td>
                  </tr>
                  <tr>
                    <td height="40">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <img src="../../Images/map_search.jpg" alt="" onclick="MapSearch()" style="cursor:hand;"/>
                        <%--<asp:ImageButton ID="ImgBtnSearch" 
                            runat="server" onclick="ImgBtnSearch_Click" 
                            ImageUrl="~/Images/map_search.jpg" /></td>--%>
                  </tr>
              </table>
            </div>
        <div id="content2" style=" display:none;">
             <table width="216" border="0" align="center" cellpadding="0" cellspacing="0" style="font-size:12px;">
                  <tr>
                    <td height="25">&nbsp<asp:RadioButton ID="rdoStorageName" runat="server" 
                            Text="按仓库名称查询：" GroupName="exact_search" 
               Checked="true" AutoPostBack="True" oncheckedchanged="rdoStorageName_CheckedChanged" />
                    </td>
                  </tr>
                  <tr>
                    <td height="25" align="center"><asp:TextBox ID="txtStorageName" runat="server" CssClass="input_bor1" 
            Width="210px"></asp:TextBox>
                    </td>
                  </tr>
                  <tr>
                    <td height="25">&nbsp;<asp:RadioButton ID="rdoSquadName" runat="server" Text="按队伍名称查询：" GroupName="exact_search" 
               AutoPostBack="True" oncheckedchanged="rdoStorageName_CheckedChanged"/>
                    </td>
                  </tr>
                  <tr>
                    <td height="25" align="center">
                        <asp:TextBox ID="txtSquadName" runat="server" CssClass="input_bor1" 
            Width="210px" Enabled="false"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td height="50">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <img src="../../Images/map_search.jpg" alt="" onclick="MapSearch()" style="cursor:hand;"/>
<%--                    <asp:ImageButton ID="btnExactSearch" 
                            runat="server" ImageUrl="~/Imgs/map_search.jpg" 
                            onclick="btnExactSearch_Click" /></td>--%>
                  </tr>
              </table>
        </div>
            </td>
            <td valign="top"><iframe id="SecurityMapFrame" name="SecurityMapFrame" src="../../MapFrame.aspx" frameborder="0" scrolling="no" height="100%" width="100%"></iframe></td>
        </tr>
    </table>
            </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
