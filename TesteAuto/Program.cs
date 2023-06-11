using FlaUI.Core;
using FlaUI.UIA3;

namespace TesteAuto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var app = Application.Launch("C:\\Users\\rafa1\\Downloads\\winrar-x64-622br.exe");
            //var app = Application.Launch("C:\\Users\\rafa1\\Downloads\\OperaGXSetup.exe");

            using (var automation = new UIA3Automation())
            {
                var aplicativo = new FlaUIAutomation(app, automation);
                aplicativo.InstalarWinRAR();
            }
        }
    }
}

