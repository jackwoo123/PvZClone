using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace PvZClone
{


    public class playerStats
    {
        public int sun=0;
    }



    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        //declare pictures here
        Texture2D gardenOverlay;
        Texture2D seeds_sprite;
        Texture2D Sunflower_sprite;
        List<SunFlower> plants = new List<SunFlower>();
        List<List<gridSquare>> grid = new List<List<gridSquare>>();

        //mouse dragging
        Boolean dragged = false;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 675;   //How much space there is dedicated! The pop up window doesnt show all of it unless its being used!
            _graphics.PreferredBackBufferHeight = 480;

            List<gridSquare> row=new List<gridSquare>(7);
            //TODO: implement a drag and drop system where the closet square is chosen.
            for(int i = 0; i < 5; i++)  //rows
            {
                for(int j = 0; j < 8; j++)  //columns for each row.
                {

                    int x = (j * 70) + 43;
                    int y = (i * 80) + 80;

                    row.Add(new gridSquare(x, y, false));
                    System.Diagnostics.Debug.WriteLine(x + " " + y);

                }
                grid.Add(row);
                row = new List<gridSquare>(7);
            }

            System.Diagnostics.Debug.WriteLine("Grid Created");

            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            gardenOverlay = Content.Load<Texture2D>("PvZGrid");
            seeds_sprite = Content.Load<Texture2D>("SeedSprites");
            //sunflower stuff
            Sunflower_sprite = Content.Load<Texture2D>("SunFlowerSprite");

            // TODO: use this.Content to load your game content here
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // TODO: Add your update logic here

            
            var mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);

            //If sunflower seed spot is clicked, drag and drop the sunflower onto the board.
            if(mouseState.LeftButton == ButtonState.Pressed && mousePosition.X > 76 && mousePosition.X<152   && mousePosition.Y <= 40)
            {
                dragged = true;
            }

            //else if(mouseState.LeftButton==ButtonState.Pressed && dragged)
            //{
            //    int column = (mousePosition.X - 50) / 70;
            //    int row = (mousePosition.Y + 100) / 144;
            //   plants.Add(new SunFlower(Sunflower_sprite, grid[row][column].GetX(), grid[row][column].GetY()));
            //    
            //}

            else if (mouseState.LeftButton == ButtonState.Released && dragged)
           {
                //Need to check if closest grid space is open.  start with 0,0

                int column = (mousePosition.X-80)/70;
                int row = (mousePosition.Y-80) / 80;
                //TODO:Fix this somehow
                if (row<5 && column <8 && !grid[row][column].IsOccupied())
                {
                    //System.Diagnostics.Debug.WriteLine("Sunflower Spawn");
                    dragged = false;

                    System.Diagnostics.Debug.WriteLine(row + " "+ column);
                    //System.Diagnostics.Debug.WriteLine(mousePosition.X/7 + " " + mousePosition.Y/5);
                    grid[row][column].SetOccupancy(true);
                    plants.Add(new SunFlower(Sunflower_sprite, grid[row][column].GetX(), grid[row][column].GetY()));
                }

                
           }

            
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(seeds_sprite, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(gardenOverlay, new Vector2(0, 50), Color.White);
            _spriteBatch.End();

            foreach(SunFlower flower in plants)
            {
                flower.Draw(_spriteBatch);
            }


            base.Draw(gameTime);
        }
    }
}
