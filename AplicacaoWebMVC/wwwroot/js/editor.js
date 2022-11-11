$(document).ready(function () {
	initSample();
});

function cadastrar() {
	var input = document.getElementById('imagem');
	var imagem = input.files[0];

	//var obj = {
	//	TextoPoesia: CKEDITOR.instances.editor.getData(),
	//	Titulo: $("#titulo").val(),
	//	Data: $("#data").val(),
	//	Imagem: imagem
	//};
	var obj = new FormData();
	obj.append('Imagem', imagem);
	obj.append('Titulo', $("#titulo").val());
	obj.append('Data', $("#data").val());
	obj.append('TextoPoesia', CKEDITOR.instances.editor.getData());

	$.ajax({
		url: '/Poesias/Cadastrar',
		method: 'POST',
		data: obj,
		cache: false,
		contentType: false,
		processData: false,
		success: function () {
			location.href = '/Poesias/Poesia'
		}
	});
}

if (CKEDITOR.env.ie && CKEDITOR.env.version < 9)
	CKEDITOR.tools.enableHtml5Elements( document );

// The trick to keep the editor in the sample quite small
// unless user specified own height.
CKEDITOR.config.height = 150;
CKEDITOR.config.width = 'auto';
CKEDITOR.name = "TextoPoesia";
CKEDITOR.editorConfig = function (config) {
	config.removePlugins = 'easyimage, cloudservices';
};


var initSample = (function () {
	CKEDITOR.replace('editor');
});

