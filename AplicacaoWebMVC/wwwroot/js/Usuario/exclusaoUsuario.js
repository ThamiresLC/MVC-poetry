
function abrirModalExclusao(id) {
    
    $("#usuarioExclusaoId").val(id);
    $("#modalExclusaoUsuario").show();
    
}

function excluirUsuario() {
    
    $.ajax({
        url: "/Usuarios/Excluir",
        cache: false,
        data: 'id=' + $("#usuarioExclusaoId").val(),
        type: "POST",
        success: function (data) {
            $("#modalExclusaoUsuario").hide();
            location.reload();
        },
    });
}

function fecharModalExclusao() {
    $("#modalExclusaoUsuario").hide();
}