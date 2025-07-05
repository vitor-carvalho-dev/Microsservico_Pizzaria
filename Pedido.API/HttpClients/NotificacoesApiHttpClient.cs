namespace Pedidos.API.HttpClients
{
    public class NotificacoesApiHttpClient
    {
        public sealed class ClientNotification(HttpClient httpClient)
        {
            public async Task CriarNotificacaoAsync(
                string pedidoId,
                string destinatario,
                string mensagem
            ) {
                var response = await httpClient.PostAsJsonAsync("/notificacao", new {
                    pedidoId,
                    destinatario,
                    mensagem
                });
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
