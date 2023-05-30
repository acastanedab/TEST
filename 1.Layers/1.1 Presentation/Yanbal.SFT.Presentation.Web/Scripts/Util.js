
function postJson(url, data, success, error) {
    //$('#loading').show();
    $.ajax({
        url: url,
        data: data,
        type: 'POST',
        dataType: 'json',
        cache: false,
        success: success,
        error: error,
        //complete: function () {
        //    $('#loading').hide();
        //}
    });
}

function getJson(url, data, success, error) {
    //var result;
    $.ajax({
        url: url,
        data: data,
        type: 'GET',
        datatype: 'json',
        cache: false,
        async: false,
        success: success,
        error: error,
    });
    //return parseDatesInObject(result);
}

function RedirectPost(location, args) {
    var form = '';
    if (args) {
        $.each(args, function (key, value) {
            form += '<input type="hidden" name="' + key + '" value="' + value + '">';
        });
    }
    var submit = $('<form action="' + location + '" method="POST" >' + form + '</form>');
    $('body').after(submit);
    submit.submit();
}