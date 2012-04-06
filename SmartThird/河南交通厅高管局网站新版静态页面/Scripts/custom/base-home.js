
/*!
 * jQuery JavaScript Library v1.0.0
 *
 * Copyright 2012, Zhao Jing
 * GPL Version 2 licenses.
 *
 * Copyright 2012 郑州豫图信息技术有限公司
 */
 
 /* 首页特效 */
$(document).ready(function(){
						   
	/*首页头条新闻滚播图片特效*/
	hometopnews();
	
	/**/
	slide();
	
	/*首页鼠标移动到选项卡特效*/
	mouseovertabpage();
	
	/*手表经过手风琴改变背景图片*/
	mouseOverAccordion();
	
	/*初始化友情链接特效*/
	initfriendlink("friendlink1");
	initfriendlink("friendlink2");
	initfriendlink("friendlink3");
	initfriendlink("friendlink4");
});


/*
* 首页头条新闻滚播图片特效
*/
function hometopnews()
{
	$("#topnews img").show().end();
	$("#topnews").KinSlideshow();
}

/*
*
*/
function slide()
{
	$('li.mainlevel').mousemove(function(){
		$(this).find('ul').slideDown("fast");
	});
	$('li.mainlevel').mouseleave(function(){
		$(this).find('ul').slideUp("fast");
	});
}

/*
* 首页鼠标移动过选项卡特效
*/
function mouseovertabpage()
{
	$("#menuone li").eq(0).mouseover(function(){
		$(this).children("a").addClass("tabactive");
		$("#tabcontent2").hide();
		$("#tabcontent3").hide();
		$("#tabcontent1").show().end();
	});
	$("#menuone li").eq(1).mouseover(function(){
		$(this).children("a").addClass("tabactive");
		$("#tabcontent1").hide();
		$("#tabcontent3").hide();
		$("#tabcontent2").show().end();
	});
	$("#menuone li").eq(2).mouseover(function(){
		$(this).children("a").addClass("tabactive");
		$("#tabcontent1").hide();
		$("#tabcontent2").hide();
		$("#tabcontent3").show().end();
	});
	$("#menuone li").eq(0).mouseout(function(){
		$(this).children("a").removeClass("tabactive");
	});
	$("#menuone li").eq(1).mouseout(function(){
		$(this).children("a").removeClass("tabactive");
	});
	$("#menuone li").eq(2).mouseout(function(){
		$(this).children("a").removeClass("tabactive");
	});
}

/*鼠标点击手风琴改变背景图片*/
function mouseOverAccordion()
{
	/*鼠标经过改变背景*/
	$(".accordion").click(function(){
		/*改变当前元素背景*/
		$(this).attr("class", "accordionhover");
		var text = $(this).text();	
		$("#accordion1 span").each(function(i){
			if($(this).text() != text){
				$(this).attr("class", "accordion");
			}
		});
	});
}

/*友情链接特效*/
function initfriendlink(markedId){
	$('#' + markedId + '>div').click(function(){
		$('#' + markedId + '>ul').show(300,function(){
			
		}).end();
	});
	
	$('#'+ markedId + '>ul>li').click(function(){
		$('#' + markedId + '>div').text($(this).text());
		$('#' + markedId + '>ul').hide();		
	});
	
	$('#' + markedId + '>ul>li').hover(function(){
		$(this).addClass("hover")
	},function(){
		$(this).removeClass("hover");
	});
}