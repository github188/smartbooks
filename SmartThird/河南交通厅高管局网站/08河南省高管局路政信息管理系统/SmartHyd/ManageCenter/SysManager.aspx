<%@ Page Title="系统管理" Language="C#" MasterPageFile="~/ManageCenter/ManageCenter.Master"
    AutoEventWireup="true" CodeBehind="SysManager.aspx.cs" Inherits="SmartHyd.ManageCenter.SysManager" %>

<%@ Register Src="Ascx/SysManager.ascx" TagName="SysManager" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        	body{
	            margin:0px;
	            padding:0px;
                width:100%;
                height:100%;
	            }
                 ul li{ margin:0; padding:0; border:0; list-style:none;}
                #menu{ height:35px; background-image:url(../Images/ui-hander-background-1.png); background-repeat:repeat-x; font-family:微软雅黑;}
                #menu .patrolsitemap{ height:27px; line-height:27px; margin-top:8px; width:auto; color:#f2a41e; font-size:12px; font-weight:bold; float:left;}
                #menu ul{ margin:0; float:right; padding-top:8px; height:27px; }
                #menu ul li{ width:140px; line-height:27px; float:left; margin-left:5px;}

                #menu .normal{ display:block; text-align:center; color:#FFF;  font-weight:bold; background:url(../images/btn_hover1.png) no-repeat; width:140px; height:27px; line-height:27px;  overflow:hidden; font-size:13px; text-decoration:none;color:#ffffff;}
                #menu .normal a{ display:block; text-align:center; color:#FFF; font-size:13px;font-weight:bold; background:url(../images/btn_hover1.png) no-repeat; width:140px; height:27px; line-height:27px;  overflow:hidden;  text-decoration:none;color:#ffffff;}

                #menu ul li a:hover{ display:block; text-align:center; font-weight:bold; background:url(../Images/bg_a_hover.png) no-repeat;width:140px; color:#0c3a86;height:27px; line-height:27px; overflow:hidden;text-decoration:none;}

                #menu .actived{ display:block; text-align:center; font-weight:bold; background-color:#ffffff;  width:140px; color:#0c3a86;height:27px; line-height:27px; overflow:hidden;text-decoration:none;background:url(../Images/bg_li_hover.png) no-repeat;}
                #menu .actived a{ display:block; text-align:center;  font-size:13px; text-decoration:none; font-weight:bold; background:url(../images/btn_hover1.png) no-repeat; width:140px; height:27px; line-height:27px;  overflow:hidden; font-size:13px; text-decoration:none;color:#0c3a86;}

                #buttons *{vertical-align:middle; text-align:center;}
        
            #PatrolSearch {
	    font-size: 12px;
	    font-weight: bold;
    }
    .controlstyle{ width:100%;}
    .txtboxstyle{border:none; border-bottom:1px solid #065c8f;border-top:1px solid #065c8f;border-left:1px solid #065c8f;border-right:1px solid #065c8f;}
    
  
     #menu .OperateNote
    {
        float:left;
        width:auto;
        font-weight:bold;
        font-size:12px;
        font-family:微软雅黑;
        color:#065c8f;
        padding-left:5px;
    }
    
    #menu .ReturnPreview
    {
        float:right;
        width:100px;        
        font-weight:bold;
        font-size:12px;
        font-family:微软雅黑;
        color:#065c8f;
        cursor:hand;
    }
    </style>


    <script type="text/jscript">
        $(function () {
            $("#ctl00_ContentPlaceHolder1_SysManager1_TxtDate").datepicker();
        });
        //授权用户模态窗口
        function SelectUser(textID, dialogid) {
            Clear(textID);
            $(function () {

                var dialog = $(dialogid).dialog({
                    modal: false,
                    title: "授权窗口"
                });

            });

        }
        //清空文本框
        function Clear(textID) {
            document.getElementById(textID).value = "";
        }
        function btn_submit(textID, dialogid) {

            var elem = document.getElementsByTagName("input");
            var user = document.getElementById(textID);


            for (var i = 0; i < elem.length; i++) {

                if (elem[i].type == "checkbox") {
                    if (elem[i].checked == true) {
                        user.value += elem[i].nextSibling.innerText + ","; //-- nextSibling是获得当前对象的下一个对象;nodeValue 节点的值 

                    }
                    elem[i].checked = false; //清空选中的项
                }
            }
            $(dialogid).dialog("close"); //关闭dialog窗口；
        }

        //tab效果通用函数
        function nTabs(tabObj, obj, n) {
            var tabList = document.getElementById(tabObj).getElementsByTagName("li");
            for (i = 0; i < n; i++) {
                if (tabList[i].id == obj.id) {
                    document.getElementById(tabObj + "_Title" + i).className = "actived";
                } else {
                    document.getElementById(tabObj + "_Title" + i).className = "normal";
                }
            }
        }
    </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <uc1:SysManager ID="SysManager1" runat="server" />
</asp:Content>
