$(document).ready(function () {
    $("#cep").mask("00000-000");
    $("#celular").mask("(00) 00000-0000");
    $("#telefone").mask("(00) 00000-0000");
    $("#cpf").mask("000.000.000-00");

    $("#cep").focusout(function () {
        $.ajax({
            url: "https://ws.apicep.com/cep/" + $("#cep").val() + ".json",
            cache: false,
            success: function (data) {
                $("#logradouro").val(data.address);
                $("#bairro").val(data.district);
                $("#cidade").val(data.city);
                $("#uf").val(data.state);
            },
        });

    })
});

function Cadastrar() {
    var html = "<tr>";
    html += "<td>";
    html += $("#nome").val();
    html += "</td>";
    

    html += "<td>";
    html += $("#datanascimento").val();
    html += "</td>";
   

    html += "<td>";
    html += $("#email").val();
    html += "</td>";

    html += "<td>";
    html += $("#telefone1").val();
    html += "</td>";

    html += "<td>";
    html += $("#telefone2").val();
    html += "</td>";
    html += "<td>";
    html += $("#cep").val();
    html += "</td>";

    html += "<td>";
    html += $("#logradouro").val();
    html += "</td>";

    html += "<td>";
    html += $("#cidade").val();
    html += "</td>";

    html += "<td>";
    html += $("#bairro").val();
    html += "</td>";


    html += "<td>";
    html += $("#uf").val();
    html += "</td>";
    html += "</tr>";

    $("#corpoTabelaUsuarios").append(html);

    alert("Cadastro efetuado com sucesso!");
    $("#uf").val("");
    $("#cidade").val("");
    $("#bairro").val("");
    $("#nome").val("");
    $("#telefone1").val("");
    $("#telefone2").val("");
    $("#cep").val("");
    $("#email").val("");
    $("#datanascimento").val("");
}