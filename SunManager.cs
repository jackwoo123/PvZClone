using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace PvZClone
{
	public class SunManager
	{
		int Sun = 50;

		public SunManager()
		{
		}

		public void AddSun(int x)
		{
			Sun = Sun + x;
		}

		public Boolean EnoughSun(int x)
		{

			if (Sun > x) return true;
			return false;

		}

		public void SubtractSun(int x)
		{
			Sun = Sun - x;
		}


	}
}
