<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditServiceInfo.aspx.cs" Inherits="AdminMgr_EditServiceInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>服务区信息编辑</title>
     <link href="style/css.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript">
         function ShowSelectedDiv( p){
             for(var i=1;i<11;i++){
                if(i==p){
                 document.getElementById("divContent"+p).style.display="block";
                }else{
                  document.getElementById("divContent"+i).style.display="none";
                }
             }
         }
     </script>

</head>
<body>
 <form id="form1" runat="server">
    <div  class="righttopnavbg">编辑服务区信息</div>
	<div class="serviceBtnOut" style="margin-left:10px;" id="divNav1" onclick="ShowSelectedDiv(1)"><a href="#">基本信息</a></div>
	<div class="serviceBtnOut" id="divNav2" onclick="ShowSelectedDiv(2)"><a href="#">服务区照片</a></div>
	<div class="serviceBtnOut" id="divNav3" onclick="ShowSelectedDiv(3)"><a href="#">餐厅照片</a></div>
	<div class="serviceBtnOut" id="divNav4" onclick="ShowSelectedDiv(4)"><a href="#">超市照片</a></div>
	<div class="serviceBtnOut" id="divNav5" onclick="ShowSelectedDiv(5)"><a href="#">客房照片</a></div>
	<div class="serviceBtnOut" id="divNav6" onclick="ShowSelectedDiv(6)"><a href="#">加油站照片</a></div>
	<div class="serviceBtnOut" id="divNav7" onclick="ShowSelectedDiv(7)"><a href="#">汽修照片</a></div>
	<div class="serviceBtnOut" id="divNav8" onclick="ShowSelectedDiv(8)"><a href="#">停车场照片</a></div>
	<div class="serviceBtnOut" id="divNav9" onclick="ShowSelectedDiv(9)"><a href="#">卫生间照片</a></div>
	<div class="serviceBtnOut" id="divNav10" onclick="ShowSelectedDiv(10)"><a href="#">服务队伍照片</a></div>

	<div style="width:100%; height:2px;"><img src="images/navbg.jpg"  width="100%" height="2"/></div>
	
	<div id="divContent1" style="display:block">
	 <br />
	 <table width="820" border="1"  cellpadding="0" cellspacing="0" style="border-collapse:collapse; margin-left:10px;" bordercolor="#B8C9D6">
  <tr>
    <td height="30" align="right" style="width: 114px">服务区名称</td>
    <td style="width: 323px">
        <asp:TextBox ID="txtName" runat="server" BackColor="Silver" CssClass="InputBorderStyle"
            ReadOnly="True" Width="200px"></asp:TextBox></td>
    <td align="right" style="width: 94px">评定星级</td>
    <td style="width: 315px">
        <asp:DropDownList ID="ddlStar" runat="server" CssClass="TextAreaStyle" Width="205px">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem>★</asp:ListItem>
            <asp:ListItem>★★</asp:ListItem>
            <asp:ListItem>★★★</asp:ListItem>
            <asp:ListItem>★★★★</asp:ListItem>
            <asp:ListItem>★★★★★</asp:ListItem>
            <asp:ListItem>优秀停车区</asp:ListItem>
        </asp:DropDownList></td>
  </tr>
  <tr>
    <td height="30" align="right" style="width: 114px">类型</td>
    <td style="width: 323px">
        <asp:DropDownList ID="ddlType" runat="server" CssClass="TextAreaStyle" Width="206px">
            <asp:ListItem>服务区</asp:ListItem>
            <asp:ListItem>停车区</asp:ListItem>
        </asp:DropDownList></td>
    <td align="right" style="width: 94px">归属路段高速</td>
    <td style="width: 315px">
        <asp:DropDownList ID="ddlGs" runat="server" CssClass="TextAreaStyle" Width="205px">        </asp:DropDownList></td>
  </tr>
  <tr>
    <td align="right" style="height: 31px; width: 114px;">里程桩号</td>
    <td style="height: 31px; width: 323px;">
        <asp:TextBox ID="txtStake" runat="server" CssClass="InputBorderStyle" Width="200px"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
    <td align="right" style="height: 31px; width: 94px;">联系电话</td>
    <td style="height: 31px; width: 315px;">
        <asp:TextBox ID="txtPhone" runat="server" CssClass="InputBorderStyle" Width="200px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="30" align="right" style="width: 114px">里程数</td>
    <td style="width: 323px">        
        <asp:TextBox ID="txtStakeNum" runat="server" CssClass="InputBorderStyle" Width="200px"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
    <td align="right" style="width: 94px">所属地市</td>
    <td style="width: 315px"><asp:DropDownList ID="ddlCity" runat="server" CssClass="TextAreaStyle" Width="205px">        </asp:DropDownList>
        </td>
  </tr>
  <tr>
    <td height="30" align="right" style="width: 114px">服务项目</td>
    <td colspan="3">
        <asp:TextBox ID="txtServices" runat="server" CssClass="InputBorderStyle" Width="700px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="30" align="right" style="width: 114px">欢迎辞</td>
    <td colspan="3">
        <asp:TextBox ID="txtWelcome" runat="server" CssClass="InputBorderStyle" Width="700px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="30" align="right" style="width: 114px">
        餐厅简介</td>
    <td style="width: 323px">
        <asp:TextBox ID="txtCYRemark" runat="server" CssClass="TextAreaStyle" Height="80px"
            TextMode="MultiLine" Width="300px"></asp:TextBox></td>
    <td align="right" style="width: 94px">超市简介</td>
    <td style="width: 315px">
        <asp:TextBox ID="txtCSRemark" runat="server" CssClass="TextAreaStyle" Height="80px"
            TextMode="MultiLine" Width="300px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="30" align="right" style="width: 114px">客房简介</td>
    <td style="width: 323px">
        <asp:TextBox ID="txtZSRemark" runat="server" CssClass="TextAreaStyle" Height="80px"
            TextMode="MultiLine" Width="300px"></asp:TextBox>
        </td>
    <td align="right" style="width: 94px">
        加油站简介</td>
    <td style="width: 315px">
    <asp:TextBox ID="txtJYZRemark" runat="server" CssClass="TextAreaStyle" Height="80px"
            TextMode="MultiLine" Width="300px"></asp:TextBox>
        </td>
  </tr>
  <tr>
    <td height="30" align="right" style="width: 114px">汽修简介</td>
    <td style="width: 323px">
        <asp:TextBox ID="txtQXRemark" runat="server" CssClass="TextAreaStyle" Height="80px"
            TextMode="MultiLine" Width="300px"></asp:TextBox></td>
    <td align="right" style="width: 94px">停车场简介</td>
    <td style="width: 315px">
        <asp:TextBox ID="txtTCSRemark" runat="server" CssClass="TextAreaStyle" Height="80px"
            TextMode="MultiLine" Width="300px"></asp:TextBox></td>
  </tr>
   <tr>
    <td height="30" align="right" style="width: 114px">卫生间简介</td>
    <td style="width: 323px">
        <asp:TextBox ID="txtWSJRemark" runat="server" CssClass="TextAreaStyle" Height="80px"
            TextMode="MultiLine" Width="300px"></asp:TextBox></td>
    <td align="right" style="width: 94px">服务队伍简介</td>
    <td style="width: 315px">
        <asp:TextBox ID="txtFWDWRemark" runat="server" CssClass="TextAreaStyle" Height="80px"
            TextMode="MultiLine" Width="300px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="30" align="right" style="width: 114px">服务区简介</td>
    <td colspan="3">
        <asp:TextBox ID="txtRemark" runat="server" CssClass="TextAreaStyle" Height="80px"
            TextMode="MultiLine" Width="716px"></asp:TextBox></td>
    </tr>
  <tr>
    <td height="30" align="center" style="width: 114px">
        <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*为必填项"></asp:Label>&nbsp;</td>
    <td colspan="3">
        <asp:ImageButton ID="btnSaveInfo" runat="server" ImageUrl="~/AdminMgr/images/btnSubmit.jpg"
            OnClick="btnSaveInfo_Click" />
        <asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
    </tr>
	 <tr>
    <td height="40" colspan="4">&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*"></asp:Label>
        请认真填写服务区信息，务必保证数据的规范、完整、准确，各服务项目简介要展示其基本服务信息及主要功能(如：营业时间、联系方式、车位数、油种等等)。</td>
    </tr>
