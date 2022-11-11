$(document).ready(function () {
    //$('#smartwizard').smartWizard({
    //    selected: 0,
    //    theme: 'arrows',
    //    autoAdjustHeight: true,
    //    transitionEffect: 'fade',
    //    showStepURLhash: false,

    //});
           
});

function Login() {

    if ($("#userName").val() == "" || $("#userPassword").val() == "") {
        alert("Digite usuário e senha.");
    }
    else if ($("#userName").val() == "aunnt" && $("#userPassword").val() == "thata112") {
        document.location.href= "Poesias/Poesia";
    }
    else {
        alert("Usuário ou senha invalidos.");
        $("#userName").val("");
        $("#userPassword").val("");
    }
}