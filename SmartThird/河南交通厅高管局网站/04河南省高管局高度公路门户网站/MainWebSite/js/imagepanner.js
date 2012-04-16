/* Simple Image Panner (March 11th, 10)
* This notice must stay intact for usage 
* Author: Dynamic Drive at http://www.dynamicdrive.com/
* Visit http://www.dynamicdrive.com/ for full source code
*/

jQuery.noConflict()

var ddimagepanner={

	init:function($, $img, options){
		var s=options
		s.imagesize=[$img.width(), $img.height()]
		s.pos=(s.pos=="center")? [-(s.imagesize[0]/2-s.wrappersize[0]/2), -(s.imagesize[1]/2-s.wrappersize[1]/2)] : [0, 0] //initial coords of image
		s.pos=[Math.floor(s.pos[0]), Math.floor(s.pos[1])]
		$img.css({position:'absolute', left:s.pos[0], top:s.pos[1]})
		s.dragcheck={h: (s.wrappersize[0]>s.imagesize[0])? false:true, v:(s.wrappersize[1]>s.imagesize[1])? false:true}
		if (s.dragcheck.h==false && s.dragcheck.v==false) //if image shouldn't be pannable (container larger than image)
			s.$pancontainer.css({cursor:'auto'})
		else
			this.dragimage($, $img, s)
	},

	dragimage:function($, $img, s){
		$img.mousedown(function(e){
			var imgoffset=$img.offset()
			s.pos=[parseInt($img.css('left')), parseInt($img.css('top'))]
			var xypos=[e.clientX, e.clientY]
			$img.bind('mousemove.dragstart', function(e){
				var pos=s.pos
				var dx=e.clientX-xypos[0] //distance to move horizontally
				var dy=e.clientY-xypos[1] //vertically
				if (s.dragcheck.h==true) //allow dragging horizontally?
					var newx=(dx>0)? Math.min(0, s.pos[0]+dx) : Math.max(-s.imagesize[0]+s.wrappersize[0], s.pos[0]+dx) //Set horizonal bonds. dx>0 indicates drag right versus left
				if (s.dragcheck.v==true) //allow dragging vertically?
					var newy=(dy>0)? Math.min(0, s.pos[1]+dy) : Math.max(-s.imagesize[1]+s.wrappersize[1], s.pos[1]+dy) //Set vertical bonds. dy>0 indicates drag downwards versus up
				$img.css({left:(typeof newx!="undefined")? newx : s.pos[0], top:(typeof newy!="undefined")? newy : s.pos[1]})
				return false //cancel default drag action
			})
			return false //cancel default drag action
		})
		$(document).bind('mouseup', function(e){
			$img.unbind('mousemove.dragstart')
		})
	}

}


jQuery.fn.imgmover=function(options){
	var $=jQuery
	return this.each(function(){ //return jQuery obj
		if (this.tagName!="IMG")
			return true //skip to next matched element
		var $imgref=$(this)
		if (parseInt(this.style.width)>0 && parseInt(this.style.height)>0) //if image has explicit CSS width/height defined
			ddimagepanner.init($, $imgref, options)
		else if (this.complete){ //account for IE not firing image.onload
			ddimagepanner.init($, $imgref, options)
		}
		else{
			$imgref.bind('load', function(){
				ddimagepanner.init($, $imgref, options)
			})
		}
	})
}


jQuery(document).ready(function($){ //By default look for DIVs with class="pancontainer"
	var $pancontainer=$('div.pancontainer')
	$pancontainer.each(function(){
		var $this=$(this).css({position:'relative', overflow:'hidden', cursor:'move'})
		var $img=$this.find('img:eq(0)') //image to pan
		var options={$pancontainer:$this, pos:$this.attr('data-orient'), wrappersize:[$this.width(), $this.height()]}
		$img.imgmover(options)
	})
})