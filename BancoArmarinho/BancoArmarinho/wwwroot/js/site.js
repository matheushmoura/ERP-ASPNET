$(document).ready(function () {
    $("#txtCEP").change(function () {
        var cep = $("#txtCEP").val();
        if (cep.length <= 0) return;
        $.get("https://api.postmon.com.br/v1/cep/" + cep, function (result) {
            if (result.estado != null || result.estado != "") {

                $("#txtEndereço").val(result.logradouro);
                $("#txtBairro").val(result.bairro);
                $("#txtCidade").val(result.cidade);
                $("#txtEstado").val(result.estado);
            }
            else {
                alert("CEP inválido!");
                return;
            }
        });
    });
   
});