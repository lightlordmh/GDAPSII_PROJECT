using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

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
        Texture2D monsterImg; // the texture of the monster (using player 
        Texture2D keyTexture; // the texture of the keys

        Level level;
        Character player; // the player object
        List<Key> keys; // list of keys
        Map map; // defines the maps placement
        Input input; // handles input
        Monster monster; // the monster object

        Texture2D corridorimg;

        Random rng; // used to generate positions for keys
        double timer;

        int frame;
        double timePerFrame = 100;
        int numFrames = 3;
        int framesElapsed;
        const int CHAR_Y = 69;
        const int CHAR_HEIGHT = 72;
        const int CHAR_WIDTH = 55;
        const int CHAR_X_OFFSET = 145;

        enum CharState { WalkRight, WalkLeft, WalkUp, WalkDown, FaceRight, FaceLeft, FaceUp, FaceDown };
        CharState charState; // current state of the player character
        string pastDirection; // used to store the previous state

        // the various game states present in the game
        public enum GameState
        {
            MainMenu,
            Options,
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
            monster = new Monster(3200, 640, 160, 160, 10, 10);
            map = new Map(-3200, -320, 7680, 6240);
            rng = new Random();

            keys = new List<Key>();
            keys.Add(new Key(100, 100, 40, 40, "Normal"));

            level = new Level();
            input = new Input();

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

            // TODO: use this.Content to load your game content here
            playerImg = Content.Load<Texture2D>("Player Image");
            Settings.mapTexture.Add(Content.Load<Texture2D>("Map"));
            title = Content.Load<SpriteFont>("28DaysLater_70");
            text = Content.Load<SpriteFont>("28DaysLater_14");
            menuImg = Content.Load<Texture2D>("MenuScreen");
            monsterImg = Content.Load<Texture2D>("Player");
            keyTexture = Content.Load<Texture2D>("Key Sprite");
            corridorimg = Content.Load<Texture2D>("Player");
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

                    if (SingleKeyPress(Keys.Tab)) // stretch goal
                    {
                        IsMouseVisible = true;
                        currentState = GameState.PhoneMenu;
                    }

                    // Calculate the frame to draw based on the time
                    framesElapsed = (int)(gameTime.TotalGameTime.TotalMilliseconds / timePerFrame);
                    frame = framesElapsed % numFrames + 1;

                    // check for input and update position
                    string direction = input.Check(map);

                    if (!kbState.IsKeyDown(Keys.A) && !kbState.IsKeyDown(Keys.D) && !kbState.IsKeyDown(Keys.W) && !kbState.IsKeyDown(Keys.S))
                    {
                        if (pastDirection == "Walk Left")
                        {
                            direction = "Face Left";
                        }
                        if(pastDirection == "Walk Right")
                        {
                            direction = "Face Right";
                        }
                        if (pastDirection == "Walk Up")
                        {
                            direction = "Face Up";
                        }
                        if (pastDirection == "Walk Down")
                        {
                            direction = "Face Down";
                        }
                    }

                    pastDirection = direction; // store directiong for this update to use for comparison the next frame

                    // finite state machine
                    switch (direction)
                    {
                        case "Walk Left":
                            charState = CharState.WalkLeft;
                            break;
                        case "Walk Right":
                            charState = CharState.WalkRight;
                            break;
                        case "Walk Up":
                            charState = CharState.WalkUp;
                            break;
                        case "Walk Down":
                            charState = CharState.WalkDown;
                            break;

                        case "Face Left":
                            charState = CharState.FaceLeft;
                            break;
                        case "Face Right":
                            charState = CharState.FaceRight;
                            break;
                        case "Face Up":
                            charState = CharState.FaceUp;
                            break;
                        case "Face Down":
                            charState = CharState.FaceDown;
                            break;
                    }
                    monster.aiMove(player, map);
                    // updating position of objects
                    monster.UpdateCurrPos(map.X, map.Y);


                    for(int i = 0; i < keys.Count; i++)
                    {
                        keys[i].UpdateCurrPos(map.X, map.Y);
                    }

                    if(player.DamageCheck(monster) == true)
                    {
                        currentState = GameState.GameOver;
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
                spriteBatch.DrawString(text, "ESC  -  Exit", new Vector2((GraphicsDevice.Viewport.Height / 3) + 92, 405), Color.White);
            }
            if (currentState == GameState.Controls)
            {
                // draw the background
                int backgroundX = GraphicsDevice.Viewport.Width;
                int backgroundY = GraphicsDevice.Viewport.Height;
                spriteBatch.Draw(menuImg, new Rectangle(0, 0, backgroundX, backgroundY), Color.White);

                // draw a screen which teaches players how to control the game
                spriteBatch.DrawString(title, "Controls", new Vector2((GraphicsDevice.Viewport.Height / 5) + 50, 200), Color.White);
                spriteBatch.DrawString(text, "C to return to Main Menu", new Vector2((GraphicsDevice.Viewport.Height / 3) + 25, 285), Color.White);
                spriteBatch.DrawString(text, "A  -  Move Left", new Vector2((GraphicsDevice.Viewport.Height / 3) + 60, 360), Color.White);
                spriteBatch.DrawString(text, "S  -  Move Down", new Vector2((GraphicsDevice.Viewport.Height / 3) + 60, 405), Color.White);
                spriteBatch.DrawString(text, "D  -  Move Right", new Vector2((GraphicsDevice.Viewport.Height / 3) + 60, 450), Color.White);
                spriteBatch.DrawString(text, "Shift  -  Sprint", new Vector2((GraphicsDevice.Viewport.Height / 3) + 60, 495), Color.White);
            }
            if (currentState == GameState.MainGame)
            {
                //draw the map
                map.Draw(spriteBatch);

<<<<<<< HEAD
//<<<<<<< HEAD
//=======
=======
>>>>>>> 36eaed428f1f14389ccbd7a3fa5dcc708699deb8
                // testing corridors
                foreach (Corridor corridor in Settings.corridorList)
                {
                    corridor.UpdateCurrPos(map.XCurr, map.YCurr);
                    spriteBatch.Draw(playerImg, corridor.PositionCurr, Color.Red);
                }

<<<<<<< HEAD
//>>>>>>> c6b72f81626781076d804a45c83747d294b7c09d
=======
>>>>>>> 36eaed428f1f14389ccbd7a3fa5dcc708699deb8

                // draw the player to the screen
                // if the player is walking in a direction
                if (charState == CharState.WalkUp)
                {
                    spriteBatch.Draw(playerImg, new Vector2(player.X, player.Y), null, Color.White, 1.57f, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
                }
                if (charState == CharState.WalkRight)
                {
                    spriteBatch.Draw(playerImg, new Rectangle(CHAR_X_OFFSET + frame * player.Width, player.Y, player.Width, player.Height), null, Color.White);
                }
                if (charState == CharState.WalkDown)
                {
                    spriteBatch.Draw(playerImg, new Rectangle(player.X, player.Y + player.Height, player.Height, player.Height), null, Color.White, -1.57f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                }
                if (charState == CharState.WalkLeft)
                {
                    spriteBatch.Draw(playerImg, new Vector2(player.X, player.Y), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
                }

                // if the player is only facing a direction (not walking)
                if (charState == CharState.FaceUp)
                {
                    spriteBatch.Draw(playerImg, new Rectangle(player.X + player.Width, player.Y, player.Width, player.Height), null, Color.White, 1.57f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                }
                if (charState == CharState.FaceRight)
                {
                    spriteBatch.Draw(playerImg, player.Position, Color.White);
                }
                if (charState == CharState.FaceDown)
                {
                    spriteBatch.Draw(playerImg, new Rectangle(player.X, player.Y + player.Height, player.Height, player.Height), null, Color.White, -1.57f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                }
                if (charState == CharState.FaceLeft)
                {
                    spriteBatch.Draw(playerImg, player.Position, null, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                }

                // draw the keys to the map
                for (int i = 0; i < keys.Count; i++)
                {
                    keys[i].CurrentTexture = keyTexture;
                    keys[i].Draw(spriteBatch);
                }

                // draw the level, level score and timer
                spriteBatch.DrawString(text, "Level   " + Settings.currentLevel, new Vector2(5, 10), Color.White);
                spriteBatch.DrawString(text, "Key Pieces   " + player.NumKeyParts, new Vector2(5, 40), Color.White);
                spriteBatch.DrawString(text, String.Format("Timer   {0:0.00}", timer), new Vector2(5, 70), Color.White);


                foreach (Corridor corridor in Settings.corridorList)
                {
                    spriteBatch.Draw(corridorimg, corridor.Position, Color.Red);
                }

                //drawing the monster 
            }
            if (currentState == GameState.PhoneMenu) // stretch goal
            {

            }
            if (currentState == GameState.GameOver)
            {
                return; // ends the game
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
