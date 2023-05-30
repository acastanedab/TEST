/// <summary>
/// Script de Controladora de la Vista de Index
/// </summary>
/// <remarks>
/// Creación: 	GMD 20140922 <br />
/// </remarks>
ns('Yanbal.SFT.Presentation.Web.Policy.Culture.Index');
Yanbal.SFT.Presentation.Web.Policy.Culture.Index.Controller = function () {
    var base = this;
    base.Ini = function () {
        'use strict';

        base.Control.ModalCreate = new Yanbal.SFT.Web.Components.Dialog({
            autoOpen: false,
            maxHeight: 750,
            width: 800,
            modal: true
        });

        base.Control.ModalEdit = new Yanbal.SFT.Web.Components.Dialog({
            autoOpen: false,
            maxHeight: 750,
            width: 800,
            modal: true
        });

        base.Control.FiltersSearch.TxtCultureCode().mask("SS-SS");
        base.Control.FiltersSearch.TxtCultureCode().keypress(base.Event.EventCodeKeyPress);

        if (base.Function.ApplyBinding(Yanbal.SFT.Presentation.Web.Policy.Culture.Models.Index)) {
            base.Control.BtnSearch().click(base.Event.BtnSearchClick);
            base.Control.BtnCreate().click(base.Event.BtnCreateClick);
            base.Function.GenerateGrid(Yanbal.SFT.Presentation.Web.Policy.Culture.Models.Index);
            base.Control.DivResultSearch().fadeIn();
            base.Event.BtnSearchClick();
        };
    };

    base.Parameters = {
        SelectedForm: {
            SelectedRecord: null
        },
        Search: null
    };

    base.Control = {
        ModalCreate: null,
        ModalEdit: null,
        Message: new Yanbal.SFT.Web.Components.Message(),
        CreationForm: null,
        EditionForm: null,
        GridResult: null,
        FormFilterSearch: function () { return $('#frmCultureIndex'); },
        DivResultSearch: function () { return $('#divSearchResult'); },
        BtnSearch: function () { return $('#btnSearch'); },
        BtnCreate: function () { return $('#btnCreate'); },
        FiltersSearch: {
            TxtCultureCode: function () { return $('#txtSearchCultureCode'); },
            TxtLanguage: function () { return $('#slcSearchLanguage'); },
            TxtCountry: function () { return $('#slcSearchCountry'); },
            TxtRegistrationStatus: function () { return $('#slcSearchRegistrationStatus'); }
        }
    };

    base.Event = {
        EventCodeKeyPress: function (event) {
            var key = getKeyCode(event);
            var isValid = !(event && key == 13);
            if (isValid == false) {
                base.Event.BtnSearchClick();
            }
            return isValid;
        },

        BtnSearchClick: function () {
            base.Parameters.Search = {
                CultureCode: base.Control.FiltersSearch.TxtCultureCode().val(),
                LanguageCode: base.Control.FiltersSearch.TxtLanguage().val(),
                CountryCode: base.Control.FiltersSearch.TxtCountry().val(),
                RegistrationStatus: base.Control.FiltersSearch.TxtRegistrationStatus().val()
            };

            base.Function.ExecuteQuery();
        },

        BtnCreateClick: function () {
            base.Control.ModalCreate.getAjaxContent({
                data: {
                    CountryCode: base.Control.FiltersSearch.TxtCountry().val(),
                    LanguageCode: base.Control.FiltersSearch.TxtLanguage().val()
                },
                action: Yanbal.SFT.Presentation.Web.Policy.Culture.Actions.Create,
                onSuccess: base.Event.ModalCreateSuccess,
            });
        },

        BtnEditClick: function (e, args) {
            var button = $(e.target);
            var item = base.Control.GridResult.getDataView().getItem(args.row);
            if (button.hasClass(Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.Edit.id)) {
                var columns = base.Control.GridResult.getView().getColumns();
                var selectedColumn = columns[args.cell];
                var selectedRegistration = base.Control.GridResult.getDataView().getItem(args.row);
                if (selectedColumn.id == "Edit") {
                    base.Control.ModalEdit.getAjaxContent({
                        data: {
                            CultureCode: selectedRegistration.CultureCode
                        },
                        action: Yanbal.SFT.Presentation.Web.Policy.Culture.Actions.Edit,
                        onSuccess: base.Event.ModalEditSuccess
                    });
                }
            }

            e.stopImmediatePropagation();
        },

        ModalCreateSuccess: function (data) {
            base.Control.CreationForm = new Yanbal.SFT.Presentation.Web.Policy.Culture.Create.Controller();
            base.Control.CreationForm.Ini({
                Container: base.Control.ModalCreate,
                AjaxCreateSuccessCustom: base.Event.DialogAjaxSuccess
            });
        },

        ModalEditSuccess: function (data) {
            base.Control.EditionForm = new Yanbal.SFT.Presentation.Web.Policy.Culture.Edit.Controller();
            base.Control.EditionForm.Ini({
                Container: base.Control.ModalEdit,
                AjaxEditSuccessCustom: base.Event.DialogAjaxSuccess
            });
        },

        DialogAjaxSuccess: function (data) {
            base.Event.BtnSearchClick();
        },

        AjaxSearchSuccess: function (data) {
            if (data != null) {
                base.Function.GenerateGrid(Yanbal.SFT.Presentation.Web.Policy.Culture.Models.Index);
                base.Control.GridResult.setData(data);
            }
        }
    };

    base.Ajax = {
        AjaxBuscar: new Yanbal.SFT.Web.Components.Ajax({
            action: Yanbal.SFT.Presentation.Web.Policy.Culture.Actions.Search,
            autoSubmit: false,
            onSuccess: base.Event.AjaxSearchSuccess
        })
    };

    base.Function = {
        validateCultureFormat: function (field, event) {
            var culture = field.value;
            var charCode = (event.charCode) ? event.charCode : ((event.keyCode) ? event.keyCode
			: ((event.which) ? event.which : 0));
            var lastCharacter = String.fromCharCode(charCode);
            if (charCode == 8 || charCode == 9 || charCode == 35 || charCode == 36 || charCode == 37 || charCode == 38 || charCode == 39 || charCode == 40) {
                return true;
            }
            else {
                if (culture.length < 5) {

                    if (validteOnlyLetters(event)) {
                        if (culture.length < 2) {
                            var finalCulture = culture + lastCharacter;
                            if (finalCulture.length < 3) {
                                if (finalCulture.length == 2) finalCulture = finalCulture + '-';
                                culture = finalCulture;
                            }
                        } else {
                            var finalCulture = culture + lastCharacter;
                            culture = finalCulture;
                        }
                    }
                }
            }

            field.value = culture;
            return false;
        },

        ApplyBinding: function (model, container) {
            var isValid = (typeof model !== 'undefined');
            if (isValid) {
                var containerDom = (container) ? container[0] : container;
                isValid = (model.Error.Code == 0);
                if (isValid) {
                    ko.applyBindings(model, containerDom);
                } else {
                    base.Control.Mensaje.Warning({ message: model.Error.Message });
                }

            } else {
                base.Control.Mensaje.Warning({ message: Yanbal.SFT.Presentation.Web.Shared.Resources.ErrorCargarViewModel });
            }

            return isValid;
        },

        ExecuteQuery: function () {
            base.Function.GenerateGrid(Yanbal.SFT.Presentation.Web.Policy.Culture.Models.Index);
            base.Control.GridResult.load();
        },

        GenerateGrid: function (model) {
            if (base.Control.GridResult != null) {
                base.Control.GridResult.destroy();
            }

            var columns = new Array();
            columns.push({
                id: 'Edit', name: '', field: 'CultureCode', width: 50, cssClass: 'center u-actions',
                Formater: function (row, cell, value, columnDef, dataContext) {
                    var string = '';
                    string += Yanbal.SFT.Presentation.Web.Global.Grid.Buttons.ValidateSecurity(Yanbal.SFT.Presentation.Web.Global.Grid.Action.Modificar, model.Edit);
                    return string;
                }
            });

            columns.push({ id: 'CultureCode', name: Yanbal.SFT.Presentation.Web.Policy.Culture.Resources.LabelGridCultureCode, field: 'CultureCode', width: 70, cssClass: 'center u-actions' });
            columns.push({ id: 'Language', name: Yanbal.SFT.Presentation.Web.Policy.Culture.Resources.LabelGridLanguage, field: 'LanguageName', width: 100 });
            columns.push({ id: 'Country', name: Yanbal.SFT.Presentation.Web.Policy.Culture.Resources.LabelGridCountry, field: 'CountryName', width: 90 });
            columns.push({ id: 'ShortDateFormat', name: Yanbal.SFT.Presentation.Web.Policy.Culture.Resources.LabelGridShortDateFormat, field: 'DescriptionShortDateFormat', width: 100 });
            columns.push({ id: 'LongDateFormat', name: Yanbal.SFT.Presentation.Web.Policy.Culture.Resources.LabelGridLongDateFormat, field: 'DescriptionLongDateFormat', width: 160 });
            columns.push({ id: 'RangeForTwoDigitYears', name: Yanbal.SFT.Presentation.Web.Policy.Culture.Resources.LabelGridRangeForTwoDigitYears, field: 'RangeLimitConcatenatedYear', width: 120, cssClass: 'center' });
            columns.push({ id: 'ShortTimeFormat', name: Yanbal.SFT.Presentation.Web.Policy.Culture.Resources.LabelGridShortTimeFormat, field: 'DescriptionShortTimeFormat', width: 100 });
            columns.push({ id: 'LongTimeFormat', name: Yanbal.SFT.Presentation.Web.Policy.Culture.Resources.LabelGridLongTimeFormat, field: 'DescriptionLongTimeFormat', width: 100 });
            columns.push({ id: 'CodeFormatIntegerNumber', name: Yanbal.SFT.Presentation.Web.Policy.Culture.Resources.LabelGridFormatIntegerNumbers, field: 'DescriptionFormatIntegerNumber', width: 130, cssClass: 'center' });
            columns.push({ id: 'CodeFormatDecimalNumber', name: Yanbal.SFT.Presentation.Web.Policy.Culture.Resources.LabelGridFormatDecimalNumbers, field: 'DescriptionFormatDecimalNumber', width: 130, cssClass: 'center' });
            columns.push({ id: 'RegistrationStatus', name: Yanbal.SFT.Presentation.Web.Policy.Culture.Resources.LabelGridRegistrationStatus, field: 'DescriptionRegistrationStatus', width: 80, cssClass: 'center' });

            base.Control.GridResult = new Yanbal.SFT.Web.Components.Grid({
                renderTo: 'grdResult',
                isPager: true,
                isServerPaging: true,
                proxy: {
                    action: Yanbal.SFT.Presentation.Web.Policy.Culture.Actions.Search,
                    data: base.Parameters.Search
                },
                columns: columns,
                //forceFitColumns: true,
                width: '100%'
            });

            base.Control.GridResult.getView().onClick.subscribe(base.Event.BtnEditClick);
        }
    };
};