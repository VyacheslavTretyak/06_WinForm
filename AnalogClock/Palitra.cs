using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalogClock
{
	class Palitra
	{
		private Color[] colors;
		public Color this[int index]
		{
			get {
				if (index >= colors.Length)
				{
					index = colors.Length - 1;
				}
				if(index < 0)
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
				//Color.FromArgb(70, 18, 32),
				//Color.FromArgb(140, 47, 57),
				//Color.FromArgb(178, 58, 72),
				//Color.FromArgb(252, 185, 178),
				//Color.FromArgb(254, 208, 187),

				Color.FromArgb(80, 81, 79),
				Color.FromArgb(242, 95, 92),
				Color.FromArgb(255, 224, 102),
				Color.FromArgb(36, 123, 160),
				Color.FromArgb(112, 193, 179),
			};
		}

		
	}
}
