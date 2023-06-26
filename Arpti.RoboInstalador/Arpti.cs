using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Arpti.RoboInstalador
{
    public partial class Arpti : Form
    {
        public Arpti()
        {
            InitializeComponent();
        }

        private void Arpti_Load(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipTitle = "ARPTI";
            notifyIcon1.BalloonTipText = "texto de notificação";
            notifyIcon1.Text = "ARPTI OK";
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void Arpti_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void iniciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Robo robo = new Robo();
            robo.Start();

            Console.WriteLine("Robô iniciado. Aguardando mensagens...");

            // Aguardar alguma ação para encerrar o programa, por exemplo:
            Console.ReadLine();

            robo.Stop();
            Console.WriteLine("Robô encerrado.");
        }

        private void pararToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
