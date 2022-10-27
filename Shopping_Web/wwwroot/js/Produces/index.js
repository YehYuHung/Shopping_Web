//var url = 'https://opendata.cwb.gov.tw/api/v1/rest/datastore/F-D0047-089?Authorization=CWB-0ECF92FF-1305-4B2E-8E01-2FFA1C4759FA&limit=1';
//var url2 = 'https://opendata.cwb.gov.tw/api/v1/rest/datastore/F-D0047-083?Authorization=CWB-0ECF92FF-1305-4B2E-8E01-2FFA1C4759FA&limit=2';
//var data = null;
var respData = null;


function queryData(url, data, sCallback) {
    $.ajax({
        url: url,
        type: "GET",
        data: data,
        contentType: false ? "apllication/x-www-form-urlencoded; charset=UTF-8" : false,
    }).done(function (response) {
        if (sCallback) {
            sCallback(response);
        }
    })
}

$("#queryBtn").click(function () {
    let url = $("#urlInput").val();
    console.log(url);
    queryData(url, null, (resp) => {
        console.log(resp);
        $("#blockBox").removeClass("hidden");
        $("#requestData").html(JSON.stringify(resp));
    });
});