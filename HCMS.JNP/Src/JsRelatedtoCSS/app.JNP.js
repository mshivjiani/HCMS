
jQuery(document).ready(function ($) {

    /*add identifier to body*/
    $('body').addClass('JNP');

    //nest logo div holder in header
    $('#header').append('<div class="logo"></div>')

    /*user login spacing for IE8*/
    $('#userInfo a:first').css('marginRight', '10px');
    $('#userInfo a:last').css('marginLeft', '10px');
    /*remove pipe and add soft break to use login information*/
    $("#userInfo").html(function (index, text) {
        return text.replace("|", "<br />");
    });

    /*main tab functionality*/
    var tabDivWidth = $('.topNav').outerWidth() / $('.topNav li').length + 'px';

    $('.topNav li').css('width', tabDivWidth)


    /*identify the chevron on state; position the subnavigation system*/
    if ($('.topNav').length) {
        curMenu = $('.topNav .rtsSelected').parent();
        curMenuLeft = curMenu.position().left;
        curMenu.addClass('rtsSelected_parent');
        $('.subNav ul').css('margin-left', curMenuLeft - 55)
    }


    /*override inline style on telerik control*/
    $('.RadTabStripVertical ').attr('style', '');

    /*style rad grid*/
    $('.RadGrid').parent().attr('style', '');

    /*override telerik control font family and size*/
    $('.RadGrid td, .RadGrid th, .rmText').css({
        fontFamily: 'arial,helvetica,sans-serif'
    });

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

        var userProg = 50;

        /*progress bar */
        function progress(percent, $element) {
            var progressBarWidth = percent * $element.width() / 100;
            $element.find('div').animate({ width: progressBarWidth }, 500).html(percent + "%&nbsp;");
        }

        progress(userProg, $('#progressBar'));

        /*fake functionality for testing*/
        //        $('.topNav li:first-child').addClass('topNav-state-on');
        //        $('.subNav li:eq(1) a').addClass('subNav-state-on');



    });


});
