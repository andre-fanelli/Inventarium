$(document).ready(function () {
    // Conectar ao SignalR Hub
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/buildHub")
        .build();

    // Quando uma atualização de progresso for recebida, atualizar o SweetAlert
    connection.on("ReceiveProgressUpdate", function (message) {
        // Atualiza a mensagem e a barra de progresso
        Swal.update({
            title: 'Gerando executável...',
            text: message, // A mensagem recebida do SignalR
            onBeforeOpen: () => {
                Swal.showLoading();
            }
        });
    });

    // Conectar ao SignalR
    connection.start().catch(function (err) {
        console.error("Erro ao conectar ao SignalR:", err.toString());
    });

    // Quando o botão for clicado para gerar o executável
    $('#btnGerarExe').click(function () {
        // Exibir um alerta de carregamento enquanto o executável está sendo gerado
        Swal.fire({
            title: 'Gerando executável...',
            text: 'Por favor, aguarde.',
            showConfirmButton: false,
            allowOutsideClick: false,
            willOpen: () => {
                Swal.showLoading();
            }
        });

        // Enviar uma requisição AJAX para gerar o executável
        $.ajax({
            url: '/Build/Generate',  // Garante que o URL da ação seja correto
            type: 'POST',
            success: function (response) {
                // Fechar o indicador de carregamento
                Swal.close();

                if (response.success) {
                    // Exibir um link para download do arquivo gerado
                    Swal.fire({
                        title: 'Executável Gerado!',
                        text: 'Seu arquivo está pronto para ser baixado.',
                        icon: 'success',
                        showConfirmButton: true,
                        confirmButtonText: 'Baixar',
                        preConfirm: () => {
                            // Redireciona para a URL do arquivo gerado
                            window.location.href = response.url;
                        }
                    });
                } else {
                    // Exibir uma mensagem de erro se algo der errado
                    Swal.fire({
                        title: 'Erro!',
                        text: 'Ocorreu um erro ao gerar o executável. Tente novamente.',
                        icon: 'error',
                        confirmButtonText: 'OK'
                    });
                }
            },
            error: function () {
                // Fechar o indicador de carregamento
                Swal.close();

                // Exibir um erro caso a requisição falhe
                Swal.fire({
                    title: 'Erro!',
                    text: 'Falha na requisição. Tente novamente.',
                    icon: 'error',
                    confirmButtonText: 'OK'
                });
            }
        });
    });
});
