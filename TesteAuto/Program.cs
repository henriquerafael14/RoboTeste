using System;

namespace TesteAuto
{
    public class Program
    {
        public static void Main()
        {
            Robo robo = new Robo();
            robo.Start();

            Console.WriteLine("Robô iniciado. Aguardando mensagens...");

            // Aguardar alguma ação para encerrar o programa, por exemplo:
            Console.ReadLine();

            robo.Stop();
            Console.WriteLine("Robô encerrado.");
        }
    }
}
