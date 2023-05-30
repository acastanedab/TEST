/// <summary>
/// Controlador de progreso de carga o peticiones
/// </summary>
/// <remarks>
/// Creacion: 	EDGAR MELGAREJO 20140226 <br />
/// </remarks>
ns('Yanbal.SFT.Web.Components');
Yanbal.SFT.Web.Components.ProgressBar = function (opts) {
    this.init(opts);
};

Yanbal.SFT.Web.Components.ProgressBar.prototype = {
    idDivProgrees: 'divProgressSFT_GMD',
    idDivDialog: 'divProgressDialogSFT_GMD',
    init: function (opts) {
        this._privateFunction.createProgressBar.apply(this, [opts]);
    },
    setMaxValue: function (max) {
        if (this.divProgress) {
            this.divProgress.progressbar('option', 'max', max);
        }
    },
    setValue: function (value) {
        if (this.divProgress) {
            this.divProgress.progressbar('option', 'value', value);
        }
    },
    getValue: function () {
        var value = null;
        if (this.divProgress) {
            value = this.divProgress.progressbar('option', 'value');
        }
        return value;
    },
    show: function () {
        if (this.divDialog) {
            this.divDialog.dialog('open');
        }
        else {
            if (this.divProgress) {
                this.divProgress.show();
            }
        }
    },
    hide: function () {
        if (this.divDialog) {
            this.divDialog.dialog('close');
        }
        else {
            if (this.divProgress) {
                this.divProgress.hide();
            }
        }
    },
    destroy: function () {
        if (this.divProgress) {
            this.divProgress.progressbar('destroy');
            this.divProgress.remove();
        }
        if (this.divDialog) {
            this.divDialog.dialog('destroy');
            this.divDialog.remove();
        }
    },
    _privateFunction: {
        createProgressBar: function (opts) {
            if (!opts.targetLoading) {
                this.divDialog = this._privateFunction.implementDialogElement.apply(this, [opts]);
                opts.targetLoading = this.divDialog;
            }
            else {
                opts.targetLoading = $('#' + opts.targetLoading);
            }
            this.divProgress = this._privateFunction.implementProgressElement.apply(this, [opts.targetLoading, opts.maxValue]);
        },
        implementProgressElement: function (targetLoading, maxValue) {
            var divProgress = $('#' + this.idDivProgrees);
            if (divProgress.length == 0) {
                divProgress = $('<div />');
                divProgress.attr('id', this.idDivProgrees);
                divProgress.addClass("progressBar-SFT");
                divProgress.append($('<div class="progressBar-SFT-label"></div>'));
                if (Yanbal.SFT.Web.Shared.General.Resources) {
                    divProgress.find('.progressBar-SFT-label').text(Yanbal.SFT.Presentation.Web.Shared.Resources.LabelLoading);
                }
                targetLoading.append(divProgress);
            }
            if (targetLoading) {
                divProgress.css('position', 'relative');
                divProgress.css('top', '0px');
                divProgress.css('left', '0px');
            }
            var me = this;
            var config = {
                value: maxValue ? 0 : false,
                change: function () {
                    if (me.getValue() != false) {
                        divProgress.find('.progressBar-SFT-label').text(me.getValue() + "%");
                    }
                }
            };
            if (maxValue) {
                config.max = maxValue;
            }
            divProgress.progressbar(config);
            return divProgress;
        },
        implementDialogElement: function (opts) {
            var div = $('#' + this.idDivDialog);
            if (div.length == 0) {
                div = $('<div />');
                div.attr('id', this.idDivDialog);
                $('body').append(div);
            }
            div.dialog({
                dialogClass: "no-close-dialog",
                closeOnEscape: false,
                height: 100,
                width: 220,
                modal: opts.modal ? opts.modal : true,
                resizable: false,
                title: 'Loading...'
            });
            return div;
        }
    }
};
