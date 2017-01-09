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

$("#daysLink").click(function (event) {
    event.preventDefault();
    var url = $(this).attr('href');
    $('#content').load(url);
    });

$("#membersLink").click(function(event) {
        event.preventDefault();
        var url = $(this).attr('href');
        $('#content').load(url);
});

$("#clickme").click(function () {
    $("#foodclub").animate({
        width: "toggle",
        height: "toggle"
    }, {
        duration: 5000,
        complete: function () {
            $(this).after("<div>Animationen er færdig</div>");
        }
    });
});

//Javascript til at skrive, hvornår siden sidst er opdateret:
$('footer').append("<p>Siden er sidst opdateret: " + document.lastModified + "</p>");




