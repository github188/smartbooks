<%@ Page Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="MessageBoardList.aspx.cs" Inherits="MessageBoardList" Title="Untitled Page" %>
<%@ Import Namespace="Model" %>
<%@ Import Namespace="DataAccess" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!--主体-->
<div id="main" style="margin-top:10px;">
	<div class="right">
    	<dl class="basecontent">
        	<dt><p class="weizhi">您的位置：<a href="index.aspx">首页</a> >> 服务留言</p>服务留言</dt><dd><p class="mess_name">信息板已经有<asp:Label ID="lblCount" runat="server" Text="0"></asp:Label>个脚印，<a href="#leaveMessage" class="red" >我也留个脚印</a></p>
                 <asp:Repeater ID="rptMessageList" runat="server"> 
                 <ItemTemplate>
                   <div class="mess_con">
                	<div class="say">
                    	<div class="say_date"><p class="right mar_r20"><%# Eval("M_Time") %></p><span class="blue"><%# Eval("M_UName")%></span> </div>
                        <p class="say_con"><%# Eval("M_Content")%></p>
                    </div>
                    <div class="answer"><span class="blue">管理员回复：</span><%# Eval("M_Reply")%></div>
                </div>
                 </ItemTemplate>
                 </asp:Repeater>  
               
            <div class="mess_con align">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageIndexBoxType="DropDownList" PageSize="15" PrevPageText="上一页" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" SubmitButtonText="Go" TextAfterPageIndexBox="页" TextBeforePageIndexBox="转到" OnPageChanged="AspNetPager1_PageChanged">
        </webdiyer:AspNetPager>
             </div>
              <!--留言板-->
                <div class="liuyan">
                <p class="liuyan_name">请在此留下您的脚印<a name="leaveMessage" id="leaveMessage"></a></p> 
                    <table width="700" border="1" cellspacing="0" cellpadding="0">
                      <tr>
                        <td width="77" height="40">姓名(昵称)：</td>
                        <td width="623">
                            <asp:TextBox ID="txtUName" runat="server" Width="300px" CssClass="inputborder1"></asp:TextBox></td>
                      </tr>
                      <tr>
                        <td valign="top">留言内容：</td>
                        <td>
                            <asp:TextBox ID="txtContent" runat="server" Height="80px" TextMode="MultiLine" Width="500px" CssClass="inputborder1"></asp:TextBox></td>
                      </tr>
                      <tr>
                        <td height="40">&nbsp;</td>
                        <td>
                            &nbsp;<asp:Button ID="btnSubmit" runat="server" Height="25px" Text="提交" Width="65px" OnClick="btnSubmit_Click" />
                            &nbsp; &nbsp; &nbsp;
                            <asp:Button ID="btnReset" runat="server" Height="25px" Text="重置" Width="65px" OnClick="btnReset_Click" />
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
                      </tr>
                    </table>
              </div>
            </dd>
            <dd class="pager_b"></dd>
        </dl>
    	
    </div>
  <div>
   	  <dl id="jiben">
            <dt><p class="more37"><a href="ServiceBasicInfo.aspx" target="_blank">更多 >></a></p>基本信息</dt><dd><div class="wid200">
                <p class="align fon16"><%=((ServiceInfo)Session["serviceinfo"]).S_Name %></p>
                <p class="align" style=" padding:7px 0;">
                <%
                    if (((ServiceInfo)Session["serviceinfo"]).S_Star == "★★★★★") { 
                    %>
                     <img src="images/star.jpg"  alt="五星级服务区" />
                    <%
                    }else if(((ServiceInfo)Session["serviceinfo"]).S_Star == "★★★★"){
                    %>
                     <img src="images/4star.jpg"  alt="四星级服务区" />
                    <%
                    }else if(((ServiceInfo)Session["serviceinfo"]).S_Star == "★★★"){
                    %>
                     <img src="images/3star.jpg"  alt="三星级服务区" />
                    <%
                    }else if(((ServiceInfo)Session["serviceinfo"]).S_Star == "★★"){
                    %>
                     <img src="images/2star.jpg"  alt="二星级服务区" />
                    <%
                    }else if(((ServiceInfo)Session["serviceinfo"]).S_Star == "★"){
                    %>
                     <img src="images/1star.jpg"  alt="一星级服务区" />
                    <%
                    }
                    else if (((ServiceInfo)Session["serviceinfo"]).S_Star == "优秀停车区")
                    {
                    %>
                     <img src="images/parking.jpg" width="138" height="26" alt="优秀停车区" />
                    <%
                    }
                     %>
               
                </p>
                位置：<%=PubClass.DBHelper.GetStringScalar("select H_Name from T_HighWayInfo where H_ID=" + ((ServiceInfo)Session["serviceinfo"]).S_HID)%>，桩号：<%=((ServiceInfo)Session["serviceinfo"]).S_Stake %><br />
                服务电话：<%=((ServiceInfo)Session["serviceinfo"]).S_Phone %><br />
             <p class="service_pic">
               <a href='ServiceImg/<%=((ServiceInfo)Session["serviceinfo"]).S_Image %>' rel="lightbox[serviceimg]" title='<%=((ServiceInfo)Session["serviceinfo"]).S_Name %>形象照片'><img src='ServiceImg/<%=((ServiceInfo)Session["serviceinfo"]).S_Image %>' width="96" height="72" alt="<%=((ServiceInfo)Session["serviceinfo"]).S_Name %>形象照片" /></a></p>
               <span title="<%=((ServiceInfo)Session["serviceinfo"]).S_Remark %>"> <%=PubClass.Tool.SubString(((ServiceInfo)Session["serviceinfo"]).S_Remark, 64)%> </span></div>
            </dd>
            <dd class="jiben_b"></dd>
        </dl>
      <div class="diaocha">
          <div class="diaocha_con">
            <p class="right"><a href="ServiceVote.aspx">参与投票</a></p>
        <a href="SurveyResult.aspx" target="_blank">投票结果</a></div>
      </div>
  </div>
    <div class="clear"></div>
</div>
</asp:Content>

