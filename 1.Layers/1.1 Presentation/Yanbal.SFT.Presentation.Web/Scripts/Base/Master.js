$.datepicker.parseDate = function (format, value, settings) {
    if (format == null || value == null) {
        throw "Invalid arguments";
    }

    value = (typeof value === "object" ? value.toString() : value + "");
    if (value === "") {
        return null;
    }

    var iFormat, dim, extra,
        iValue = 0,
        shortYearCutoffTemp = (settings ? settings.shortYearCutoff : null) || this._defaults.shortYearCutoff,
        shortYearCutoff = (typeof shortYearCutoffTemp !== "string" ? shortYearCutoffTemp :
            new Date().getFullYear() % 100 + parseInt(shortYearCutoffTemp, 10)),
        dayNamesShort = (settings ? settings.dayNamesShort : null) || this._defaults.dayNamesShort,
        dayNames = (settings ? settings.dayNames : null) || this._defaults.dayNames,
        monthNamesShort = (settings ? settings.monthNamesShort : null) || this._defaults.monthNamesShort,
        monthNames = (settings ? settings.monthNames : null) || this._defaults.monthNames,
        year = -1,
        month = -1,
        day = -1,
        doy = -1,
        literal = false,
        date,
        // Check whether a format character is doubled
        lookAhead = function (match) {
            var matches = (iFormat + 1 < format.length && format.charAt(iFormat + 1) === match);
            if (matches) {
                iFormat++;
            }
            return matches;
        },
        // Extract a number from the string value
        getNumber = function (match) {
            var isDoubled = lookAhead(match),
                size = (match === "@" ? 14 : (match === "!" ? 20 :
                    (match === "y" && isDoubled ? 4 : (match === "o" ? 3 : 2)))),
                    digits = new RegExp("^\\d{1," + size + "}"),
                    num = value.substring(iValue).match(digits);
            if (!num) {
                throw "Missing number at position " + iValue;
            }
            iValue += num[0].length;
            return parseInt(num[0], 10);
        },
            // Extract a name from the string value and convert to an index
            getName = function (match, shortNames, longNames) {
                var index = -1,
                    names = $.map(lookAhead(match) ? longNames : shortNames, function (v, k) {
                        return [[k, v]];
                    }).sort(function (a, b) {
                        return -(a[1].length - b[1].length);
                    });

                $.each(names, function (i, pair) {
                    var name = pair[1];
                    if (value.substr(iValue, name.length).toLowerCase() === name.toLowerCase()) {
                        index = pair[0];
                        iValue += name.length;
                        return false;
                    }
                });
                if (index !== -1) {
                    return index + 1;
                } else {
                    throw "Unknown name at position " + iValue;
                }
            },
            // Confirm that a literal character matches the string value
            checkLiteral = function () {
                if (value.charAt(iValue) !== format.charAt(iFormat)) {
                    throw "Unexpected literal at position " + iValue;
                }
                iValue++;
            };

    for (iFormat = 0; iFormat < format.length; iFormat++) {
        if (literal) {
            if (format.charAt(iFormat) === "'" && !lookAhead("'")) {
                literal = false;
            } else {
                checkLiteral();
            }
        } else {
            switch (format.charAt(iFormat)) {
                case "d":
                    day = getNumber("d");
                    break;
                case "D":
                    getName("D", dayNamesShort, dayNames);
                    break;
                case "o":
                    doy = getNumber("o");
                    break;
                case "m":
                    month = getNumber("m");
                    break;
                case "M":
                    month = getName("M", monthNamesShort, monthNames);
                    break;
                case "y":
                    year = getNumber("y");
                    break;
                case "@":
                    date = new Date(getNumber("@"));
                    year = date.getFullYear();
                    month = date.getMonth() + 1;
                    day = date.getDate();
                    break;
                case "!":
                    date = new Date((getNumber("!") - this._ticksTo1970) / 10000);
                    year = date.getFullYear();
                    month = date.getMonth() + 1;
                    day = date.getDate();
                    break;
                case "'":
                    if (lookAhead("'")) {
                        checkLiteral();
                    } else {
                        literal = true;
                    }
                    break;
                default:
                    checkLiteral();
            }
        }
    }

    if (iValue < value.length) {
        extra = value.substr(iValue);
        if (!/^\s+/.test(extra)) {
            throw "Extra/unparsed characters found in date: " + extra;
        }
    }

    if (year === -1) {
        year = new Date().getFullYear();
    } else if (year < 100) {
        var yearNow = new Date().getFullYear();
        year = (parseInt((yearNow / 100)) * 100) + year;
        //year = new Date().getFullYear();
        //year += new Date().getFullYear() - new Date().getFullYear() % 100 +
        //    (year <= shortYearCutoff ? 0 : -100);
    }

    if (doy > -1) {
        month = 1;
        day = doy;
        do {
            dim = this._getDaysInMonth(year, month - 1);
            if (day <= dim) {
                break;
            }
            month++;
            day -= dim;
        } while (true);
    }

    date = this._daylightSavingAdjust(new Date(year, month - 1, day));
    if (date.getFullYear() !== year || date.getMonth() + 1 !== month || date.getDate() !== day) {
        throw "Invalid date"; // E.g. 31/02/00
    }
    return date;
};

