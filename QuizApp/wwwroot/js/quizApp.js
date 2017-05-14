$(document).ready(function () {

    var quizId = $('#QuizId').val();

    $('#saveQuestion').click(function () {
        var quizId = $('#QuizId').val();
        var score = $('#Score').val();
        var title = $('#Title').val();

        var data = {
            QuizId: quizId,
            Score: score,
            Title: title
        };

        $.ajax({
            url: '/api/AddQuestion',
            method: 'POST',
            data: JSON.stringify(data),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                alert(data);
            },
            error: function () {
                alert(data);
            }
        });


        console.log(quizId + " " + score + " " + title);
    });

    function parsingJson(Id) {
        var url = "/api/questions/" + Id;
        console.log(Id);    
        $("#questions").html("");
        $.getJSON(url, function (data) {
            for (var i = 0; i < data.length; i++){
                var item = data[i].title;
                $('#questions').append('<div>'+item+'<button class="deleteButton" value="'+data[i].id+'">Delete</button></div>');
            } 
            console.log(data);
        });
    }

    $("#questionButton").click(function () {
        parsingJson(quizId);
    });
    

});

$(document.body).on('click', '.deleteButton', function () {
    var id = $(this).val();
    alert(id);
});


