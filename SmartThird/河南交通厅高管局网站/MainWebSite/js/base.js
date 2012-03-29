
function showPaper(issueId,order,type) {
    var url;
    if(type==null||type!="4"){
        url="/ViewPage.aspx?issueId="+issueId+"&order="+order;
    }else{
        url="/ShowIssue.aspx?issueId="+issueId;
    }
    
    var iWidth=window.screen.width; //窗口宽度
    var iHeight=window.screen.height;//窗口高度
    var iTop=0;
    var iLeft = 0;
    if (type == null || type != "4") {
        window.open(url, "showPaper", "Scrollbars=yes,Toolbar=no,Location=no,Resizable=yes,fullScreen=yes,Width=" + iWidth + " ,Height=" + iHeight + ",top=" + iTop + ",left=" + iLeft + ",status=yes"); 
    } else {
        window.open(url, "showPaper", "Scrollbars=yes,Toolbar=yes,Location=yes,Resizable=yes,fullScreen=no,Width=" + iWidth + " ,Height=" + iHeight + ",top=" + iTop + ",left=" + iLeft + ",status=yes"); 
    }
}


function resize(issueId,order) {
    var url="ViewPage.aspx?issueId="+issueId+"&order="+order;
    var iWidth=window.screen.width; //窗口宽度
    var iHeight=window.screen.height;//窗口高度
    var iTop=0;
    var iLeft=0;
    window.open(url,"showPaper","Scrollbars=yes,Toolbar=no,Location=no,Resizeable=yes,fullScreen=yes,Width="+iWidth+" ,Height="+iHeight+",top="+iTop+",left="+iLeft); 
}

//用div实现的弹出窗口
function showpopInfo(show) {
	//alert(show);
	if (show == "true") {
		document.getElementById("popoverlay").style.top = (window.document.body.scrollTop + document.getElementById("popoverlay").style.height) + "px";
		document.getElementById("popoverlay").style.display = "block";
		document.getElementById("popdiv").style.display = "block";
		//alert(show);
	} else {
		document.getElementById("popoverlay").style.display = "none";
		document.getElementById("popdiv").style.display = "none";
		//alert(show);
	}
}

 function getScrollTop() {   
     var scrollPos = 0;    
     if (typeof window.pageYOffset != 'undefined') {    
        scrollPos = window.pageYOffset;    
     }    
     else if (typeof window.document.compatMode != 'undefined' &&    
        window.document.compatMode != 'BackCompat') {    
        scrollPos = window.document.documentElement.scrollTop;    
     }    
     else if (typeof window.document.body != 'undefined') {    
        scrollPos = window.document.body.scrollTop;    
     }    
     return scrollPos;   
 } 
 
 function getScrollLeft() {   
     var scrollPos = 0;    
     if (typeof window.pageXOffset != 'undefined') {    
        scrollPos = window.pageXOffset;    
     }    
     else if (typeof window.document.compatMode != 'undefined' &&    
        window.document.compatMode != 'BackCompat') {    
        scrollPos = window.document.documentElement.scrollLeft;    
     }    
     else if (typeof window.document.body != 'undefined') {    
        scrollPos = window.document.body.scrollLeft;    
     }    
     return scrollPos;   
 } 

 function showCover(e,url,picUrl){
    var x;
    var y;
    if (document.all)
    {
        x = (getScrollLeft()+event.clientX);
        y = (getScrollTop()+event.clientY);
    }else{
        var ev=e;
        x = ev.pageX;
        y = ev.pageY;
    }
    var html='<div class="popImageDiv" style="left:'+x+'px;top:'+y+'px;"><a href="'+url+'"><img id="popImage" alt=""  src="'+picUrl+'"/></a></div>';
    var oDiv = document.createElement('div');
		oDiv.id = "popImageDiv";
		oDiv.innerHTML = html;
		document.body.appendChild(oDiv);
 }
 
 function cancelShowCover(){
    var popImageDiv=document.getElementById("popImageDiv");
    if(popImageDiv){
        document.body.removeChild(popImageDiv);
    }
 }