function ObtenerPagina(paginaSolicitada, TotalPaginas, PaginaActual) {
    if (paginaSolicitada == 'A' && PaginaActual == 1)
        return 0;

    if (paginaSolicitada == 'P' && PaginaActual == 1)
        return 0;


    var PaginaResult = 0;

    switch (paginaSolicitada) {
        case "P":
            PaginaResult = 1;
            break;
        case "A":
            PaginaResult = PaginaActual - 1;
            break;
        case "S":
            if (PaginaActual == TotalPaginas) {
                return 0;
            } else PaginaResult = PaginaActual + 1;

            break;
        case "U":
            if (PaginaActual == TotalPaginas) {
                return 0;
            } else
                PaginaResult = TotalPaginas;
            break;
    }
    return PaginaResult;
}

/**
 * Función que valida que se ingresen sólo números en un componente de la página.
 * evento, Evento que tipo "onkeypress" que se esta validando.
 */
function validateOnlyNumbers(evento) {
    /*Validar la existencia del objeto event*/
    evento = (evento) ? evento : event;

    /*Extraer el codigo del caracter de uno de los diferentes grupos de codigos*/
    //var charCode = (evento.charCode) ? evento.charCode : ((evento.keyCode) ? evento.keyCode
    //	: ((evento.which) ? evento.which : 0));

    var key = evento.keyCode ? evento.keyCode : evento.which ? evento.which : evento.charCode; //Aceptado por FF y IE

    /*Predefinir como invalido*/
    var respuesta = false;

    /*Validar si el codigo corresponde a los NO aceptables*/
    //if (key > 31 && (key < 48 || key > 57) && (key == 37 && key == 39)) {
    /*Asignar FALSE a la respuesta si es de los NO aceptables*/
    //  respuesta = false;
    //}
    if (key >= 48 && key <= 57)
    { respuesta = true; }
    if (evento.charCode == 0)/*direccionales*/
    { respuesta = true; }

    if (key == 13)/*enter*/
    { respuesta = true; }

    /*Regresar la respuesta*/
    return respuesta;
}

/**
 * Función que valida que se ingresen sólo números, letras y el caracter punto en un componente de la página.
 * evento, Evento que tipo "onkeypress" que se esta validando.
 */
function validateOnlyNumbersAndPoint(evento) {
    /*Validar la existencia del objeto event*/
    evento = (evento) ? evento : event;

    var key = evento.keyCode ? evento.keyCode : evento.which ? evento.which : evento.charCode; 

    /*Predefinir como invalido*/
    var respuesta = false;

    if (key >= 48 && key <= 57 || key == 46)
    { respuesta = true; }
    if (evento.charCode == 0)/*direccionales*/
    { respuesta = true; }

    if (key == 13)/*enter*/
    { respuesta = true; }

    /*Regresar la respuesta*/
    return respuesta;
}

