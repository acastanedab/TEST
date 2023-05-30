(function ($) {
    function SlickGridPager(dataView, grid, $container, opts) {
        var $status;
        var serverPageInfo = {
            pageSize: parseInt(opts.defaultPageSize),
            pageNum: 0,
            totalPages: 1,
            totalRows: 0
        };
        var serverProxy = null;

        function init() {


            if (!opts.isServerPaging) {
                dataView.setPagingOptions({
                    pageSize: opts.defaultPageSize,
                });
                dataView.onPagingInfoChanged.subscribe(function (e, pagingInfo) {
                    updatePager(pagingInfo);
                });
            }
            constructPagerUI();
            //updatePager(dataView.getPagingInfo());
            ///EMP(Se modifico la actualización deacuerdo a la forma de paginación)
            updatePager(opts.isServerPaging ? serverPageInfo : dataView.getPagingInfo());
        }

        function getNavState() {
            var cannotLeaveEditMode = !Slick.GlobalEditorLock.commitCurrentEdit();
            var pagingInfo = opts.isServerPaging ? serverPageInfo : dataView.getPagingInfo();
            var lastPage = pagingInfo.totalPages - 1;

            if (lastPage == -1) {
                lastPage = 0;
            }

            return {
                canGotoFirst: !cannotLeaveEditMode && pagingInfo.pageSize != 0 && pagingInfo.pageNum > 0,
                canGotoLast: !cannotLeaveEditMode && pagingInfo.pageSize != 0 && pagingInfo.pageNum != lastPage,
                canGotoPrev: !cannotLeaveEditMode && pagingInfo.pageSize != 0 && pagingInfo.pageNum > 0,
                canGotoNext: !cannotLeaveEditMode && pagingInfo.pageSize != 0 && pagingInfo.pageNum < lastPage,
                pagingInfo: pagingInfo
            }
        }

        function processData(data) {
            var totalRows = 0;
            if (data != null && data.length > 0 && data[0].RowsTotal) {
                totalRows = data[0].RowsTotal;
            }
            data = data.splice(serverPageInfo.pageSize);
            setTotalServerRows(totalRows);
            updatePager(serverPageInfo);
            return data;
        }

        function setTotalServerRows(totalRows) {
            serverPageInfo.totalRows = totalRows;
            serverPageInfo.totalPages = Math.ceil(serverPageInfo.totalRows / serverPageInfo.pageSize);
        }

        function setPageSize(n) {
            if (opts.isServerPaging) {
                serverPageInfo.pageSize = n;
                serverPageInfo.totalPages = Math.ceil(serverPageInfo.totalRows / serverPageInfo.pageSize);
                serverPageInfo.pageNum = 0;
                if (opts.onPageChange) {
                    opts.onPageChange(serverPageInfo);
                }
            }
            else {
                dataView.setRefreshHints({
                    isFilterUnchanged: true
                });
                dataView.setPagingOptions({ pageSize: n });
            }
        }

        function gotoFirst() {
            if (getNavState().canGotoFirst) {
                if (opts.isServerPaging) {
                    serverPageInfo.pageNum = 0;
                    if (opts.onPageChange) {
                        opts.onPageChange(serverPageInfo);
                    }
                }
                else {
                    dataView.setPagingOptions({ pageNum: 0 });
                }
            }
        }

        function gotoLast() {
            var state = getNavState();
            if (state.canGotoLast) {
                if (opts.isServerPaging) {
                    serverPageInfo.pageNum = serverPageInfo.totalPages - 1;
                    if (opts.onPageChange) {
                        opts.onPageChange(serverPageInfo);
                    }
                }
                else {
                    dataView.setPagingOptions({ pageNum: state.pagingInfo.totalPages - 1 });
                }
            }
        }

        function gotoPrev() {
            var state = getNavState();
            if (state.canGotoPrev) {
                if (opts.isServerPaging) {
                    serverPageInfo.pageNum = serverPageInfo.pageNum - 1;
                    if (opts.onPageChange) {
                        opts.onPageChange(serverPageInfo);
                    }
                }
                else {
                    dataView.setPagingOptions({ pageNum: state.pagingInfo.pageNum - 1 });
                }
            }
        }

        function gotoNext() {
            var state = getNavState();
            if (state.canGotoNext) {
                if (opts.isServerPaging) {
                    serverPageInfo.pageNum = serverPageInfo.pageNum + 1;
                    if (opts.onPageChange) {
                        opts.onPageChange(serverPageInfo);
                    }
                }
                else {
                    dataView.setPagingOptions({ pageNum: state.pagingInfo.pageNum + 1 });
                }
            }
        }

        function constructPagerUI() {
            $container.empty();

            //var pageAuto = $container.attr('pageauto'); //EMP: Se modifico el valor por defect segun el pagesize enviado
            var pageAuto = opts.defaultPageSize;

            var $nav = $("<span class='slick-pager-nav' />").appendTo($container);
            var $settings = $("<span class='slick-pager-settings' />").appendTo($container);
            $status = $("<span class='slick-pager-status' />").appendTo($container);

            $settings
                .append("<div class='pull-right'><div class='form-inline form-search' role='form'><div class='form-group' style='padding-right: 26px'><label class='control-label' for='numero-order'>" + Yanbal.SFT.Presentation.Web.Shared.Resources.LabelRowsPerPage + ":</label></div><div class='form-group'><select class='form-control'><option>Auto</option><option>10</option><option>25</option><option>50</option><option>100</option></select></div></div></div>");

            $settings.find("select").on('change', updateSizePage);

            var icon_prefix = "<span class='ui-state-default ui-corner-all ui-icon-container'><span class='ui-icon ";
            var icon_suffix = "' /></span>";

            $(icon_prefix + "ui-icon-lightbulb" + icon_suffix)
                .click(function () {
                    $(".slick-pager-settings-expanded").toggle()
                })

            $(icon_prefix + "ui-icon-seek-first" + icon_suffix)
                .click(gotoFirst)
                .appendTo($nav);

            $(icon_prefix + "ui-icon-seek-prev" + icon_suffix)
                .click(gotoPrev)
                .appendTo($nav);

            $(icon_prefix + "ui-icon-seek-next" + icon_suffix)
                .click(gotoNext)
                .appendTo($nav);

            $(icon_prefix + "ui-icon-seek-end" + icon_suffix)
                .click(gotoLast)
                .appendTo($nav);

            $container.find(".ui-icon-container")
                .hover(function () {
                    $(this).toggleClass("ui-state-hover");
                });

            $container.children().wrapAll("<div class='slick-pager' />");
        }

        function updateSizePage() {  //JS              
            var pagesize = this.value;
            if (pagesize == 'Auto' || pagesize == undefined) {
                pagesize = opts.defaultPageSize;
            }
            if (pagesize != undefined) {
                if (pagesize == -1) {
                    var vp = grid.getViewport();
                    setPageSize(vp.bottom - vp.top);
                } else {
                    setPageSize(parseInt(pagesize));
                }
            }
        }

        function updatePager(pagingInfo) {
            var state = getNavState();
            var totalRowsCount = opts.isServerPaging ? pagingInfo.totalRows : dataView.getItems().length;
            //var visibleRowsCount = grid.isServerPaging ? pagingInfo.pageSize/*calcular*/ : pagingInfo.totalRows;
            var totalRowsLabel = '';

            $container.find(".slick-pager-nav span").removeClass("ui-state-disabled");
            if (!state.canGotoFirst) {
                $container.find(".ui-icon-seek-first").addClass("ui-state-disabled");
            }
            if (!state.canGotoLast) {
                $container.find(".ui-icon-seek-end").addClass("ui-state-disabled");
            }
            if (!state.canGotoNext) {
                $container.find(".ui-icon-seek-next").addClass("ui-state-disabled");
            }
            if (!state.canGotoPrev) {
                $container.find(".ui-icon-seek-prev").addClass("ui-state-disabled");
            }
            var lastRows = pagingInfo.pageSize;
            if ((pagingInfo.pageNum + 1).toString() == pagingInfo.totalPages.toString() || pagingInfo.totalPages.toString() == 0) {
                lastRows = pagingInfo.totalRows - (pagingInfo.pageNum * pagingInfo.pageSize);
            }
            totalRowsLabel = ' ' + Yanbal.SFT.Presentation.Web.Shared.Resources.LabelRow + ' ' + lastRows + " / " + totalRowsCount;
            if (pagingInfo.pageSize == 0) {
                $status.text(totalRowsLabel);
            } else {
                $status.text(" " + Yanbal.SFT.Presentation.Web.Shared.Resources.LabelPage + " " + (pagingInfo.pageNum + 1) + " / " + ((pagingInfo.totalPages != 0) ? pagingInfo.totalPages : 1) + ' | ' + totalRowsLabel);
            }
        }

        $.extend(this, {
            "isServerPaging": opts.isServerPaging ? opts.isServerPaging : false,
            "serverPageInfo": serverPageInfo,
            "processData": processData,
            "updateSizePage": updateSizePage
        });
        init();
    }

    // Slick.Controls.Pager
    $.extend(true, window, { Slick: { Controls: { Pager: SlickGridPager } } });
})(jQuery);
