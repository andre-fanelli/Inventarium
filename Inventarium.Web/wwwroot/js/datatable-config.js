
window.initDataTable = function (tableId, translations = window.dtTranslations.global) {
    if (!tableId) return;

        $('#' + tableId).DataTable({
            scrollX: true,
            responsive: false,
            autoWidth: false,
            pageLength: 10,
            lengthMenu: [5, 10, 25, 50, 100],
            dom: 'Bfrtip',
            buttons: [
                {
                    extend: 'colvis',
                    text: translations.colvis,
                    className: 'btn btn-secondary btn-sm dropdown-toggle mb-2'
                },
                {
                    extend: 'excel',
                    text: translations.excel || 'Excel',
                    className: 'btn btn-secondary btn-sm mb-2'
                },
                {
                    extend: 'pdf',
                    text: translations.pdf,
                    className: 'btn btn-secondary btn-sm mb-2'
                },
                {
                    extend: 'print',
                    text: translations.print,
                    className: 'btn btn-secondary btn-sm mb-2'
                }
            ],
            language: {
                lengthMenu: translations.lengthMenu,
                zeroRecords: translations.zeroRecords,
                info: translations.info,
                infoEmpty: translations.infoEmpty,
                infoFiltered: translations.infoFiltered,
                search: translations.search,
                paginate: {
                    first: translations.paginateFirst,
                    last: translations.paginateLast,
                    next: translations.paginateNext,
                    previous: translations.paginatePrevious
                },
                buttons: {
                    colvis: translations.colvis
                }
            }
        });
}