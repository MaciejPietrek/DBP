namespace Frontend.View.Controls
{
	partial class Filters<T>
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
			this.mainTableLayout = new System.Windows.Forms.TableLayoutPanel();
			this.applyFilterButton = new System.Windows.Forms.Button();
			this.mainTableLayout.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainTableLayout
			// 
			this.mainTableLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mainTableLayout.ColumnCount = 1;
			this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTableLayout.Controls.Add(this.applyFilterButton, 0, 1);
			this.mainTableLayout.Location = new System.Drawing.Point(3, 3);
			this.mainTableLayout.Name = "mainTableLayout";
			this.mainTableLayout.RowCount = 2;
			this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.mainTableLayout.Size = new System.Drawing.Size(634, 307);
			this.mainTableLayout.TabIndex = 0;
			// 
			// applyFilterButton
			// 
			this.applyFilterButton.Location = new System.Drawing.Point(3, 280);
			this.applyFilterButton.Name = "applyFilterButton";
			this.applyFilterButton.Size = new System.Drawing.Size(75, 23);
			this.applyFilterButton.TabIndex = 0;
			this.applyFilterButton.Text = "Filtruj";
			this.applyFilterButton.UseVisualStyleBackColor = true;
			// 
			// Filters
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.mainTableLayout);
			this.Name = "Filters";
			this.Size = new System.Drawing.Size(640, 313);
			this.mainTableLayout.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel mainTableLayout;
		private System.Windows.Forms.Button applyFilterButton;
	}
}
