/*$(document).ready(function () {
    /*$("#buscador_principal").typeahead({
        source: [
            {id: "id1", name: "jQuery"},
            {id: "id2", name: "Script"},
            {id: "id3", name: "Net"}
        ]
    });*

    $(".modal").on("hidden.bs.modal", function () {
        $('.modal-dialog').css({
            top: 0,
            left: 0
        });
    });

    $('.modal-dialog').draggable({
        handle: ".modal-header"
    });

    $('.dataTables').DataTable({
        responsive: true
    });

    $('[data-toggle="tooltip"]').tooltip({
        placement: 'top', // or bottom, left, right, and variations
        title: "Top"
    });

    $('input[type=radio]').iCheck({
        radioClass: 'iradio_square-blue',
    });

    $('input[type=checkbox]').iCheck({
        checkboxClass: 'icheckbox_square-blue',
    });

    if (!$.datepicker.initialized) {
        $(document).mousedown($.datepicker._checkExternalClick)
            .find(document.body).append($.datepicker.dpDiv);
        $.datepicker.initialized = true;
    }

    $.datepicker.regional['es'] = {
        closeText: 'Cerrar',
        prevText: '< Ant',
        nextText: 'Sig >',
        currentText: 'Hoy',
        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
        weekHeader: 'Sm',
        dateFormat: 'dd-mm-yy',
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ''
    };
    
    $.datepicker.setDefaults($.datepicker.regional['es']);

    $(".datepickers").datepicker({
        autoclose: true
    });

    $('.telefono').mask('(000) 000-0000', { placeholder: "(000) 000-0000" });
});*/
//CARGA EL PARAMETRO DENTRO DEL MODAL CON GET
function AjaxModalGet(titulo, route, parametro, modal) {
    var bandera = true;
    var param = "";
    var mod = "m_central";
    var region = "x";
    if (parametro != undefined) {
        param = {parametro1: parametro}
    }

    if (modal != undefined) {
        mod = modal;
        switch (modal) {
            case "m_middle":
                region = "m";
                break;
            case "m_small":
                region = "s";
                break;
            case "m_normal":
                region = "n";
                break;
            case "m_ayudas":
                region = "a";
                break;
            default:
                region = "x";
                break;
        }
    }

    /*if (ayuda != undefined) {
        $('#' + region + '_ayuda').removeClass("d-none");
        var ruta_ayuda = ruta.split("/");
        $('#' + region + '_ayuda').on("click", function () { AjaxModalGet('Ayuda - ' + titulo, '/' + ruta_ayuda[1] + '/Ayuda', ruta_ayuda[2], 'm_ayudas'); })
    }*/

    var ruta = (ruta_actual + "/" + route).replace('#', '');
    if (titulo == '') bandera = false;
    $('#' + mod).modal('show');
    $.ajax({
        type: 'GET',
        url: ruta,
        data: param,
        cache: false,
        beforeSend: AjaxWait,
        success: AjaxSucceeded,
        error: AjaxFailed
    });
    function AjaxWait() {
        var ruta_imagen = (ruta_actual + "/Content/images/loading1.gif").replace('#', '');
        $('#' + region + '_cuerpo').html("<img class='w-100' src='" + ruta_imagen+"' />");
    }
    function AjaxSucceeded(result) {
        if (bandera) {
            $('#' + region + '_titulo').html(titulo);
        }
        $("#"+region+"_cuerpo").html(result);
    }
    function AjaxFailed(result) {
        $('#' + region + '_titulo').html("Error");
        $('#' + region + '_cuerpo').load(ruta_actual+"/Home/Error");
    }
}

/*function anular_nota(id) {
    $("#document").html(id);
    $("#m_anular").modal("show");
}*/

function exportar_documento(id) {
    $("#e_document").html(id);
    $("#m_expotar").modal("show");
}

