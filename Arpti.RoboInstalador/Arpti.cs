using System;
using System.Windows.Forms;

namespace Arpti.RoboInstalador
{
	public partial class Arpti : Form
	{
		private Robo robo;

		public Arpti()
		{
			InitializeComponent();
		}

		private void Arpti_Load(object sender, EventArgs e)
		{
			notifyIcon1.BalloonTipTitle = "ARPTI";
			notifyIcon1.BalloonTipText = "A janela foi minimizada. Procure pelo ícone oculto na área de notificação da barra de tarefas.";
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

		private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			robo = new Robo();
			robo.Start();
			button1.Enabled = false;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (robo != null)
			{
				robo.Stop();
				robo = null;
				button1.Enabled = true;
			}
		}
	}
}
