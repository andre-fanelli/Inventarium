$(document).ready(function () {
    $('#notebooksTable').DataTable({
        scrollX: true,
        responsive: false,
        pageLength: 10,
        lengthMenu: [5, 10, 25, 50, 100],
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'colvis',
                text: 'Mostrar/Ocultar Colunas',
                className: 'btn btn-secondary btn-sm dropdown-toggle mb-2'
            }
        ],
        language: {
            lengthMenu: "Exibir _MENU_ registros por página",
            zeroRecords: "Nenhum registro encontrado",
            info: "Página _PAGE_ de _PAGES_",
            infoEmpty: "Nenhum dado disponível",
            infoFiltered: "(filtrado de _MAX_ registros no total)",
            search: "Pesquisar:",
            paginate: {
                first: "Primeira",
                last: "Última",
                next: "Próxima",
                previous: "Anterior"
            },
            buttons: {
                colvis: 'Mostrar colunas'
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
                url: `/Notebooks/DeleteAjax/${deleteId}`,  // Passa o ID no URL
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