/**
 * Función que valida que se ingresen sólo números, letras, espacio en blanco y guión bajo en un componente de la página.
 * evento, Evento que tipo "onkeypress" que se esta validando. 
 */
function validarSoloNumerosLetrasEspaciosEnBlancoYGuionBajo(evento) {
    tecla = (document.all) ? evento.keyCode : evento.which;
    if (tecla == 8 || tecla == 0)
        return true;
    patron = /^[A-Za-z0-9_\s\u00f1\u00d1\u00e1\u00c1\u00e9\u00c9\u00ed\u00cd\u00f3\u00d3\u00fa\u00da]$/;
    var codigo = String.fromCharCode(tecla);
    return patron.test(codigo);
}

/**
 * Función que valida que se ingresen sólo números, letras y espacio en blanco en un componente de la página.
 * evento, Evento que tipo "onkeypress" que se esta validando. 
 */
function validarSoloNumerosLetrasYEspaciosEnBlanco(evento) {
    tecla = (document.all) ? evento.keyCode : evento.which;
    if (tecla == 8 || tecla == 0)
        return true;
    patron = /^[A-Za-z0-9\s\u00f1\u00d1\u00e1\u00c1\u00e9\u00c9\u00ed\u00cd\u00f3\u00d3\u00fa\u00da]$/;
    var codigo = String.fromCharCode(tecla);
    return patron.test(codigo);
}

function AlfanumericoYGuion(evento) {
    var key = evento.keyCode ? evento.keyCode : evento.which ? evento.which : evento.charCode; //Aceptado por FF y IE
    var patron = /^[\u00F1A-Za-z0-9\-.\s]+$/i;
    var codigo = String.fromCharCode(key);
    var flag = patron.test(codigo);
    return flag;
}

function fechaconbarra(evento) {
    var key = evento.keyCode ? evento.keyCode : evento.which ? evento.which : evento.charCode; //Aceptado por FF y IE
    var patron = /^[\z0-9\/\s]+$/i;
    var codigo = String.fromCharCode(key);
    var flag = patron.test(codigo);
    return flag;
}

function MontoPago(evento) {
    var key = evento.keyCode ? evento.keyCode : evento.which ? evento.which : evento.charCode; //Aceptado por FF y IE
    var patron = /^[\z0-9\.\,\s]+$/i;
    var codigo = String.fromCharCode(key);
    var flag = patron.test(codigo);
    return flag;
}

/**
 * Permite validar las teclas principales. 
 * tecla, tecla pulsada.
 */
function validarTeclasPrincipales(tecla) {
    var arr = new Array(8, 9, 35, 36, 37, 38, 39, 40);
    //var arr = new Array(8, 9);
    for (ctaArr = 0; ctaArr < arr.length; ctaArr++) {
        if (tecla == arr[ctaArr])
            return true;
    }
    return false;
}

//arnaldo me dijo
/**
 * Valida si sólo se ha ingresado letras.
 * evento, Evento que tipo "onkeypress" que se esta validando.
 */
function validateOnlyLetters(event) {
    var key = getKeyCode(event);
    if (validarTeclasPrincipales(key))
        return true;
    if (event && key == 13)/*enter*/
        return true;
    if (event && key >= 65 && key <= 90)
        return true;
    if (event && key >= 97 && key <= 122)
        return true;
    if (event && key == 32)/*espace*/
        return true;
    if (event && key >= 164 && key <= 165)
        return true;
    if (event && key == 209)/*letra Ñ*/
        return true;
    if (event && key == 241)/*letra ñ*/
        return true;
    if (event && key == 193)/*letra Á*/
        return true;
    if (event && key == 201)/*letra É*/
        return true;
    if (event && key == 205)/*letra Í*/
        return true;
    if (event && key == 211)/*letra Ó*/
        return true;
    if (event && key == 218)/*letra Ú*/
        return true;
    if (event && key == 225)/*letra á*/
        return true;
    if (event && key == 233)/*letra é*/
        return true;
    if (event && key == 237)/*letra í*/
        return true;
    if (event && key == 243)/*letra ó*/
        return true;
    if (event && key == 250)/*letra ú*/
        return true;
    //if (event && key == 37)/*direccionales izquierda*/
    //    return true;
    //if (event && key == 39)/*direccionales derecha*/
    //  return true;
    if (event.charCode == 0)/*direccionales*/
        return true;
    return false;
}


