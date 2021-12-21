$(document).ready(function () {
    getLogo();
});

function getLogo() {
    var url = 'Login/Get';
    $.ajax({
        async: true,
        url: url,
        data: '',
        type: "GET",
        success: function (data) {
            if (data != null) {
                
            } else {
            }
        },
        error: function (data) {

        }
    });
}