using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.UIA3;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace TesteAuto
{
    public class FlaUIAutomation
    {
        private Application _app;
        private UIA3Automation _automation;

        public FlaUIAutomation(Application app, UIA3Automation automation)
        {
            _app = app;
            _automation = automation;
        }

        public void FecharAplicativo() => _app.Close();

        public void InstalarWinRAR()
        {
            // Obtém a janela de confirmação de instalação do WinRAR
            var telaDeInstalacao = _app.GetMainWindow(_automation);
            if (telaDeInstalacao == null)
                FecharAplicativo();

            var botaoInstalar = telaDeInstalacao.FindFirstDescendant(x => x.ByText("Instalar")).AsButton();
            if (botaoInstalar == null)
                throw new Exception("O botão de Instalar não foi encontrado!"); 

            Mouse.MoveTo(botaoInstalar.GetClickablePoint());
            Mouse.LeftClick();

            Thread.Sleep(1000);

            // Obtém a lista de todos os processos ativos antes do clique no botão "Instalar"
            var processosAnteriores = Process.GetProcesses();

            // Aguarda o início de um novo processo
            Process novoProcesso = null;
            var stopwatch = Stopwatch.StartNew();
            while (novoProcesso == null && stopwatch.Elapsed < TimeSpan.FromSeconds(10))
            {
                // Obtém a lista de todos os processos atuais
                var processosAtuais = Process.GetProcesses();

                // Encontra o novo processo que não estava presente na lista anterior
                novoProcesso = processosAtuais.FirstOrDefault(p => !processosAnteriores.Contains(p));

                Thread.Sleep(500);
            }

            if (novoProcesso == null)
                throw new Exception("O novo processo não foi iniciado.");

            var telaDeConfirmacao = _app.GetAllTopLevelWindows(_automation);
            var botaoOk = telaDeInstalacao.FindFirstDescendant(x => x.ByText("OK")).AsButton();
            if (botaoOk == null)
                throw new Exception();

            Mouse.MoveTo(botaoInstalar.GetClickablePoint());
            Mouse.LeftClick();

            Thread.Sleep(1000);
        }

        public void InstalarOperaGX()
        {
            // Obtém a janela de confirmação de instalação do WinRAR
            var telaDeInstalacao = _app.GetMainWindow(_automation);
            if (telaDeInstalacao == null)
                FecharAplicativo();

            var botaoInstalar = telaDeInstalacao.FindFirstDescendant(telaDeInstalacao => telaDeInstalacao.ByText("Aceitar e instalar")).AsButton();
            if (botaoInstalar == null)
                throw new Exception("O botão de Aceitar termos não foi encontrado!");

            Mouse.MoveTo(botaoInstalar.GetClickablePoint());
            Mouse.LeftClick();

            Thread.Sleep(2000);
            var telaDeAceite = _app.GetMainWindow(_automation);
            if (telaDeAceite == null)
                FecharAplicativo();
            var botaoAceitar = telaDeAceite.FindFirstDescendant(telaDeAceite => telaDeAceite.ByText("Definir em configurações")).AsButton();
            if (botaoAceitar == null)
                throw new Exception("O botão de Aceitar instalação não foi encontrado!");

            Mouse.MoveTo(botaoInstalar.GetClickablePoint());
            Mouse.LeftClick();

            Thread.Sleep(1000);

            FecharAplicativo();
        }
    }
}