/*Validar solo Letras en la Busqueda General de Consultora*/
function validarTeclasPrincipalesLetras(tecla) {
    //var arr = new Array(8, 9, 35, 36, 37, 38, 39, 40);
    var arr = new Array(8, 9);
    for (ctaArr = 0; ctaArr < arr.length; ctaArr++) {
        if (tecla == arr[ctaArr])
            return true;
    }
    return false;
}

function ValidarSiEsNumericoValido(monto) {
    if ($.trim(monto) == '') return false;

    return /^([0-9])*[.]?[0-9]*$/.test(monto);

}

function ValidarSiEsNumericoValidoNulo(monto) {
    //if ($.trim(monto) == '') return false;

    return /^([0-9])*[.]?[0-9]*$/.test(monto);

}

function formateafecha(fecha) {
    if (fecha.length >= 1) {
        var resultado = fecha.substr(0, fecha.length - 1);
        var ultimo = fecha.substr(fecha.length - 1);
        if (fecha.length <= 10) {
            if (fecha.length != 3 && fecha.length != 6) {
                if (fecha.length >= 3 && fecha.length < 6 &&
                        fecha.indexOf('/') != 2) {
                    resultado = fecha.substr(0, 2);
                } else {
                    if (fecha.length >= 6 && fecha.lastIndexOf('/') != 5) {
                        resultado = fecha.substr(0, 5);
                    } else {
                        if (ultimo.search(/\d/g) > -1) {
                            if (fecha.length <= 2) {
                                if (fecha <= 31) {
                                    resultado = resultado + ultimo;
                                }
                            } else {
                                if (fecha.length <= 5) {
                                    if (fecha.substr(3, fecha.length - 1) <= 12) {
                                        resultado = resultado + ultimo;
                                    }
                                } else {
                                    resultado = resultado + ultimo;
                                }
                            }
                        }
                    }
                }
            } else {
                if (ultimo == '/') {
                    resultado = resultado + ultimo;
                }
            }
        }
        return resultado;
    } else {
        return fecha;
    }
}

function formatearFechaBase(fecha) {
    var d = fecha.split("/")[0];
    var m = fecha.split("/")[1];
    var y = fecha.split("/")[2];
    if (fecha.indexOf('/') > 1) {
        return d + '/' + m + '/' + y;
    } else {
        var yf = fecha.split("-")[0];
        var mf = fecha.split("-")[1];
        var df = fecha.split("-")[2];
        return df + '/' + mf + '/' + yf;
    }

}

function validarFormatoFecha(campo, evento) {
    var fecha = campo.value;
    evento = (evento) ? evento : event;

    var key = evento.keyCode ? evento.keyCode : evento.which ? evento.which : evento.charCode;

    if (evento && key == 8) { /* retroceso */
        return true;
    }

    //if (evento && key == 37) { /*direccionales izquierda*/
    //  return true;
    //}

    //if (evento && key == 39) { /*direccionales derecha*/
    //    return true;
    //}

    if (evento.charCode == 0)/*direccionales*/
        return true;

    if (fecha.length < 10) {
        var ultimo = String.fromCharCode((evento.charCode) ? evento.charCode : ((evento.keyCode) ? evento.keyCode : ((evento.which) ? evento.which : 0)));
        if (validateOnlyNumbers(evento)) {
            if (fecha.length < 2) {
                var dia = fecha + ultimo;
                if (dia <= 31) {
                    if (fecha.length == 1) dia = dia + '/';
                    fecha = dia;
                }
            } else {
                if (fecha.length < 5) {
                    var mes = fecha.substr(3, fecha.length - 1) + ultimo;
                    if (mes <= 12) {
                        if (fecha.length == 4) mes = mes + '/';
                        fecha = fecha.substr(0, 3) + mes;
                    }
                } else {
                    fecha = fecha + ultimo;
                }
            }
        }
    }
    campo.value = fecha;

    return false;
}

