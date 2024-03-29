﻿namespace Frontend.View.Forms
{
	partial class LoginForm
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
			this.loginTextBox = new System.Windows.Forms.TextBox();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.loginLabel = new System.Windows.Forms.Label();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.signInButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// loginTextBox
			// 
			this.loginTextBox.Location = new System.Drawing.Point(51, 6);
			this.loginTextBox.MaxLength = 40;
			this.loginTextBox.Name = "loginTextBox";
			this.loginTextBox.Size = new System.Drawing.Size(219, 20);
			this.loginTextBox.TabIndex = 0;
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.Location = new System.Drawing.Point(51, 32);
			this.passwordTextBox.MaxLength = 40;
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.PasswordChar = '*';
			this.passwordTextBox.Size = new System.Drawing.Size(219, 20);
			this.passwordTextBox.TabIndex = 1;
			// 
			// loginLabel
			// 
			this.loginLabel.AutoSize = true;
			this.loginLabel.Location = new System.Drawing.Point(12, 9);
			this.loginLabel.Name = "loginLabel";
			this.loginLabel.Size = new System.Drawing.Size(33, 13);
			this.loginLabel.TabIndex = 2;
			this.loginLabel.Text = "Login";
			// 
			// passwordLabel
			// 
			this.passwordLabel.AutoSize = true;
			this.passwordLabel.Location = new System.Drawing.Point(9, 32);
			this.passwordLabel.Name = "passwordLabel";
			this.passwordLabel.Size = new System.Drawing.Size(36, 13);
			this.passwordLabel.TabIndex = 3;
			this.passwordLabel.Text = "Hasło";
			// 
			// signInButton
			// 
			this.signInButton.Location = new System.Drawing.Point(12, 58);
			this.signInButton.Name = "signInButton";
			this.signInButton.Size = new System.Drawing.Size(75, 23);
			this.signInButton.TabIndex = 4;
			this.signInButton.Text = "Zaloguj";
			this.signInButton.UseVisualStyleBackColor = true;
			this.signInButton.Click += new System.EventHandler(this.SignInButtonClicked);
			// 
			// LoginForm
			// 
			this.AcceptButton = this.signInButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(283, 92);
			this.Controls.Add(this.signInButton);
			this.Controls.Add(this.passwordLabel);
			this.Controls.Add(this.loginLabel);
			this.Controls.Add(this.passwordTextBox);
			this.Controls.Add(this.loginTextBox);
			this.Name = "LoginForm";
			this.Text = "Logowanie";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox loginTextBox;
		private System.Windows.Forms.TextBox passwordTextBox;
		private System.Windows.Forms.Label loginLabel;
		private System.Windows.Forms.Label passwordLabel;
		private System.Windows.Forms.Button signInButton;
	}
}