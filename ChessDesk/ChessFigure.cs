using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessDesk
{
	public enum ChessCommand
	{
		White,
		Black
	}
	public enum ChessName
	{
		Pawn,
		Rook,
		Knight,
		Bishop,
		Queen,
		King
	}
	class ChessFigure
	{				
		private ChessDesk desk;
		private Point moveLocation;
		private int defeat;
		public PictureBox PicBox { get; set; }
		private string position = "a1";		
		public string Position {
			get { return position; }
			set {  SetPosition(value); }
		}
		public ChessCommand Command { get; set; }
		public ChessName Name{ get; set; }


		public ChessFigure(ChessName name, ChessCommand command, Image img, Color col, string pos, ChessDesk desk)
		{
			this.desk = desk;
			CreatePicBox(img, col);
			Command = command;
			Name = name;
			Position = pos;		
		}		
		private void Defeat()
		{
			ChessFigure[] arr = null;
			if (Command == ChessCommand.Black)
			{
				arr = desk.defeatB;
			}
			else
			{
				arr = desk.defeatW;
			}
			defeat = -1;
			while (arr[++defeat] != null) ;
			arr[defeat] = this;
			desk[Position[0] - 'a', Position[1] - '1'] = null;			
			Position = "00";
		}
		private void SetDefeatPosition()
		{
			int column = 2;
			int raw = defeat;
			if (defeat > 7)
			{
				column++;
				raw -= 8;
			}
			if (Command == ChessCommand.Black)
			{				
				PicBox.Location = new Point(desk.StartPoint.X - desk.QuadSize * column, desk.StartPoint.Y + desk.QuadSize * raw);
			}
			else
			{
				PicBox.Location = new Point(desk.StartPoint.X + desk.QuadSize * (8 + column - 1), desk.StartPoint.Y + desk.QuadSize * raw);
			}
		}
		public void SetPosition(string pos)
		{
			SetRect();
			try
			{
				if(pos == "00")
				{			
					position = pos;
					SetDefeatPosition();
					return;
				}
				if(pos.Length != 2)
				{
					throw new Exception("Error length of position!");
				}
				if(pos[0]<'a' || pos[0] > 'h' || pos[1] < '1' || pos[1] > '8')
				{
					throw new Exception("Error position format!");
				}
				if (Position == "00")
				{
					Undo();
				}
				else
				{
					desk[Position[0] - 'a', Position[1] - '1'] = null;
				}
				position = pos;
				desk[Position[0] - 'a', Position[1] - '1'] = this;

				Point p = new Point(Position[0] - 'a', Position[1] - '1');	
				PicBox.Location = new Point(desk.StartPoint.X + desk.QuadSize * p.X, desk.StartPoint.Y + desk.QuadSize * (7-p.Y));				
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void Undo()
		{
			if(Command == ChessCommand.Black)
			{
				desk.defeatB[defeat] = null;
			}
			else
			{
				desk.defeatW[defeat] = null;
			}
		}
		public void SetRect()
		{
			PicBox.Size = new Size(desk.QuadSize, desk.QuadSize);			
		}
		private PictureBox CreatePicBox(Image img, Color col)
		{
			PicBox = new PictureBox();
			PicBox.Image = SetChessColor(img, col);
			PicBox.BackColor = Color.Transparent;			
			PicBox.SizeMode = PictureBoxSizeMode.StretchImage;
			PicBox.MouseDown += PicBox_MouseDown;
			PicBox.MouseUp += PicBox_MouseUp;
			PicBox.MouseMove += PicBox_MouseMove;
			desk.PicBox.Controls.Add(PicBox);
			PicBox.BringToFront();
			return PicBox;
		}

		private void PicBox_MouseMove(object sender, MouseEventArgs e)
		{		
			if(moveLocation != Point.Empty)
			{
				PicBox.BringToFront();
				Point p = PicBox.Location;
				p.X += e.X - moveLocation.X;
				p.Y += e.Y - moveLocation.Y;
				PicBox.Location = p;				
			}
		}

		private void SetQuad()
		{
			int half = desk.QuadSize / 2;
			Point p = new Point(PicBox.Location.X + half - desk.StartPoint.X, PicBox.Location.Y + half - desk.StartPoint.Y);
			int x = p.X / desk.QuadSize;
			int y = 7 - p.Y / desk.QuadSize;
			if(x<0 || x>7 || y<0 || y > 7)
			{
				Position = Position;
				return;
			}
			ChessFigure fig = desk[x, y];
			if (fig != null)
			{
				if (fig.Command != Command)
				{					
					Position = fig.Position;
					fig.Defeat();
				}
				else
				{
					Position = Position;//Return on previous position
				}	
			}
			else
			{
				Position = $"{(char)(x + 'a')}{y + 1}";			
			}			
		}
		

		private void PicBox_MouseUp(object sender, MouseEventArgs e)
		{
			moveLocation = Point.Empty;
			SetQuad();
		}

		private void PicBox_MouseDown(object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left)
			{
				moveLocation = new Point(e.X, e.Y);
			}
		}

		private Bitmap SetChessColor(Image img, Color col)
		{
			Bitmap bmp = new Bitmap(img);
			for (int x = 0; x < bmp.Width; x++)
			{
				for (int y = 0; y < bmp.Width; y++)
				{
					if (bmp.GetPixel(x, y) == Color.FromArgb(0, 0, 0))
					{
						bmp.SetPixel(x, y, col);
					}
				}
			}
			return bmp;
		}

		internal void Redraw()
		{
			SetPosition(Position);
		}
	}
}
