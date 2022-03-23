var buttonSave = document.querySelector('#salvar').addEventListener("click", function (event) {

    var dadosDaTabela = document.querySelectorAll('.table tbody tr');

    if (dadosDaTabela.length <= 0)
        return;

    var extratoBancario = [];


    for (var i = 0; i < dadosDaTabela.length; i++) {

        var linhaColuna = dadosDaTabela[i].children;

        extratoBancario.push({
            Trntype: linhaColuna[1].innerHTML,
            Dtposted: linhaColuna[0].innerHTML,
            Trnamt: linhaColuna[2].innerHTML,
            Memo: linhaColuna[3].innerHTML
        });
    }
    $.ajax({
        type: "POST",
        url: "/CadastrarExtrato",
        data: JSON.stringify(extratoBancario),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            resultado(true, result.message);
            removerTodosArquivos();
        },
        error: function (err) {
            console.log(extratoBancario);
            resultado(false, `${err.statusText} ${err.status}`)
        }
    });

});

var removerTodosArquivos = function () {
    fetch("/ExtratoBancario/Index")
        .then(function () { });
}

var resultado = function (isSuccess, message) {
    $('.message').css("display", "block");

    if (isSuccess) {
        $('.message div').addClass("alert-success");
        $('#salvar').css("display", "none");
    } else {
        $('.message div').addClass("alert-danger");
    }
    $('.message span').html(message);
}