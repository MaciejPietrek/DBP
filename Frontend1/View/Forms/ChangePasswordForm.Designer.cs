﻿namespace Frontend.View.Forms
{
	partial class ChangePasswordForm
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
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.passwordEdit = new Frontend.View.Controls.PasswordEdit();
			this.SuspendLayout();
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(27, 88);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 1;
			this.okButton.Text = "Ok";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.OkCLick);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(108, 88);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Anuluj";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// passwordEdit
			// 
			this.passwordEdit.AutoSize = true;
			this.passwordEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.passwordEdit.Location = new System.Drawing.Point(12, 12);
			this.passwordEdit.Name = "passwordEdit";
			this.passwordEdit.Padding = new System.Windows.Forms.Padding(10);
			this.passwordEdit.Size = new System.Drawing.Size(301, 70);
			this.passwordEdit.TabIndex = 0;
			// 
			// ChangePasswordForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(324, 117);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.passwordEdit);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ChangePasswordForm";
			this.Text = "Zmiana hasła";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Controls.PasswordEdit passwordEdit;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
	}
}