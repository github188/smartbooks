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