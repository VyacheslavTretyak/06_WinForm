using ChessDesk.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessDesk
{
	public partial class ChessDeskForm : Form
	{		
		private ChessDesk desk;
		public ChessDeskForm()
		{
			InitializeComponent();
			desk = new ChessDesk(pbDesk);

			ClientSize = new Size(700, 500);			
			SizeChanged += ChessDeskForm_SizeChanged;	
			pbDesk.Image = desk.DrawDesk();
			MessageBox.Show("You can resizing window and moving any figures.\nPleasure game:)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		private void ChessDeskForm_SizeChanged(object sender, EventArgs e)
		{
			pbDesk.Image = desk.DrawDesk();
		}
	}
}
