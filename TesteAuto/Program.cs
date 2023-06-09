using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using System;

namespace TesteAuto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var app = Application.Launch("C:\\Users\\rafa1\\Downloads\\OperaGXSetup.exe");

            using (var automation = new UIA3Automation())
            {
                var aplicativo = new FlaUIAutomation(app, automation);
                aplicativo.InstalarOperaGX();
            }
        }
    }
}

