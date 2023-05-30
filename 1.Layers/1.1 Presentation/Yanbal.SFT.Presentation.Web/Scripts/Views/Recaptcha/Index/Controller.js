ns('Yanbal.SFT.Web.Security.Recaptcha.Index.Controller');
Yanbal.SFT.Web.Security.Recaptcha.Index.Controller = function () {
    var base = this;
    base.Ini = function (opts) {
        'use strict';
        base.Control.myLodading.hide();
        setTimeout(base.Event.Security, 3000);
    };

    base.Control = {
        Mensaje: new Yanbal.SFT.Web.Components.Message(),
        ApiToken: function () { return $("#g-recaptcha-response"); },
        BtnAceptarRecaptcha: function () { return $("#btn-reCaptcha"); },
        myLodading: new Yanbal.SFT.Web.Components.ProgressBar({ targetLoading: this.targetLoading })
    };

    base.Event = {
        Security: function () {
            var version = Yanbal.SFT.Web.Source.Security.Recaptcha.Keys.Version;
            if (version === '3') {
                base.Control.myLodading.show();
                var filter = {
                    token: base.Control.ApiToken().val(),
                    controllerName: Yanbal.SFT.Web.Source.Security.Recaptcha.Keys.ControllerName
                };
                RedirectPost(Yanbal.SFT.Web.Source.Security.Recaptcha.Actions.ValidarRecaptcha, filter);
                return;
            }

            if (version === '2') {
                base.Control.myLodading.show();
                base.Function.RenderRecaptchav2();
                base.Control.BtnAceptarRecaptcha().on('click', base.Function.BtnAceptarRecaptchaClick);
                document.getElementById("btn-reCaptcha").disabled = true;
                $("#rHidden").removeClass('hidden');
                $("#rHidden").addClass('show');
                base.Control.myLodading.hide();
                return;
            }
        },

        AjaxValidarRecaptchaSuccess: function (data) {
            if (data !== null) {

                if (data.version === '2') {
                    var message = $('#message-recaptcha');

                    if (!data.success) {
                        message.text(data.message);
                        message.css('text-danger');
                    }
                    else {
                        base.Control.Mensaje.divDialog.close();
                    }
                }

                if (data.version === '3') {
                    if (data.success === false || data.action !== base.Control.ActionRecaptcha || data.score < 0.5) {

                        base.Function.RenderRecaptchav2();
                        document.getElementById("btn-reCaptcha").disabled = true;
                        base.Control.BtnAceptarRecaptcha().on('click', base.Function.BtnAceptarRecaptchaClick);
                        return;
                    }
                    return;
                }
            }
            else {
                base.Control.Mensaje.Warning({ message: Yanbal.ASCX.Application.TransferObject.Messages.MessageResource.ErrorLog });
            }
        }
    };

    base.Ajax = {
        AjaxValidarRecaptcha: new Yanbal.SFT.Web.Components.Ajax({
            action: Yanbal.SFT.Web.Source.Security.Recaptcha.Actions.ValidarRecaptcha,
            autoSubmit: false,
            onSuccess: base.Event.AjaxValidarRecaptchaSuccess
        })
    };

    base.Function = {

        RenderRecaptchav2: function () {
            var siteKey = Yanbal.SFT.Web.Source.Security.Recaptcha.Keys.ClavePublica;
            grecaptcha.render('reCaptchaContainer', {
                'sitekey': siteKey,
                'callback': base.Function.ReCaptchaCallback,
                theme: 'light',
                type: 'image',
                size: 'normal'
            });
        },

        RenderRecaptchav3: function () {
            var siteKey = Yanbal.SFT.Web.Source.Security.Recaptcha.Keys.ClavePublica;

            grecaptcha.ready(function () {
                grecaptcha.execute(siteKey, { action: 'ValidarCredito' }).then(function (token) {
                    document.getElementById('g-recaptcha-response').value = token;
                });
            });
        },

        ReCaptchaCallback: function () {
            document.getElementById("btn-reCaptcha").disabled = false;
        },

        BtnAceptarRecaptchaClick: function () {

            var response = grecaptcha.getResponse();

            if (response.length === 0) {
                $('#message-recaptcha').text("Captcha no verificado");
            } else {
                base.Control.myLodading.hide();
                var filter = {
                    token: base.Control.ApiToken().val(),
                    controllerName: Yanbal.SFT.Web.Source.Security.Recaptcha.Keys.ControllerName
                };
                RedirectPost(Yanbal.SFT.Web.Source.Security.Recaptcha.Actions.ValidarRecaptchav2, filter);
            }
        }
    };
};