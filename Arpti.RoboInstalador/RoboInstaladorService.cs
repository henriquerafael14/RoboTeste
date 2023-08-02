using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.UIA3;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Arpti.RoboInstalador
{
    public class RoboInstalacaoService
    {
        private Application _app;
        private UIA3Automation _automation;

        public RoboInstalacaoService(Application app, UIA3Automation automation)
        {
            _app = app;
            _automation = automation;
        }

        public void FecharAplicativo() => _app.Close();

        public void InstalarWinRAR()
        {
            var telaDeInstalacao = _app.GetMainWindow(_automation);
            if (telaDeInstalacao == null)
                FecharAplicativo();

            var botaoInstalar = telaDeInstalacao.FindFirstDescendant(x => x.ByText("Instalar")).AsButton();
            if (botaoInstalar == null)
                throw new Exception("O botão de Instalar não foi encontrado!");

            Mouse.MoveTo(botaoInstalar.GetClickablePoint());
            Mouse.LeftClick();

            Thread.Sleep(2000);
            Application appConfirmacao = ObterNovoProcesso("Configurações do WinRAR");

            var telaDeConfirmacao = appConfirmacao.GetMainWindow(_automation);
            var botaoOk = telaDeConfirmacao.FindFirstDescendant(x => x.ByText("OK")).AsButton();
            if (botaoOk == null)
                throw new Exception("O botão de OK não foi encontrado!");

            Mouse.MoveTo(botaoOk.GetClickablePoint());
            Mouse.LeftClick();

            Thread.Sleep(2000);
            Application appConcluido = ObterNovoProcesso("Instalação do WinRAR");

            var telaConcluido = appConcluido.GetMainWindow(_automation);
            var botaoConcluido = telaConcluido.FindFirstDescendant(x => x.ByText("Concluído")).AsButton();
            if (botaoConcluido == null)
                throw new Exception("O botão de OK não foi encontrado!");

            Mouse.MoveTo(botaoConcluido.GetClickablePoint());
            Mouse.LeftClick();
        }

        public void InstalarOperaGX()
        {
            var telaDeInstalacao = _app.GetMainWindow(_automation);
            if (telaDeInstalacao == null)
                FecharAplicativo();

            var botaoInstalar = telaDeInstalacao.FindFirstDescendant(telaDeInstalacao => telaDeInstalacao.ByText("Aceitar e instalar")).AsButton();
            if (botaoInstalar == null)
                throw new Exception("O botão de 'Aceitar termos' não foi encontrado!");

            Mouse.MoveTo(botaoInstalar.GetClickablePoint());
            Mouse.LeftClick();

            Thread.Sleep(2000);
            var telaDeAceite = _app.GetMainWindow(_automation);
            if (telaDeAceite == null)
                FecharAplicativo();
            var botaoAceitar = telaDeAceite.FindFirstDescendant(telaDeAceite => telaDeAceite.ByText("Aceitar")).AsButton();
            if (botaoAceitar == null)
                throw new Exception("O botão de Aceitar instalação não foi encontrado!");

            Mouse.MoveTo(botaoAceitar.GetClickablePoint());
            Mouse.LeftClick();
        }

		public void InstalarVLCPlayer()
		{
			var telaDeGuia = _app.GetMainWindow(_automation);
			if (telaDeGuia == null)
				FecharAplicativo();

			var botaoOK = telaDeGuia.FindFirstDescendant(telaDeGuia => telaDeGuia.ByText("OK")).AsButton();
			if (botaoOK == null)
				throw new Exception("O botão de 'OK' não foi encontrado!");

			Mouse.MoveTo(botaoOK.GetClickablePoint());
			Mouse.LeftClick();
			Application appConfirmacao = ObterNovoProcesso("Instalação do VLC media player");

			Thread.Sleep(2000);
			var telaDeAceite = appConfirmacao.GetMainWindow(_automation);
			if (telaDeAceite == null)
				FecharAplicativo();
			var botaoProximo = telaDeAceite.FindFirstDescendant(telaDeAceite => telaDeAceite.ByText("Próximo >")).AsButton();
			if (botaoProximo == null)
				throw new Exception("O botão de 'Próximo' não foi encontrado!");

			Mouse.MoveTo(botaoProximo.GetClickablePoint());
			Mouse.LeftClick();

			Thread.Sleep(2000);
			var telaDeLicenca = _app.GetMainWindow(_automation);
			if (telaDeLicenca == null)
				FecharAplicativo();
			var botaoLicenca = telaDeLicenca.FindFirstDescendant(telaDeLicenca => telaDeLicenca.ByText("Próximo >")).AsButton();
			if (botaoLicenca == null)
				throw new Exception("O botão de 'Próximo' não foi encontrado!");

			Mouse.MoveTo(botaoLicenca.GetClickablePoint());
			Mouse.LeftClick();

			Thread.Sleep(2000);
			var telaDeComponentes = _app.GetMainWindow(_automation);
			if (telaDeComponentes == null)
				FecharAplicativo();
			var botaoComponentes = telaDeComponentes.FindFirstDescendant(telaDeComponentes => telaDeComponentes.ByText("Próximo >")).AsButton();
			if (botaoComponentes == null)
				throw new Exception("O botão de 'Próximo' não foi encontrado!");

			Mouse.MoveTo(botaoComponentes.GetClickablePoint());
			Mouse.LeftClick();

            Thread.Sleep(2000);
			var telaDeInstalacao = _app.GetMainWindow(_automation);
			if (telaDeInstalacao == null)
				FecharAplicativo();

			var botaoInstalar = telaDeInstalacao.FindFirstDescendant(telaDeInstalacao => telaDeInstalacao.ByText("Instalar")).AsButton();
			if (botaoInstalar == null)
				throw new Exception("O botão de 'Instalar' não foi encontrado!");

			Mouse.MoveTo(botaoComponentes.GetClickablePoint());
			Mouse.LeftClick();

			Thread.Sleep(10000);
			var telaDeConclusao = _app.GetMainWindow(_automation);
			if (telaDeConclusao == null)
				FecharAplicativo();

			var botaoConcluir = telaDeConclusao.FindFirstDescendant(telaDeConclusao => telaDeConclusao.ByText("Concluir")).AsButton();
			if (botaoConcluir == null)
				throw new Exception("O botão de 'Concluir' não foi encontrado!");

			Mouse.MoveTo(botaoConcluir.GetClickablePoint());
			Mouse.LeftClick();
		}

		private static Application ObterNovoProcesso(string nomeProcesso)
        {
            var processos = Process.GetProcesses().ToList();
            var novoProcesso = processos.Where(p => p.MainWindowTitle == nomeProcesso).First();
            if (novoProcesso == null)
                throw new Exception("Ocorreu um erro ao finalizar instalação do WinRAR!");

            var app = Application.Attach(novoProcesso);
            return app;
        }
    }
}
