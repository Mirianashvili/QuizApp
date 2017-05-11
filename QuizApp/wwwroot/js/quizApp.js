$(document).ready(function () {

    parsingJson();

    $('#saveQuestion').click(function () {
        var quizId = $('#QuizId').val();
        var score = $('#Score').val();
        var title = $('#Title').val();

        $.ajax({
            url: '/question/create',
            method: 'POST',
            data: {
                QuizId: quizId,
                Score: score,
                Title:title
            },
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                alert(data);
            },
            error: function () {
                alert("error");
            }
        });


        console.log(quizId + " " + score + " " + title);
    });


    function parsingJson() {
        $.getJSON("/api/questions/1", function (data) {
            for (var i = 0; i < data.length; i++){
                var item = data[i].title;
                $('#questions').append('<div>'+item+'</div>');
            } 
        });
    }
   
});

