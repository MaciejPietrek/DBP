using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frontend.View.Controls
{
	public class GridView : DataGridView
	{
		public GridView()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.SuspendLayout();
			// 
			// GridView
			// 
			this.AllowUserToAddRows = false;
			this.AllowUserToDeleteRows = false;
			this.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MinimumSize = new System.Drawing.Size(400, 300);
			this.MultiSelect = false;
			this.ReadOnly = true;
			this.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
			this.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
			this.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.Size = new System.Drawing.Size(400, 300);
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();
			this.ResumeLayout(false);

		}

		#region Properties

		/// <summary>
		/// Adds setting up sizes of columns created automatically
		/// </summary>
		public new object DataSource
		{
			get
			{
				return base.DataSource;
			}
			set
			{
				base.DataSource = value;
				if (InvokeRequired)
					Invoke(new Action(SetupColumnSizes), null);
				else
					SetupColumnSizes();
			}
		}

		#endregion Properties

		#region Methods

		/// <summary>
		/// Sets initial columns sizes so that they fit their contents
		/// </summary>
		private void SetupColumnSizes()
		{
			if (ColumnCount == 0)
				return;
			for (int i = 0; i < ColumnCount - 1; i++)
				Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			Columns[ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
		}

		#endregion Methods
	}
}
