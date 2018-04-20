using ChessDesk.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessDesk
{
	class ChessDesk
	{		
		private Palitra palitra;
		private List<ChessFigure> figures;
		private ChessFigure[,] field;
		public ChessFigure this[int indexX, int indexY]
		{
			get { return field[indexX, indexY]; }
			set { field[indexX, indexY] = value; }
		}
		public Point StartPoint { get; set; }
		public int QuadSize { get; set; } = 0;
		public PictureBox PicBox { get; set; }
		public ChessFigure[] defeatB;
		public ChessFigure[] defeatW;
		public ChessDesk(PictureBox pb)
		{
			PicBox = pb;
			palitra = new Palitra();
			figures = new List<ChessFigure>();
			field = new ChessFigure[8, 8];
			defeatB = new ChessFigure[16];
			defeatW = new ChessFigure[16];
			CalcSize();
			SetFigures();
		}

		private void SetFigures()
		{
			List<Image> imgs = new List<Image>()
			{
				Resources.rookB,
				Resources.knightB,
				Resources.bishopB,
				Resources.queenB,
				Resources.kingB,
			};
			int[] order = { 0, 1, 2, 3, 4, 2, 1, 0 };
			ChessFigure fig = null;
			for (int i = 0; i < 8; i++)
			{
				fig = new ChessFigure(ChessName.Pawn, ChessCommand.White, Resources.pawnB, palitra[4], $"{(char)('a'+i)}2", this);
				figures.Add(fig);
				fig = new ChessFigure((ChessName)(Enum.GetValues(typeof(ChessName)).GetValue(order[i])), ChessCommand.White, imgs[order[i]], palitra[4], $"{(char)('a' + i)}1", this);
				figures.Add(fig);
			}
			for (int i = 0; i < 8; i++)
			{
				fig = new ChessFigure(ChessName.Pawn, ChessCommand.Black, Resources.pawnB, palitra[1], $"{(char)('a' + i)}7", this);
				figures.Add(fig);
				fig = new ChessFigure((ChessName)(Enum.GetValues(typeof(ChessName)).GetValue(order[i])), ChessCommand.Black, imgs[order[i]], palitra[1], $"{(char)('a' + i)}8", this);
				figures.Add(fig);
			}
		}
		public void CalcSize()
		{
			Size formSize = PicBox.ClientSize;
			if (formSize.Width > formSize.Height)
			{
				QuadSize = formSize.Height / 9;
				StartPoint = new Point((formSize.Width - QuadSize * 8) / 2, QuadSize / 2);
			}
			else
			{
				QuadSize = formSize.Width / 9;
				StartPoint = new Point(QuadSize / 2, (formSize.Height - QuadSize * 8) / 2);
			}
		}
		public Bitmap DrawDesk()
		{
			Bitmap bmp = new Bitmap(PicBox.ClientSize.Width, PicBox.ClientSize.Height);
			Graphics g = Graphics.FromImage(bmp);
			CalcSize();
			g.Clear(palitra[0]);
			bool isFill = true;
			for (int x = 0; x < 8; x++)
			{
				for (int y = 0; y < 8; y++)
				{
					isFill = !isFill;
					Point p = new Point(StartPoint.X + x * QuadSize, StartPoint.Y + y * QuadSize);
					g.FillRectangle(new SolidBrush(palitra[isFill ? 2 : 3]), new Rectangle(p, new Size(QuadSize, QuadSize)));
				}
				isFill = !isFill;
			}
			Font font = new Font(FontFamily.GenericMonospace, QuadSize / 3);
			for (int y = 0; y < 8; y++)
			{
				Point p = new Point(StartPoint.X - QuadSize / 2, QuadSize / 4 + StartPoint.Y + y * QuadSize);
				g.DrawString((8 - y).ToString(), font, new SolidBrush(palitra[1]), p);
			}
			for (int x = 0; x < 8; x++)
			{
				Point p = new Point(QuadSize / 4 + StartPoint.X + x * QuadSize, StartPoint.Y + 8 * QuadSize);
				g.DrawString(((char)(97 + x)).ToString(), font, new SolidBrush(palitra[1]), p);

			}			
			g.Dispose();
			RedrawFigures();
			return bmp;
		}

		private void RedrawFigures()
		{
			foreach (ChessFigure fig in figures)
			{
				fig.Redraw();
			}
		}
	}
}
