function requestDB(url, data, type, callback) {//запрос к базе данных
    $.ajax({
        type: type,
        url: url,
        contentType: 'application/json',
        data: JSON.stringify(data),
    }).done(function (data) {
        if (callback !=null){
            callback(data);
        }
    }).fail(function (msg) {//если не удалось выполнить запрос - выводим ошибку
        console.log(msg)
    });
};
