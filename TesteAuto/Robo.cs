using FlaUI.Core;
using FlaUI.UIA3;
using System;

namespace TesteAuto
{
    public class Robo
    {
        private readonly RabbitMQService _rabbitMQService;

        public Robo()
        {
            _rabbitMQService = new RabbitMQService("queue_instalacao");
        }

        public void Start()
        {
            _rabbitMQService.StartListening(HandleMessage);
        }

        private void HandleMessage(string message)
        {
            if (message == "WinRAR")
            {
                var app = Application.Launch("C:\\Users\\rafa1\\Downloads\\winrar-x64-622br.exe");

                using (var automation = new UIA3Automation())
                {
                    var aplicativo = new RoboInstalacaoService(app, automation);
                    aplicativo.InstalarWinRAR();
                }
            }
            // Lógica para processar a mensagem recebida do RabbitMQ
            Console.WriteLine("Mensagem recebida: " + message);
        }

        public void Stop()
        {
            _rabbitMQService.Dispose();
        }
    }

}
