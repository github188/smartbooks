// JavaScript Document
function TabMove(id,index,count)
{
	var defaultCss="xinwen1";
	var SelectCss="xinwen2";
	for(var n=1;n<=count;n++)
	{
		document.getElementById("Button"+id+n).className=defaultCss;
		document.getElementById("ContentBox"+id+n).style.display='none';
	}
		document.getElementById("Button"+id+index).className=SelectCss;
		document.getElementById("ContentBox"+id+index).style.display='';
	

}

function TabMove2(id,index,count)
{
	var defaultCss="fuwu1";
	var SelectCss="fuwu2";
	for(var n=1;n<=count;n++)
	{
		document.getElementById("yzfw"+id+n).className=defaultCss;
			document.getElementById("contents"+id+n).style.display='none';
	}
	document.getElementById("yzfw"+id+index).className=SelectCss;
		document.getElementById("contents"+id+index).style.display='';
}
