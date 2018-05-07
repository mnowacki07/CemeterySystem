function generateFooterFilters($table) {
    $table.find('tfoot th').each(function () {
        var title = $(this).text();
        if (title != null && title != '') {
            // first character to lowerCase
            $(this).html('<input type="text" placeholder="Szukaj ' + title.charAt(0).toLowerCase() + title.slice(1) + '" class="table-footer-filter" />');
        }
    });

    var table = $table.DataTable();
    // Apply the search
    table.columns().every(function () {
        var that = this;

        $('input', this.footer()).on('keyup change', function () {
            if (that.search() !== this.value) {
                that
                    .search(this.value)
                    .draw();
            }
        });
    });
}

var jQueryDataTableTranslations = {
    "processing": "Przetwarzanie...",
    "search": "Szukaj:",
    "lengthMenu": "Pokaż _MENU_ pozycji",
    "info": "Pozycje od _START_ do _END_ z _TOTAL_ łącznie",
    "infoEmpty": "Pozycji 0 z 0 dostępnych",
    "infoFiltered": "(filtrowanie spośród _MAX_ dostępnych pozycji)",
    "infoPostFix": "",
    "loadingRecords": "Wczytywanie...",
    "zeroRecords": "Nie znaleziono pasujących pozycji",
    "emptyTable": "Brak danych",
    "paginate": {
        "first": "Pierwsza",
        "previous": "Poprzednia",
        "next": "Następna",
        "last": "Ostatnia"
    },
    "aria": {
        "sortAscending": ": aktywuj, by posortować kolumnę rosnąco",
        "sortDescending": ": aktywuj, by posortować kolumnę malejąco"
    }
};