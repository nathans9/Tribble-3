using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Tribble_3
{
    //TO DO
    //Fix teleptortain
    public class Game1 : Game
    {
        public static GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D Grey; //Grey goes up
        Texture2D Cream; //Cream goes side
        Texture2D Brown; //Brown goes on an angle
        Texture2D Orange; //Orange spins around
        public static Rectangle greyR;
        public static Rectangle creamR;
        public static Rectangle brownR;
        public static Rectangle orangeR;
        public static Vector2 speedG;
        public static Vector2 speedC;
        public static Vector2 speedB;
        public static Vector2 speedO;
        public static Rectangle check; //this is set to the values of the tribble rectangles to adjust the properties of each tribble simply
        public static Vector2 swap; //this is set the the speed vector of the tribbles to swap their speeds when they collide
        public static bool restrain; //this determines whether the tribbles leave the screen or not

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.PreferredBackBufferWidth = 900;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            this.Window.Title = "Boing";
            Window.AllowUserResizing = false;
            greyR = new Rectangle(100, 10, 100, 100);
            creamR = new Rectangle(300, 300, 100, 100);
            brownR = new Rectangle(500, 400, 100, 100);
            orangeR = new Rectangle(800, 200, 100, 100);
            speedG = new Vector2(0, 3);
            speedC = new Vector2(3, 0);
            speedB = new Vector2(4, 3);
            speedO = new Vector2(3, 3);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Grey = Content.Load<Texture2D>("tribbleGrey");
            Cream = Content.Load<Texture2D>("tribbleCream");
            Brown = Content.Load<Texture2D>("tribbleBrown");
            Orange = Content.Load<Texture2D>("tribbleOrange");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            CollisionCheck();

            //Grey
            restrain = true;
            check = greyR;
            swap = speedG;
            BoundaryCheck();
            greyR = check;
            speedG = swap;
            greyR.X += (int)speedG.X;
            greyR.Y += (int)speedG.Y;

            //Cream
            restrain = false;
            creamR.X += (int)speedC.X;
            creamR.Y += (int)speedC.Y;

            check = creamR;
            BoundaryCheck();
            creamR = check;
            
            //Brown
            restrain = false;
            brownR.X += (int)speedB.X;
            brownR.Y += (int)speedB.Y;

            check = brownR;
            BoundaryCheck();
            brownR = check;
            
            //Orange
            restrain = true;
            check = orangeR;
            swap = speedO;
            BoundaryCheck();
            orangeR = check;
            speedO = swap;
            orangeR.X += (int)speedO.X;
            orangeR.Y += (int)speedO.Y;

            Debug.WriteLine(brownR.X);
            Debug.WriteLine(brownR.Y);

            base.Update(gameTime);
        }

        public static void CollisionCheck()
        {
            if (greyR.Intersects(creamR))
            {
                Vector2 a, b;
                a = speedG;
                b = speedC;
                speedG = b;
                speedC = a;
            }

            if (greyR.Intersects(orangeR))
            {
                Vector2 a, b;
                a = speedG;
                b = speedO;
                speedG = b;
                speedO = a;
            }

            if (greyR.Intersects(brownR))
            {
                Vector2 a, b;
                a = speedG;
                b = speedB;
                speedG = b;
                speedB = a;
            }

            if (creamR.Intersects(orangeR))
            {
                Vector2 a, b;
                a = speedO;
                b = speedC;
                speedO = b;
                speedC = a;
            }

            if (creamR.Intersects(brownR))
            {
                Vector2 a, b;
                a = speedB;
                b = speedC;
                speedB = b;
                speedC = a;
            }

            if (brownR.Intersects(orangeR))
            {
                Vector2 a, b;
                a = speedO;
                b = speedB;
                speedO = b;
                speedB = a;
            }

        }
        public static void BoundaryCheck()
        {
            if (!restrain)
            {
                //if (check.X < 0 && check.Y < 0)
                //{
                //    check.X = _graphics.PreferredBackBufferWidth - 2;
                //    check.Y = _graphics.PreferredBackBufferHeight - 2;
                //}

                if (check.Top > _graphics.PreferredBackBufferHeight)
                    check.Y = -check.Height;
                else if (check.Bottom < 0)
                    check.Y = _graphics.PreferredBackBufferHeight;

                if (check.Left > _graphics.PreferredBackBufferWidth)
                    check.X = -check.Width;
                else if (check.Right < 0)
                    check.X = _graphics.PreferredBackBufferWidth;
            }
            else
            {
                if (check.Bottom >= _graphics.PreferredBackBufferHeight)
                {
                    //check.Y = _graphics.PreferredBackBufferHeight;
                    swap.Y = -swap.Y;
                }
                else if (check.Top <= 0)
                {
                    //check.Y = 1;
                    swap.Y = -swap.Y;
                }
                else if (check.Right >= _graphics.PreferredBackBufferWidth)
                {
                    //check.X = _graphics.PreferredBackBufferWidth;
                    swap.X = -swap.X;
                }
                else if (check.Left <= 0)
                {
                    //check.X = 1;
                    swap.X = -swap.X;
                }
            }
            
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(Grey, greyR, Color.White);
            _spriteBatch.Draw(Cream, creamR, Color.White);
            _spriteBatch.Draw(Brown, brownR, Color.White);
            _spriteBatch.Draw(Orange, orangeR, Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}