namespace Frontend.View.Forms
{
	partial class AddEditForm
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
			this.tableLayoutPanelExternal = new System.Windows.Forms.TableLayoutPanel();
			this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.tableLayoutPanelInternal = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanelExternal.SuspendLayout();
			this.flowLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanelExternal
			// 
			this.tableLayoutPanelExternal.ColumnCount = 1;
			this.tableLayoutPanelExternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelExternal.Controls.Add(this.flowLayoutPanel, 0, 1);
			this.tableLayoutPanelExternal.Controls.Add(this.tableLayoutPanelInternal, 0, 0);
			this.tableLayoutPanelExternal.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelExternal.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanelExternal.Name = "tableLayoutPanelExternal";
			this.tableLayoutPanelExternal.RowCount = 2;
			this.tableLayoutPanelExternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelExternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanelExternal.Size = new System.Drawing.Size(897, 387);
			this.tableLayoutPanelExternal.TabIndex = 0;
			// 
			// flowLayoutPanel
			// 
			this.flowLayoutPanel.Controls.Add(this.okButton);
			this.flowLayoutPanel.Controls.Add(this.cancelButton);
			this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel.Location = new System.Drawing.Point(3, 350);
			this.flowLayoutPanel.Name = "flowLayoutPanel";
			this.flowLayoutPanel.Size = new System.Drawing.Size(891, 34);
			this.flowLayoutPanel.TabIndex = 0;
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.okButton.Location = new System.Drawing.Point(3, 3);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 0;
			this.okButton.Text = "Zapisz";
			this.okButton.UseVisualStyleBackColor = true;
			this.okButton.Click += new System.EventHandler(this.OkClick);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(84, 3);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Anuluj";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelCLick);
			// 
			// tableLayoutPanelInternal
			// 
			this.tableLayoutPanelInternal.ColumnCount = 2;
			this.tableLayoutPanelInternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelInternal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanelInternal.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanelInternal.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanelInternal.Name = "tableLayoutPanelInternal";
			this.tableLayoutPanelInternal.RowCount = 1;
			this.tableLayoutPanelInternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanelInternal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 341F));
			this.tableLayoutPanelInternal.Size = new System.Drawing.Size(891, 341);
			this.tableLayoutPanelInternal.TabIndex = 1;
			// 
			// AddEditForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(897, 387);
			this.Controls.Add(this.tableLayoutPanelExternal);
			this.Name = "AddEditForm";
			this.Text = "Dodawanie/Edycja";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
			this.tableLayoutPanelExternal.ResumeLayout(false);
			this.flowLayoutPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelExternal;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelInternal;
	}
}