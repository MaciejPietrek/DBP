namespace Frontend.View.Controls
{
	partial class PasswordEdit
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.newPasswordLabel = new System.Windows.Forms.Label();
			this.confirmPasswordLabel = new System.Windows.Forms.Label();
			this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
			this.newPasswordTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// newPasswordLabel
			// 
			this.newPasswordLabel.AutoSize = true;
			this.newPasswordLabel.Location = new System.Drawing.Point(13, 10);
			this.newPasswordLabel.Name = "newPasswordLabel";
			this.newPasswordLabel.Size = new System.Drawing.Size(65, 13);
			this.newPasswordLabel.TabIndex = 2;
			this.newPasswordLabel.Text = "Nowe hasło";
			// 
			// confirmPasswordLabel
			// 
			this.confirmPasswordLabel.AutoSize = true;
			this.confirmPasswordLabel.Location = new System.Drawing.Point(13, 40);
			this.confirmPasswordLabel.Name = "confirmPasswordLabel";
			this.confirmPasswordLabel.Size = new System.Drawing.Size(83, 13);
			this.confirmPasswordLabel.TabIndex = 3;
			this.confirmPasswordLabel.Text = "Potwierdź hasło";
			// 
			// confirmPasswordTextBox
			// 
			this.confirmPasswordTextBox.Location = new System.Drawing.Point(102, 37);
			this.confirmPasswordTextBox.Name = "confirmPasswordTextBox";
			this.confirmPasswordTextBox.PasswordChar = '*';
			this.confirmPasswordTextBox.Size = new System.Drawing.Size(186, 20);
			this.confirmPasswordTextBox.TabIndex = 1;
			// 
			// newPasswordTextBox
			// 
			this.newPasswordTextBox.Location = new System.Drawing.Point(102, 7);
			this.newPasswordTextBox.Name = "newPasswordTextBox";
			this.newPasswordTextBox.PasswordChar = '*';
			this.newPasswordTextBox.Size = new System.Drawing.Size(186, 20);
			this.newPasswordTextBox.TabIndex = 0;
			// 
			// PasswordEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.newPasswordTextBox);
			this.Controls.Add(this.confirmPasswordTextBox);
			this.Controls.Add(this.confirmPasswordLabel);
			this.Controls.Add(this.newPasswordLabel);
			this.Name = "PasswordEdit";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.Size = new System.Drawing.Size(301, 70);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label newPasswordLabel;
		private System.Windows.Forms.Label confirmPasswordLabel;
		private System.Windows.Forms.TextBox confirmPasswordTextBox;
		private System.Windows.Forms.TextBox newPasswordTextBox;
	}
}
