using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ChatClient
{
    public partial class MainWindow : Window
    {
        private TcpClient _client;
        private NetworkStream _stream;

        public MainWindow()
        {
            InitializeComponent();
            ConnectToServer();
        } 

        private async void ConnectToServer()
        {
            try
            {
                _client = new TcpClient();
                await _client.ConnectAsync("127.0.0.1", 5000);
                _stream = _client.GetStream();
                AppendMessage("Подключение к серверу установлено.");
                
                _ = ReceiveMessagesAsync();
            }
            catch (Exception ex)
            {
                AppendMessage($"Ошибка подключения: {ex.Message}");
            }
        }

        private async Task ReceiveMessagesAsync()
        {
            var buffer = new byte[1024];
            try
            {
                while (true)
                {
                    int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        AppendMessage("Соединение с сервером потеряно.");
                        break;
                    }

                    var message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    AppendMessage(message);
                }
            }
            catch (Exception ex)
            {
                AppendMessage($"Ошибка при получении данных: {ex.Message}");
            }
            finally
            {
                _client.Close();
            }
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        private async void SendMessage()
        {
            var message = MessageBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(message) || _stream == null) return;

            try
            {
                var data = Encoding.UTF8.GetBytes(message);
                await _stream.WriteAsync(data, 0, data.Length);
                MessageBox.Clear();
            }
            catch (Exception ex)
            {
                AppendMessage($"Ошибка отправки сообщения: {ex.Message}");
            }
        }

        private void AppendMessage(string message)
        {            
            Dispatcher.Invoke(() =>
            {
                ChatBox.AppendText($"{message}{Environment.NewLine}");
                ChatBox.ScrollToEnd();
            });
        }

        private async void LoadDataButton_Click(object sender, RoutedEventArgs e)
        {
            ChatBox.AppendText("Загрузка данных...\n");
    
            // Запуск асинхронной задачи
            string data = await LoadDataAsync();

            ChatBox.AppendText($"Данные загружены: {data}\n");
        }

        // Асинхронный метод загрузки данных
        private async Task<string> LoadDataAsync()
        {
            // Имитация длительной загрузки (например, из базы данных или API)
            await Task.Delay(3000); // Задержка 3 секунды
            return "😀";
        }  // Это не блокирует UI, и пользователь может продолжать взаимодействовать с приложением.
    }
}
