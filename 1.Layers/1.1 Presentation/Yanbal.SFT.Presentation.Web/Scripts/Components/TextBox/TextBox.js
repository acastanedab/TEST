ns('Yanbal.SFT.Web.Components');
Yanbal.SFT.Web.Components.TextBox = {

    Options: {
        NameMask: 'Mask'
    },
    Function: {
        Configure: function (idContainer) {

            var inputs = new Array();

            if (idContainer == undefined) {
                inputs = $('input[type=text], input[type=password], textarea');
            } else {
                inputs = $('#' + idContainer).find('input[type=text], input[type=password], textarea')
            }

            $.each(inputs, function (index, value) {
                var input = $(value);

                input.bind('drop', Yanbal.SFT.Web.Components.TextBox.Event.General.drop);

                var type = input.attr(Yanbal.SFT.Web.Components.TextBox.Options.NameMask);

                if (typeof type !== typeof undefined && type !== false) {
                    switch (type) {
                        case 'negativeDecimal':
                            Yanbal.SFT.Web.Components.TextBox.Function.ApplyNegativeDecimal(input);
                            break;
                        case 'decimal':
                            Yanbal.SFT.Web.Components.TextBox.Function.ApplyDecimal(input);
                            break;
                        case 'integer':
                            Yanbal.SFT.Web.Components.TextBox.Function.ApplyInteger(input);
                            break;
                    }
                }
            });

            inputs = undefined;
        },
        ApplyNegativeDecimal: function (input) {
            var maxlength = input.attr('maxlength');

            if (!(typeof maxlength !== typeof undefined && maxlength !== false)) {
                maxlength = 6;
            }

            maxlength = parseInt(maxlength);

            var largeDecimal = 3; //tamaño decimal
            var countSeparatorMiles = parseInt(maxlength / 3); //numero de separadores

            var newMaxlength = 1 + maxlength + largeDecimal + countSeparatorMiles

            input.attr('maxlength', newMaxlength);
            input.attr('lengthNumber', maxlength);
            input.attr('lengthSymbol', 0);

            input.blur(Yanbal.SFT.Web.Components.TextBox.Event.NegativeDecimal.blur);
            input.bind('paste', Yanbal.SFT.Web.Components.TextBox.Event.NegativeDecimal.paste);
            input.keypress(Yanbal.SFT.Web.Components.TextBox.Event.NegativeDecimal.keypress);
        },
        ApplyDecimal: function (input) {
            var maxlength = input.attr('maxlength');

            if (!(typeof maxlength !== typeof undefined && maxlength !== false)) {
                maxlength = 6;
            }

            maxlength = parseInt(maxlength);

            var largeDecimal = 3; //tamaño decimal
            var countSeparatorMiles = parseInt(maxlength / 3); //numero de separadores

            var newMaxlength = maxlength + largeDecimal + countSeparatorMiles

            input.attr('maxlength', newMaxlength);
            input.attr('lengthNumber', maxlength);

            input.blur(Yanbal.SFT.Web.Components.TextBox.Event.Decimal.blur);
            input.bind('paste', Yanbal.SFT.Web.Components.TextBox.Event.Decimal.paste);
            input.keypress(Yanbal.SFT.Web.Components.TextBox.Event.Decimal.keypress);
        },
        ApplyInteger: function (input) {
            var maxlength = input.attr('maxlength');

            if (!(typeof maxlength !== typeof undefined && maxlength !== false)) {
                maxlength = 4;
            }

            maxlength = parseInt(maxlength);

            var largeDecimal = 0; //tamaño decimal
            var countSeparatorMiles = parseInt(maxlength / 3); //numero de separadores

            var newMaxlength = maxlength + largeDecimal + countSeparatorMiles

            input.attr('maxlength', newMaxlength);
            input.attr('lengthNumber', maxlength);

            input.blur(Yanbal.SFT.Web.Components.TextBox.Event.Integer.blur);
            input.bind('paste', Yanbal.SFT.Web.Components.TextBox.Event.Integer.paste);
            input.keypress(Yanbal.SFT.Web.Components.TextBox.Event.Integer.keypress);
        },
        FormatDecimal: function (options) {
            $.formatCurrency.regions[''].symbol = (options.symbol == undefined) ? '' : options.symbol;
            $.formatCurrency.regions[''].decimalSymbol = (options.decimalSymbol == undefined) ? Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorDecimal : options.decimalSymbol;
            $.formatCurrency.regions[''].digitGroupSymbol = (options.digitGroupSymbol == undefined) ? Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorMiles : options.digitGroupSymbol;
            var integerDigits = options.input.attr('lengthNumber');
            var maxValue = Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorDecimal + '99';
            for (var i = 0; i < integerDigits; i++) {
                maxValue = '9' + ((i != 0 && i % 3 == 0) ? Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorMiles : "") + maxValue;
            }

            maxValue = ((options.symbol == undefined || options.symbol == null) ? '' : options.symbol) + maxValue;

            if (((options.symbol != '-') && ConvertDecimal(options.input.val()) < ConvertDecimal(maxValue))
                || ((options.symbol == '-') && ConvertDecimal(options.input.val()) > ConvertDecimal(maxValue))
                ) {
                options.input.formatCurrency({
                    roundToDecimalPlace: 2,
                    eventOnDecimalsEntered: true
                });
            }
            else {
                options.input.attr('value', maxValue);
            }
        },
        FormatInteger: function (options) {
            $.formatCurrency.regions[''].symbol = (options.symbol == undefined) ? '' : options.symbol;
            $.formatCurrency.regions[''].decimalSymbol = (options.decimalSymbol == undefined) ? '-' : options.decimalSymbol;
            $.formatCurrency.regions[''].digitGroupSymbol = (options.digitGroupSymbol == undefined) ? Yanbal.SFT.Presentation.Web.Global.Format.IntegerSeparatorMiles : options.digitGroupSymbol;

            options.input.formatCurrency({
                roundToDecimalPlace: 0,
                eventOnDecimalsEntered: true
            });
        }
    },
    Event: {
        General: {
            drop: function () {
                return false;
            }
        },
        NegativeDecimal: {
            blur: function (input) {
                var symbol = (($(this).val().substring(0, 1) === '-') ? "-" : null)
                Yanbal.SFT.Web.Components.TextBox.Function.FormatDecimal({
                    input: $(this),
                    symbol: symbol
                });
                if (symbol == "-" && $(this).val().substring(0, 1) == '(') {
                    $(this).val($(this).val().substring(1, $(this).val().length - 1));
                }
            },
            paste: function (e) {
                var cadena = obtenerValorCopy(e);
                var patron = '^-?[0-9]{1,5}(\\' + Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorDecimal + '[0-9]{0,2})?$';

                var regexp = new RegExp(patron);

                if (!cadena.search(patron))
                    return true;
                else
                    return false;
            },
            keypress: function (evento) {
                var keyCode = getKeyCode(evento);
                var input = $(this);



                // backspace
                if (keyCode == 8) { return true; }

                // direccionales
                if (evento.charCode == 0) { return true; }

                // signo negativo
                if (evento.charCode == 45) {
                    if (document.activeElement.selectionStart == 0) {
                        return true;
                    }
                    return false;
                }

                // 0-9
                if (keyCode > 47 && keyCode < 58) {
                    var symbol = input.val().substring(0, 1);
                    if (symbol == '-') {
                        input.attr('lengthSymbol', 1);
                    }
                    else {
                        input.attr('lengthSymbol', 0);
                    }
                    var selectedText = null;

                    if (window.getSelection) // Firefox
                    {
                        selectedText = input.val().substring(document.activeElement.selectionStart, document.activeElement.selectionEnd);
                    }
                    else // IE
                    {
                        selectedText = document.selection.createRange().text;
                    }

                    if (selectedText != null && selectedText.length == input.val().length) {
                        input.val('');
                    }

                    var lengthNumber = parseInt(input.attr('lengthNumber')) + parseInt(input.attr('lengthSymbol'));

                    if (input.val() != undefined && input.val().indexOf(Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorDecimal) == -1 && input.val().length == lengthNumber) {
                        return false;
                    }

                    if (input.val() == '') { return true; }
                    var patron = '^-?(\d{1,3}' + Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorMiles + '(\d{3}' + Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorMiles + ')*\d{3}(' + Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorDecimal + '\d{1,3})?|\d{1,3}(' + Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorDecimal + '\d{3})?)$ ' + Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorDecimal + '{4}[0-9]{2}$';
                    var regexp = new RegExp(patron);
                    return !(regexp.test(input.val()));
                }

                // Separador Decimal
                if (keyCode == Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorDecimal.charCodeAt(0)) {
                    if (input.val() == '') { return false; }
                    regexp = /^-?[0-9]+$/;
                    return regexp.test(input.val());
                }

                // other key
                return false;
            }
        },
        Decimal: {
            blur: function (input) {
                Yanbal.SFT.Web.Components.TextBox.Function.FormatDecimal({
                    input: $(this)
                });
            },
            paste: function (e) {
                var cadena = obtenerValorCopy(e);
                var patron = '^[0-9]{1,5}(\\' + Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorDecimal + '[0-9]{0,2})?$';

                var regexp = new RegExp(patron);

                if (!cadena.search(patron))
                    return true;
                else
                    return false;
            },
            keypress: function (evento) {
                var keyCode = getKeyCode(evento);
                var input = $(this);

                // backspace
                if (keyCode == 8) { return true; }

                // direccionales
                if (evento.charCode == 0) { return true; }


                // 0-9
                if (keyCode > 47 && keyCode < 58) {

                    var selectedText = null;

                    if (window.getSelection) // Firefox
                    {
                        selectedText = input.val().substring(document.activeElement.selectionStart, document.activeElement.selectionEnd);
                    }
                    else // IE
                    {
                        selectedText = document.selection.createRange().text;
                    }

                    if (selectedText != null && selectedText.length == input.val().length) {
                        input.val('');
                    }

                    var lengthNumber = input.attr('lengthNumber');

                    if (input.val() != undefined && input.val().indexOf(Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorDecimal) == -1 && input.val().length == lengthNumber) {
                        return false;
                    }

                    if (input.val() == '') { return true; }
                    var patron = '^(\d{1,3}' + Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorMiles + '(\d{3}' + Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorMiles + ')*\d{3}(' + Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorDecimal + '\d{1,3})?|\d{1,3}(' + Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorDecimal + '\d{3})?)$ ' + Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorDecimal + '{4}[0-9]{2}$';
                    var regexp = new RegExp(patron);
                    return !(regexp.test(input.val()));
                }

                // Separador Decimal
                if (keyCode == Yanbal.SFT.Presentation.Web.Global.Format.DecimalSeparatorDecimal.charCodeAt(0)) {
                    if (input.val() == '') { return false; }
                    regexp = /^[0-9]+$/;
                    return regexp.test(input.val());
                }

                // other key
                return false;
            }
        },
        Integer: {
            blur: function () {
                Yanbal.SFT.Web.Components.TextBox.Function.FormatInteger({
                    input: $(this)
                });
            },
            paste: function (e) {
                return validarCopySoloNumerico(e);
            },
            keypress: function (evento) {

                var input = $(this);

                var selectedText = null;

                if (window.getSelection) // Firefox
                {
                    selectedText = input.val().substring(document.activeElement.selectionStart, document.activeElement.selectionEnd);
                }
                else // IE
                {
                    selectedText = document.selection.createRange().text;
                }

                if (selectedText != null && selectedText.length == input.val().length) {
                    input.val('');
                }

                var lengthNumber = input.attr('lengthNumber');

                if (input.val() != undefined && input.val().length == lengthNumber) {
                    return false;
                }

                return validateOnlyNumbers(evento);
            }
        }
    }
};
