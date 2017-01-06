
// Convert links (<a...>) to ajax requests
$("#homeLink").click(function (event) {
    event.preventDefault();
    var url = $(this).attr('href');
    $('#content').load(url);
});

$("#aboutLink").click(function (event) {
    event.preventDefault();
    var url = $(this).attr('href');
    $('#content').load(url);
});

$("#contactLink").click(function (event) {
    event.preventDefault();
    var url = $(this).attr('href');
    $('#content').load(url, function () {
        //$.getScript("/Scripts/music-lab1.js");
    });
});