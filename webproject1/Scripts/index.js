$(document).ready(function (e) {
    $.getJSON('https://ipapi.co/159.121.204.129/json/',
        function (data) {
            //console.log(data);
            $("#longitude").html(`<strong>longitude</strong> ${data.longitude}`);
            $("#latitude").html(`<strong>latitude</strong> ${data.latitude}`);

            document.getElementById("json1").textContent = JSON.stringify(data, undefined, 2);
        });

    $.getJSON('http://jsonplaceholder.typicode.com/users',
        function (data) {
            //console.log(data);
            document.getElementById("json2").textContent = JSON.stringify(data, undefined, 2);
        });


    $.getJSON('http://api.icndb.com/jokes/random',
        function (data) {
            console.log(data);
            document.getElementById("json3").textContent = htmlDecode(data.value.joke);
        });


});

function htmlDecode(input) {
    var doc = new DOMParser().parseFromString(input, "text/html");
    return doc.documentElement.textContent;
}