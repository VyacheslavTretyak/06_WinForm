namespace ChessDesk
{
	partial class ChessDeskForm
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
			this.pbDesk = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pbDesk)).BeginInit();
			this.SuspendLayout();
			// 
			// pbDesk
			// 
			this.pbDesk.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.pbDesk.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbDesk.Location = new System.Drawing.Point(0, 0);
			this.pbDesk.Name = "pbDesk";
			this.pbDesk.Size = new System.Drawing.Size(284, 261);
			this.pbDesk.TabIndex = 0;
			this.pbDesk.TabStop = false;
			// 
			// ChessDeskForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.pbDesk);
			this.MinimumSize = new System.Drawing.Size(90, 90);
			this.Name = "ChessDeskForm";
			this.Text = "ChessDesk";
			((System.ComponentModel.ISupportInitialize)(this.pbDesk)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pbDesk;
	}
}