</table>
	</div>
	
	<div id="divContent2" style="display:none">
	<br />
	<table width="740px" border="1"  cellpadding="0" cellspacing="0" bordercolor="#B8C9D6"  style="border-collapse:collapse; margin-left:10px;">
  <tr>
    <td width="130px"  height="30" align="right"  >服务区照片</td>
    <td  style="width:607px;">
        <asp:Image ID="ImgService" runat="server" Width="600px" /></td>
  </tr>
  <tr>
    <td height="30" align="right" >文件上传</td>
    <td>
        <asp:FileUpload ID="FileUploadService" runat="server" Width="359px" CssClass="TextAreaStyle" /></td>
  </tr>
  <tr>
    <td height="30" >&nbsp;</td>
    <td>
          <asp:ImageButton ID="btnSaveImage" runat="server" ImageUrl="~/AdminMgr/images/btnupload.jpg" OnClick="btnSaveImage_Click" />
    
        </td>
  </tr>
  <tr>
    <td height="40" colspan="2">
        服务区照片上传说明：上传的照片要能够展示服务区形象，照片的宽高比例为4:3，最佳宽为600像素，支持.gif、.jpg图片格式,上传新照片后替换掉原照片。</td>
    </tr>
</table>

	</div>
	
	<div id="divContent3" style="display:none" >
	    <br />
	<table width="740px" border="1"  cellpadding="0" cellspacing="0" bordercolor="#B8C9D6"  style="border-collapse:collapse; margin-left:10px;">
  <tr>
    <td   height="30" align="right" style="width: 119px"   >
        餐厅照片</td>
    <td style="width:607px;">
        <asp:Image ID="ImgCY" runat="server" Width="600px" /></td>
  </tr>
  <tr>
    <td height="30" align="right" style="width: 119px">文件上传</td>
    <td>
        <asp:FileUpload ID="FileUploadCY" runat="server" Width="359px" CssClass="TextAreaStyle" /></td>
  </tr>
  <tr>
    <td height="30" style="width: 119px">&nbsp;</td>
    <td>
        <asp:ImageButton ID="btnCY" runat="server" ImageUrl="~/AdminMgr/images/btnupload.jpg" OnClick="btnCY_Click" /></td>
  </tr>
  <tr>
    <td height="40" colspan="2">
        餐厅照片上传说明：上传的照片要能够展示餐厅形象，照片的宽高比例为4:3，最佳宽为600像素，支持.gif、.jpg图片格式,上传新照片后替换掉原照片。</td>
    </tr>
