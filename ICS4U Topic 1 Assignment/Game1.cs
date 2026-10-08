using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace ICS4U_Topic_1_Assignment
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        Texture2D theKnight, shade, aspid, aspidProjectile;

        Rectangle knightRect, shadeRect, aspidRect, aspidProjectileRect_1, aspidProjectileRect_2, aspidProjectileRect_3;

        float projectileRotation;

        Texture2D background;

        Random generator;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0, 0, 1536, 864);

            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            generator = new Random();

            knightRect = new Rectangle(generator.Next(1000, 1250), 450, 167, 275);
            shadeRect = new Rectangle(knightRect.X - 350, 500, 259, 208);
            aspidRect = new Rectangle(825, 250, 107, 137);

            aspidProjectileRect_1 = new Rectangle(1000, 300, 68, 69);
            aspidProjectileRect_2 = new Rectangle(975, 400, 68, 69);
            aspidProjectileRect_3 = new Rectangle(900, 450, 68, 69);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            background = Content.Load<Texture2D>("images/backgroundHollowKnight");

            theKnight = Content.Load<Texture2D>("images/theKnight");
            shade = Content.Load<Texture2D>("images/shade");
            aspid = Content.Load<Texture2D>("images/primalAspid");
            aspidProjectile = Content.Load<Texture2D>("images/primalAspidProjectiles");


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(background, window, Color.White);

            _spriteBatch.Draw(theKnight, knightRect, Color.White);
            _spriteBatch.Draw(shade, shadeRect, null,  Color.White * 0.75f, 0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 1f);
            _spriteBatch.Draw(aspid, aspidRect, null,  Color.White, 0f, new Vector2(aspidRect.Width / 2, aspidRect.Height / 2), SpriteEffects.FlipHorizontally, 1f);

            _spriteBatch.Draw(aspidProjectile, aspidProjectileRect_1, null, Color.White, 1.8f, new Vector2(aspidProjectileRect_1.Width / 2, aspidProjectileRect_1.Height / 2), SpriteEffects.FlipHorizontally, 1f);
            _spriteBatch.Draw(aspidProjectile, aspidProjectileRect_2, null, Color.White, 2f, new Vector2(aspidProjectileRect_2.Width / 2, aspidProjectileRect_2.Height / 2), SpriteEffects.FlipHorizontally, 1f);
            _spriteBatch.Draw(aspidProjectile, aspidProjectileRect_3, null, Color.White, 2.5f, new Vector2(aspidProjectileRect_3.Width / 2, aspidProjectileRect_3.Height / 2), SpriteEffects.FlipHorizontally, 1f);



            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
