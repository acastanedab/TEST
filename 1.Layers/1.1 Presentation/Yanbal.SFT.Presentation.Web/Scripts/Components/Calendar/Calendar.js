/// <summary>
/// Controlador de progreso de carga o peticiones
/// </summary>
/// <remarks>
/// Creacion: 	EDGAR MELGAREJO 20140707 <br />
/// </remarks>
ns('Yanbal.SFT.Web.Components');
Yanbal.SFT.Web.Components.Calendar = function (opts) {
    this.init(opts);
};

Yanbal.SFT.Web.Components.Calendar.prototype = {

    inputFrom: null,
    inputTo: null,

    init: function (opts) {
        this.inputFrom = opts.inputFrom ? opts.inputFrom : null;
        this.inputTo = opts.inputTo ? opts.inputTo : null;
        this.destroy();
        var me = this;
        //this._privateFunction

        if (this.inputFrom && this.inputFrom != null) {
            var configFrom = {
                dateFormat: Yanbal.SFT.Presentation.Web.Global.Format.Date,
                onClose: function (selected) {
                    var result = ValidarFechaOnBlur(this);
                    if (me.inputTo && me.inputTo != null) {
                        if (result) {
                            me.inputTo.datepicker('option', 'minDate', selected);
                        }
                        else {
                             me.inputTo.datepicker('option', 'minDate', null);
                        }
                    }
                }
            };
            if (opts.maxDateFrom && opts.maxDateFrom != null) {
                configFrom.maxDate = opts.maxDateFrom;
            }
            if (opts.minDateFrom && opts.minDateFrom != null) {
                configFrom.minDate = opts.minDateFrom;
            }
            this.inputFrom.datepicker(configFrom);
        }

        if (this.inputTo && this.inputTo != null) {
            var configTo = {                
                dateFormat: Yanbal.SFT.Presentation.Web.Global.Format.Date,
                onClose: function (selected) {
                    var result = ValidarFechaOnBlur(this);
                    if (me.inputFrom && me.inputFrom != null) {
                        if (result) {
                            me.inputFrom.datepicker('option', 'maxDate', selected);
                        }
                        else {
                            me.inputFrom.datepicker('option', 'maxDate', null);
                        }
                    }
                }
            };
            if (opts.maxDateTo && opts.maxDateTo != null) {
                configTo.maxDate = opts.maxDateTo;
            } 
            this.inputTo.datepicker(configTo);
        }

    },

    destroy: function () {
        if (this.inputFrom) {
            this.inputFrom.datepicker("destroy");
        }
        if (this.inputTo) {
            this.inputTo.datepicker("destroy");
        }
    },

    _privateFunction: {
        createDatePicker: function (input, reference) {
            if (input && input != null) {
                input.datepicker({
                    dateFormat: Yanbal.SFT.Presentation.Web.Global.Format.Date,
                    onClose: function (selected) {
                        if (reference && reference != null) {
                            reference.datepicker('option', 'minDate', selected);
                        }
                    }
                });
            }
        }
    }
};