</table>
	</div>
	
	
	<div id="divContent4" style="display:none">
	 <br />
	<table width="740px" border="1"  cellpadding="0" cellspacing="0" bordercolor="#B8C9D6"  style="border-collapse:collapse; margin-left:10px;">
  <tr>
    <td   height="30" align="right" style="width: 118px"   >
        超市照片</td>
    <td  style="width:607px;">
        <asp:Image ID="ImgCS" runat="server" Width="600px" /></td>
  </tr>
  <tr>
    <td height="30" align="right" style="width: 118px">文件上传</td>
    <td>
        <asp:FileUpload ID="FileUploadCS" runat="server" Width="359px" CssClass="TextAreaStyle" /></td>
  </tr>
  <tr>
    <td height="30" style="width: 118px">&nbsp;</td>
    <td>
        <asp:ImageButton ID="btnCS" runat="server" ImageUrl="~/AdminMgr/images/btnupload.jpg" OnClick="btnCS_Click" /></td>
  </tr>
  <tr>
    <td height="40" colspan="2">
        超市照片上传说明：上传的照片要能够展示超市形象，照片的宽高比例为4:3，最佳宽为600像素，支持.gif、.jpg图片格式,上传新照片后替换掉原照片。</td>
    </tr>
</table>
	   
	</div>
	
	<div id="divContent5" style="display:none">
	   <br />
	<table width="740px" border="1" cellpadding="0" cellspacing="0" bordercolor="#B8C9D6"  style="border-collapse:collapse; margin-left:10px;">
  <tr>
    <td  height="30" align="right" style="width: 119px"   >
        客房照片</td>
    <td  style="width:607px;">
        <asp:Image ID="ImgZS" runat="server" Width="600px" /></td>
  </tr>
  <tr>
    <td height="30" align="right" style="width: 119px">文件上传</td>
    <td>
        <asp:FileUpload ID="FileUploadZS" runat="server" Width="359px" CssClass="TextAreaStyle" /></td>
  </tr>
  <tr>
    <td height="30" style="width: 119px">&nbsp;</td>
    <td>
        <asp:ImageButton ID="btnZS" runat="server" ImageUrl="~/AdminMgr/images/btnupload.jpg" OnClick="btnZS_Click" /></td>
  </tr>
  <tr>
    <td height="40" colspan="2">
        客房照片上传说明：上传的照片要能够展示客房形象，照片的宽高比例为4:3，最佳宽为600像素，支持.gif、.jpg图片格式,上传新照片后替换掉原照片。</td>
    </tr>
