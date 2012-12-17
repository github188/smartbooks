<%@ Page Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="index.aspx.cs"
    Inherits="index" Title="Untitled Page" %>

<%@ Import Namespace="Model" %>
<%@ Import Namespace="DataAccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        var PicsGlidePad = new function () {
            function $id(id) { return document.getElementById(id); };
            this.picsGlide = function (auto, oEventCont, oSlider, sSingleSize, second, fSpeed, point) {
                var oSubLi = $id(oEventCont).getElementsByTagName('li');
                var interval, timeout, oslideRange;
                var time = 1;
                var speed = fSpeed
                var sum = oSubLi.length;
                var a = 0;
                var delay = second * 1000;
                var setValLeft = function (s) {
                    return function () {
                        oslideRange = Math.abs(parseInt($id(oSlider).style[point]));
                        $id(oSlider).style[point] = -Math.floor(oslideRange + (parseInt(s * sSingleSize) - oslideRange) * speed) + 'px';
                        if (oslideRange == [(sSingleSize * s)]) {
                            clearInterval(interval);
                            a = s;
                        }
                    }
                };
                var setValRight = function (s) {
                    return function () {
                        oslideRange = Math.abs(parseInt($id(oSlider).style[point]));
                        $id(oSlider).style[point] = -Math.ceil(oslideRange + (parseInt(s * sSingleSize) - oslideRange) * speed) + 'px';
                        if (oslideRange == [(sSingleSize * s)]) {
                            clearInterval(interval);
                            a = s;
                        }
                    }
                }
                function autoGlide() {
                    for (var c = 0; c < sum; c++) { oSubLi[c].className = ''; };
                    clearTimeout(interval);
                    if (a == (parseInt(sum) - 1)) {
                        for (var c = 0; c < sum; c++) { oSubLi[c].className = ''; };
                        a = 0;
                        oSubLi[a].className = "active";
                        interval = setInterval(setValLeft(a), time);
                        timeout = setTimeout(autoGlide, delay);
                    } else {
                        a++;
                        oSubLi[a].className = "active";
                        interval = setInterval(setValRight(a), time);
                        timeout = setTimeout(autoGlide, delay);
                    }
                }
                if (auto) { timeout = setTimeout(autoGlide, delay); };
                for (var i = 0; i < sum; i++) {
                    oSubLi[i].onmouseover = (function (i) {
                        return function () {
                            for (var c = 0; c < sum; c++) { oSubLi[c].className = ''; };
                            clearTimeout(timeout);
                            clearInterval(interval);
                            oSubLi[i].className = "active";
                            if (Math.abs(parseInt($id(oSlider).style[point])) > [(sSingleSize * i)]) {
                                interval = setInterval(setValLeft(i), time);
                                this.onmouseout = function () { if (auto) { timeout = setTimeout(autoGlide, delay); }; };
                            } else if (Math.abs(parseInt($id(oSlider).style[point])) < [(sSingleSize * i)]) {
                                interval = setInterval(setValRight(i), time);
                                this.onmouseout = function () { if (auto) { timeout = setTimeout(autoGlide, delay); }; };
                            }
                        }
                    })(i)
                }
            }
        }
    </script>
    <script type="text/javascript" language="javascript">
        function ShowItemDiv(itemName, sonItemCount, sonItemIndex) {
            for (var i = 1; i <= sonItemCount; i++) {
                if (sonItemIndex == i) {
                    document.getElementById(itemName + "div" + sonItemIndex).style.display = "block";
                } else {
                    document.getElementById(itemName + "div" + i).style.display = "none";
                }
            }
        }
    </script>
    <!--主体-->
    <div id="main">
        <!--第一层-->
        <div class="mar_t10">
            <div class="left">
                <dl id="jiben">
                    <dt>
                        <p class="more37">
                            <a href="ServiceBasicInfo.aspx" target="_blank">更多 >></a></p>
                        基本信息</dt><dd><div class="wid200">
                            <p class="align fon16">
                                <%=((ServiceInfo)Session["serviceinfo"]).S_Name %></p>
                            <p class="align" style="padding: 7px 0;">
                                <%
                                    if (((ServiceInfo)Session["serviceinfo"]).S_Star == "★★★★★")
                                    { 
                                %>
                                <img src="images/star.jpg" alt="五星级服务区" />
                                <%
                                    }
                    else if (((ServiceInfo)Session["serviceinfo"]).S_Star == "★★★★")
                    {
                                %>
                                <img src="images/4star.jpg" alt="四星级服务区" />
                                <%
                                    }
                    else if (((ServiceInfo)Session["serviceinfo"]).S_Star == "★★★")
                    {
                                %>
                                <img src="images/3star.jpg" alt="三星级服务区" />
                                <%
                                    }
                    else if (((ServiceInfo)Session["serviceinfo"]).S_Star == "★★")
                    {
                                %>
                                <img src="images/2star.jpg" alt="二星级服务区" />
                                <%
                                    }
                    else if (((ServiceInfo)Session["serviceinfo"]).S_Star == "★")
                    {
                                %>
                                <img src="images/1star.jpg" alt="一星级服务区" />
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
                                <a href='ServiceImg/<%=((ServiceInfo)Session["serviceinfo"]).S_Image %>' rel="lightbox[serviceimg]"
                                    title='<%=((ServiceInfo)Session["serviceinfo"]).S_Name %>形象照片'>
                                    <img src='ServiceImg/<%=((ServiceInfo)Session["serviceinfo"]).S_Image %>' width="96"
                                        height="72" alt="<%=((ServiceInfo)Session["serviceinfo"]).S_Name %>形象照片" /></a></p>
                            <span title="<%=((ServiceInfo)Session["serviceinfo"]).S_Remark %>">
                                <%=PubClass.Tool.SubString(((ServiceInfo)Session["serviceinfo"]).S_Remark, 64)%>
                            </span>
                        </div>
                        </dd>
                    <dd class="jiben_b">
                    </dd>
                </dl>
                <div class="diaocha">
                    <div class="diaocha_con">
                        <p class="right">
                            <a href="ServiceVote.aspx" target="_blank">参与投票</a></p>
                        <a href="SurveyResult.aspx" target="_blank">投票结果</a></div>
                </div>
            </div>
            <div class="left mar_l10">
                <dl id="news">
                    <dt>
                        <p class="more37">
                            <a href="ServiceNewsList.aspx" target="_blank">更多 >></a></p>
                        驿站新闻</dt><dd><div class="news_con">
                            <ul class="newlist right">
                                <asp:Repeater ID="rptYzNews" runat="server">
                                    <ItemTemplate>
                                        <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString()) %>]</span><a
                                            href='NewsDetailInfo.aspx?nid=<%# Eval("N_ID") %>' target="_blank" title='<%# Eval("N_Title") %>'><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),19) %></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                            <div class="picsGlide1">
                                <%-- 出错了--%>
                                <ul id="GlideList2" class="GsPicList" style="left: 0;">
                                    <asp:Repeater ID="rptPicNews" runat="server">
                                        <ItemTemplate>
                                            <li><a href='newsImages/<%# CommonFunction._GetMidInfo(Eval("N_Title").ToString(),"{","}") %>'
                                                rel="lightbox[picnews]" title='<%# CommonFunction._GetMidInfo(Eval("N_Title").ToString(),"(",")") %>'>
                                                <img src='newsImages/<%# CommonFunction._GetMidInfo(Eval("N_Title").ToString(),"[","]") %>'
                                                    alt='<%# CommonFunction._GetMidInfo(Eval("N_Title").ToString(),"(",")") %>' /></a>
                                                <div class="title">
                                                    <a href='NewsDetailInfo.aspx?nid=<%# Eval("N_ID") %>' target="_blank" title='<%# CommonFunction._GetMidInfo(Eval("N_Title").ToString(), "(", ")") %>'>
                                                        <%# PubClass.Tool.SubString(CommonFunction._GetMidInfo(Eval("N_Title").ToString(), "(", ")"), 10)%></a></div>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                                <ul id="Glide2" class="GlideList">
                                    <%
                                        if (ViewState["rptPicNews"] != null)
                                        {
                                            System.Data.DataTable dtPicNews = (System.Data.DataTable)ViewState["rptPicNews"];
                                            for (int i = 1; i <= dtPicNews.Rows.Count; i++)
                                            {
                                                if (i == 1)
                                                {
                                    %>
                                    <li class="active">1</li><%
}
                            else
                            { 
                                    %><li>
                                        <%=i %></li>
                                    <%        
                                        }
                        }
                    }
                                    %>
                                </ul>
                            </div>
                            <script type="text/javascript">
                                PicsGlidePad.picsGlide(true, 'Glide2', 'GlideList2', 150, 3, 0.1, 'left');
                            </script>
                        </div>
                        </dd>
                    <dd class="news_b">
                    </dd>
                </dl>
                <dl id="zhengshu" class="mar_t10">
                    <dt>
                        <p class="more32">
                            <a href="CertificateList.aspx" target="_blank">更多 >></a></p>
                    </dt>
                    <dd>
                        <ul class="zhengshu">
                            <asp:Repeater ID="rptISO" runat="server">
                                <ItemTemplate>
                                    <%if (dtISO.Rows.Count > 0)
                                      {%>
                                    <li><a href='CertificateImg/<%# CommonFunction._GetMidInfo(Eval("N_Title").ToString(),"{","}") %>'
                                        rel="lightbox[iso]" title='<%# Eval("N_Content") %>'>
                                        <p>
                                            <img src="CertificateImg/<%# CommonFunction._GetMidInfo(Eval("N_Title").ToString(),"[","]") %>"
                                                width="128" alt='<%# Eval("N_Content") %>' /></p>
                                    </a><a href='CertificateImg/<%# CommonFunction._GetMidInfo(Eval("N_Title").ToString(),"{","}") %>'
                                        rel="lightbox[isot]" title='<%# Eval("N_Content") %>'>
                                        <%# PubClass.Tool.SubString(Eval("N_Content").ToString(),19)%></a></li>
                                    <%} %>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                        <div class="clear">
                        </div>
                    </dd>
                    <dd class="zhengshu_b">
                    </dd>
                </dl>
            </div>
            <div class="left mar_l10">
                <dl id="gonggao">
                    <dt>
                        <p class="more37">
                            <a href="SiteNoticeList.aspx?tid=2" target="_blank">更多 >></a></p>
                        站内公告</dt><dd><div class="gonggao_con">
                            <marquee direction="up" scrollamount="3" height="132px" width="230px">
                                <ul class="gglist">
                                    <asp:Repeater ID="rptSiteNotice" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <%# Eval("N_Content") %><span>[<%# PubClass.Tool.Get_ShortDate(Eval("N_Time").ToString())%>]</span></li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul></marquee>
                        </div>
                        </dd>
                    <dd class="gonggao_b">
                    </dd>
                </dl>
                <dl id="guanli" class="mar_t10">
                    <dt>
                        <p class="more37">
                            <a href="NewsList.aspx?tid=3" target="_blank">更多 >></a></p>
                        管理制度</dt><dd><div class="guanli_con">
                            <ul class="gllist">
                                <asp:Repeater ID="rptGLZD" runat="server">
                                    <ItemTemplate>
                                        <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("N_Time").ToString())%>]</span><a
                                            href='NewsDetailInfo.aspx?nid=<%# Eval("N_ID") %>' target="_blank" title='<%# Eval("N_Title") %>'><%# PubClass.Tool.SubString(Eval("N_Title").ToString(),14) %></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        </dd>
                    <dd class="guanli_b">
                    </dd>
                </dl>
            </div>
            <div class="clear">
            </div>
        </div>
        <!--第二层-->
        <div class="mar_t10">
            <div class="serivcelist_t">
                <p class="right mar_t20 mar_r20">
                    <span style="color: #039">服务内容：餐厅服务、超市服务、加油服务、客房服务、汽修服务、停车服务</span></p>
            </div>
            <div class="servicelist_bg left type">
                <table width="320" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <th width="63" align="center">
                            餐厅<br />
                            服务
                        </th>
                        <td width="257">
                            <div class="typestyle">
                                <a href='javascript:ShowItemDiv("item1",7,1)'>经营品种</a> <a href='javascript:ShowItemDiv("item1",7,2)'>
                                    收费标准</a> <a href='javascript:ShowItemDiv("item1",7,3)'>提供餐别</a> <a href='javascript:ShowItemDiv("item1",7,4)'
                                        style="border-right: none;">服务承诺</a> <a href='javascript:ShowItemDiv("item1",7,5)'>自助餐标准</a>
                                <a href='javascript:ShowItemDiv("item1",7,6)'>会议培训用餐</a> <a href='javascript:ShowItemDiv("item1",7,7)'>
                                    特色菜品</a>
                            </div>
                        </td>
                    </tr>
                </table>
                <div id="item1div1" style="display: block">
                    <ul class="typelist">
                        <asp:Repeater ID="rptitem1div1" runat="server">
                            <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("I_Time").ToString()) %>]</span><a
                                    href='ServiceItemDetail.aspx?itemid=<%# Eval("I_ID") %>' target="_blank" title='<%# Eval("I_Title") %>'>
                                    <%# PubClass.Tool.SubString(Eval("I_Title").ToString(),19) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div id="item1div2" style="display: none">
                    <ul class="typelist">
                        <asp:Repeater ID="rptitem1div2" runat="server">
                            <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("I_Time").ToString()) %>]</span><a
                                    href='ServiceItemDetail.aspx?itemid=<%# Eval("I_ID") %>' target="_blank" title='<%# Eval("I_Title") %>'>
                                    <%# PubClass.Tool.SubString(Eval("I_Title").ToString(),19) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div id="item1div3" style="display: none">
                    <ul class="typelist">
                        <asp:Repeater ID="rptitem1div3" runat="server">
                            <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("I_Time").ToString()) %>]</span><a
                                    href='ServiceItemDetail.aspx?itemid=<%# Eval("I_ID") %>' target="_blank" title='<%# Eval("I_Title") %>'>
                                    <%# PubClass.Tool.SubString(Eval("I_Title").ToString(),19) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div id="item1div4" style="display: none">
                    <ul class="typelist">
                        <asp:Repeater ID="rptitem1div4" runat="server">
                            <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("I_Time").ToString()) %>]</span><a
                                    href='ServiceItemDetail.aspx?itemid=<%# Eval("I_ID") %>' target="_blank" title='<%# Eval("I_Title") %>'>
                                    <%# PubClass.Tool.SubString(Eval("I_Title").ToString(),19) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div id="item1div5" style="display: none">
                    <ul class="typelist">
                        <asp:Repeater ID="rptitem1div5" runat="server">
                            <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("I_Time").ToString()) %>]</span><a
                                    href='ServiceItemDetail.aspx?itemid=<%# Eval("I_ID") %>' target="_blank" title='<%# Eval("I_Title") %>'>
                                    <%# PubClass.Tool.SubString(Eval("I_Title").ToString(),19) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div id="item1div6" style="display: none">
                    <ul class="typelist">
                        <asp:Repeater ID="rptitem1div6" runat="server">
                            <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("I_Time").ToString()) %>]</span><a
                                    href='ServiceItemDetail.aspx?itemid=<%# Eval("I_ID") %>' target="_blank" title='<%# Eval("I_Title") %>'>
                                    <%# PubClass.Tool.SubString(Eval("I_Title").ToString(),19) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div id="item1div7" style="display: none">
                    <ul class="typelist">
                        <asp:Repeater ID="rptitem1div7" runat="server">
                            <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("I_Time").ToString()) %>]</span><a
                                    href='ServiceItemDetail.aspx?itemid=<%# Eval("I_ID") %>' target="_blank" title='<%# Eval("I_Title") %>'>
                                    <%# PubClass.Tool.SubString(Eval("I_Title").ToString(),19) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <div class="servicelist_bg left mar_l10 type">
                <table width="320" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <th width="63" align="center" valign="middle">
                            超市<br />
                            服务
                        </th>
                        <td width="257" valign="top">
                            <div class="typestyle">
                                <a href='javascript:ShowItemDiv("item2",4,1)'>经营品种</a> <a href='javascript:ShowItemDiv("item2",4,2)'>
                                    特产专柜</a> <a href='javascript:ShowItemDiv("item2",4,3)'>急救药品</a> <a href='javascript:ShowItemDiv("item2",4,4)'
                                        style="border-right: none;">工艺品</a></div>
                        </td>
                    </tr>
                </table>
                <div id="item2div1" style="display: block;">
                    <ul class="typelist">
                        <asp:Repeater ID="rptitem2div1" runat="server">
                            <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("I_Time").ToString()) %>]</span><a
                                    href='ServiceItemDetail.aspx?itemid=<%# Eval("I_ID") %>' target="_blank" title='<%# Eval("I_Title") %>'>
                                    <%# PubClass.Tool.SubString(Eval("I_Title").ToString(),19) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div id="item2div2" style="display: none">
                    <ul class="typelist">
                        <asp:Repeater ID="rptitem2div2" runat="server">
                            <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("I_Time").ToString()) %>]</span><a
                                    href='ServiceItemDetail.aspx?itemid=<%# Eval("I_ID") %>' target="_blank" title='<%# Eval("I_Title") %>'>
                                    <%# PubClass.Tool.SubString(Eval("I_Title").ToString(),19) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div id="item2div3" style="display: none">
                    <ul class="typelist">
                        <asp:Repeater ID="rptitem2div3" runat="server">
                            <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("I_Time").ToString()) %>]</span><a
                                    href='ServiceItemDetail.aspx?itemid=<%# Eval("I_ID") %>' target="_blank" title='<%# Eval("I_Title") %>'>
                                    <%# PubClass.Tool.SubString(Eval("I_Title").ToString(),19) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div id="item2div4" style="display: none">
                    <ul class="typelist">
                        <asp:Repeater ID="rptitem2div4" runat="server">
                            <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("I_Time").ToString()) %>]</span><a
                                    href='ServiceItemDetail.aspx?itemid=<%# Eval("I_ID") %>' target="_blank" title='<%# Eval("I_Title") %>'>
                                    <%# PubClass.Tool.SubString(Eval("I_Title").ToString(),19) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <div class="servicelist_bg left mar_l10 type">
                <table width="320" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <th width="63" align="center">
                            客房<br />
                            服务
                        </th>
                        <td width="257" valign="top">
                            <div class="typestyle">
                                <a href='javascript:ShowItemDiv("item3",3,1)'>供房类型</a> <a href='javascript:ShowItemDiv("item3",3,2)'>
                                    收费标准</a> <a href='javascript:ShowItemDiv("item3",3,3)'>供房数量</a></div>
                        </td>
                    </tr>
                </table>
                <div id="item3div1" style="display: block">
                    <ul class="typelist">
                        <asp:Repeater ID="rptitem3div1" runat="server">
                            <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("I_Time").ToString()) %>]</span><a
                                    href='ServiceItemDetail.aspx?itemid=<%# Eval("I_ID") %>' target="_blank" title='<%# Eval("I_Title") %>'>
                                    <%# PubClass.Tool.SubString(Eval("I_Title").ToString(),19) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div id="item3div2" style="display: none">
                    <ul class="typelist">
                        <asp:Repeater ID="rptitem3div2" runat="server">
                            <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("I_Time").ToString()) %>]</span><a
                                    href='ServiceItemDetail.aspx?itemid=<%# Eval("I_ID") %>' target="_blank" title='<%# Eval("I_Title") %>'>
                                    <%# PubClass.Tool.SubString(Eval("I_Title").ToString(),19) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div id="item3div3" style="display: none">
                    <ul class="typelist">
                        <asp:Repeater ID="rptitem3div3" runat="server">
                            <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("I_Time").ToString()) %>]</span><a
                                    href='ServiceItemDetail.aspx?itemid=<%# Eval("I_ID") %>' target="_blank" title='<%# Eval("I_Title") %>'>
                                    <%# PubClass.Tool.SubString(Eval("I_Title").ToString(),19) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <div class="servicelist_bg left type">
                <table width="320" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <th width="63" align="center">
                            加油<br />
                            服务
                        </th>
                        <td width="257" valign="top">
                            <div class="typestyle">
                                <a href='javascript:ShowItemDiv("item4",3,1)'>供应油品</a> <a href='javascript:ShowItemDiv("item4",3,2)'>
                                    油品价格</a> <a href='javascript:ShowItemDiv("item4",3,3)'>加油机数量</a></div>
                        </td>
                    </tr>
                </table>
                <div id="item4div1" style="display: block">
                    <ul class="typelist">
                        <asp:Repeater ID="rptitem4div1" runat="server">
                            <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("I_Time").ToString()) %>]</span><a
                                    href='ServiceItemDetail.aspx?itemid=<%# Eval("I_ID") %>' target="_blank" title='<%# Eval("I_Title") %>'>
                                    <%# PubClass.Tool.SubString(Eval("I_Title").ToString(),19) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div id="item4div2" style="display: none">
                    <ul class="typelist">
                        <asp:Repeater ID="rptitem4div2" runat="server">
                            <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("I_Time").ToString()) %>]</span><a
                                    href='ServiceItemDetail.aspx?itemid=<%# Eval("I_ID") %>' target="_blank" title='<%# Eval("I_Title") %>'>
                                    <%# PubClass.Tool.SubString(Eval("I_Title").ToString(),19) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div id="item4div3" style="display: none">
                    <ul class="typelist">
                        <asp:Repeater ID="rptitem4div3" runat="server">
                            <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("I_Time").ToString()) %>]</span><a
                                    href='ServiceItemDetail.aspx?itemid=<%# Eval("I_ID") %>' target="_blank" title='<%# Eval("I_Title") %>'>
                                    <%# PubClass.Tool.SubString(Eval("I_Title").ToString(),19) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <div class="servicelist_bg left mar_l10 type">
                <table width="320" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <th width="63" align="center" valign="middle">
                            汽修<br />
                            服务
                        </th>
                        <td width="257" valign="top">
                            <div class="typestyle">
                                <a href='javascript:ShowItemDiv("item5",3,1)'>维修范围</a> <a href='javascript:ShowItemDiv("item5",3,2)'>
                                    收费标准</a> <a href='javascript:ShowItemDiv("item5",3,3)'>资质类别</a></div>
                        </td>
                    </tr>
                </table>
                <div id="item5div1" style="display: block">
                    <ul class="typelist">
                        <asp:Repeater ID="rptitem5div1" runat="server">
                            <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("I_Time").ToString()) %>]</span><a
                                    href='ServiceItemDetail.aspx?itemid=<%# Eval("I_ID") %>' target="_blank" title='<%# Eval("I_Title") %>'>
                                    <%# PubClass.Tool.SubString(Eval("I_Title").ToString(),19) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div id="item5div2" style="display: none">
                    <ul class="typelist">
                        <asp:Repeater ID="rptitem5div2" runat="server">
                            <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("I_Time").ToString()) %>]</span><a
                                    href='ServiceItemDetail.aspx?itemid=<%# Eval("I_ID") %>' target="_blank" title='<%# Eval("I_Title") %>'>
                                    <%# PubClass.Tool.SubString(Eval("I_Title").ToString(),19) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div id="item5div3" style="display: none">
                    <ul class="typelist">
                        <asp:Repeater ID="rptitem5div3" runat="server">
                            <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("I_Time").ToString()) %>]</span><a
                                    href='ServiceItemDetail.aspx?itemid=<%# Eval("I_ID") %>' target="_blank" title='<%# Eval("I_Title") %>'>
                                    <%# PubClass.Tool.SubString(Eval("I_Title").ToString(),19) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <div class="servicelist_bg left mar_l10 type">
                <table width="320" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <th width="63" align="center">
                            停车<br />
                            服务
                        </th>
                        <td width="257" valign="top">
                            <div class="typestyle">
                                <a href='javascript:ShowItemDiv("item6",4,1)'>停车分区</a> <a href='javascript:ShowItemDiv("item6",4,2)'>
                                    停车位数量</a> <a href='javascript:ShowItemDiv("item6",4,3)' style="border-right: none;
                                        width: 100px;">危险品专属车位</a> <a href='javascript:ShowItemDiv("item6",4,4)'>降温加水服务</a></div>
                        </td>
                    </tr>
                </table>
                <div id="item6div1" style="display: block">
                    <ul class="typelist">
                        <asp:Repeater ID="rptitem6div1" runat="server">
                            <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("I_Time").ToString()) %>]</span><a
                                    href='ServiceItemDetail.aspx?itemid=<%# Eval("I_ID") %>' target="_blank" title='<%# Eval("I_Title") %>'>
                                    <%# PubClass.Tool.SubString(Eval("I_Title").ToString(),19) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div id="item6div2" style="display: none">
                    <ul class="typelist">
                        <asp:Repeater ID="rptitem6div2" runat="server">
                            <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("I_Time").ToString()) %>]</span><a
                                    href='ServiceItemDetail.aspx?itemid=<%# Eval("I_ID") %>' target="_blank" title='<%# Eval("I_Title") %>'>
                                    <%# PubClass.Tool.SubString(Eval("I_Title").ToString(),19) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div id="item6div3" style="display: none">
                    <ul class="typelist">
                        <asp:Repeater ID="rptitem6div3" runat="server">
                            <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("I_Time").ToString()) %>]</span><a
                                    href='ServiceItemDetail.aspx?itemid=<%# Eval("I_ID") %>' target="_blank" title='<%# Eval("I_Title") %>'>
                                    <%# PubClass.Tool.SubString(Eval("I_Title").ToString(),19) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div id="item6div4" style="display: none">
                    <ul class="typelist">
                        <asp:Repeater ID="rptitem6div4" runat="server">
                            <ItemTemplate>
                                <li><span>[<%# PubClass.Tool.Get_MonthAndDay(Eval("I_Time").ToString()) %>]</span><a
                                    href='ServiceItemDetail.aspx?itemid=<%# Eval("I_ID") %>' target="_blank" title='<%# Eval("I_Title") %>'>
                                    <%# PubClass.Tool.SubString(Eval("I_Title").ToString(),19) %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <!--第三层-->
        <div id="link">
            <dl>
                <dt>友情链接</dt><dd><asp:Repeater ID="rptMyLink" runat="server">
                    <ItemTemplate>
                        <a href='<%# Eval("L_URL") %>' title='<%# Eval("L_Title") %>' target="_blank">
                            <%# Eval("L_Title")%></a>
                    </ItemTemplate>
                </asp:Repeater>
                </dd>
            </dl>
        </div>
        <div class="clear">
        </div>
    </div>
</asp:Content>
