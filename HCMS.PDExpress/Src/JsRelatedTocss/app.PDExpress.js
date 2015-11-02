
jQuery(document).ready(function ($) {

    /*add identifier to body*/
    $('body').addClass('PDE');

    //nest logo div holder in header
    $('#header').append('<div class="logo"></div>')

    /*user login spacing for IE8*/
    $('#userInfo a:first').css('marginRight', '10px');
    $('#userInfo a:last').css('marginLeft', '10px');
    /*remove pipe and add soft break to use login information*/
    $("#userInfo").html(function (index, text) {
        return text.replace("|", "<br />");
    });


    /* -------------------------------------------------- 
    :: setup framework=
    ---------------------------------------------------*/

    $leftNavWidth = $('.leftNav').innerWidth();
    $topNavWidth = $('.topNav').innerWidth();

    /*override inline style on telerik control*/
    $('.topNav .rtsLI ').attr('style', '');

    /*resize left nav bar to match first tab length*/
    $('.topNav .rtsUL li:first').css('width', $leftNavWidth + 'px');

    /*resize each horizontal tab to be full length of top nav*/
    $('.topNav .rtsUL li:gt(0)').css('width', ($('.topNav .RadTabStrip_WebBlue').width() - $leftNavWidth) / ($('.topNav .rtsUL li').length - 1));
    /*IE8 sizing*/
    $('.lt-ie8 .topNav .rtsUL li:last').css('border-right', '0px !important');

    $('#content, .siteContent').css('width', ($topNavWidth - $leftNavWidth) - 20 + 'px');
    $('#content, .siteContent').css('margin-left', $leftNavWidth + 'px');

    /*style rad grid*/
    $('.RadGrid').parent().attr('style', '');
    $('.spanAction input').attr('style', '');

    

    /*telerik dropdown arrow testing*/
    $('.siteCont .rmItem').eq(0).attr('style', '');
    $('.rmItem img').hide();

    /*override inline style on telerik control*/
    var pageWidth = $('siteCont').width();
    $('.RadEditor iframe').css('width', pageWidth + 'px');


    /*find iframe and change bg to white || IE Only
    $('iframe').contents().find('body').css('background-color', '#fff');*/

 
    $(window).load(function () {
    });


});
