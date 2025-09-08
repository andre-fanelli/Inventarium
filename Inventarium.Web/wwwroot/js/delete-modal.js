
window.initDeleteModal = function(controllerName) {
    $('#deleteModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget); 
        var deleteId = button.data('id');
        $('#deleteItemId').val(deleteId); 
    });

    $('#confirmDelete').off('click').on('click', function () {
        var deleteId = $('#deleteItemId').val();
        if (!deleteId) return;

        $.ajax({
            url: `/${controllerName}/DeleteAjax/${deleteId}`,
            type: 'POST',
            headers: {
                'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()
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
                    $('#row-' + deleteId).remove();
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
    };
}