</table>
	</div>
	
	<div id="divContent6" style="display:none">
	    <br />
	<table width="740px" border="1" cellpadding="0" cellspacing="0" bordercolor="#B8C9D6"  style="border-collapse:collapse; margin-left:10px;">
  <tr>
    <td   height="30" align="right" style="width: 130px"  >
        加油站照片</td>
    <td  style="width:607px;">
        <asp:Image ID="ImgJYZ" runat="server" Width="600px" /></td>
  </tr>
  <tr>
    <td height="30" align="right" style="width: 130px">文件上传</td>
    <td>
        <asp:FileUpload ID="FileUploadJYZ" runat="server" Width="359px" CssClass="TextAreaStyle" /></td>
  </tr>
  <tr>
    <td height="30" style="width: 130px">&nbsp;</td>
    <td>
        <asp:ImageButton ID="btnJYZ" runat="server" ImageUrl="~/AdminMgr/images/btnupload.jpg" OnClick="btnJYZ_Click" /></td>
  </tr>
  <tr>
    <td height="40" colspan="2">
        加油站照片上传说明：上传的照片要能够展示加油站形象，照片的宽高比例为4:3，最佳宽为600像素，支持.gif、.jpg图片格式,上传新照片后替换掉原照片。</td>
    </tr>
</table>
	</div>
	
	<div id="divContent7" style="display:none">
	   <br />
	<table width="740px;"  border="1"  cellpadding="0" cellspacing="0" bordercolor="#B8C9D6"  style="border-collapse:collapse; margin-left:10px;">
  <tr>
    <td   height="30" align="right" style="width: 135px"   >
        汽修照片</td>
    <td style="width:607px;" >
        <asp:Image ID="ImgQX" runat="server" Width="600px" /></td>
  </tr>
  <tr>
    <td height="30" align="right" style="width: 135px">文件上传</td>
    <td>
        <asp:FileUpload ID="FileUploadQX" runat="server" Width="359px" CssClass="TextAreaStyle" /></td>
  </tr>
  <tr>
    <td height="30" style="width: 135px">&nbsp;</td>
    <td>
        <asp:ImageButton ID="btnQX" runat="server" ImageUrl="~/AdminMgr/images/btnupload.jpg" OnClick="btnQX_Click" /></td>
  </tr>
  <tr>
    <td height="40" colspan="2">
        汽修照片上传说明：上传的照片要能够展示汽车修理厂形象，照片的宽高比例为4:3，最佳宽为600像素，支持.gif、.jpg图片格式,上传新照片后替换掉原照片。</td>
    </tr>
