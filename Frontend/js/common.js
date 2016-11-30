$(function(){
	$("span.menu").click(function(){
						$(".top-nav ul").slideToggle(500, function(){
						});
						
					});
});

/** 
 *扩展jQuery方法，获取URL请求参数 
 *Get object of URL parameters var allVars = $.getUrlVars(); 
 *Getting URL var by its name var byName = $.getUrlVar('name'); 
 */  
$.extend({  
  getUrlVars: function(){  
    var vars = [], hash;  
    var href = window.location.href;  
    var hashes = href.slice(href.indexOf('?') + 1).split('&');  
    for(var i = 0; i < hashes.length; i++)  
    {  
      hash = hashes[i].split('=');  
      vars.push(hash[0]);  
      vars[hash[0]] = hash[1];  
    }  
    return vars;  
  },  
  getUrlVar: function(name){  
    return $.getUrlVars()[name];  
  } 
}  
); 