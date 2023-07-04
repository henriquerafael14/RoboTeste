using FlaUI.Core;
using FlaUI.UIA3;
using System;

namespace Arpti.RoboInstalador
{
    public class Robo
    {
        private readonly RabbitMQService _rabbitMQService;

        public Robo()
        {
            _rabbitMQService = new RabbitMQService();
        }

        public void Start()
        {
            _rabbitMQService.StartListening(HandleMessage);
        }

		private void HandleMessage(string message)
        {
            if (message == "WinRAR")
            {
                var app = Application.Launch("C:\\Users\\Rafael\\Downloads\\winrar-x64-622br.exe");

                using (var automation = new UIA3Automation())
                {
                    var aplicativo = new RoboInstalacaoService(app, automation);
                    aplicativo.InstalarWinRAR();

                    _rabbitMQService.PublicarMensagem("Instalação Finalizada");
                }
			}
			if (message == "OperaGX")
			{
				var app = Application.Launch("C:\\Users\\Rafael\\Downloads\\OperaGXSetup.exe");

				using (var automation = new UIA3Automation())
				{
					var aplicativo = new RoboInstalacaoService(app, automation);
					aplicativo.InstalarOperaGX();

					_rabbitMQService.PublicarMensagem("Instalação Finalizada");
				}
			}
			if (message == "VLCPlayer")
			{
				var app = Application.Launch("C:\\Users\\Rafael\\Downloads\\vlc-3.0.18-win64.exe");

				using (var automation = new UIA3Automation())
				{
					var aplicativo = new RoboInstalacaoService(app, automation);
					aplicativo.InstalarVLCPlayer();

					_rabbitMQService.PublicarMensagem("Instalação Finalizada");
				}
			}
		}

        public void Stop()
        {
            _rabbitMQService.Dispose();
        }
    }
}
