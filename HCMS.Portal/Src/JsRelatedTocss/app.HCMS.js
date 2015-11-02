/**************************************************
HCMS Specific UI Support
***************************************************/
jQuery(document).ready(function ($) {

	/*add identifier to body*/
	$('body').addClass('HCMS');

	//nest logo div holder in header
	$('#header').append('<div class="logo"></div>')

	/*set up the backgrounds on the springboard page*/
	//$('.HCMS').append('<img src="../App_Themes/HCMS_Default/Images/bg_springboard_birds_woods.jpg" id="bg">');
	$('.HCMS').append('<img src="App_Themes/HCMS_Default/Images/bg_springboard_birds_woods.jpg" id="bg">');


	/*user login spacing for IE8*/
	$('#userInfo a:first').css('marginRight', '10px');
	$('#userInfo a:last').css('marginLeft', '10px');

	/*remove pipe and add soft break to use login information*/
	$("#userInfo").html(function (index, text) {
		return text.replace("|", "<br />");
	});


	/*take care of browser pixel differences*/
	$.browser.chrome = /chrome/.test(navigator.userAgent.toLowerCase());

	if ($.browser.chrome) {
		// alert('chrome')
	}


	/*Fix tab layering */
	$('.rtsSelected').click(function () {
		$('.rtsLink').css('z-index', '0');
		$(this).css('z-index', '3000');
	});


	/*hide tab for non-admin users*/
	$('.HCMS .rtsDisabled').hide();


	/*REMOVE INLINE STYLE*/
	$('.bt_launch').removeAttr('style');


	/* ------------------------------------------------ 
	:: ADMIN FRAMEWORK
	:: Not a great way to handle this, but due to time
	:: constraints, an easy fix.
	--------------------------------------------------- */

	if (window.location.href.indexOf("Admin") > -1) {

		$('body').addClass('Admin');
		$('#bg').hide();

		$leftNavWidth = $('.leftNav').innerWidth();
		$topNavWidth = $('.topNav').innerWidth();

		// Override Telerik Inline Styles
		$('.RadTabStrip').attr('style', '');

		// Resize Left Nav to Match First Tab Length
		$('.topNav .rtsUL li:first').css('width', $leftNavWidth + 1 + 'px');

		// Calculate Remaining Tab Lengths to Fill Container
		$remainingNavWidth = $('.topNav .RadTabStrip').width() - $leftNavWidth - 1;
		$numRemainingTabs = $('.topNav .rtsUL li').length - 1;

		$('.topNav .rtsUL li:gt(0)').css('width', ($remainingNavWidth / $numRemainingTabs));

		// Pixel Tweaks
		$('.topNav .rtsUL li.rtsLast a').css('border-right', 0);
		if ($('.topNav .rtsUL li.rtsLast a').hasClass('rtsSelected')) {
			$('.topNav').css('background-color', 'transparent');
		}

		// IE8 Sizing
		//$('.topNav .rtsUL li:last').css('border-right', '0px !important');

		// Resize Content to Match Tabs
		$('#content, .siteContent').css('width', ($topNavWidth - $leftNavWidth) - 20 + 'px');
		$('#content, .siteContent').css('margin-left', $leftNavWidth + 'px');

	}

	else { return; }


});



$(window).load(function () {
   
    //resize the bgs depending on screensize
    var theWindow = $(window),
	    $bg = $("#bg"),
	    aspectRatio = $bg.width() / $bg.height();

    function resizeBg() {
        if ((theWindow.width() / theWindow.height()) < aspectRatio) {
            $bg
		    	.removeClass()
		    	.addClass('bgheight');
        } else {
            $bg
		    	.removeClass()
		    	.addClass('bgwidth');
        }

    }

    theWindow.resize(function () {
        resizeBg();
    }).trigger("resize");

});