</table>
	</div>
	
	<div id="divContent8" style="display:none">
	   <br />
	<table width="740px" border="1"  cellpadding="0" cellspacing="0" bordercolor="#B8C9D6"  style="border-collapse:collapse; margin-left:10px;">
  <tr>
    <td  height="30" align="right" style="width: 130px"   >
        停车场照片</td>
    <td  style="width:607px;">
        <asp:Image ID="ImgTCS" runat="server" Width="600px" /></td>
  </tr>
  <tr>
    <td height="30" align="right" style="width: 130px">文件上传</td>
    <td>
        <asp:FileUpload ID="FileUploadTCS" runat="server" Width="359px" CssClass="TextAreaStyle" /></td>
  </tr>
  <tr>
    <td height="30" style="width: 130px">&nbsp;</td>
    <td>
        <asp:ImageButton ID="btnTCS" runat="server" ImageUrl="~/AdminMgr/images/btnupload.jpg" OnClick="btnTCS_Click" /></td>
  </tr>
  <tr>
    <td height="40" colspan="2">
        停车场照片上传说明：上传的照片要能够展示停车场形象，照片的宽高比例为4:3，最佳宽为600像素，支持.gif、.jpg图片格式,上传新照片后替换掉原照片。</td>
    </tr>
</table>
	</div>
	
	
	<div id="divContent9" style="display:none">
	   <br />
	<table width="740px" border="1"  cellpadding="0" cellspacing="0" bordercolor="#B8C9D6"  style="border-collapse:collapse; margin-left:10px;">
  <tr>
    <td width="130px"   height="30" align="right"   >
        卫生间照片</td>
    <td  style="width:607px;">
        <asp:Image ID="ImgWSJ" runat="server" Width="600px" /></td>
  </tr>
  <tr>
    <td height="30px" align="right">文件上传</td>
    <td>
        <asp:FileUpload ID="FileUploadWSJ" runat="server" Width="359px" CssClass="TextAreaStyle" /></td>
  </tr>
  <tr>
    <td height="30">&nbsp;</td>
    <td>
        <asp:ImageButton ID="btnWSJ" runat="server" ImageUrl="~/AdminMgr/images/btnupload.jpg" OnClick="btnWSJ_Click" /></td>
  </tr>
  <tr>
    <td height="40" colspan="2">
        卫生间照片上传说明：上传的照片要能够展示卫生间形象，照片的宽高比例为4:3，最佳宽为600像素，支持.gif、.jpg图片格式,上传新照片后替换掉原照片。</td>
    </tr>
</table>
	</div>
	
	
	
	<div id="divContent10" style="display:none">
	   <br />
	<table width="740px" border="1"  cellpadding="0" cellspacing="0" bordercolor="#B8C9D6"  style="border-collapse:collapse; margin-left:10px;">
  <tr>
    <td   height="30" align="right" style="width: 139px"  >
        服务队伍照片</td>
    <td style="width:607px;"  >
        <asp:Image ID="ImgFWDW" runat="server" Width="600px" /></td>
  </tr>
  <tr>
    <td height="30" align="right" style="width: 139px">文件上传</td>
    <td>
        <asp:FileUpload ID="FileUploadFWDW" runat="server" Width="359px" CssClass="TextAreaStyle" /></td>
  </tr>
  <tr>
    <td height="30" style="width: 139px">&nbsp;</td>
    <td>
        <asp:ImageButton ID="btnFWDW" runat="server" ImageUrl="~/AdminMgr/images/btnupload.jpg" OnClick="btnFWDW_Click" /></td>
  </tr>
  <tr>
    <td height="40" colspan="2">
        服务队伍照片上传说明：上传的照片要能够展示服务队伍形象，照片的宽高比例为4:3，最佳宽为600像素，支持.gif、.jpg图片格式,上传新照片后替换掉原照片。</td>
    </tr>
</table>
	</div>
	
	
	</form>
</body>
</html>
