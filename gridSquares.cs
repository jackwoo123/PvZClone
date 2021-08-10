using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PvZClone
{

	public class gridSquare
	{
		int x = 0;
		int y = 0;
		Boolean filled = false;
		public gridSquare(int _xBound, int _yBound, Boolean occupied)
		{
			x = _xBound;
			y = _yBound;
			filled = occupied;
		}
		public Boolean IsOccupied()
		{
			return filled;
		}
		
		public void SetOccupancy(Boolean value)
        {
			filled = value;
        }
		public int GetX()
        {
			return x;
        }
		public int GetY()
		{
			return y;
		}

	}
}