using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDesk
{
	class Palitra
	{
		private Color[] colors;
		public Color this[int index]
		{
			get
			{
				if (index >= colors.Length)
				{
					index = colors.Length - 1;
				}
				if (index < 0)
				{
					index = 0;
				}
				return colors[index];
			}
		}
		public Palitra()
		{
			colors = new Color[]
			{		
				Color.FromArgb(80, 81, 79),
				Color.FromArgb(242, 95, 92),
				Color.FromArgb(255, 224, 102),
				Color.FromArgb(36, 123, 160),
				Color.FromArgb(112, 193, 179),
			};
		}

	}
}
