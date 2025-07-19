using Microsoft.AspNetCore.SignalR;

namespace InventariumWebApp.BuildScript
{
    public class BuildHub : Hub
    {
        // Método para enviar as atualizações de progresso para todos os clientes
        public async Task SendProgressUpdate(string message)
        {
            await Clients.All.SendAsync("ReceiveProgressUpdate", message);
        }
    }
}
