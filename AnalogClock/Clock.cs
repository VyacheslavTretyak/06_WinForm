using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace AnalogClock
{
	class Clock
	{
		private Graphics g;
		private Rectangle rect;
		private int radius = 0;
		private Point center;
		private Palitra palitra;
		public DateTime Time { get; set; }		
		public Clock(Rectangle rect)
		{			
			this.rect = rect;
			rect.Inflate(-1, -1);
			radius = rect.Width / 2;
			center = new Point(radius, radius);
			palitra = new Palitra();
		}
		public void Draw(Graphics graphics)
		{
			g = graphics;
			DrawBackGround();
			DrawArrows();
		}

		private void DrawArrows()
		{
			Pen pen = new Pen(palitra[1], 2);
			g.DrawLine(pen, center, ArrowCalc(radius-20f, Time.Second));
			pen = new Pen(palitra[3], 4);
			g.DrawLine(pen, center, ArrowCalc(radius - 30f, Time.Minute));
			pen = new Pen(palitra[0], 6);
			g.DrawLine(pen, center, ArrowCalc(radius - 40f, Time.Hour * 5 + Time.Minute/12));
		}

		private Point ArrowCalc(float radius, int val)
		{
			double x = center.X + Math.Cos((Math.PI*2) * (val / 60f) - Math.PI/2) * radius;
			double y = center.Y + Math.Sin((Math.PI*2) * (val / 60f) - Math.PI/2) * radius;
			return new Point((int)x, (int)y);
		}

		private void DrawBackGround()
		{
			Pen pen = new Pen(new SolidBrush(palitra[0]), 10);			
			g.DrawEllipse(pen, rect);			
			LinearGradientBrush grad = new LinearGradientBrush(rect, palitra[2], palitra[4], LinearGradientMode.Vertical);
			g.FillEllipse(grad, rect);
			g.DrawEllipse(pen, rect);
			pen = new Pen(new SolidBrush(palitra[3]),3);
			int l = 15;
			for (int i = 0; i < 60; i++)
			{
				if (i % 5 == 0)
				{
					l = 20;
				}
				else
				{
					l = 15;
				}
				g.DrawLine(pen, ArrowCalc(radius - l, i), ArrowCalc(radius - 10, i));
			}
			Font font = new Font(FontFamily.GenericMonospace, 12);
			SolidBrush brush = new SolidBrush(palitra[3]);
			g.DrawString("Tretyak V.", font, brush, new Point(center.X - 50, center.Y - 50));
		}
	}
}
