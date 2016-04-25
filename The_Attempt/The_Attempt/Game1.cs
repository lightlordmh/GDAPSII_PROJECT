using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace The_Attempt
{
    // Authors: Israel Anthony, Kyle Vanderwiel, Russell Swartz, Evan Keating
    /// <summary>
    /// This is the Main Game class. It handles the game loop, current state and logic
    /// </summary> 
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // menu attributes
        SpriteFont title; // font used for Title on the Main Menus
        SpriteFont text; // font used for other text
        Texture2D menuImg; // background for the menu

        // keyboard attributes (used to switch between game states)
        KeyboardState kbState; // current keyboard state
        KeyboardState previousKbState; // previous keyboardstate


        // in-game attributes
        Texture2D playerImg; // the texture for the player
        Texture2D monsterImg; //the texture of the monster (using player 
        Level level;
        Character player; // the player object
        Map map; // defines the maps placement
        Input input; // handles input
        Monster monster; // the monster object


        double timer; // timer for the level

        // the various game states present in the game
        public enum GameState
        {
            MainMenu,
            Controls,
            MainGame,
            GameOver,
            PhoneMenu,     
        }
        GameState currentState; // the current game state

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // set the window to the dimensions defined in the Settings class
            graphics.PreferredBackBufferHeight = Settings.WinHeight; 
            graphics.PreferredBackBufferWidth = Settings.WinWidth;
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
           
            IsMouseVisible = true; // Enable the mouse to be visable with in the game window
            currentState = GameState.MainMenu; // start the game off at the menu state

            // initialize attributes and place objects
            kbState = new KeyboardState();
            previousKbState = new KeyboardState();
            player = new Character(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2, 80, 80);
            monster = new Monster(3200, 640, 80, 80, 10, 10);
            map = new Map(-3200, -320, 7680, 6240);
            base.Initialize();
            level = new Level();
            input = new Input();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            playerImg = Content.Load<Texture2D>("Player");
            Settings.mapTexture.Add(Content.Load<Texture2D>("Map"));
            title = Content.Load<SpriteFont>("28DaysLater_70");
            text = Content.Load<SpriteFont>("28DaysLater_14");
            menuImg = Content.Load<Texture2D>("MenuScreen");
            monsterImg = Content.Load<Texture2D>("Player");
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

                        level.LoadCorridors();
                        map.SetMapTexture();
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

                    //check for input and update position
                    input.Check(map);

                    //updating position of objects
                    monster.UpdateCurrPos(map.X, map.Y);

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
                    Settings.currentLevel = 0;
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
                //draw the map
                map.Draw(spriteBatch);

                //testing
                foreach (Corridor corridor in Settings.corridorList)
                {
                    corridor.UpdateCurrPos(map.XCurr, map.YCurr);
                    spriteBatch.Draw(playerImg, corridor.PositionCurr, Color.Red);
                }
                // draw the player to the screen
                spriteBatch.Draw(player.CurrentTexture, player.Position, Color.White);
                // draw the level, level score and timer
                spriteBatch.DrawString(text, "Level   " + Settings.currentLevel, new Vector2(5, 10), Color.White);
                spriteBatch.DrawString(text, "Key Pieces   " + player.NumKeyParts, new Vector2(5, 40), Color.White);
                spriteBatch.DrawString(text, String.Format("Timer   {0:0.00}", timer), new Vector2(5, 70), Color.White);

                // draw the objects on the screen



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
