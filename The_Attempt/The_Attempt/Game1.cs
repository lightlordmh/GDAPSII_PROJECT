using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace The_Attempt
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary> SOMETHING
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        GameState currentState;
        SpriteBatch spriteBatch;

        Texture2D playerImg;
        Character player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = Settings.WinHeight;
            graphics.PreferredBackBufferWidth = Settings.WinWidth;
        }

        public enum GameState
        {
            MainMenu,
            Controls,
            MainGame,
            GameOver,
            PhoneMenu,     
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            player = new Character(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2, 100, 100);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            playerImg = Content.Load<Texture2D>("Player");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            switch (currentState)
            {
                case GameState.MainMenu:
                    break;
                case GameState.Controls:
                    break;
                case GameState.MainGame:
                    break;
                case GameState.PhoneMenu:
                    break;
                case GameState.GameOver:
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            player.CurrentTexture = playerImg;
            spriteBatch.Draw(player.CurrentTexture, player.Position, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