function queryMessage(paperId,issueId,pageId){
      var queryMessage_callback= function(ret){
      
      //if(true){
      if(ret!=null&&ret.value){

            var message=ret.value;
            var key=message.Key;
            var page=message.Value;
            var IssueId=page.IssueId;
            var PaperTime=page.AddTime;
              
            var cookieTest=new eyunCookie();
            var messageValue=cookieTest.get("Message");
            if (messageValue==IssueId) {
                return;
            }
              
            var paper=page.NewsPaper;
            var PaperName=paper.NewsPaperName;
            var paperId=paper.NewsPaperId;
            var paperType=paper.NewsPaperPageType;
            
            var issue=page.Issue;
            var pageCount= issue.PageCount;
            
            var year=1900+PaperTime.getYear();
            if (document.all) {
                year=PaperTime.getYear();
            }
            
            var month=PaperTime.getMonth()+1;
            var day=PaperTime.getDate();
            
            var strMonth=month.toString();
            if (month<10) {
                strMonth="0"+month;
            }
            
            var strDay=day.toString();
            if (day<10) {
                strDay="0"+day;
            }
            
            var strDate2=year.toString()+"-"+strMonth+"-"+strDay;
            
            var info="今日<";
            //info+="<a href=\"";
            
            //info+="Issue.aspx?issueId=";
            //info+=IssueId;
            //info+="\"  title=\"点击查看报纸\" ";
            
            /*
            info+="javascript:showPaper('";
            info+=IssueId;
            info+="','1','"
            info+=paperType
            info+="');\"  title=\"点击查看报纸清晰版\" ";
            */
            
            //info+=">";
            info+=PaperName;
            //info+="</a>";
            info+=">已更新.";
            info+="<span class=\"timeSmal\">&nbsp;&nbsp;&nbsp;";
            if (PaperTime.getHours()<10) {
                info=info+"0"+PaperTime.getHours()+":";
            }else{
                info+=PaperTime.getHours()+":";
            }
            
            if (PaperTime.getMinutes()<10) {
                info=info+"0"+PaperTime.getMinutes()+":";
            }else{
                info+=PaperTime.getMinutes()+":";
            }
            
            
            if (PaperTime.getSeconds()<10) {
                info=info+"0"+PaperTime.getSeconds()+":";
            }else{
                info+=PaperTime.getSeconds();
            }

            info+=".</span>";
            
            document.getElementById("MessageValue").innerHTML=info;
            
             var cookieTest=new eyunCookie();
             cookieTest.key="Message";
             cookieTest.value=IssueId;
             cookieTest.expires=3600000;;
             cookieTest.set();
            
            enetgetMsg();
        }
      };

      ePaperNet.ViewPage.queryMessage(paperId,issueId,pageId,queryMessage_callback);
}


function makeNewUrl(oldUrl,key,value)
{
    oldUrl=oldUrl.replace("#","");
    var ipage = oldUrl.lastIndexOf(key+"=");
    var clienurl = oldUrl;
    var pageURL ="";
    
    if (ipage >= 0)
    {
        var clienurl = oldUrl.substr(0, ipage);
        var lasturl = oldUrl.substr(ipage);
        if(lasturl.indexOf("&")>0){
            pageURL = clienurl + key+"=" + value+lasturl.substr(lasturl.indexOf("&"));
        }else{
             pageURL = clienurl + key+"=" + value;
        }
    }
    else
    {
        var ipa = oldUrl.lastIndexOf("?");
        if (ipa > 0)
        {
            var pageURL = clienurl + "&"+key+"=" + value;
        }
        else
        {
            var pageURL = clienurl + "?"+key+"=" + value;
        }
    }
    return pageURL;
}
