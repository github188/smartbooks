// JavaScript Document

  $(function(){
		  initfriendlink("friendlink1");
		  initfriendlink("friendlink2");
		  initfriendlink("friendlink3");
		  initfriendlink("friendlink4");
  });

  function initfriendlink(markedId)
  {
	  $("#"+markedId+">div").click(function(){
		  $("#"+markedId+">ul").toggle();
	  });
	  $("#"+markedId+">ul>li").click(function(){
		  $("#"+markedId+">div").text($(this).text());
		  $("#"+markedId+">ul").hide();
	  });
	  $("#"+markedId+">ul>li").hover(function(){
		  $(this).addClass("hover")
	  },function(){
		  $(this).removeClass("hover");
	  });
  }
