// JavaScript Document
//tab效果通用函数
function nTabs(tabObj,obj,n){
var tabList = document.getElementById(tabObj).getElementsByTagName("li");
for(i=0; i <n; i++)
{
if (tabList[i].id == obj.id)
{
   document.getElementById(tabObj+"_Title"+i).className = "active";
      document.getElementById(tabObj+"_Content"+i).style.display = "block";
}else{
   document.getElementById(tabObj+"_Title"+i).className = "normal";
   document.getElementById(tabObj+"_Content"+i).style.display = "none";
}
}
}

<!--
//切换到相关页
function gopage(n) 
{
  var tag = document.getElementById("s-nav").getElementsByTagName("li");
  var taglength = tag.length;

  for (i=1;i<=taglength;i++)
  {
    document.getElementById("m"+i).className="";
    document.getElementById("d"+i).style.display='none';
  }
    document.getElementById("m"+n).className="on";
    document.getElementById("d"+n).style.display='';
}
//-->