function imprimir_global(titulo, ruta) {
    $('#imp_desde').unbind('dblclick');
    $('#imp_hasta').unbind('dblclick');

    if (titulo != undefined) {
        $("#imp_desde").on("dblclick", function () { AjaxModalGet(titulo, ruta, 'nada2', 'm_middle'); })
        $("#imp_hasta").on("dblclick", function () { AjaxModalGet(titulo, ruta, 'nada2', 'm_middle'); })
    }
    $("#m_imprimir").modal("show");
}

/*function revertir_nota(id) {
    $("#r_document").html(id);
    $("#m_revertir").modal("show");
}
*/
function nada2(codigo, descripcion) {
    $('#m_middle').modal('hide');
}

function nada(codigo, descripcion) {
    $('#m_central').modal('hide');
}

function loading_show() {
    $('body').loadingModal({
        text: 'Por favor espere',
        animation: 'circle',
    });
    $('body').loadingModal('show');
}

function loading_hide() {
    $('body').loadingModal('hide');
}

function presiona(e, funcion) {
    var tecla = (document.all) ? event.keyCode : e.which;
    if (tecla == 13) {
        funcion();
    }
}

function IsNumeric(sText) {
    var ValidChars = "0123456789.";
    var IsNumber=true;
    var Char;

    for (i = 0; i < sText.length && IsNumber == true; i++) 
    { 
        Char = sText.charAt(i); 
        if (ValidChars.indexOf(Char) == -1) 
        {
            IsNumber = false;
        }
    }
    return IsNumber;
}

function solo_enteros(e) {
    var tipo = e.keyCode;
    //if ((tipo == 8) || (tipo == 9) || (tipo == 116) || (tipo == 46)) return true; // BACKSPACE, TAB, F5, DELETE
    var regex = new RegExp("^[0-9]+$");
    var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(str)) {
        return true;
    }
    e.preventDefault();
    return false
}

function solo_numeros(e) {
    var tipo = e.keyCode;
    //if ((tipo == 8) || (tipo == 9) || (tipo == 116) || (tipo == 46)) return true; // BACKSPACE, TAB, F5, DELETE
    var regex = new RegExp("^[0-9.]+$");
    var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(str)) {
        return true;
    }
    e.preventDefault();
    return false
}

function solo_telefono(e) {
    var tipo = e.keyCode;
    //if ((tipo == 8) || (tipo == 9) || (tipo == 116) || (tipo == 46)) return true; // BACKSPACE, TAB, F5, DELETE
    var regex = new RegExp("^[0-9 ()-.]+$");
    var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(str)) {
        return true;
    }
    e.preventDefault();
    return false
}

function solo_alfanumericos(e) {
    var tipo = e.keyCode;
    //if ((tipo == 8) || (tipo == 9) || (tipo == 116) || (tipo == 46)) return true; // BACKSPACE, TAB, F5, DELETE
    var regex = new RegExp("^[a-zA-ZñÑ.0-9@\ \-]+$");
    var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(str)) {
        return true;
    }

    e.preventDefault();
    return false
}

function solo_letras(e) {
    var tipo = e.keyCode;
    //if ((tipo == 8) || (tipo == 9) || (tipo == 116) || (tipo == 46)) return true; // BACKSPACE, TAB, F5, DELETE
    var regex = new RegExp("^[a-zA-ZñÑ\ \-]+$");
    var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    if (regex.test(str)) {
        return true;
    }

    e.preventDefault();
    return false
}

function solo_decimal(e, valor) {
    var tipo = e.keyCode;
    //if ((tipo == 8) || (tipo == 9) || (tipo == 116) || (tipo == 46)) return true; // BACKSPACE, TAB, F5, DELETE
    var regex = new RegExp("^[0-9.]+$");
    var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    var tempValue = valor.value + str;
    if (regex.test(str)) {
        if (filter(tempValue)) return true;
    }
    e.preventDefault();
    return false
}
function filter(__val__) {
    var preg = /^([0-9]+\.?[0-9]{0,2})$/;
    if (preg.test(__val__) === true) {
        return true;
    } else {
        return false;
    }
}