function validarFormatoDecimal(campo, event) {
    var keyCode = getKeyCode(event);

    // backspace
    if (keyCode == 8) { return true; }

    if (event.charCode == 0)/*direccionales*/
        return true;

    // 0-9
    if (keyCode > 47 && keyCode < 58) {
        if (this.value == '') { return true; }
        var patron = '.{4}[0-9]{2}$';
        var regexp = new RegExp(patron);
        return !(regexp.test(campo.value));
    }

    // .
    if (event.char == Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorDecimal) {
        if (campo.value == '') { return false; }
        regexp = /^[0-9]+$/;
        return regexp.test(campo.value);
    }

    // other key
    return false;
}

function validarCampoFecha(value) {
    var date_regex = /^(0[1-9]|1\d|2\d|3[01])\/(0[1-9]|1[0-2])\/(19|20)\d{2}$/;
    return date_regex.test(value);
};

function validarCampoHora(value) {
    var date_regex = /^(0[1-9]|1\d|2[0-3]):([0-5]\d)$/;
    return date_regex.test(value);
};

function validarFormatoHora(campo, evento) {
    var fecha = campo.value;
    if (fecha.length < 5) {
        var ultimo = String.fromCharCode(evento.keyCode);
        if (validateOnlyNumbers(evento)) {
            if (fecha.length < 2) {
                var hora = fecha + ultimo;
                if (hora <= 23) {
                    if (fecha.length == 1) hora = hora + ':';
                    fecha = hora;
                }
            } else {
                if (fecha.length < 5) {
                    var minuto = fecha.substr(3, fecha.length - 1) + ultimo;
                    if (minuto <= 59) {
                        if (fecha.length == 1) minuto = minuto;
                        fecha = fecha.substr(0, 3) + minuto;
                    }
                }
            }
        }
    }
    campo.value = fecha;
    return false;
}

function AgregarComas(nStr) {
    nStr += '';
    x = nStr.split('.');
    x1 = x[0];
    x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + ',' + '$2');
    }
    return x1 + x2;
}

//extendiendo Mensajes
function HtmlEncode(value) {
    return $('<div/>').text(value).html();
}

function HtmlDecode(value) {
    return $('<div/>').html(value).text();
}

window.alert = function (mensaje) {
    var Mensaje = new Yanbal.SFT.Web.Components.Message();
    Mensaje.Warning({
        message: mensaje
    });


};

/* Función que valida si la cadena contiene solo números.
 *  Ejemplo de uso:
 *   Al usar validateStringOnlyNumber(“1234″) : retorna True.
 *   Al usar validateStringOnlyNumber(“a123″) : retorna False.
 */
function validateStringOnlyNumber(cadena) {
    var patron = /^[0-9\r\n]+$/;
    if (!cadena.search(patron))
        return true;
    else
        return false;
}

function validateStringOnlyDecimalPoint(cadena) {
    var patron = /^[-+]?\d+(\.\d+)?$/;
    if (!cadena.search(patron))
        return true;
    else
        return false;
}

/* Función que valida si la cadena contiene solo números.
 *  Ejemplo de uso:
 *   Al usar validaCadenaSoloTexto(“abcd”) : retorna True.
 *   Al usar validaCadenaSoloTexto(“1abc”) : retorna False.
 */
function validaCadenaSoloTexto(cadena) {
    var patron = /^[a-zA-Z]*$/;
    if (!cadena.search(patron))
        return true;
    else
        return false;
}

function getKeyCode(evento) {
    return evento.keyCode ? evento.keyCode : evento.which ? evento.which : evento.charCode;
}

function validarCopySoloNumerico(e) {
    var texto = getValueCopy(e);
    return validateStringOnlyNumber(texto);
}

