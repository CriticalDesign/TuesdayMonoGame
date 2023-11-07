using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TuesdayMonoGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _hero, _skelly;
        private int _heroX, _heroY, _heroSpeed;

        private SpriteFont _gameFont, _gameFont2;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _heroX = 10;
            _heroY = 10;
            _heroSpeed = 5;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _hero = Content.Load<Texture2D>("Hero");
            _skelly = Content.Load<Texture2D>("Skelly");
            _gameFont = Content.Load<SpriteFont>("GameFont");
            _gameFont2 = Content.Load<SpriteFont>("GameFont2");


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if(Keyboard.GetState().IsKeyDown(Keys.Right))
                _heroX += _heroSpeed;

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                _heroY += _heroSpeed;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(_hero, new Rectangle(_heroX, _heroY, _hero.Width / 3, _hero.Height / 3), Color.White * 0.5f);  //the 0.5f fades the image by 50%
            _spriteBatch.Draw(_skelly, new Rectangle(250, 250, _skelly.Width / 5, _skelly.Height / 5), Color.White);  //the 

            _spriteBatch.DrawString(_gameFont, "My Awesome Game!", new Vector2(150, 150), Color.White);
            _spriteBatch.DrawString(_gameFont2, "My Awesome Game!", new Vector2(150, 200), Color.Yellow);

            //public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth)
            //_spriteBatch.Draw(_hero, new Rectangle(50, 100, _hero.Width/2, _hero.Height/2), null,  Color.CornflowerBlue * 0.5f, 0.5f, new Vector2(_hero.Width / 2, _hero.Height / 2), SpriteEffects.FlipHorizontally, 0);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}