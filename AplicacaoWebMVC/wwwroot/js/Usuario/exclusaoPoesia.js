
function abrirModalExclusao(id) {
    
    $("#poesiaExclusaoId").val(id);
    $("#modalExclusaoPoesia").show();
    
}

function excluirPoesia() {
    $.ajax({
        url: "/Poesias/Excluir",
        cache: false,
        data: 'id=' + $("#poesiaExclusaoId").val() + '&usuarioId=' + $("#usuarioId").val(),
        type: "POST",
        success: function (data) { 
            $("#modalExclusaoPoesia").hide();
            location.reload();
        },
    });
}

function fecharModalExclusao() {
    $("#modalExclusaoPoesia").hide();
}