/// <summary>
/// Libreria para la creacion de grillas
/// </summary>
/// <remarks>
/// Creacion:  Jose Luis Ramirez Rivera 20120523 <br />
/// </remarks>
ns('Yanbal.SFT.Web.Components');
Yanbal.SFT.Web.Components.Grid = function (opts) {
    this.init(opts);
};

Yanbal.SFT.Web.Components.Grid.prototype = {
    identity: null,
    slickGrid: null,
    columns: null,
    dataView: null,
    showHeaderRow: null,
    explicitInitialization: null,
    renderTo: null,
    editable: null,
    enableAddRow: null,
    enableCellNavigation: null,
    autoEdit: null,

    divGrid: null,
    divPager: null,

    checkboxSelector: null,
    pager: null,
    isPager: null,
    isPagerauto: null,
    isPagerpageSize: null,
    isCheckboxSelector: null,
    isRadioButtonSelector: null,

    isServerPaging: null,
    serverProxy: null,
    autoHeight: null,
    forceFitColumns: null,

    inlineFilters: null,

    selectActiveRow: null,

    defaultHeight: 460,
    defaultWidth: '100%',

    width: null,
    minWidth: null,
    height: null,
    minHeight: null,
    headerRowHeight: null,
    applyTooltip: null,
    showHeaderCheckBox: null,

    groupItemMetadataProvider: null,
    onLoad: null,
    onBeforeLoad: null,
    onToggleCheckboxRowSelection: null,
    tempDataSelected: null,
    isGetAll: false,

    init: function (opts) {
        if (opts) {
            this.renderTo = '#' + opts.renderTo;
            this.divGrid = $(this.renderTo);
            this.width = opts.width ? opts.width : null;
            this.height = opts.height ? opts.height : null;

            this.defaultHeight = opts.defaultHeight ? opts.defaultHeight : 460;

            this.applyTooltip = opts.applyTooltip && opts.applyTooltip != null ? opts.applyTooltip : true;

            this.isPager = opts.isPager && opts.isPager != null ? opts.isPager : false;
            //this.isPagerauto = opts.isPagerauto && opts.isPagerauto != null ? opts.isPagerauto : '15';
            this.isPagerpageSize = opts.isPagerpageSize && opts.isPagerpageSize != null ? opts.isPagerpageSize : Yanbal.SFT.Presentation.Web.Global.Grid.Options.PagerpageSize;
            this.isCheckboxSelector = opts.isCheckboxSelector && opts.isCheckboxSelector != null ? opts.isCheckboxSelector : false;

            this.isRadioButtonSelector = opts.isRadioButtonSelector && opts.isRadioButtonSelector != null ? opts.isRadioButtonSelector : false;


            this.isServerPaging = opts.isServerPaging && opts.isServerPaging != null ? opts.isServerPaging : false;
            this.editable = opts.editable ? opts.editable : true;

            this.enableAddRow = opts.enableAddRow ? opts.enableAddRow : false;
            this.enableCellNavigation = opts.onError ? opts.onError : true;
            this.autoEdit = opts.autoEdit ? opts.autoEdit : true;
            this.autoHeight = (opts.autoHeight != undefined && opts.autoHeight != null) ? opts.autoHeight : true;
            this.forceFitColumns = opts.forceFitColumns ? opts.forceFitColumns : false;

            this.inlineFilters = opts.inlineFilters ? opts.inlineFilters : false;

            this.selectActiveRow = opts.selectActiveRow ? opts.selectActiveRow : false;

            this.groupItemMetadataProvider = opts.groupItemMetadataProvider ? opts.groupItemMetadataProvider : null;

            this.headerRowHeight = opts.headerRowHeight ? opts.headerRowHeight : 30;
            this.showHeaderRow = opts.showHeaderRow ? opts.showHeaderRow : false;
            this.showHeaderCheckBox = opts.showHeaderCheckBox != null && opts.showHeaderCheckBox != undefined ? opts.showHeaderCheckBox : true;
            this.explicitInitialization = opts.explicitInitialization ? opts.explicitInitialization : false;
            this.columns = opts.columns;
            this.onLoad = opts.onLoad ? opts.onLoad : null;
            this.onBeforeLoad = opts.onBeforeLoad ? opts.onBeforeLoad : null;
            this.onToggleCheckboxRowSelection = opts.onToggleCheckboxRowSelection ? opts.onToggleCheckboxRowSelection : null;
            if (opts.proxy) {
                this.setServerProxy(opts.proxy);
            }
            this.tempDataSelected = new Array();
        }
        this.formatGrid();
        this.createGrid();

    },
    getView: function () {
        return this.slickGrid;
    },

    getDataView: function () {
        return this.slickGrid.getData();
    },
    getColumns: function () {
        return this.slickGrid.getColumns();
    },
    createGrid: function () {

        this.createDataView();

        this.createSelector();

        this.slickGrid = new Slick.Grid(this.renderTo, this.dataView, this.columns, {
            editable: this.editable,
            enableAddRow: this.enableAddRow,
            enableCellNavigation: this.enableCellNavigation,
            autoEdit: this.autoEdit,
            autoHeight: this.autoHeight,
            forceFitColumns: this.forceFitColumns,
            enableColumnReorder: (!this.forceFitColumns),
            headerRowHeight: this.headerRowHeight,
            showHeaderRow: this.showHeaderRow,
            explicitInitialization: this.explicitInitialization,
            enableTextSelectionOnCells: true
        });
        this.slickGrid.getCanvas().css('min-height', '25px');

        if (this.forceFitColumns) {
            this.slickGrid.getViewportSelector().css('overflow-x', 'hidden');
            this.divGrid.resize(function () {
                //me.slickGrid.resizeCanvas();
            });
        }
        this.createRowSelectionModel();

        this.createPager(this.isPagerauto, this.isPagerpageSize);

        this.registerPlugin();

        this.implementsEvent();

        var me = this;


        //this.setData([]);
        if ($.browser.msie) {
            var me = this;
            $(window).scroll(function () {
                var actual = me.slickGrid.getViewportSelector().scrollLeft();
                me.slickGrid.getViewportSelector().scrollLeft((actual == 0 ? (actual + 1) : (actual - 1)));
                me.slickGrid.getViewportSelector().scrollLeft(actual);
            });
        }
        this.implementsToolTip();
    },
    implementsToolTip: function () {
        if (this.applyTooltip) {
            this.divGrid.tooltip({
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
    },
    implementsEvent: function () {
        var me = this;

        if (this.enableAddRow == true) {
            this.slickGrid.onAddNewRow.subscribe(function (e, args) {
                args.item.id = me.identity;
                me.getDataView().addItem(args.item);
                me.identity++;
            });
        }
    },
    createDataView: function () {
        var me = this;

        this.dataView = new Slick.Data.DataView({ inlineFilters: this.inlineFilters, groupItemMetadataProvider: this.groupItemMetadataProvider });
        this.dataView.onRowCountChanged.subscribe(function (e, args) {
            me.slickGrid.updateRowCount();
            me.slickGrid.render();
        });
        this.dataView.onRowsChanged.subscribe(function (e, args) {
            me.slickGrid.invalidateRows(args.rows);
            me.slickGrid.render();
        });
    },
    createRowSelectionModel: function () {
        this.slickGrid.setSelectionModel(new Slick.RowSelectionModel({ selectActiveRow: this.selectActiveRow }));
    },
    createSelector: function () {
        var me = this;
        if (this.isCheckboxSelector) {
            this.checkboxSelector = new Slick.CheckboxSelectColumn({
                cssClass: 'slick-cell-checkboxsel',
                toolTip: Yanbal.SFT.Presentation.Web.Shared.Resources.LabelSelectDeselectAll,
                showHeaderCheckBox: this.showHeaderCheckBox,
                onToggleRowSelection: function (rowId, isChecked) {
                    var objeto = me.slickGrid.getData().getItemById(rowId);
                    if (!isChecked) {
                        me.tempDataSelected = $.grep(me.tempDataSelected, function (value, index) {
                            return value.RowId != objeto.RowId;
                        });
                    }
                    if (me.onToggleCheckboxRowSelection && me.onToggleCheckboxRowSelection != null) {
                        me.onToggleCheckboxRowSelection([objeto], isChecked);
                    }
                },
                onHeaderClick: function (selectedAll) {
                    if (selectedAll) {
                        if (me.getPageInfo().totalRows > 0) {
                            me.closeToolTip();
                            me.load(true);
                            me.implementsToolTip();
                        }
                    }
                    else {
                        if (me.onToggleCheckboxRowSelection && me.onToggleCheckboxRowSelection != null) {
                            me.onToggleCheckboxRowSelection(me.tempDataSelected, false);
                        }
                        me.tempDataSelected = new Array();
                    }
                }
            });
            this.columns.splice(0, 0, this.checkboxSelector.getColumnDefinition());
        } else if (this.isRadioButtonSelector) {
            this.checkboxSelector = new Slick.RadioSelectColumn({
                cssClass: 'slick-cell-checkboxsel',
                toolTip: '',
                onToggleRowSelection: function (rowId, isChecked) {
                    if (isChecked) {
                        var objeto = me.slickGrid.getData().getItemById(rowId);
                        me.tempDataSelected = new Array();
                        me.tempDataSelected.push(objeto);
                    }
                }
            });
            this.columns.splice(0, 0, this.checkboxSelector.getColumnDefinition());
        }
    },
    createPager: function (auto, pageSize) {
        if (this.isPager) {
            var idPager = this.divGrid.attr('id') + 'Pager';
            if ($('#' + idPager).length > 0) {
                $('#' + idPager).remove();
            }
            this.divPager = $('<div />');
            this.divPager.attr('id', idPager);
            this.divPager.css('width', this.width);
            //this.divPager.attr('pageauto', auto);//js
            this.divGrid.after(this.divPager);
            var me = this;
            this.pager = new Slick.Controls.Pager(this.dataView, this.slickGrid, this.divPager,
                {
                    defaultPageSize: pageSize,
                    onPageChange: function (serverPageInfo) {

                        if (!me.tempDataSelected) {
                            me.tempDataSelected = new Array();
                        }
                        if (me.isRadioButtonSelector) {
                            if (me.getSelectionData().length > 1) {
                                $.each(me.getSelectionData(), function (index, value) {
                                    var valido = true;
                                    $.each(me.tempDataSelected, function (indexT, temp) {
                                        if (value.RowId == temp.RowId) {
                                            valido = false;
                                            return valido;
                                        }
                                    });
                                    if (valido) {
                                        me.tempDataSelected = new Array();
                                        me.tempDataSelected.push(value);
                                        return false;
                                    }
                                });
                            } else {
                                me.tempDataSelected = me.getSelectionData();
                            }

                        }
                        else if (me.isCheckboxSelector) {
                            $.each(me.getSelectionData(), function (index, value) {
                                var valido = true;
                                $.each(me.tempDataSelected, function (indexT, temp) {
                                    if (value.RowId == temp.RowId) {
                                        valido = false;
                                        return valido;
                                    }
                                });
                                if (valido) {
                                    me.tempDataSelected.push(value);
                                }
                            });
                        }

                        me.load();

                        if (me.onPageChange) {
                            me.onPageChange();
                        }
                    },
                    isServerPaging: this.isServerPaging
                });
        }
    },
    formatGrid: function () {

        this.divGrid.css('background-color', 'white');
        this.divGrid.css('margin-bottom', '10px');

        if (this.width != null) {
            this.divGrid.css('width', this.width);
        } else {
            this.divGrid.css('width', this.defaultWidth);
        }

        if (this.height != null) {
            this.autoHeight = false;
            this.divGrid.height(this.height);
        } else {
            if (this.autoHeight == false) {
                this.divGrid.height(this.defaultHeight);
            }
        }

    },
    registerPlugin: function () {
        if (this.isCheckboxSelector || this.isRadioButtonSelector) {
            this.slickGrid.registerPlugin(this.checkboxSelector);
        }
        if (this.groupItemMetadataProvider != null) {
            this.slickGrid.registerPlugin(this.groupItemMetadataProvider);
        }
    },
    setData: function (data) {
        $.each(data, function (index, value) {
            value.id = index;
        });

        this.slickGrid.getData().beginUpdate();
        this.slickGrid.getData().setItems(data);
        this.slickGrid.getData().endUpdate();

        if (this.isServerPaging == true) {
            this.slickGrid.invalidate();
        }

        if (this.isPager == true && this.isServerPaging != true) {
            this.pager.updateSizePage();
        }

        if (data.length == 0) {
            this.slickGrid.getCanvas().html('<div style="text-align:left;font-style:italic;padding-left:10px">' + Yanbal.SFT.Presentation.Web.Shared.Resources.LabelSearchResultsBlank + '</div>');
        }

        this.implementsToolTip();
        this.configureAutoHeight();
        this.identity = data.length;

    },

    configureAutoHeight: function () {
        var countHeight = this.getDataView().getItems().length * this.getView().getOptions().rowHeight;
        if (this.autoHeight == true) {
            if (countHeight > this.defaultHeight) {
                this.divGrid.height(this.defaultHeight + 2);
                this.slickGrid.setOptions({
                    autoHeight: false
                });
                this.slickGrid.resizeCanvas();
            }
            else {
                this.slickGrid.setOptions({
                    autoHeight: true
                });
                this.divGrid.css('height', 'auto');
                this.slickGrid.getViewportSelector().css('height', 'auto');
                this.slickGrid.resizeCanvas();

            }

        }
    },
    //JGR
    setFilter: function (filter) {
        this.dataView.setFilter(filter);
    },
    addItem: function (item) {
        this.slickGrid.getData().beginUpdate();
        this.slickGrid.getData().addItem(item);
        //this.slickGrid.setSelectedRows([]);
        this.slickGrid.getData().endUpdate();
    },
    getSelectionData: function () {
        var selectedIndexes = this.slickGrid.getSelectedRows();
        var selectedData = new Array();
        var me = this;

        $.each(selectedIndexes, function (index, value) {
            var objeto = me.slickGrid.getData().getItemById(value);
            //var objeto = me.slickGrid.getData().getItem(value);
            selectedData.push(objeto);
        });

        $.each(me.tempDataSelected, function (index, value) {
            var valido = true;
            $.each(selectedData, function (indexT, temp) {
                if (value.RowId == temp.RowId) {
                    valido = false;
                    return valido;
                }
            });
            if (valido) {
                selectedData.push(value);
            }
        });

        return selectedData;
    },
    getSelectionDataFilter: function () {
        var selectedIndexes = this.slickGrid.getSelectedRows();
        var selectedData = new Array();
        var me = this;

        $.each(selectedIndexes, function (index, value) {
            //var objeto = me.slickGrid.getData().getItemById(value);
            var objeto = me.slickGrid.getData().getItem(value);
            selectedData.push(objeto);
        });

        return selectedData;
    },
    getSelectedRows: function () {
        return this.slickGrid.getSelectedRows();
    },
    setSelectedRows: function (arrayIndex) {
        this.slickGrid.setSelectedRows(arrayIndex);
    },
    setSelectedAll: function () {
        if (this.isServerPaging == true) {
            this.load(true);
        }
        var data = this.getDataView().getItems();
        var selectedData = new Array();
        $.each(data, function (index, value) {
            selectedData.push(value.id);
        });

        this.slickGrid.setSelectedRows(selectedData);
    },
    //EMP
    setServerProxy: function (proxy) {
        if (proxy) {
            if (this.serverProxy == null) {
                this.serverProxy = {
                    ajax: new Yanbal.SFT.Web.Components.Ajax({
                        autoSubmit: false,
                        onSuccess: function (data, scope) {

                            if (scope.onBeforeLoad) {
                                var dataTemp = scope.onBeforeLoad(data);
                                data = dataTemp ? dataTemp : data;
                            }
                            if (scope.isGetAll) {
                                scope.isGetAll = false;
                                scope.tempDataSelected = data;
                                if (scope.onToggleCheckboxRowSelection && scope.onToggleCheckboxRowSelection != null) {
                                    scope.onToggleCheckboxRowSelection(scope.tempDataSelected, true);
                                }
                            }
                            else {
                                /*Solo cuando no es*/
                                if (scope.pager.isServerPaging) {
                                    scope.pager.processData(data);
                                }
                                scope.setData(data);

                                var data = scope.getDataView().getItems();
                                var selectedData = new Array();

                                $.each(data, function (index, value) {
                                    $.each(scope.tempDataSelected, function (indexT, temp) {
                                        if (value.RowId == temp.RowId) {
                                            selectedData.push(value.id);
                                            return false;
                                        }
                                    });
                                });

                                scope.slickGrid.setSelectedRows(selectedData);
                                var isSelectAll = scope.tempDataSelected.length == scope.getPageInfo().totalRows && scope.getPageInfo().totalRows > 0;
                                if (scope.isCheckboxSelector && scope.checkboxSelector != null) {
                                    scope.checkboxSelector.changeStateHeader(isSelectAll);
                                }
                                if (scope.onLoad) {
                                    scope.onLoad(data);
                                }
                            }
                        }
                    }),
                    params: null
                };
            }
            this.serverProxy.ajax.action = proxy.action ? proxy.action : this.serverProxy.ajax.action;
            this.serverProxy.params = proxy.data ? proxy.data : this.serverProxy.params;
            this.serverProxy.ajax.data = this.serverProxy.params;
        }
    },
    load: function (getAll) {
        if (this.serverProxy != null) {
            this.isGetAll = getAll != undefined ? getAll : false;
            if (this.pager.isServerPaging) {
                var pageInfo = this.getPageInfo();
                this.serverProxy.params.PageSize = getAll ? (pageInfo.totalRows * 1.2) : this.pager.serverPageInfo.pageSize;
                this.serverProxy.params.PageNo = getAll ? 1 : this.pager.serverPageInfo.pageNum + 1;
            }
            this.serverProxy.ajax.data = this.serverProxy.params;
            this.serverProxy.ajax.submit(this);
        }
    },
    getPageInfo: function () {
        var pageInfo = null;
        if (this.pager && this.pager != null) {
            if (this.pager.isServerPaging) {
                pageInfo = this.pager.serverPageInfo;
            }
            else {
                pageInfo = this.dataView.getPagingInfo();
            }
        }
        return pageInfo;
    },
    ///
    destroy: function () {
        this.slickGrid.destroy();
    },
    closeToolTip: function () {
        this.divGrid.tooltip('destroy');
    }

}