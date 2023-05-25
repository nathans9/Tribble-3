using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tribble_3
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D Grey; //Grey goes up
        Texture2D Cream; //Cream goes side
        Texture2D Brown; //Brown goes on an angle
        Texture2D Orange; //Orange spins around

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferHeight = 640;
            _graphics.PreferredBackBufferWidth = 640;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            this.Window.Title = "Boing";
            Window.AllowUserResizing = false;
            Rectangle greyR = new Rectangle(300, 10, 50, 50);
            Rectangle creamR = new Rectangle(300, 10, 50, 50);
            Rectangle brownR = new Rectangle(300, 10, 50, 50);
            Rectangle orangeR = new Rectangle(300, 10, 50, 50);
            Vector2 speedG = new Vector2(0, 3);
            Vector2 speedC = new Vector2(3, 0);
            Vector2 speedB = new Vector2(4, 3);
            Vector2 speedO = new Vector2(3, 3);
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



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            // TODO: Add your drawing code here
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}