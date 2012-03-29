<%@ Page Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="ServiceVote.aspx.cs" Inherits="ServiceVote" Title="Untitled Page" %>
<%@ Import Namespace="Model" %>
<%@ Import Namespace="DataAccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!--主体-->
<div id="main" style="margin-top:10px;">
	<div class="right">
    <dl class="basecontent">
        <dt><p class="weizhi">您的位置：<a href="index.aspx">首页</a> >> 服务区用户在线满意度调查</p>在线调查</dt><dd><div id="diaochatable" >
            <table width="660" height="523" border="0" cellpadding="1" cellspacing="1" align="center">
              <tr>
                <td width="58" height="33" align="center"><strong>序号</strong></td>
                <td align="center" style="width: 440px"><strong>调 查 内 容</strong></td>
                <td align="center" style="width: 339px"><strong>评 价 满 意 度</strong></td>
              </tr>
              <tr>
                <td height="24" align="center">1</td>
                <td style="width: 440px"> 您对该服务区综合评价如何 </td>
                <td align="center" style="width: 339px">
                   <asp:RadioButtonList ID="rdozh" runat="server" RepeatDirection="Horizontal" BorderStyle="None" CellPadding="0" CellSpacing="0">
                    <asp:ListItem Selected="True" Value="A">满意</asp:ListItem>
                    <asp:ListItem Value="B">基本满意</asp:ListItem>
                    <asp:ListItem Value="C">不满意</asp:ListItem>
                </asp:RadioButtonList></td>
              </tr>
              <tr>
                <td height="24" align="center"> 2 </td>
                <td style="width: 440px"> 您认为该服务区公益服务如何 </td>
                <td align="center" style="width: 339px"><asp:RadioButtonList ID="rdogy" runat="server" RepeatDirection="Horizontal" BorderStyle="None" CellPadding="0" CellSpacing="0">
                    <asp:ListItem Selected="True" Value="A">满意</asp:ListItem>
                    <asp:ListItem Value="B">基本满意</asp:ListItem>
                    <asp:ListItem Value="C">不满意</asp:ListItem>
                </asp:RadioButtonList></td>
              </tr>
              <tr>
                <td height="25" align="center"> 3 </td>
                <td style="width: 440px"> 您认为该服务区经营项目收费标准是否合理 </td>
               <td align="center" style="width: 339px"><asp:RadioButtonList ID="rdosf" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                   <asp:ListItem Selected="True" Value="A">满意</asp:ListItem>
                   <asp:ListItem Value="B">基本满意</asp:ListItem>
                   <asp:ListItem Value="C">不满意</asp:ListItem>
               </asp:RadioButtonList></td>
              </tr>
              <tr>
                <td height="28" align="center"> 4 </td>
                <td style="width: 440px"> 您认为该服务区环境卫生状况如何 </td>
                <td align="center" style="width: 339px"><asp:RadioButtonList ID="rdohj" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                    <asp:ListItem Selected="True" Value="A">满意</asp:ListItem>
                    <asp:ListItem Value="B">基本满意</asp:ListItem>
                    <asp:ListItem Value="C">不满意</asp:ListItem>
                </asp:RadioButtonList></td>
              </tr>
              <tr>
                <td align="center" > 5 </td>
                <td style="width: 440px" > 您认为该服务区停车场安全管理如何 </td>
             <td align="center" ><asp:RadioButtonList ID="rdotc" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                 <asp:ListItem Selected="True" Value="A">满意</asp:ListItem>
                 <asp:ListItem Value="B">基本满意</asp:ListItem>
                 <asp:ListItem Value="C">不满意</asp:ListItem>
             </asp:RadioButtonList></td>
              </tr>
              <tr>
                <td height="24" align="center"> 6 </td>
                <td style="width: 440px"> 您对该服务区规范化管理情况评价如何 </td>
                <td align="center" style="width: 339px"><asp:RadioButtonList ID="rdogl" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                    <asp:ListItem Selected="True" Value="A">满意</asp:ListItem>
                    <asp:ListItem Value="B">基本满意</asp:ListItem>
                    <asp:ListItem Value="C">不满意</asp:ListItem>
                </asp:RadioButtonList></td>
              </tr>
              <tr>
                <td height="22" align="center"> 7 </td>
                <td style="width: 440px"> 该服务区在夜间是否能得到有效服务 </td>
               <td align="center" style="width: 339px"><asp:RadioButtonList ID="rdoyj" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                   <asp:ListItem Selected="True" Value="A">满意</asp:ListItem>
                   <asp:ListItem Value="B">基本满意</asp:ListItem>
                   <asp:ListItem Value="C">不满意</asp:ListItem>
               </asp:RadioButtonList></td>
              </tr>
              <tr>
                <td height="24" align="center"> 8 </td>
                <td style="width: 440px"> 该服务区的治安情况评价 </td>
                <td align="center" style="width: 339px"><asp:RadioButtonList ID="rdoza" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                    <asp:ListItem Selected="True" Value="A">满意</asp:ListItem>
                    <asp:ListItem Value="B">基本满意</asp:ListItem>
                    <asp:ListItem Value="C">不满意</asp:ListItem>
                </asp:RadioButtonList></td>
              </tr>
              <tr>
                <td height="24" align="center"> 9 </td>
                <td style="width: 440px"> 您认为该服务区各项硬件设施是否能满足实际需要 </td>
                <td align="center" style="width: 339px"><asp:RadioButtonList ID="rdoss" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                    <asp:ListItem Selected="True" Value="A">满意</asp:ListItem>
                    <asp:ListItem Value="B">基本满意</asp:ListItem>
                    <asp:ListItem Value="C">不满意</asp:ListItem>
                </asp:RadioButtonList></td>
              </tr>
              <tr>
                <td height="24" align="center"> 10 </td>
                <td style="width: 440px"> 您对该服务区公厕设施、卫生的评价 </td>
              <td align="center" style="width: 339px"><asp:RadioButtonList ID="rdogc" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                  <asp:ListItem Selected="True" Value="A">满意</asp:ListItem>
                  <asp:ListItem Value="B">基本满意</asp:ListItem>
                  <asp:ListItem Value="C">不满意</asp:ListItem>
              </asp:RadioButtonList></td>
              </tr>
              <tr>
                <td height="23" align="center"> 11 </td>
                <td style="width: 440px"> 您对该服务区的超市（便利店）营业员服务工作是否满意 </td>
               <td align="center" style="width: 339px"><asp:RadioButtonList ID="rdocs" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                   <asp:ListItem Selected="True" Value="A">满意</asp:ListItem>
                   <asp:ListItem Value="B">基本满意</asp:ListItem>
                   <asp:ListItem Value="C">不满意</asp:ListItem>
               </asp:RadioButtonList></td>
              </tr>
              <tr>
                <td height="24" align="center"> 12 </td>
                <td style="width: 440px"> 您对该服务区的餐饮服务工作是否满意 </td>
               <td align="center" style="width: 339px"><asp:RadioButtonList ID="rdocy" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                   <asp:ListItem Selected="True" Value="A">满意</asp:ListItem>
                   <asp:ListItem Value="B">基本满意</asp:ListItem>
                   <asp:ListItem Value="C">不满意</asp:ListItem>
               </asp:RadioButtonList></td>
              </tr>
              <tr>
                <td height="26" align="center"> 13 </td>
                <td style="width: 440px"> 您对该服务区的客房服务工作是否满意 </td>
               <td align="center" style="width: 339px"><asp:RadioButtonList ID="rdokf" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                   <asp:ListItem Selected="True" Value="A">满意</asp:ListItem>
                   <asp:ListItem Value="B">基本满意</asp:ListItem>
                   <asp:ListItem Value="C">不满意</asp:ListItem>
               </asp:RadioButtonList></td>
              </tr>
              <tr>
                <td height="29" align="center"> 14 </td>
                <td style="width: 440px">您对该服务区的加油站服务工作是否满意</td>
              <td align="center" style="width: 339px"><asp:RadioButtonList ID="rdojy" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                  <asp:ListItem Selected="True" Value="A">满意</asp:ListItem>
                  <asp:ListItem Value="B">基本满意</asp:ListItem>
                  <asp:ListItem Value="C">不满意</asp:ListItem>
              </asp:RadioButtonList></td>
              </tr>
              <tr>
                <td height="24" align="center"> 15 </td>
                <td style="width: 440px"> 您对该服务区的汽修服务工作是否满意 </td>
                <td align="center" style="width: 339px"><asp:RadioButtonList ID="rdoqx" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                    <asp:ListItem Selected="True" Value="A">满意</asp:ListItem>
                    <asp:ListItem Value="B">基本满意</asp:ListItem>
                    <asp:ListItem Value="C">不满意</asp:ListItem>
                </asp:RadioButtonList></td>
              </tr>
              <tr>
               <td colspan="3"><br /><p>请顾客留下宝贵的意见：</p>
                   <asp:TextBox ID="txtRemark" runat="server" CssClass="inputborder1" Height="86px" TextMode="MultiLine" Width="611px"></asp:TextBox><br /><p style=" padding-left:100px;">
                       <asp:Button ID="btnSubmit" runat="server" Text="提交" Height="25px" Width="65px" OnClick="btnSubmit_Click" />&nbsp;&nbsp;<asp:Button
                           ID="btnReset" runat="server" Text="重置" Height="25px" OnClick="btnReset_Click" Width="65px" /></p>
                   <asp:Literal ID="Literal1" runat="server"></asp:Literal><br /></td>
              </tr>
          </table>
            </div>
    	</dd>
            <dd class="pager_b"></dd>
        </dl>
        </div>
    <div>
    	<dl id="jiben">
            <dt><p class="more37"><a href="ServiceBasicInfo.aspx" >更多 >></a></p>基本信息</dt><dd><div class="wid200">
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
            <p class="right"><a href="#">参与投票</a></p>
        <a href="SurveyResult.aspx" target="_blank">投票结果</a></div>
      </div>
    </div>
    <div class="clear"></div>
</div>
</asp:Content>

