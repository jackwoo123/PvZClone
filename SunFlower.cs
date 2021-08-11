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
		//TODO:Create a value that tracks the starting time that the sunflower spawned.

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

		public void Update()
        {

			//TODO: Make a timing system such that every 5 seconds 50 sun spawns on the players counter!

        }


	}
}