function ValidarCopySoloAlfanumerico(e) {
    var texto = getValueCopy(e);
    var patron = /^[\u00F1A-Za-z0-9\-.\s]+$/i;
    var flag = patron.test(texto);
    return flag;
}

function validateCopyOnlyLetters(e) {
    var texto = getValueCopy(e);
    return validaCadenaSoloTexto(texto);
}

function validateCopyStringOnlyDecimalPoint(e) {
    var texto = getValueCopy(e);
    return validateStringOnlyDecimalPoint(texto);
}

function validateCopyDate(e) {
    var texto = getValueCopy(e);
    return validarCampoFecha(texto);
}

function validarCopyHora(e) {
    var texto = getValueCopy(e);
    return validarCampoHora(texto);
}

function getValueCopy(e) {
    var texto = "";
    if (window.clipboardData) {
        texto = window.clipboardData.getData('Text');
    }
    else {
        texto = e.originalEvent.clipboardData.getData('text/plain');
    }
    return texto;
}

function validateDateRange(txtStart, txtEnd) {

    var isValid = true;

    var valueStart = txtStart.is('input') ? txtStart.val() : txtStart.html();
    var valueEnd = txtEnd.is('input') ? txtEnd.val() : txtEnd.html();

    if (valueStart != '' && valueEnd != '') {
        var dateStart = $.datepicker.parseDate(Yanbal.SFT.Presentation.Web.Global.Format.Date, valueStart);
        var dateEnd = $.datepicker.parseDate(Yanbal.SFT.Presentation.Web.Global.Format.Date, valueEnd);
        isValid = (dateStart <= dateEnd);
    }
    return isValid;
}

function aplicarToolTip(container) {

    if (container == undefined) {
        container = null;
    }

    container.tooltip({
        position: {
            my: 'center bottom-5',
            at: 'center top',
            using: function (position, feedback) {
                $(this).css(position);
                $(this).html(this.innerText)
                $('<div>')
                  .addClass('arrow')
                  .addClass(feedback.vertical)
                  .addClass(feedback.horizontal)
                  .appendTo(this);
            }
        },
        close: function (event, ui) {

        },
        open: function (event, ui) {

        },
        create: function (event, ui) {

        },
        hide: { effect: "fadIn", duration: 500 }
    });
}

function ValidarFechaOnBlur(objeto) {
    var ok = true;
    if (objeto.value.length < 10)
        ok = false;
    else {
        try {
            var date = $.datepicker.parseDate(Yanbal.SFT.Presentation.Web.Global.Format.Date, objeto.value);
            ok = (date.getFullYear() >= 1900)
        }
        catch (err) {
            ok = false;
        }
    }

    if (!ok)
        $('#' + objeto.id).val('');

    return ok;
}

function ValidarFechaOnBlur2(objeto) {
    var ok = true;
    if (objeto.val().length < 10)
        ok = false;
    else {
        try {
            var date = $.datepicker.parseDate(Yanbal.SFT.Presentation.Web.Global.Format.Date, objeto.val());
            ok = (date.getFullYear() >= 1900)
        }
        catch (err) {
            ok = false;
        }
    }

    if (!ok)
        $(objeto.selector).val('');

    return ok;
}

function QuitarDrop() {
    var controls = $("input[type=text], input[type=password], textarea");
    controls.bind("drop", function () {
        return false;
    });
    controls = undefined;
}

function formato_numeroDecimal(numero, decimales, separador_decimal, separador_miles) { // v2007-08-06
    numero = parseFloat(numero);
    if (isNaN(numero)) {
        return "";
    }

    if (decimales !== undefined) {
        // Redondeamos
        numero = numero.toFixed(decimales);
    }

    // Convertimos el punto en separador_decimal
    numero = numero.toString().replace(".", separador_decimal !== undefined ? separador_decimal : ",");

    if (separador_miles) {
        // Añadimos los separadores de miles
        var miles = new RegExp("(-?[0-9]+)([0-9]{3})");
        while (miles.test(numero)) {
            numero = numero.replace(miles, "$1" + separador_miles + "$2");
        }
    }

    return numero;
}

