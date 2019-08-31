namespace Frontend
{
	partial class MainForm
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
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageConstant = new System.Windows.Forms.TabPage();
			this.flowLayoutPanelConstant = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.logoutButton = new System.Windows.Forms.Button();
			this.tabControl.SuspendLayout();
			this.tabPageConstant.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPageConstant);
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(802, 414);
			this.tabControl.TabIndex = 0;
			// 
			// tabPageConstant
			// 
			this.tabPageConstant.Controls.Add(this.flowLayoutPanelConstant);
			this.tabPageConstant.Location = new System.Drawing.Point(4, 22);
			this.tabPageConstant.Name = "tabPageConstant";
			this.tabPageConstant.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageConstant.Size = new System.Drawing.Size(794, 388);
			this.tabPageConstant.TabIndex = 0;
			this.tabPageConstant.Text = "Nowa";
			this.tabPageConstant.ToolTipText = "Otwórz nową zakładkę";
			this.tabPageConstant.UseVisualStyleBackColor = true;
			// 
			// flowLayoutPanelConstant
			// 
			this.flowLayoutPanelConstant.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanelConstant.Location = new System.Drawing.Point(3, 3);
			this.flowLayoutPanelConstant.Name = "flowLayoutPanelConstant";
			this.flowLayoutPanelConstant.Size = new System.Drawing.Size(788, 382);
			this.flowLayoutPanelConstant.TabIndex = 1;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel1.Controls.Add(this.logoutButton);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 417);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(802, 33);
			this.flowLayoutPanel1.TabIndex = 1;
			// 
			// logoutButton
			// 
			this.logoutButton.Location = new System.Drawing.Point(3, 3);
			this.logoutButton.Name = "logoutButton";
			this.logoutButton.Size = new System.Drawing.Size(75, 23);
			this.logoutButton.TabIndex = 0;
			this.logoutButton.Text = "Wyloguj";
			this.logoutButton.UseVisualStyleBackColor = true;
			this.logoutButton.Click += new System.EventHandler(this.LogoutButtonClicked);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.tabControl);
			this.Name = "MainForm";
			this.Text = "Okno główne";
			this.tabControl.ResumeLayout(false);
			this.tabPageConstant.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageConstant;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button logoutButton;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelConstant;
	}
}

