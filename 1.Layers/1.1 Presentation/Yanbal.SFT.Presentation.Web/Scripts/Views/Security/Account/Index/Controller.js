/// <summary>
/// Script de Controladora de la Vista de Ingreso al Sistema
/// </summary>
/// <remarks>
/// Creación: GMD 20140828 <br />
/// </remarks>
ns('Yanbal.SFT.Presentation.Web.Security.Account.Index.Controller');
Yanbal.SFT.Presentation.Web.Security.Account.Index.Controller = function () {
    var base = this;
    base.Ini = function (opts) {
        'use strict';
        base.Control.BtnLogOn().click(base.Event.BtnLogOnClick);
        base.Control.ParametersLogOn.TxtUser().keypress(base.Event.txtUserKeypress);
        base.Control.ParametersLogOn.TxtPassword().keypress(base.Event.txtPasswordKeypress);
        base.Control.Validator = new Yanbal.SFT.Web.Components.Validator({
            form: 'frmLogOn',
            messages: Yanbal.SFT.Web.LogOn.Mensaje.Resources
        });

    };

    base.Parameters = {

    };

    base.Control = {
        Validator: null,
        Modal: null,
        Message: new Yanbal.SFT.Web.Components.Message(),
        FormularioIngresoSistema: null,
        BtnLogOn: function () { return $('#btnLogOn'); },
        ParametersLogOn: {
            TxtUser: function () { return $('#txtUser'); },
            TxtPassword: function () { return $('#txtPassword'); }
        }
    };
    base.Event = {
        txtUserKeypress: function (e) {
            var key = e.keyCode || e.which;
            if (key == 13) {
                base.Event.BtnLogOnClick();
            }
        },

        txtPasswordKeypress: function (e) {
            var key = e.keyCode || e.which;
            if (key == 13) {
                base.Event.BtnLogOnClick();
            }
        },

        BtnLogOnClick: function () {
            if (base.Function.ValidateRegister()) {
                var clavePublicaCaptcha = Yanbal.SFT.Web.LogOn.Models.ClavePublica;
                var response = clavePublicaCaptcha == "" ? "" : grecaptcha.getResponse();
                base.Ajax.AjaxLogOn.data = {
                    token: response,
                    User: base.Control.ParametersLogOn.TxtUser().val(),
                    Password: base.Control.ParametersLogOn.TxtPassword().val()
                };
                base.Ajax.AjaxLogOn.submit();
            }
        },

        AjaxLogOnSuccess: function (data) {
            if (data != null && data.CodeError == 1) {
                if (data.CodeError == 1) {
                    window.location.href = Yanbal.SFT.Web.LogOn.Actions.Route;
                }
            }
            else if (data != null && data.CodeError == -5) {
                base.Control.Message.Warning({ message: Yanbal.SFT.FreightManagement.Common.Messages.MessageResource.ErrorPass });
            }
            else {
                base.Control.Message.Warning({ message: Yanbal.SFT.FreightManagement.Common.Messages.MessageResource.ErrorLog });
            }
            var it = 0;
        }
    };

    base.Ajax = {
        AjaxLogOn: new Yanbal.SFT.Web.Components.Ajax({
            action: Yanbal.SFT.Web.LogOn.Actions.LogOn,
            autoSubmit: false,
            onSuccess: base.Event.AjaxLogOnSuccess
        }),
    };

    base.Function = {
        ValidateRegister: function () {
            var isValid = true;
            var clavePublicaCaptcha = Yanbal.SFT.Web.LogOn.Models.ClavePublica;
            var token = clavePublicaCaptcha == "" ? "" : grecaptcha.getResponse();
            var txtUser = base.Control.ParametersLogOn.TxtUser().val();
            var txtPassword = base.Control.ParametersLogOn.TxtPassword().val();

            if (token == "" && clavePublicaCaptcha != "") {
                isValid = false,
                base.Control.Message.Warning({
                    message: Yanbal.SFT.Web.LogOn.Mensaje.Resources.VerificacionCaptcha
                });
            }
            else if (txtUser == "") {
                isValid = false,
                base.Control.Message.Warning({
                    message: Yanbal.SFT.Web.LogOn.Mensaje.Resources.EmptyUser
                });
            }
            else {
                if (txtPassword == "") {
                    isValid = false,
                    base.Control.Message.Warning({
                        message: Yanbal.SFT.Web.LogOn.Mensaje.Resources.EmptyPassword
                    });
                }
                else {
                    isValid = true;
                }
            }

            return isValid;
        },

        AplicarBinding: function (model, contenedor) {
            var isValid = (typeof model !== 'undefined');

            if (isValid) {
                var contenedorDom = (contenedor) ? contenedor[0] : contenedor;
                isValid = (model.Error.Code == 0);
                if (isValid) {
                    ko.applyBindings(model, contenedorDom);
                } else {
                    base.Control.Mensaje.Warning({ message: model.Error.Message });
                }

            } else {
                base.Control.Mensaje.Warning({ message: Yanbal.SFT.Presentation.Web.Shared.Message.LoadErrorViewModel });
            }
            return isValid;
        }
    };
};