function validarSoloLetrasSinEspaciosEnBlanco(evento) {
    var key = evento.keyCode ? evento.keyCode : evento.which ? evento.which : evento.charCode; //Aceptado por FF y IE
    if (validarTeclasPrincipales(key))
        return true;
    if (evento && key >= 65 && key <= 90)
        return true;
    if (evento && key >= 97 && key <= 122)
        return true;
    if (evento && key >= 164 && key <= 165)
        return true;
    if (evento && key == 209)/*letra Ñ*/
        return true;
    if (evento && key == 241)/*letra ñ*/
        return true;
    if (evento && key == 193)/*letra Á*/
        return true;
    if (evento && key == 201)/*letra É*/
        return true;
    if (evento && key == 205)/*letra Í*/
        return true;
    if (evento && key == 211)/*letra Ó*/
        return true;
    if (evento && key == 218)/*letra Ú*/
        return true;
    if (evento && key == 225)/*letra á*/
        return true;
    if (evento && key == 233)/*letra é*/
        return true;
    if (evento && key == 237)/*letra í*/
        return true;
    if (evento && key == 243)/*letra ó*/
        return true;
    if (evento && key == 250)/*letra ú*/
        return true;
    //if (evento && key == 37)/*direccionales izquierda*/
    //    return true;
    //if (evento && key == 39)/*direccionales derecha*/
    //    return true;
    if (evento.charCode == 0)/*direccionales*/
        return true;
    return false;
}

function validaCadenaSoloLetrasYParentesis(cadena) {
    var patron = /^[a-zA-Z()\u0020]*$/;
    if (!cadena.search(patron))
        return true;
    else
        return false;
}

function validarSoloLetrasYParentesis(evento) {
    var key = evento.keyCode ? evento.keyCode : evento.which ? evento.which : evento.charCode; //Aceptado por FF y IE
    if (validarTeclasPrincipales(key))
        return true;
    if (evento && key == 13)/*enter*/
        return true;
    if (evento && key >= 65 && key <= 90)
        return true;
    if (evento && key >= 97 && key <= 122)
        return true;
    if (evento && key == 32)/*espace*/
        return true;
    if (evento && key >= 164 && key <= 165)
        return true;
    if (evento && key == 209)/*letra Ñ*/
        return true;
    if (evento && key == 241)/*letra ñ*/
        return true;
    if (evento && key == 193)/*letra Á*/
        return true;
    if (evento && key == 201)/*letra É*/
        return true;
    if (evento && key == 205)/*letra Í*/
        return true;
    if (evento && key == 211)/*letra Ó*/
        return true;
    if (evento && key == 218)/*letra Ú*/
        return true;
    if (evento && key == 225)/*letra á*/
        return true;
    if (evento && key == 233)/*letra é*/
        return true;
    if (evento && key == 237)/*letra í*/
        return true;
    if (evento && key == 243)/*letra ó*/
        return true;
    if (evento && key == 250)/*letra ú*/
        return true;
    if (evento && key == 40)/* ( */
        return true;
    if (evento && key == 41)/* ) */
        return true;
    //if (evento && key == 37)/*direccionales izquierda*/
    //    return true;
    //if (evento && key == 39)/*direccionales derecha*/
    //    return true;
    if (evento.charCode == 0)/*direccionales*/
        return true;
    return false;
}

function validateCopyOnlyLettersYParentesis(e) {
    var texto = getValueCopy(e);
    return validaCadenaSoloLetrasYParentesis(texto);
}

function validarCorreoElectronico(evento) {
    var key = evento.keyCode ? evento.keyCode : evento.which ? evento.which : evento.charCode; //Aceptado por FF y IE
    var patron = /[A-Z0-9a-z@._-]/;
    var codigo = String.fromCharCode(key);
    var flag = patron.test(codigo);
    return flag;
}

