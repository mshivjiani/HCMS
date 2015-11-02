
function onBPCursorChanging(event, data) {
    data.cancel = true;
}

function onBPHighlightChanging(event, data) {
    data.cancel = true;
}

function getBPGeneralTemplate(templateName) {
    var result = new primitives.orgdiagram.TemplateConfig();
    result.name = templateName;
    result.isActive = false;

    result.itemSize = new primitives.common.Size(230, 120);
    result.minimizedItemSize = new primitives.common.Size(6, 6);
    result.highlightPadding = new primitives.common.Thickness(2, 2, 2, 2);

    var itemTemplate = $('<div class="bp-item bp-corner-all bt-item-frame">'
                    + '<div name="titleBackground" class="bp-item bp-corner-all bp-title-frame" style="top: 2px; left: 2px; width: 226px; height: 20px;">'
                        + '<div name="fullName" class="bp-item bp-title" style="top: 2px; left: 5px; width: 100%; height: 18px;">'
                        + '</div>'
                    + '</div>'
                    + '<div name="detailLine" class="bp-item-root" style="top: 26px; left: 5px; width: 175px; height: auto; font-size: 12px;"></div>'
                + '</div>').css({
                    width: result.itemSize.width + "px",
                    height: result.itemSize.height + "px"
                });
    result.itemTemplate = itemTemplate.wrap('<div>').parent().html();

    return result;
}

function onBPTemplateRender(event, data) {
    switch (data.renderingMode) {
        case primitives.common.RenderingMode.Create:
            //data.element.find("[name=email]").click(function (e) {
            /* Block mouse click propogation in order to avoid layout updates before server postback*/
            //    primitives.common.stopPropagation(e);
            //});
            /* Initialize widgets here */
            break;
        case primitives.common.RenderingMode.Update:
            /* Update widgets here */
            break;
    }

    var itemConfig = data.context;

    switch (data.templateName) {
        case "FPPSNode":
        case "RootNode":
        case "WFPNode":
            data.element.find("[name=titleBackground]").css({ "background": itemConfig.itemTitleColor });
            data.element.find("[name=detailLine]").html("<b>" + itemConfig["title"] + "</b><br />" +
                                    itemConfig["payPlan"] + "-" + itemConfig["series"] + "-" + itemConfig["gradefpl"] + "<br />" +
                                    "Org Code: " + itemConfig["orgCode"] + "<br />" +
                                    itemConfig["workScheduleType"]);

            var fields = ["title", "fullName"];

            for (var index = 0; index < fields.length; index += 1) {
                var field = fields[index];
                data.element.find("[name=" + field + "]").text(itemConfig[field]);
            }
            break;
    }
}
