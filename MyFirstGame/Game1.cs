using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using TextureAtlas;

namespace MyFirstGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D background;
        private Texture2D shuttle;
        private Texture2D earth;

        private SpriteFont font;
        private int score = 0;

        private AnimatedSprite animatedSprite;

        private Texture2D arrow;
        private float angle = 0;

        private Texture2D blue;
        private Texture2D green;
        private Texture2D red;
        private float blueAngle = 0;
        private float greenAngle = 0;
        private float redAngle = 0;
        private float blueSpeed = 0.025f;
        private float greenSpeed = 0.017f;
        private float redSpeed = 0.022f;
        private float distance = 100;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            background = Content.Load<Texture2D>("stars");
            shuttle = Content.Load<Texture2D>("shuttle");
            earth = Content.Load<Texture2D>("earth");

            font = Content.Load<SpriteFont>("Score");

            Texture2D texture = Content.Load<Texture2D>("SmileyWalk");
            animatedSprite = new AnimatedSprite(texture, 4, 4);

            arrow = Content.Load<Texture2D>("arrow");

            blue = Content.Load<Texture2D>("blue");
            green = Content.Load<Texture2D>("green");
            red = Content.Load<Texture2D>("red");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            score++;

            animatedSprite.Update();

            angle += 0.01f;

            blueAngle += blueSpeed;
            greenAngle += greenSpeed;
            redAngle += redSpeed;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
            _spriteBatch.Draw(earth, new Vector2(400, 240), Color.White);
            _spriteBatch.Draw(shuttle, new Vector2(450, 240), Color.White);

            _spriteBatch.DrawString(font, "Score: " + score, new Vector2(100, 100), Color.White);

            Vector2 location = new Vector2(400, 120);  // where to draw sprite
            Rectangle sourceRectangle = new Rectangle(0, 0, arrow.Width, arrow.Height);
            Vector2 origin = new Vector2(arrow.Width / 2, arrow.Height);  // origin of rotation within texture
            _spriteBatch.Draw(arrow, location, sourceRectangle, Color.White, angle, origin, 1.0f, SpriteEffects.None, 1);

            _spriteBatch.End();

            Vector2 bluePosition = new Vector2(
                (float)Math.Cos(blueAngle) * distance,
                (float)Math.Sin(blueAngle) * distance
            );
            Vector2 greenPosition = new Vector2(
                (float)Math.Cos(greenAngle) * distance,
                (float)Math.Sin(greenAngle) * distance
            );
            Vector2 redPosition = new Vector2(
                (float)Math.Cos(redAngle) * distance,
                (float)Math.Sin(redAngle) * distance
            );
            Vector2 center = new Vector2(300, 140);  // center of circle

            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
            _spriteBatch.Draw(blue, center + bluePosition, Color.White);
            _spriteBatch.Draw(green, center + greenPosition, Color.White);
            _spriteBatch.Draw(red, center + redPosition, Color.White);
            _spriteBatch.End();

            animatedSprite.Draw(_spriteBatch, new Vector2(300, 200));

            base.Draw(gameTime);
        }
    }
}