function soloNumeros(e){
    var key = window.event ? e.which : e.keyCode;
    
    if ((key == 110) || (key == 9) || (key == 116)) return false;
    if (key == 8) return true;
    if (key < 48 || key > 57) {
        if (key < 96 || key > 105) e.preventDefault();
    }
}

function soloEnteros(e){
    var key = window.event ? e.which : e.keyCode;

    if ((key == 8) || (key == 9) || (key == 116)) return false;
    if (key < 48 || key > 57) {
        if (key < 96 || key > 105) e.preventDefault();
    }
}

function soloLetras(letra){
    key = letra.keyCode || letra.which;
    tecla = String.fromCharCode(key).toLowerCase();
    letras = "áéíóúabcdefghijklmnñopqrstuvwxyz";
    especiales = "8-37-39-46";

    tecla_especial = false
    for(var i in especiales){
        if(key == especiales[i]){
            tecla_especial = true;
            break;
        }
    }

    
    if(letras.indexOf(tecla)==-1 && !tecla_especial && key != '32'){
        return false;
    }
}

function letrasNumeros(e){
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    alfa = "áéíóúabcdefghijklmnñopqrstuvwxyz1234567890";
    especiales = "8-37-39-46-32";
    tecla_especial2 = false
    for(var i in especiales){
        if(key == especiales[i]){
            tecla_especial2 = true;
            break;
            console.log(especiales[i])
        }
    }

    if(alfa.indexOf(tecla)==-1 && !tecla_especial2 && key != '32'){
        return false;
    }
}

function textCounter(field, countfield, maxlimit) {
    var field = $("#" + field)[0];
    var countfield = $("#" + countfield)[0];
    if (field.value.length > maxlimit) {// if too long...trim it!
        field.value = field.value.substring(0, maxlimit);
        // otherwise, update 'characters left' counter
    } else {
        countfield.innerHTML = maxlimit - field.value.length;
    };
};

function pagina_central(accion, controlador, item) {
    //console.log(accion+" - "+controlador);
    //$("#page-wrapper").load(controlador+"/"+accion);
    if (item != undefined) {
        $(".active").removeClass('active');
        $("#menu_" + item).addClass('active');
    }

    $("#sidebar")[0].style.width = "0";
    var ruta = (ruta_actual + "/" + controlador + "/" + accion).replace('#', '');
    var param = "";
    $.ajax({
        type: 'GET',
        url: ruta,
        data: param,
        cache: false,
        beforeSend: AjaxWait,
        success: AjaxSucceeded,
        error: AjaxFailed
    });
    function AjaxWait() {
        loading_show();
    }
    function AjaxSucceeded(result) {
        loading_hide();
        $("#contenido").html(result);
    }
    function AjaxFailed(result) {
        loading_hide();
        $("#contenido").load(ruta_actual + "/Home/Error");
    }    
}

function valida_email(valor) {
    var regex = /[\w-\.]{2,}@([\w-]{2,}\.)*([\w-]{2,}\.)[\w-]{2,4}/;
    
    if (regex.test($("#" + valor).val().trim())) {
        $("#msj_" + valor)[0].style.display = "none";
        $("#msj_" + valor)[0].innerHTML = "";
        return true;
    }

    $("#msj_" + valor)[0].style.display = "block";
    $("#msj_" + valor)[0].innerHTML = "Error en el correo";
    return false
}

function mostrar_panel(accion, controlador) {
    $("#sidebar")[0].style.width = "100%";
    var ruta = (ruta_actual +"/"+ controlador + "/" + accion).replace('#', '');
    var param = "";
    $.ajax({
        type: 'GET',
        url: ruta,
        data: param,
        cache: false,
        beforeSend: AjaxWait,
        success: AjaxSucceeded,
        error: AjaxFailed
    });
    function AjaxWait() {
        var ruta_imagen = (ruta_actual + "/Content/images/loading1.gif").replace('#', '');
        $('#panel_contenido').html("<img class='w-100' src='" + ruta_imagen+"' />");
    }
    function AjaxSucceeded(result) {
        $("#panel_contenido").html(result);
        $("#panel_contenido")[0].style.height = "auto";
    }
    function AjaxFailed(result) {
        $('#panel_contenido').load(ruta_actual + "/Home/Error");
    }
}

