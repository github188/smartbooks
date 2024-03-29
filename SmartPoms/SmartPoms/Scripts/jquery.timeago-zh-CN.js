/*
 * timeago: a jQuery plugin, version: 0.8.2 (2010-02-16)
 * @requires jQuery v1.2.3 or later
 *
 * Timeago is a jQuery plugin that makes it easy to support automatically
 * updating fuzzy timestamps (e.g. "4 minutes ago" or "about 1 day ago").
 *
 * For usage and examples, visit:
 * http://timeago.yarp.com/
 *
 * Licensed under the MIT:
 * http://www.opensource.org/licenses/mit-license.php
 *
 * Copyright (c) 2008-2010, Ryan McGeary (ryanonjavascript -[at]- mcgeary [*dot*] org)
 */
(function($) {
  $.timeago = function(timestamp) {
    if (timestamp instanceof Date) return inWords(timestamp);
    else if (typeof timestamp == "string") return inWords($.timeago.parse(timestamp));
    else return inWords($.timeago.datetime(timestamp));
  };
  var $t = $.timeago;

  $.extend($.timeago, {
    settings: {
      refreshMillis: 60000,
      allowFuture: true,
      strings: {
		prefixAgo: null,
		prefixFromNow: null,
		suffixAgo:"前",
		suffixFromNow: "后",
        ago: null, // DEPRECATED, use suffixAgo
        fromNow: null, // DEPRECATED, use suffixFromNow
		seconds: "几秒",
		minute: "一分钟",
		minutes: "几分钟",
		ten_minutes:"十几分钟",
		halfHour: "半小时",
		hour: "一小时",
		hours: "几小时",
		ten_hours:"十几小时",
		day: "天",
		days: "几天",
		month: "一个月",
		months: "几月",
		year: "去年",
		years: "几年"
      }
    },
    inWords: function(distanceMillis) {
      var $l = this.settings.strings;
      var prefix = $l.prefixAgo;
      var suffix = $l.suffixAgo || $l.ago;
	  
      if (this.settings.allowFuture) {
        if (distanceMillis < 0) {
          prefix = $l.prefixFromNow;
          suffix = $l.suffixFromNow || $l.fromNow;
        }
        distanceMillis = Math.abs(distanceMillis);
      }

		//间隔有多少秒
      var seconds = distanceMillis / 1000; 
     	//间隔有多少分钟
	 var minutes = seconds / 60;
      var hours = minutes / 60;
      var days = hours / 24;
      var years = days / 365;

      var words = 	seconds < 45 && substitute($l.seconds, Math.round(seconds)) ||
					seconds < 90 && substitute($l.minute, 1) ||
					minutes < 10 && substitute($l.minutes, Math.round(minutes)) ||
					minutes < 20 && substitute($l.ten_minutes, Math.round(minutes)) ||
					minutes < 30 && substitute($l.halfHour, Math.round(minutes)) ||
					minutes < 90 && substitute($l.hour, 1) ||
					hours < 10 && substitute($l.hours, Math.round(hours)) ||
					hours < 24 && substitute($l.ten_hours, Math.round(hours)) ||
					hours < 48 && substitute($l.day, 1) ||
					days < 30 && substitute($l.days, Math.floor(days)) ||
					days < 60 && substitute($l.month, 1) ||
					days < 365 && substitute($l.months, Math.floor(days / 30)) ||
					years < 2 && substitute($l.year, 1) ||
					substitute($l.years, Math.floor(years));

      	return $.trim([prefix, words, suffix].join(""));
    },
    parse: function(iso8601) { //用原始数据生成js的Date对象
      var s = $.trim(iso8601);
      s = s.replace(/-/,"/").replace(/-/,"/");
      s = s.replace(/T/," ").replace(/Z/," UTC");
      s = s.replace(/([\+-]\d\d)\:?(\d\d)/," $1$2"); // -04:00 -> -0400
      return new Date(s);
    },
    datetime: function(elem) {
      // jQuery's `is()` doesn't play well with HTML5 in IE
      var isTime = $(elem).get(0).tagName.toLowerCase() == "time"; // $(elem).is("time");
      var iso8601 = isTime ? $(elem).attr("datetime") : $(elem).attr("title");
      return $t.parse(iso8601);
    }
  });

  $.fn.timeago = function() {
    var self = this;
    self.each(refresh);

    var $s = $t.settings;
    if ($s.refreshMillis > 0) {
      setInterval(function() { self.each(refresh); }, $s.refreshMillis);
    }
    return self;
  };

  function refresh() {
    var data = prepareData(this);
	//console.log(data.datetime instanceof Date);
    if (!isNaN(data.datetime)) {
      $(this).text(inWords(data.datetime));
    }
    return this;
  }
  
  //分析elem，得到原始数据
  function prepareData(element) {
    element = $(element);
    if (!element.data("timeago")) {
      element.data("timeago", { datetime: $t.datetime(element) });
      var text = $.trim(element.text());
      if (text.length > 0) element.attr("title", text);
    }
    return element.data("timeago");
  }

  function inWords(date) {
    return $t.inWords(distance(date));
  }

  function distance(date) {
    return (new Date().getTime() - date.getTime());
  }

  function substitute(stringOrFunction, value) {
    var string = $.isFunction(stringOrFunction) ? stringOrFunction(value) : stringOrFunction;
    return string.replace(/%d/i, value);
  }

  // fix for IE6 suckage
  document.createElement("abbr");
  document.createElement("time");
})(jQuery);
