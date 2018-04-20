namespace AnalogClock
{
	partial class AnalogClockForm
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
			this.btnClose = new System.Windows.Forms.Button();
			this.pCloseRegion = new System.Windows.Forms.Panel();
			this.lTime = new System.Windows.Forms.Label();
			this.picBox = new System.Windows.Forms.PictureBox();
			this.pCloseRegion.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
			this.SuspendLayout();
			// 
			// btnClose
			// 
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.ForeColor = System.Drawing.Color.White;
			this.btnClose.Location = new System.Drawing.Point(89, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(20, 20);
			this.btnClose.TabIndex = 0;
			this.btnClose.TabStop = false;
			this.btnClose.Text = "X";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// pCloseRegion
			// 
			this.pCloseRegion.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.pCloseRegion.Controls.Add(this.lTime);
			this.pCloseRegion.Controls.Add(this.btnClose);
			this.pCloseRegion.Location = new System.Drawing.Point(192, 0);
			this.pCloseRegion.Name = "pCloseRegion";
			this.pCloseRegion.Size = new System.Drawing.Size(109, 20);
			this.pCloseRegion.TabIndex = 1;
			// 
			// lTime
			// 
			this.lTime.AutoSize = true;
			this.lTime.Location = new System.Drawing.Point(3, 4);
			this.lTime.Name = "lTime";
			this.lTime.Size = new System.Drawing.Size(49, 13);
			this.lTime.TabIndex = 1;
			this.lTime.Text = "00:00:00";
			// 
			// picBox
			// 
			this.picBox.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.picBox.Location = new System.Drawing.Point(0, 20);
			this.picBox.Name = "picBox";
			this.picBox.Size = new System.Drawing.Size(300, 300);
			this.picBox.TabIndex = 2;
			this.picBox.TabStop = false;
			// 
			// AnalogClockForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(300, 320);
			this.Controls.Add(this.picBox);
			this.Controls.Add(this.pCloseRegion);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "AnalogClockForm";
			this.Text = "Form1";
			this.pCloseRegion.ResumeLayout(false);
			this.pCloseRegion.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Panel pCloseRegion;
		private System.Windows.Forms.PictureBox picBox;
		private System.Windows.Forms.Label lTime;
	}
}

