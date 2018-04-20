using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalogClock
{
	public partial class AnalogClockForm : Form
	{
		private Size szCloseRegion;
		private bool isMouseDown = false;
		private Point startMove;
		private Clock clock;
		private Timer timer;
		private Bitmap bmp;
		private Palitra palitra;
		public AnalogClockForm()
		{
			InitializeComponent();
			szCloseRegion = pCloseRegion.Size;
	
			bmp = new Bitmap(picBox.Width, picBox.Height);
			CutForm();
			clock = new Clock(picBox.ClientRectangle);
			palitra = new Palitra();

			btnClose.Click += BtnClose_Click;

			pCloseRegion.MouseEnter += PCloseRegion_MouseEnter;
			pCloseRegion.MouseLeave += PCloseRegion_MouseLeave;
			pCloseRegion.MouseDown += PCloseRegion_MouseDown;
			pCloseRegion.MouseUp += PCloseRegion_MouseUp;
			pCloseRegion.MouseMove += PCloseRegion_MouseMove;

			pCloseRegion.BackColor = palitra[0];
			lTime.ForeColor = palitra[2];
			pCloseRegion.Size = szCloseRegion;
			pCloseRegion.Location = new Point(Width - pCloseRegion.Width, 0);
			btnClose.BackColor = palitra[1];

			bmp = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);

			timer = new Timer();
			timer.Interval = 1000;
			timer.Tick += Timer_Tick;
			timer.Start();
		}	

		private void Timer_Tick(object sender, EventArgs e)
		{			
			Graphics g = Graphics.FromImage(bmp);
			g.Clear(Color.White);
			clock.Time = DateTime.Now;
			lTime.Text = $"{clock.Time.Hour:D2}:{clock.Time.Minute:D2}:{clock.Time.Second:D2}";
			clock.Draw(g);
			picBox.Image = bmp;
			g.Dispose();
		}
		private void PCloseRegion_MouseMove(object sender, MouseEventArgs e)
		{
			if (isMouseDown)
			{
				int x = MousePosition.X - Width + pCloseRegion.Width - startMove.X;
				int y = MousePosition.Y - startMove.Y;
				Location = new Point(x, y);
			}
		}

		private void PCloseRegion_MouseUp(object sender, MouseEventArgs e)
		{
			isMouseDown = false;	
		}

		private void PCloseRegion_MouseDown(object sender, MouseEventArgs e)
		{
			
			isMouseDown = true;
			startMove = e.Location ;
		}

		private void PCloseRegion_MouseLeave(object sender, EventArgs e)
		{
			pCloseRegion.Cursor = Cursors.Default;
		}

		private void PCloseRegion_MouseEnter(object sender, EventArgs e)
		{
			pCloseRegion.Cursor = Cursors.SizeAll;
		}

		private void BtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void CutForm()
		{
			GraphicsPath gpCircle = new GraphicsPath();
			Rectangle picRect = new Rectangle(new Point(0, 20), picBox.Size);
			gpCircle.AddEllipse(picRect);
			picBox.BackColor = Color.Gray;
			Region region = new Region(gpCircle);
			region.Union(new Rectangle(new Point(ClientRectangle.Width - szCloseRegion.Width, 0), szCloseRegion));
			Region = region;			
		}
	}
}
