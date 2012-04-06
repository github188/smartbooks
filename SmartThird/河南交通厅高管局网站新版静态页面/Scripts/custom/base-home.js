
/*!
 * jQuery JavaScript Library v1.0.0
 *
 * Copyright 2012, Zhao Jing
 * GPL Version 2 licenses.
 *
 * Copyright 2012 ֣��ԥͼ��Ϣ�������޹�˾
 */
 
 /* ��ҳ��Ч */
$(document).ready(function(){
						   
	/*��ҳͷ�����Ź���ͼƬ��Ч*/
	hometopnews();
	
	/**/
	slide();
	
	/*��ҳ����ƶ���ѡ���Ч*/
	mouseovertabpage();
	
	/*�ֱ����ַ��ٸı䱳��ͼƬ*/
	mouseOverAccordion();
	
	/*��ʼ������������Ч*/
	initfriendlink("friendlink1");
	initfriendlink("friendlink2");
	initfriendlink("friendlink3");
	initfriendlink("friendlink4");
});


/*
* ��ҳͷ�����Ź���ͼƬ��Ч
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
* ��ҳ����ƶ���ѡ���Ч
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

/*������ַ��ٸı䱳��ͼƬ*/
function mouseOverAccordion()
{
	/*��꾭���ı䱳��*/
	$(".accordion").click(function(){
		/*�ı䵱ǰԪ�ر���*/
		$(this).attr("class", "accordionhover");
		var text = $(this).text();	
		$("#accordion1 span").each(function(i){
			if($(this).text() != text){
				$(this).attr("class", "accordion");
			}
		});
	});
}

/*����������Ч*/
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