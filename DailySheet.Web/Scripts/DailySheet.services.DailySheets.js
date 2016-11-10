DailySheet.services.DailySheets = DailySheet.services.DailySheets || {};

DailySheet.services.DailySheets.insert = function (data, onSuccess, onError) {
    var url = "/api/DailySheets/";

    var settings = {
        cache: false
        , contentType: "application/json; charset=UTF-8"
        , data: data
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "POST"
    };
    $.ajax(url, settings);
}

DailySheet.services.DailySheets.update = function (id, data, onSuccess, onError) {

    var url = "/api/DailySheets/" + id;
    var settings = {
        cache: false
    , contentType: "application/json; charset=UTF-8"
    , data: data
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "PUT"
    };

    $.ajax(url, settings);

}

DailySheet.services.DailySheets.selectAll = function (onSuccess, onError) {
    var url = "/api/DailySheets/";
    var settings = {
        cache: false //only necessary for GET requests, forces fresh results
        //contentType:
        //data:
            , dataType: "json"
            , success: onSuccess
            , error: onError
            , type: "GET"
    };

    $.ajax(url, settings);

}

DailySheet.services.DailySheets.selectById = function (id, onSuccess, onError) {

    var url = "/api/DailySheets/" + id;
    var settings = {
        cache: false
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "GET"
    };

    $.ajax(url, settings);
}

DailySheet.services.DailySheets.delete = function (id, onSuccess, onError) {


    var url = "/api/DailySheets/" + id;
    var settings = {
        cache: false
        //, contentType: "application/x-www-form-urlencoded; charset=UTF-8"
    , dataType: "json"
    , success: onSuccess
    , error: onError
    , type: "DELETE"
    };

    $.ajax(url, settings);

}