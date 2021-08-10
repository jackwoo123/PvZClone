using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PvZClone
{


	public class SunFlower
	{
		public Texture2D sunflower_texture;
		int x, y;
		public SunFlower(Texture2D _texture, int _x, int _y)
		{
			sunflower_texture = _texture;
			x = _x;
			y = _y;

		}
		public void Draw(SpriteBatch spriteBatch)
		{

			spriteBatch.Begin();
			spriteBatch.Draw(sunflower_texture, new Vector2(x,y), Color.White);
			spriteBatch.End();


		}


	}
}