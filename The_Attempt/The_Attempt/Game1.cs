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
        CollDetect collDetect;
        Texture2D doorImg;
        Texture2D flashLightOn;
        Texture2D flashLightOff;

        Level level;
        Character player; // the player object
        List<Key> keys; // list of keys
        Map map; // defines the maps placement
        Input input; // handles input
        Monster monster; // the monster object
        Key key;
        Door door;

        Texture2D corridorimg;

        Random rng; // used to generate positions for keys
        double timer;
        bool lightOn = true;
        int invincible = 0;

        int frame;
        double timePerFrame = 100;
        int numFrames = 7;
        int framesElapsed;
        const int CHAR_Y = 0;
        const int CHAR_HEIGHT = 64;
        const int CHAR_WIDTH = 44;
        const int CHAR_X_OFFSET = 156;

        enum CharState { WalkRight, WalkLeft, WalkUp, WalkDown, FaceRight, FaceLeft, FaceUp, FaceDown }
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




            player = new Character((GraphicsDevice.Viewport.Width / 2) - (CHAR_WIDTH/2), (GraphicsDevice.Viewport.Height / 2) - (CHAR_HEIGHT/2), CHAR_WIDTH, CHAR_HEIGHT);
            monster = new Monster(3520, 960, 160, 160, 1, 2);

            map = new Map(-3200, -320, 7680, 6240);
            rng = new Random();
            collDetect = new CollDetect();

            keys = new List<Key>();
            keys.Add(new Key(100, 100, 40, 40, "Normal")); 

            level = new Level();
            input = new Input();

            key = new Key(4000, 960, 80, 80, "full");  //to move the key to a more in depth part of the maze put in these instead of 4000, 960  (2560,3840)
            door = new Door(4000, 1280, 100, 100);    // same with the door (5760, 4640)

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
            monsterImg = Content.Load<Texture2D>("Enemy Image");
            keyTexture = Content.Load<Texture2D>("Key Sprite");
            corridorimg = Content.Load<Texture2D>("Player");
            doorImg = Content.Load<Texture2D>("MenuScreen");
            flashLightOn = Content.Load<Texture2D>(Settings.Flashlight);
            flashLightOff = Content.Load<Texture2D>("FLON3");
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
                        monster.CurrentTexture = monsterImg;
                        key.CurrentTexture = keyTexture;
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
                    if (SingleKeyPress(Keys.Space)) // stretch goal
                    {
                        if (lightOn) lightOn = false;
                        else lightOn = true;
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
                    // updating position of objects
                    monster.aiMove(player,map);
                    monster.UpdateCurrPos(map.XCurr, map.YCurr);

                    //key stuff
                    key.UpdateCurrPos(map.XCurr, map.YCurr);
                    if(collDetect.SimpleCheck(player.PositionCurr, key.PositionCurr) == true && key.Rendered)
                    {
                        key.Rendered = false;
                        door.Open = true;
                        player.NumKeyParts++;
                    }

                    //door
                    door.UpdateCurrPos(map.XCurr, map.YCurr);

                    for(int i = 0; i < keys.Count; i++)
                    {
                        keys[i].UpdateCurrPos(map.XCurr, map.YCurr);
                    }

                    if(collDetect.SimpleCheck(player.PositionCurr, monster.PositionCurr) == true && invincible <= 0)
                    {
                        invincible = 120;
                        player.Health--;
                        if (player.Health <= 0)
                        {
                            currentState = GameState.GameOver;
                        }
                    }

                    if(invincible > 0) //reduces the time of invincible
                    {
                        invincible--;
                    }

                    if(collDetect.SimpleCheck(player.PositionCurr, door.PositionCurr) == true && player.NumKeyParts > 0)
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
                    player.Health = 3;
                    player.NumKeyParts = 0;

                    if(SingleKeyPress(Keys.Enter))
                    {
                        currentState = GameState.MainMenu;
                    }
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

                // draw the player to the screen
                /* // if the player is walking in a direction
                 if (charState == CharState.WalkUp)
                 {
                     spriteBatch.Draw(playerImg, new Vector2(player.X, player.Y), null, Color.White, 1.57f, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
                 }
                 if (charState == CharState.WalkRight)
                 {
                     spriteBatch.Draw(playerImg, player.Position, new Rectangle(CHAR_X_OFFSET + frame * player.Width, CHAR_Y, player.Width, player.Height), Color.White);
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
                     spriteBatch.Draw(playerImg, player.Position, new Rectangle(0, 0, player.Width, player.Height), Color.White, 1.57f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                 }
                 if (charState == CharState.FaceRight)
                 {
                     spriteBatch.Draw(playerImg, player.Position, new Rectangle(0, 0, player.Width, player.Height), Color.White);
                 }
                 if (charState == CharState.FaceDown)
                 {
                     spriteBatch.Draw(playerImg, player.Position, new Rectangle(0, 0, player.Width, player.Height), Color.White, -1.57f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                 }
                 if (charState == CharState.FaceLeft)
                 {
                     spriteBatch.Draw(playerImg, player.Position, new Rectangle(0, 0, player.Width, player.Height), Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                 }
 */

                //key rendering
                if(key.Rendered == true)
                {
                    key.Draw(spriteBatch);
                }

                door.Draw(spriteBatch, doorImg, doorImg);

                player.Draw(spriteBatch);

                // draw the keys to the map
                for (int i = 0; i < keys.Count; i++)
                {
                    keys[i].CurrentTexture = keyTexture;
                    keys[i].Draw(spriteBatch);
                }

                //drawing the monster
                monster.Draw(spriteBatch);

                //draw the Flashlight
                if (lightOn)
                {
                    spriteBatch.Draw(flashLightOn, new Vector2(-90, -100), Color.White);
                }
                else
                {
                    spriteBatch.Draw(flashLightOff, new Vector2(-90, -100), Color.White);
                }
                // draw the level, level score and timer
                spriteBatch.DrawString(text, "Level   " + Settings.currentLevel, new Vector2(5, 10), Color.White);
                spriteBatch.DrawString(text, "Key Pieces   " + player.NumKeyParts, new Vector2(5, 40), Color.White);
                spriteBatch.DrawString(text, String.Format("Timer   {0:0.00}", timer), new Vector2(5, 70), Color.White);
                spriteBatch.DrawString(text, "Health: " + player.Health, new Vector2(5, 100), Color.White);
        //        spriteBatch.DrawString(text, "" + monster.X, new Vector2(5, 130), Color.White);
         //       spriteBatch.DrawString(text, "" + monster.Y, new Vector2(5, 160), Color.White);
         //       spriteBatch.DrawString(text, "" + monster.Width, new Vector2(5, 190), Color.White);
            }
            if (currentState == GameState.PhoneMenu) // stretch goal
            {

            }
            if (currentState == GameState.GameOver)
            {
                // currentState = GameState.MainMenu;
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
