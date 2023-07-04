namespace Arpti.RoboInstalador
{
	partial class Arpti
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Arpti));
			notifyIcon1 = new System.Windows.Forms.NotifyIcon(components);
			contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
			abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			iniciarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			pararToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			fecharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			contextMenuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// notifyIcon1
			// 
			notifyIcon1.ContextMenuStrip = contextMenuStrip1;
			notifyIcon1.Icon = (System.Drawing.Icon)resources.GetObject("notifyIcon1.Icon");
			notifyIcon1.Text = "notifyIcon1";
			notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { abrirToolStripMenuItem, iniciarToolStripMenuItem, pararToolStripMenuItem, fecharToolStripMenuItem });
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new System.Drawing.Size(113, 92);
			// 
			// abrirToolStripMenuItem
			// 
			abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
			abrirToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
			abrirToolStripMenuItem.Text = "Abrir";
			abrirToolStripMenuItem.Click += abrirToolStripMenuItem_Click;
			// 
			// fecharToolStripMenuItem
			// 
			fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
			fecharToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
			fecharToolStripMenuItem.Text = " Fechar";
			fecharToolStripMenuItem.Click += fecharToolStripMenuItem_Click;
			// 
			// button1
			// 
			button1.Location = new System.Drawing.Point(80, 21);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(102, 28);
			button1.TabIndex = 1;
			button1.Text = "Iniciar";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// button2
			// 
			button2.Location = new System.Drawing.Point(80, 64);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(102, 30);
			button2.TabIndex = 2;
			button2.Text = "Parar";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// Arpti
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(268, 119);
			Controls.Add(button2);
			Controls.Add(button1);
			Name = "Arpti";
			StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Arpti";
			Load += Arpti_Load;
			Resize += Arpti_Resize;
			contextMenuStrip1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem iniciarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pararToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fecharToolStripMenuItem;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}