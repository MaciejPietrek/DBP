namespace Frontend.View.Forms
{
	partial class EntityChoiceForm
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
			this.tabContents = new Frontend.View.Controls.TabContents();
			this.SuspendLayout();
			// 
			// tabContents
			// 
			this.tabContents.AutoSize = true;
			this.tabContents.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tabContents.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabContents.Location = new System.Drawing.Point(0, 0);
			this.tabContents.Name = "tabContents";
			this.tabContents.Size = new System.Drawing.Size(800, 450);
			this.tabContents.TabIndex = 0;
			// 
			// EntityChoiceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tabContents);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "EntityChoiceForm";
			this.Text = "Formularz wyboru";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Controls.TabContents tabContents;
	}
}