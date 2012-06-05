<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="SmartHyd.main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>信息首页</title>
    <link href="Css/base.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="top_bar">
        <div class="left">当前位置：系统首页>>路政工作动态</div>
    </div>
    <div style=" height:20px;"></div>
    <div style="width:710px; overflow:hidden; margin:auto">
    <div class="file right">
        <dl>
            <dt><p class="right mar_r10"><a href="javascript:void(0)">MORE</a></p></dt>
            <dd>
            	<ul style="height:162px; overflow:hidden;">

                    <li><span></span><a href=""></a></li>
                    <li><span></span><a href=""></a></li>
                    <li><span></span><a href=""></a></li>
                    <li><span></span><a href=""></a></li>
                    <li><span></span><a href=""></a></li>
                    <li><span></span><a href=""></a></li>
                    <li><span></span><a href=""></a></li>

                    <%--repeater绑定 --%>
<%--                    <asp:Repeater ID="rptGFXWJ" runat="server">
                      <ItemTemplate>
                      <li><span><a href=""></a></li>
                      </ItemTemplate>
                    </asp:Repeater>--%>
                </ul>
            </dd>
            <dd class="file_b"></dd>
        </dl>
    </div>
    <div class="laws">
    	<dl>
            <dt><p class="right mar_r10"><a href="javascript:void(0)">MORE</a></p></dt>
            <dd>
            	<ul style="height:162px; overflow:hidden;">
                    <li><span></span><a href=""></a></li>
                    <li><span></span><a href=""></a></li>
                    <li><span></span><a href=""></a></li>
                    <li><span></span><a href=""></a></li>
                    <li><span></span><a href=""></a></li>
                    <li><span></span><a href=""></a></li>
                    <li><span></span><a href=""></a></li>

<%--                    <asp:Repeater ID="rptFLFG" runat="server">
                      <ItemTemplate>
                      <li><span></span><a href="javascript:void(0)"></a></li>
                      </ItemTemplate>
                    </asp:Repeater>--%>
                </ul>
            </dd>
            <dd class="laws_b"></dd>
        </dl>
    </div>
    <div class="news right mar_t10">
    	<dl>
            <dt><p class="right mar_r10"><a href="javascript:void(0)">MORE</a></p></dt>
            <dd>
            	<ul style="height:162px; overflow:hidden;">
                    <li><span></span><a href=""></a></li>
                    <li><span></span><a href=""></a></li>
                    <li><span></span><a href=""></a></li>
                    <li><span></span><a href=""></a></li>
                    <li><span></span><a href=""></a></li>
                    <li><span></span><a href=""></a></li>
                    <li><span></span><a href=""></a></li>

<%--                <asp:Repeater ID="rptTraffic" runat="server">
                      <ItemTemplate>
                      <li><span></span><a href=“javascript:void(0)” title=""></a></li>
                      </ItemTemplate>
                    </asp:Repeater>--%>
                </ul>
            </dd>
            <dd class="news_b"></dd>
        </dl>
    </div>
    <div class="mess mar_t10">
    	<dl>
            <dt><p class="right mar_r10"><a href="javascript:void(0)">MORE</a></p></dt>
            <dd>
            	<ul style="height:162px; overflow:hidden;">
                    <li><span></span><a href=""></a></li>
                    <li><span></span><a href=""></a></li>
                    <li><span></span><a href=""></a></li>
                    <li><span></span><a href=""></a></li>
                    <li><span></span><a href=""></a></li>
                    <li><span></span><a href=""></a></li>
                    <li><span></span><a href=""></a></li>

<%--                    <asp:Repeater ID="rptTZ" runat="server">
                      <ItemTemplate>
                      <li><span></span><a href="javascript:void(0)" title=""></a></li>
                      </ItemTemplate>
                    </asp:Repeater>--%>
                </ul>
            </dd>
            <dd class="mess_b"></dd>
        </dl>
    </div>
</div>
    </form>
</body>
</html>
