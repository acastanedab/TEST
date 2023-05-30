/// <summary>
/// Script de Vista
/// </summary>
/// <remarks>
/// Creación: GMD 20140716 <br />
/// </remarks>
var subMenuActual = null;
var FormularioDetalle = null;
$(document).ready(function () {
    if (history.forward(1))
        location.reload();
    //'use strict';
    if (Yanbal.SFT.Presentation.Web.Global.Format.Language) {
        var cultura = Yanbal.SFT.Presentation.Web.Global.Format.Language.toString().toLowerCase();

        $.datepicker.setDefaults($.datepicker.regional[cultura]);
    }

    function moveMenu() {
        var $panelMenu = $('.u-module-nav'),
            $modulePanel = $('.u-module-panel');

        $('#toggle-menu').on('click', function (e) {
            e.preventDefault();
            var $el = $(this),
                $ulClosest = $(this).closest('ul').find('ul');

            var valorMenu = null;
            if (valorOpcionMenu == Yanbal.SFT.Presentation.Web.Enumerated.MenuDisplayForm.ExpandedForm) {
                var valorTemporal = $el.addClass('active');
                valorMenu = valorTemporal.hasClass('active');
            }
            else if (valorOpcionMenu == Yanbal.SFT.Presentation.Web.Enumerated.MenuDisplayForm.ContractedForm) {
                var valorTemporal = $el.removeClass('active');
                valorMenu = valorTemporal.hasClass('active');
            }
            else {
                valorMenu = $el.hasClass('active')
            }

            if (!valorMenu) {
                $el.addClass('active');
                $panelMenu
                .addClass('expanded')
                $modulePanel.addClass('expanded');
                valorOpcionMenu = null;
            } else {
                $el.removeClass('active');
                $panelMenu.removeClass('acenter expanded');
                $modulePanel.removeClass('expanded');

                var $btn = $('.btn-submenu');
                $btn.removeClass('active');
                $btn.closest('.w-submenu').removeClass('active');
                $btn.next('ul').hide();

                if (subMenuActual != null) {
                    subMenuActual.addClass('active');
                    subMenuActual.closest('.w-submenu').addClass('active');
                    subMenuActual.next('ul').show();
                    $('#' + Yanbal.SFT.Presentation.Web.Global.MenuCurrent.SubModule).focus();
                }

                valorOpcionMenu = null;
            }
            $("div[name = gridResult]").resize();
        });
    };

    moveMenu();
    function subMenu() {
        var $btn = $('.btn-submenu');

        $btn.on('click', function () {
            $el = $(this),
                  $currentMenu = $el.next('ul');
            $wrap = $el.closest('.w-submenu');

            if ($currentMenu.is(':hidden')) {
                if ($el.parent().parent().parent().parent().hasClass('expanded')) {
                    $("#toggle-menu").trigger("click");
                    if (!$el.hasClass('active')) {
                        if (subMenuActual != null) {
                            subMenuActual.removeClass('active');
                            subMenuActual.closest('.w-submenu').removeClass('active');
                            subMenuActual.next('ul').slideUp();
                        }

                        $el.addClass('active');
                        $wrap.addClass('active');
                        $currentMenu.slideDown(function () {
                            $('#' + Yanbal.SFT.Presentation.Web.Global.MenuCurrent.SubModule).focus();
                        });
                    } else {
                        $('#' + Yanbal.SFT.Presentation.Web.Global.MenuCurrent.SubModule).focus();
                    }
                } else {
                    if (subMenuActual != null) {
                        subMenuActual.removeClass('active');
                        subMenuActual.closest('.w-submenu').removeClass('active');
                        subMenuActual.next('ul').slideUp();
                    }
                    $el.addClass('active');
                    $wrap.addClass('active');
                    $currentMenu.slideDown(function () {
                        $('#' + Yanbal.SFT.Presentation.Web.Global.MenuCurrent.SubModule).focus();
                    });
                }
                subMenuActual = $el;
            }
            else {
                $el.removeClass('active');
                $wrap.removeClass('active');
                $currentMenu.slideUp();
                subMenuActual = null;
            }
        });
    }
    subMenu();

    function seleccionarMenuActual() {

        var modulo = Yanbal.SFT.Presentation.Web.Global.MenuCurrent.Module;
        var submenu = Yanbal.SFT.Presentation.Web.Global.MenuCurrent.SubModule;

        $('#' + modulo).addClass('active');
        $('#' + submenu).addClass('active');
        $('#' + modulo).find('.btn-submenu, .w-submenu').addClass('active');
        $('#' + modulo).find('.btn-submenu').next('ul').slideDown('fast', function () {
            $('#' + submenu).focus();
        });
        subMenuActual = $('#' + modulo).find('.btn-submenu');
    }

    $('.u-toggle').on('click', function (event) {
        event.preventDefault();
        $(this).parent().parent().next().toggle('fast');
    });

    $.validator.addMethod("Alfhanumeric", function (value, element) {
        return this.optional(element) || /^[\u00F1A-Za-z0-9\-.\s]+$/i.test(value);
    }, "");
    $.validator.addMethod("DateTime", function (value, element) {
        if (this.optional(element)) {
            return true;
        }
        var ok = true;
        if (value.length < 10)
            ok = false;
        try {
            var date = $.datepicker.parseDate(Yanbal.SFT.Presentation.Web.Global.Format.Date, value);
            ok = (date.getFullYear() >= 1900)
        }
        catch (err) {
            ok = false;
        }
        return ok;
    });

    var controles = $('.datepicker1');
    controles.bind("blur", function () {
        return ValidarFechaOnBlur(this);
    });

    Yanbal.SFT.Web.Components.TextBox.Function.Configure();

    seleccionarMenuActual();
    if (Yanbal.SFT.Presentation.Web.Global.MenuCurrent.Module != "") {
        valorOpcionMenu = Yanbal.SFT.Presentation.Web.Global.Policy.Menu.IndicatorDropdownMenu;
        $("#toggle-menu").trigger("click");
    }
});
