const translations = @Html.Raw(dtLang);

document.getElementById("selectAll").addEventListener("click", function () {
    const checkboxes = document.querySelectorAll(".selectRow");
    checkboxes.forEach(cb => cb.checked = this.checked);
});

function getSelectedIds() {
    const ids = [];
    document.querySelectorAll(".selectRow:checked").forEach(cb => {
        ids.push(cb.value);
    });
    return ids;
}

document.getElementById("exportPdf").addEventListener("click", function () {
    const ids = getSelectedIds();
    if (ids.length === 0) {
        alert("Selecione ao menos um equipamento.");
        return;
    }
    window.location.href = "/Computers/ExportPdf?ids=" + ids.join(",");
});

document.getElementById("exportExcel").addEventListener("click", function () {
    const ids = getSelectedIds();
    if (ids.length === 0) {
        alert("Selecione ao menos um equipamento.");
        return;
    }
    window.location.href = "/Computers/ExportExcel?ids=" + ids.join(",");
});

$(document).ready(function () {
    $('#computersTable').DataTable({
        scrollX: true,
        responsive: false,
        pageLength: 10,
        lengthMenu: [5, 10, 25, 50, 100],
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'colvis',
                text: translations.colvis,
                className: 'btn btn-secondary btn-sm dropdown-toggle mb-2'
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
});


$(document).ready(function () {
    // Quando o modal de exclusão for aberto
    $('#deleteModal').on('show.bs.modal', function (event) {
        let button = $(event.relatedTarget); // O botão que foi clicado
        let deleteId = button.data('id'); // Pega o ID do atributo data-id
        $('#deleteItemId').val(deleteId); // Define o valor no campo oculto do formulário
    });

    // Quando o usuário confirmar a exclusão
    $('#confirmDelete').click(function () {
        let deleteId = $('#deleteItemId').val(); // Pega o valor do campo oculto

        if (deleteId) {
            $.ajax({
                url: `/Computers/DeleteAjax/${deleteId}`,  // Passa o ID no URL
                type: 'POST',
                headers: {
                    'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val() // Verificação de segurança
                },
                success: function () {
                    $('#deleteModal').modal('hide');
                    Swal.fire({
                        icon: 'success',
                        title: 'Registro apagado!',
                        text: 'A exclusão foi realizada com sucesso.',
                        timer: 2000,
                        showConfirmButton: false
                    }).then(() => {
                        $('#row-' + deleteId).remove();  // Remove a linha da tabela
                    });
                },
                error: function () {
                    Swal.fire({
                        icon: 'error',
                        title: 'Erro',
                        text: 'Ocorreu um erro ao apagar o registro.'
                    });
                }
            });
        }
    });
});