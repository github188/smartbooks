<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menu.aspx.cs" Inherits="management_menu" %>
<%@ Import Namespace="StationModel" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>��๦�ܲ˵�����-����ʡ��ͨ���������ٹ�·������շѹ�����վ��̨����ϵͳ</title>
    <link href="style/default.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../js/jquery-1.3.2.js"></script>
    <script type="text/javascript" language="javascript">
	    function ExchangeItem(itemIndex,itemContIndex){
			if(document.getElementById(itemContIndex).style.display=="none"){
				document.getElementById(itemIndex).className="item_open";
				document.getElementById(itemContIndex).style.display="block"
			}else if(document.getElementById(itemContIndex).style.display=="block"){
			    document.getElementById(itemIndex).className="item_close";
				document.getElementById(itemContIndex).style.display="none"
		   }
		}
		function ExchangeSubItem(itemIndex,subItemCount,subItemIndex){
			for(var i=1;i<=subItemCount;i++){
			   if(i==subItemIndex){
				  document.getElementById(itemIndex+i).className="subitem_sel"; 
			   }else{
				  document.getElementById(itemIndex+i).className="subitem_unsel";  
			   }
			}
		}
	</script>
</head>
<body class="body_bg">
    <form id="form1" runat="server">
    <div id="menu">
    
    
   
        
        <%
            UserInfo info = (UserInfo)Session["StationUser"];
            if (info.U_IsSuper == 1) {
        %>
           <div id="item1" class="item_close" onclick='ExchangeItem("item1","itemcont1")'>�շ�վ��Ϣ����</div>
        <div id="itemcont1" style="display:none; padding:10px;">
             <div class="subitem_unsel" id="item11" onclick='ExchangeSubItem("item1",2,1)'><a href="StationMgr.aspx" target="MainFrame">�շ�վ�б�</a></div>
             <div class="subitem_unsel" id="item12" onclick='ExchangeSubItem("item1",2,2)'><a href="AddStation.aspx" target="MainFrame">����շ�վ</a></div>
        </div>
        
      <div id="item2" class="item_close"  onclick='ExchangeItem("item2","itemcont2")'>�շ�վ�û�����</div>
        <div id="itemcont2" style="display:none; padding:10px;">
            <div class="subitem_unsel" id="item21"  onclick='ExchangeSubItem("item2",2,1)'><a href="UserMgr.aspx" target="MainFrame">�û��б�</a></div>
            <div class="subitem_unsel" id="item22"  onclick='ExchangeSubItem("item2",2,2)'><a href="AddUser.aspx" target="MainFrame">����û�</a></div>
        </div>
        
        
         <div id="item3" class="item_close"  onclick='ExchangeItem("item3","itemcont3")'>ϵͳ����</div>
        <div id="itemcont3" style="display:none; padding:10px;">
             <div class="subitem_unsel" id="item31" onclick='ExchangeSubItem("item3",3,1)'><a href="EditPwd.aspx" target="MainFrame">�޸�����</a></div>
             <div class="subitem_unsel" id="item32" onclick='ExchangeSubItem("item3",3,2)'><a href="loginout.aspx" target="_top">�˳�ϵͳ</a></div>
             <div class="subitem_unsel" id="item33" onclick='ExchangeSubItem("item3",3,3)'><a href="../StationList.aspx" target="_top">��վ��ҳ</a></div>
        </div>
        <%
            }
            else if (info.U_IsSuper == 0)
           {
             %>
         <div id="item4" class="item_close"  onclick='ExchangeItem("item4","itemcont4")'>�շ�վ��Ϣ����</div>
        <div id="itemcont4" style="display:none;  padding:10px;">
             <div class="subitem_unsel" id="item41" onclick='ExchangeSubItem("item4",1,1)'><a href="EditStation.aspx" target="MainFrame">�༭��Ϣ</a></div>
        </div>
        
        
         <div id="item5" class="item_close"  onclick='ExchangeItem("item5","itemcont5")'>�շ�վ��̬</div>
        <div id="itemcont5" style="display:none;  padding:10px;">
             <div class="subitem_unsel" id="item51" onclick='ExchangeSubItem("item5",6,1)'><a href="ArticleMgr.aspx?tid=1" target="MainFrame">���¶�̬</a></div>
             <div class="subitem_unsel" id="item52" onclick='ExchangeSubItem("item5",6,2)'><a href="ArticleMgr.aspx?tid=2" target="MainFrame">֪ͨ����</a></div>
             <div class="subitem_unsel" id="item53" onclick='ExchangeSubItem("item5",6,3)'><a href="ArticleMgr.aspx?tid=3" target="MainFrame">����չʾ</a></div>
             <div class="subitem_unsel" id="item54" onclick='ExchangeSubItem("item5",6,4)'><a href="ArticleMgr.aspx?tid=4" target="MainFrame">����֮��</a></div>
             <div class="subitem_unsel" id="item55" onclick='ExchangeSubItem("item5",6,5)'><a href="ArticleMgr.aspx?tid=5" target="MainFrame">վ���Ļ�</a></div>
             <div class="subitem_unsel" id="item56" onclick='ExchangeSubItem("item5",6,6)'><a href="ArticleMgr.aspx?tid=6" target="MainFrame">�շ�վ���</a></div>
        </div>
        
        
         <div id="item7" class="item_close"  onclick='ExchangeItem("item7","itemcont7")'>ϵͳ����</div>
        <div id="itemcont7" style="display:none;  padding:10px;">
             <div class="subitem_unsel" id="item71" onclick='ExchangeSubItem("item7",3,1)'><a href="EditPwd.aspx" target="MainFrame">�޸�����</a></div>
             <div class="subitem_unsel" id="item72" onclick='ExchangeSubItem("item7",3,2)'><a href="loginout.aspx" target="_top">�˳�ϵͳ</a></div>
             <div class="subitem_unsel" id="item73" onclick='ExchangeSubItem("item7",3,3)'><a href="../StationList.aspx" target="_top">��վ��ҳ</a></div>
        </div>
        <%
            }
        %>
        

      </div>
    </form>
</body>
</html>
