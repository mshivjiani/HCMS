function customConfirm(sender, confirmationMessagePrompt, confirmTitle, height, validationGroup) 
{
    var calcValidationGroup = (validationGroup == null || validationGroup == "") ? "" : validationGroup;

    // callback function
    function confirmCallBackFn(arg) 
    {
        if (arg)
            __doPostBack(sender.name, "");  // validation group intentionally blank
    }

    // This line will open a rad confirmation window, it will not wait for the response
    var newHeight = (height == null) ? 140 : height;
    radconfirm(confirmationMessagePrompt, confirmCallBackFn, 275, newHeight, null, confirmTitle);
}

function customConfirmWithValidation(sender, confirmationMessagePrompt, confirmTitle, height, validationGroup) 
{
    var calcValidationGroup = (validationGroup == null || validationGroup == "") ? "" : validationGroup;

    // callback function
    function confirmCallBackFn(arg) 
    {
        if (arg)
            __doPostBack(sender.name, "");   // validation group intentionally blank
    }

    if (Page_ClientValidate(calcValidationGroup)) 
    {
        // This line will open a rad confirmation window, it will not wait for the response
        var newHeight = (height == null) ? 140 : height;
        radconfirm(confirmationMessagePrompt, confirmCallBackFn, 275, newHeight, null, confirmTitle);
    }
     else
        Page_BlockSubmit = false;
}

function ConfirmWithValidation(msg, valGrp) {
    // alert(Page_IsValid);
    // alert(Page_BlockSubmit);

    if (Page_ClientValidate(valGrp)) 
    {
        return confirm(msg);
    }
    else 
    {
        Page_BlockSubmit = false;
        return false;
    }
}