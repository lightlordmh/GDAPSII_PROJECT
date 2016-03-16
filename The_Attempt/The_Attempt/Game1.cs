using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

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

        SpriteFont title; // font used for Title on the Main Menus
        SpriteFont text; // font used for other text
        Texture2D menuImg; // background for the menu

        // keyboard attributes
        KeyboardState kbState; // current keyboard state
        KeyboardState previousKbState; // previous keyboardstate

        int currentLevel; // current level the player is on
        double timer; // timer for the level

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

            kbState = new KeyboardState(); // initialize keyboard state
            previousKbState = new KeyboardState(); // initialize previous keyboard state 
            currentState = GameState.MainMenu; // start the game off at the menu state
            IsMouseVisible = true; // Enable the mouse to be visable with in the game window
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
            title = Content.Load<SpriteFont>("28DaysLater_70");
            text = Content.Load<SpriteFont>("28DaysLater_14");
            menuImg = Content.Load<Texture2D>("MenuScreen");
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
            previousKbState = kbState;
            kbState = Keyboard.GetState();

            switch (currentState)
            {
                case GameState.MainMenu:
                    if (SingleKeyPress(Keys.Enter))
                    {
                        IsMouseVisible = false;
                        currentState = GameState.MainGame;
                    }
                    if(SingleKeyPress(Keys.C))
                    {
                        IsMouseVisible = true;
                        currentState = GameState.Controls;
                    }
                    break;
                case GameState.Controls:
                    // to return to the Main Menu from the Controls screen, press C again
                    if (SingleKeyPress(Keys.C))
                    {
                        IsMouseVisible = true;
                        currentState = GameState.MainMenu;
                    }


                    break;
                case GameState.MainGame:
                    // during the game, the player can press tab to bring up their phone menu
                    if (SingleKeyPress(Keys.Tab))
                    {
                        IsMouseVisible = true;
                        currentState = GameState.PhoneMenu;
                    }


                    break;
                case GameState.PhoneMenu:
                    // once in the phone menu screen, press tab again to return back to the game
                    if (SingleKeyPress(Keys.Tab))
                    {
                        IsMouseVisible = false;
                        currentState = GameState.MainGame;
                    }
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
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            player.CurrentTexture = playerImg;           

            if(currentState == GameState.MainMenu)
            { 
                // draw the background
                int backgroundX = GraphicsDevice.Viewport.Width;
                int backgroundY = GraphicsDevice.Viewport.Height;
                spriteBatch.Draw(menuImg, new Rectangle(0, 0, backgroundX, backgroundY), Color.White);

                // draw the text to the screen
                spriteBatch.DrawString(title, "The Attempt", new Vector2(GraphicsDevice.Viewport.Height / 5, 200), Color.White);
                spriteBatch.DrawString(text, "Enter  -  Launch Game", new Vector2((GraphicsDevice.Viewport.Height / 3) + 45, 315), Color.White);
                spriteBatch.DrawString(text, "C  -  Controls", new Vector2((GraphicsDevice.Viewport.Height / 3) + 80, 360), Color.White);
                
            }
            if (currentState == GameState.Controls)
            {
                // draw the background
                int backgroundX = GraphicsDevice.Viewport.Width;
                int backgroundY = GraphicsDevice.Viewport.Height;
                spriteBatch.Draw(menuImg, new Rectangle(0, 0, backgroundX, backgroundY), Color.White);

                // draw a screen which teaches players how to control the game
            }
            if (currentState == GameState.MainGame)
            {
                // draw the player to the screen
                spriteBatch.Draw(player.CurrentTexture, player.Position, Color.White);

                // draw the level, level score and timer
                spriteBatch.DrawString(text, "Level   " + currentLevel, new Vector2(5, 10), Color.White);
                spriteBatch.DrawString(text, "Key Pieces   " + player.NumKeyParts, new Vector2(5, 40), Color.White);
                spriteBatch.DrawString(text, String.Format("Timer   {0:0.00}", timer), new Vector2(5, 70), Color.White);
            }
            if (currentState == GameState.PhoneMenu)
            {

            }
            if (currentState == GameState.GameOver)
            {

            }
            
            
            spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// Returns true if this is the first frame that they key was pressed and false otherwise
        /// </summary>
        /// <param name="key">Key used to run the test on.</param>
        public bool SingleKeyPress(Keys key)
        {
            // if the key was pressed now but not in the previous state, this is the first frame that the key was pressed
            if (kbState.IsKeyDown(key) && previousKbState.IsKeyUp(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
