document.addEventListener('DOMContentLoaded', function () {
    // Sucesso
    if (window.successMessage) {
        Swal.fire({
            icon: 'success',
            title: 'Sucesso!',
            text: successMessage,
            confirmButtonColor: '#3085d6'
        });
    }

    // Erro
    if (window.errorMessage) {
        Swal.fire({
            icon: 'error',
            title: 'Erro!',
            text: errorMessage,
            confirmButtonColor: '#d33'
        });
    }

    // Confirmação de exclusão
    document.querySelectorAll('.btn-delete-user').forEach(button => {
        button.addEventListener('click', function () {
            const userId = this.getAttribute('data-userid');
            const userEmail = this.getAttribute('data-useremail');

            Swal.fire({
                title: 'Tem certeza?',
                html: `Deseja excluir o usuário <strong>${userEmail}</strong>?`,
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#d33',
                cancelButtonColor: '#6c757d',
                confirmButtonText: 'Sim, excluir',
                cancelButtonText: 'Cancelar'
            }).then((result) => {
                if (result.isConfirmed) {
                    // Chama a ação Delete via AJAX
                    const token = document.querySelector('input[name="__RequestVerificationToken"]').value;
                    fetch(window.userDeleteUrl, {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json',
                            'RequestVerificationToken': token // Passa o token anti-forgery
                        },
                        body: JSON.stringify({ id: userId })
                    })
                        .then(response => response.json())
                        .then(data => {
                            if (data.success) {
                                Swal.fire({
                                    icon: 'success',
                                    title: 'Usuário excluído!',
                                    text: 'O usuário foi excluído com sucesso.',
                                    confirmButtonText: 'OK'
                                }).then(() => {
                                    // Atualiza a lista ou faz qualquer outra coisa
                                    location.reload();  // Recarrega a página para atualizar a lista de usuários
                                });
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Erro!',
                                    text: data.message,
                                    confirmButtonText: 'OK'
                                });
                            }
                        })
                        .catch(error => {
                            Swal.fire({
                                icon: 'error',
                                title: 'Erro!',
                                text: 'Ocorreu um erro na requisição.',
                                confirmButtonText: 'OK'
                            });
                        });
                }
            });
        });
    });
});
