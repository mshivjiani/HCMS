var largeOpts = 
{
    lines: 13, // The number of lines to draw
    length: 33, // The length of each line
    width: 7, // The line thickness
    radius: 30, // The radius of the inner circle
    corners: 1, // Corner roundness (0..1)
    rotate: 0, // The rotation offset
    direction: 1, // 1: clockwise, -1: counterclockwise
    color: '#000', // #rgb or #rrggbb or array of colors
    speed: 1, // Rounds per second
    trail: 50, // Afterglow percentage
    shadow: false, // Whether to render a shadow
    hwaccel: false, // Whether to use hardware acceleration
    className: 'spinner', // The CSS class to assign to the spinner
    zIndex: 15000, // The z-index (defaults to 2000000000)
    top: '50%', // Top position relative to parent
    left: '50%' // Left position relative to parent
};

var target = document.getElementById('diagramChartContainer');
var spinner = new Spinner(largeOpts).spin(target);

function startSpin() 
{
    // special spinner that isn't blocked while the system processes the request
    // spinner = new Spinner(largeOpts).spin(target);

    $("#divWaitMessage").show();
    $("#mainDiagramChart").css("opacity", "0.5");
    $("#mainDiagramChart").css("filter", "alpha(opacity = 50)");
}

function stopSpin() 
{
    spinner.stop();
    $("#divWaitMessage").hide();
    $("#mainDiagramChart").css("opacity", "1");
    $("#mainDiagramChart").css("filter", "alpha(opacity = 100)");
}

function convertCanvasAndUpload(evt) 
{
    startSpin();

    if (evt != null)
        evt.preventDefault();

    html2canvas($("#divDiagramFullSizeImage"),
    {
        allowTaint: true,
        useCORS: true,
        taintTest: false,
        letterRendering: true,
        width: 8175,
        height: 8175,
        onrendered: function (canvas) 
        {
            var img = canvas.toDataURL("image/png").replace(/^data[:]image\/(png|jpg|jpeg)[;]base64,/i, "");
            var dataParam = '{"chartID" : "' + ctrlDisplay_srvChartID + '", "type" : "' + ctrlDisplay_srvChartType + '", "imageData" : "' + img + '"}';

            // alert(img.length + '\n' + (img.length * 0.75) + '\n' + (img.length / 1.37));

            $.ajax(
            {
                type: "POST",
                url: "../Processing/ImageProcessor.asmx/Upload",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: dataParam,
                error: function (xhr, textStatus, errorThrown) {
                    stopSpin();
                    var jsonResponse = JSON.parse(xhr.responseText);

                    if (jsonResponse.Message == "App Timeout") {
                        alert('Your session has timed out. We will be redirecting you to your \'My Tracker\' page.');
                        window.location.href = "../Tracker/OrgChartTracker.aspx";
                    }
                    else if (jsonResponse.Message == "MemoryException")
                        alert('The system has reached the maximum amount of requests that it can process at this time. ' +
                                'This is only for a temporary period while we attempt to process all of the queued requests. ' +
                                'Please try your request again at a later time or contact a system administrator if this issue persists.');
                    else
                    // alert(errorThrown + '\n' + xhr.status + '\n' + xhr.responseText);
                        alert(jsonResponse.Message);
                },
                success: function (msg) {
                    window.location.href = "../Processing/chartExportHandler.ashx";
                    stopSpin();
                }
            });
        }
    });
}