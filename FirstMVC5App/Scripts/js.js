$(function () {
//Подсказка при наведении на кнопки в книгах
    $('.tool_type_book').tooltip();
////////////////////////////////////////////

//Переход при двойном нажатии на строке в таблице  
    $('.clickable-row').dblclick(function () {
        location.href = $(this).data("href");
    });
/////////////////////////////////////////////////

//Модальное окно на книгах
    //http://metanit.com/sharp/mvc5/14.6.php
    $('.book_details').click(function (e) {
        $.ajaxSetup({ cache: false});
        e.preventDefault();//https://learn.javascript.ru/default-browser-action
        $.get(this.href, function(data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        });
    });
///////////////////////////
});

//Загрузка данных по AJAX тестируем работу
    $(function () {
        BOOK.Object.Init();
    });

    var BOOK = BOOK || {};
    BOOK.Object = {
        data: [],

        Init: function() {
            BOOK.Object.GetBooks(
                function callback(data) {
                    BOOK.Object.data = data;

                    $.ajax({
                        url: "/book/SetBooks/",
                        type: "POST",
                        //contentType: "application/json; charset=utf-8",
                        data: { data : JSON.stringify(data) }
                    });
                });
        },

        GetBooks: function(collback) {
            var data = {};
            $.ajax({
                type: "POST",
                //contentType: "application/json; charset=utf-8",
                url: "/book/GetBooks/",
                dataType: "json",
                //data: data,
                success: function (data) {
                    //if (data.IsSuccess == true) {
                        collback(data);
                    //}// else {
                    //    // alert(data.d.Message); 
                    //    console.warn(data.Message);
                    //}
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    var error = thrownError.length === 0 ? "Обрыв соединения" : thrownError + ". Обрыв соединения";
                    error += "Url: " + url + "; Data: " + data;
                    //alert(error);                    
                    console.warn(error);
                }
            });
        }
    };
//////////////////////////////////////////