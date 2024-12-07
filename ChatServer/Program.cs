using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class Program
{
    private static TcpListener? _server;    

    private static ConcurrentDictionary<string, TcpClient> _clients = new();

    static async Task Main(string[] args)
    {
        Console.WriteLine("Запускаем сервер...");
        
        int port = 5000;
        _server = new TcpListener(IPAddress.Any, port);
        _server.Start();
        Console.WriteLine($"Сервер запущен на порту {port}.");

        while (true)
        {            
            var client = await _server.AcceptTcpClientAsync();
            var clientEndPoint = client.Client.RemoteEndPoint?.ToString();
            if (clientEndPoint != null)
            {
                Console.WriteLine($"Клиент подключён: {clientEndPoint}");
                _clients.TryAdd(clientEndPoint, client);
                _ = HandleClientAsync(client, clientEndPoint);
            }
        }
    }

    private static async Task HandleClientAsync(TcpClient client, string clientEndPoint)
{
    try
    {
        BroadcastMessageAsync($"Пользователь {clientEndPoint} подключился.");

        var stream = client.GetStream();
        var buffer = new byte[1024];

        while (true)
        {
            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            if (bytesRead == 0) break;

            var message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            BroadcastMessageAsync($"{clientEndPoint}: {message}");
        }
    }
    catch
    {
        // Игнорируем ошибки клиента
    }
    finally
    {
        client.Close();
        _clients.TryRemove(clientEndPoint, out _);
        BroadcastMessageAsync($"Пользователь {clientEndPoint} отключился.");
    }
}



    private static async Task BroadcastMessageAsync(string message, string sender = null)
{
    var messageBytes = Encoding.UTF8.GetBytes(message);

    foreach (var kvp in _clients)
    {
        try
        {
            var recipient = kvp.Key;

            // Личное сообщение
            if (!string.IsNullOrEmpty(sender) && message.StartsWith($"@{recipient} "))
            {
                var privateMessage = message.Substring(recipient.Length + 2);
                var privateMessageBytes = Encoding.UTF8.GetBytes($"[Личное от {sender}]: {privateMessage}");
                await kvp.Value.GetStream().WriteAsync(privateMessageBytes, 0, privateMessageBytes.Length);
            }
            // Глобальное сообщение
            else if (string.IsNullOrEmpty(sender) || !message.StartsWith("@"))
            {
                await kvp.Value.GetStream().WriteAsync(messageBytes, 0, messageBytes.Length);
            }
        }
        catch
        {
            // Игнорируем ошибки отправки
        }
    }
}





}