function ocultar_panel() {
    $("#sidebar")[0].style.width = "0";
}

function MostrarMensaje(Tipo, Mensaje) {
    toastr.options = {
        closeButton: true,
        progressBar: true,
        showMethod: 'slideDown',
        timeOut: 4000,
        positionClass: "toast-bottom-center",
    };

    switch (Tipo) {
        case "Verde":
            toastr.success(Mensaje, "Procesado");
            break;

        case "Amarillo":
            toastr.warning(Mensaje, "Alerta");
            break;

        case "Rojo":
            toastr.error(Mensaje, "Error");
            break;

        case "Azul":
            toastr.info(Mensaje, "Información");
            break;
    }
}

function anular_nota(registro) {
    swal({
        title: "¿Estás seguro?",
        text: "Confirmar Anulado del registro: ",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        cancelButtonClass: "btn-secondary",
        confirmButtonText: "Aceptar",
        cancelButtonText: "Cancelar",
    },
    function (isConfirm) {
        if (isConfirm) {

        } else {

        }
    });
}

function revertir_nota(registro) {
    swal({
        title: "¿Estás seguro?",
        text: "Revertir registro: " + registro,
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        cancelButtonClass: "btn-secondary",
        confirmButtonText: "Aceptar",
        cancelButtonText: "Cancelar",
    },
    function (isConfirm) {
        if (isConfirm) {

        } else {

        }
    });
}

function add_filas(row, clase, funcion, limite, identi) {
    //EL FALSO ES EL CAMPO PARA CAMBIAR LA FILA DE COLOR, DEPENDIENDO DE TRUE O FALSE
    if (!funcion) {
        funcion = "";
    }
    if (!limite) {
        limite = "";
    }
    if (typeof identi == "undefined") {
        identi = 0;
    }
    var otro = "";
    var funciones = funcion.split("#");
    var tr = document.createElement('tr');
    tr.id = "add_filas_" + row[identi];
    tr.className = 'text-center';
    tr.align = 'center';
    var td = new Array();
    var node = new Array();
    var texto;

    if ((limite == '') || (limite == 0)) {
        limite = row.length;
    }
    for (var i = 0; i < row.length; i++) {
        if (clase == 'td') {
            otro = otro + row[i] + "#";
        }

        td[i] = document.createElement(clase);
        texto = row[i];

        if (i > limite) {
            td[i].style.display = 'none';
        }
        node[i] = document.createTextNode(texto);
        td[i].style.maxWidth = "400px";
        td[i].appendChild(node[i]);
        tr.appendChild(td[i]);
    }

    if (funcion != "") {
        if (clase == 'td') {
            td = document.createElement(clase);
            td.align = 'center';
            td.style.cursor = "pointer";
            td.style.verticalAlign = "middle";
            for (i = 0; i < funciones.length; i++) {
                var imagen = document.createElement('i');
                if (funciones[i] != "") {
                    imagen.width = "28";
                    imagen.style.padding = "3px";
                    imagen.tittle = otro;
                    imagen.title = funciones[i];
                    imagen.id = "add_fila_i_" + row[identi];
                    switch (i) {
                        case 0:
                            imagen.className = "fa fa-edit";
                            break;
                        case 1:
                            imagen.className = "fa fa-print";
                            break;
                        case 2:
                            imagen.className = "fa fa-search";
                            break;
                        case 3:
                            imagen.className = "fa fa-undo";
                            break;
                        case 4:
                            imagen.className = "fa fa-times";
                            break;
                            break;
                        default:
                            imagen.className = "fa fa-times";
                    }
                    eval("imagen.onclick = function(){" + funciones[i] + "(this.tittle);}");
                    td.appendChild(imagen);
                }
            }
            tr.appendChild(td);
        }
    }

    return tr;
}