function validarCopyCorreoElectronico(e) {
    var texto = getValueCopy(e);
    return validarCampoCorreoElectronico(texto);
}

function validarCampoCorreoElectronico(value) {
    var date_regex = /^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    return date_regex.test(value);
};

function validarNumeroTelefono(evento) {
    var key = evento.keyCode ? evento.keyCode : evento.which ? evento.which : evento.charCode; //Aceptado por FF y IE
    var patron = /[0-9#*]/;
    var codigo = String.fromCharCode(key);
    var flag = patron.test(codigo);
    return flag;
}

function validarCopyNumeroTelefono(e) {
    var texto = getValueCopy(e);
    return validarCampoNumeroTelefono(texto);
}

function validarCampoNumeroTelefono(value) {
    var date_regex = /^[0-9#*]{1}[0-9*]{1,}$/;
    return date_regex.test(value);
};

function ConvertDecimal(value) {

    var format = Yanbal.SFT.Presentation.Web.Global.Format.Decimal;
    var number = value;

    format = format.replace(Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorDecimal, '@');
    format = format.replace(Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorMiles, ',');
    format = format.replace('@', '.');

    number = number.replace(Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorDecimal, '@');
    number = number.replace(Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorMiles, ',');
    number = number.replace('@', '.');

    number = $.parseNumber(number, { format: format });

    return parseFloat(number);
};

function ConvertInteger(value) {

    var format = Yanbal.SFT.Presentation.Web.Global.Format.Integer;
    var number = value;

    format = format.replace(Yanbal.SFT.Presentation.Web.Global.Format.IntegerSeparatorMiles, ',');
    format = format.replace('@', '.');

    number = number.replace(Yanbal.SFT.Presentation.Web.Global.Format.IntegerSeparatorMiles, ',');
    number = number.replace('@', '.');

    number = $.parseNumber(number, { format: format });

    return parseInt(number);
};

function decimalACadena(decimal) {

    var format = Yanbal.SFT.Presentation.Web.Global.Format.Decimal;
    format = format.replace(Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorDecimal, '@');
    format = format.replace(Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorMiles, ',');
    format = format.replace('@', '.');

    var number = decimal.toString();

    if (typeof decimal == 'string') {
        number = number.replace(Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorDecimal, '@');
        number = number.replace(Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorMiles, '');
        number = number.replace('@', '.');
    }

    number = $.formatNumber(number, { format: format });

    number = number.replace('.', '@');
    number = number.replace(',', Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorMiles);
    number = number.replace('@', Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorDecimal);

    return number;

};
function ValidateFieldComment(valor,objeto) {

    var input = $('#' + objeto.id);
    var maxlength = input.attr('maxlength');
    var newMaxlength = Yanbal.SFT.Presentation.Web.Global.Format.MinimumCharactersGloss;
    var lista = Yanbal.SFT.Presentation.Web.Global.Format.ListAllowCharacters;
    var contador = 0;

    var result = true;
    var resultCaracteres = false;
    var resultVocales = false;
    for (var i = 0; i <= valor.length - 1; i++) {
        var char = valor[i];
        var compare = lista.indexOf(char);
        if (compare >= 0 && valor.length >= newMaxlength) {
            resultCaracteres = true;
            break;
        }
    }
    //Validar Vocales
    for (var i = 0; i <= valor.length - 1;  i++) {
        var char = valor[i];
        var compare = lista.indexOf(char);
        if (compare >= 0) {
            contador++;
        }
    }
    var count = contador++;
    if (count >= Yanbal.SFT.Presentation.Web.Global.Format.MinimumVocalsGloss) {
        resultVocales = true
    }

    if (resultCaracteres == false || resultVocales == false)
    { result = false }
    return result;

};

function ConvertShift() {
    if (String.fromCharCode(window.event.keyCode) >= "a" && String.fromCharCode(window.event.keyCode) <= "z") {
        window.event.keyCode = window.event.keyCode - 32;
    }

    if (String.fromCharCode(window.event.keyCode) == "ñ") {
        window.event.keyCode = window.event.keyCode - 32;
    }
}