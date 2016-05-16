using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
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

        //songs and sound effects
        Song menuTheme, mainTheme, winTheme, endTheme; // background music
        List<SoundEffect> soundEffects;// list of sound effects
        SoundEffectInstance instance;//instance of the walking sound effect
        SoundEffectInstance pkupKey;// instance of the key pickup sound effect
        SoundEffectInstance doorSealed;// instance of the door sealed sound effect


        // keyboard attributes (used to switch between game states)
        KeyboardState kbState; // current keyboard state
        KeyboardState previousKbState; // previous keyboardstate


        // in-game attributes
        Texture2D playerImg; // the texture for the player
        Texture2D monsterImg; // the texture of the monster (using player 
        Texture2D keyTexture; // the texture of the keys
        CollDetect collDetect;
        Texture2D loseScreen;
        Texture2D winScreen;
        Texture2D doorImg;
        Texture2D flashLightOn;
        Texture2D flashLightOff;

        Level level;
        Character player; // the player object
        List<Key> keys; // list of keys
        List<Door> doors; // list of doors
        Map map; // defines the maps placement
        Input input; // handles input
        Monster monster; // the monster object

        Texture2D corridorimg;

        Random rng; // used to generate positions for keys
        bool lightOn = true;
        int invincible = 0;

        int frame;
        double timePerFrame = 100;
        int numFrames = 7;
        int framesElapsed;
        double timer;

        int enemyFrame;
        int enemyFramesElapsed;

        const int CHAR_Y = 0;
        const int CHAR_HEIGHT = 64;
        const int CHAR_WIDTH = 46;
        const int CHAR_X_OFFSET = 4;




        const int ENEMY_Y = 0;
        const int ENEMY_HEIGHT = 160;
        const int ENEMY_WIDTH = 160;
        const int ENEMY_X_OFFSET = 2;



        enum CharState { WalkRight, WalkLeft, WalkUp, WalkDown, FaceRight, FaceLeft, FaceUp, FaceDown }
        CharState charState; // current state of the player character
        string pastDirection; // used to store the previous state

        enum EnemyState { WalkRight, WalkLeft, WalkUp, WalkDown }
        EnemyState enemyState;

        // the various game states present in the game
        enum GameState { MainMenu, Options, Controls, MainGame, GameOver, MapOverlay, Winner }
        GameState currentState; // the current game state
        GameState oldState;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // set the window to the dimensions defined in the Settings class
            graphics.PreferredBackBufferHeight = Settings.WinHeight; 
            graphics.PreferredBackBufferWidth = Settings.WinWidth;
            Settings.Setup("GameSettings.txt");

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
            oldState = GameState.GameOver;
            // initialize attributes and place objects
            kbState = new KeyboardState();
            previousKbState = new KeyboardState();

            level = new Level();
            input = new Input();
            collDetect = new CollDetect();

            player = new Character((GraphicsDevice.Viewport.Width / 2) - (CHAR_WIDTH/2), (GraphicsDevice.Viewport.Height / 2) - (CHAR_HEIGHT/2), CHAR_WIDTH, CHAR_HEIGHT);

            monster = new Monster(3520, 960, ENEMY_WIDTH, ENEMY_HEIGHT, 4, 8);

            map = new Map(-3200, -320, 7680, 6240);

            rng = new Random();

            // place player, monster, keys, and doors on the map
            map = new Map(-3200, -320, 7680, 6240);
            player = new Character((GraphicsDevice.Viewport.Width / 2) - (CHAR_WIDTH / 2), (GraphicsDevice.Viewport.Height / 2) - (CHAR_HEIGHT / 2), CHAR_WIDTH, CHAR_HEIGHT);
            monster = new Monster(3520, 960, ENEMY_WIDTH, ENEMY_HEIGHT, 8, 2);
            keys = new List<Key>();
            doors = new List<Door>();
            keys.Add(new Key(2560 + 40, 3840 + 40, 80, 80, "full"));  
            keys.Add(new Key(5760 + 40, 640 + 40, 80, 80, "full"));
            keys.Add(new Key(6240 + 40, 2880 + 40, 80, 80, "full"));
            keys.Add(new Key(3840 + 40, 2560 + 40, 80, 80, "full"));
            keys.Add(new Key(960 + 40, 1440 + 40, 80, 80, "full"));
            keys.Add(new Key(2240 + 40, 5440 + 40, 80, 80, "full"));
            doors.Add(new Door(1120 + 20, 4160 + 20, 120, 120));
            doors.Add(new Door(4480 + 20, 3840 + 20, 120, 120));

            soundEffects = new List<SoundEffect>(); //initialize sound effects list

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
            //Load all textures used in the game
            playerImg = Content.Load<Texture2D>("Player Imagev2");
            Settings.mapTexture.Add(Content.Load<Texture2D>("Map"));
            title = Content.Load<SpriteFont>("28DaysLater_70");
            text = Content.Load<SpriteFont>("28DaysLater_14");
            menuImg = Content.Load<Texture2D>("MenuScreen");
            monsterImg = Content.Load<Texture2D>("Enemy Imagev3");
            keyTexture = Content.Load<Texture2D>("Key Sprite");
            corridorimg = Content.Load<Texture2D>("Player");
            doorImg = Content.Load<Texture2D>("Trapdoor");
            flashLightOn = Content.Load<Texture2D>(Settings.Flashlight);
            flashLightOff = Content.Load<Texture2D>("FLON3");
            loseScreen = Content.Load<Texture2D>("Game Over");
            winScreen = Content.Load <Texture2D>("Win Screen");

            //Load all songs used in the game
            menuTheme = Content.Load<Song>("MenuTheme");
            mainTheme = Content.Load<Song>("MainTheme");
            endTheme = Content.Load<Song>("EndTheme");
            MediaPlayer.IsRepeating = true;//set the media player to repeat after a song ends
            MediaPlayer.Volume = 0.5f;
       
            //Load all Sound Effects in the game
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/w_pkup"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/stone_step1"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/stone_step2"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/stone_step3"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/stone_step4"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/door_stone_move"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/door_sealed"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/pain50"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/pain75"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/pain100"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/death1"));
            soundEffects.Add(Content.Load<SoundEffect>("SoundEffects/death3"));
            SoundEffect.MasterVolume = 0.5f;//set global sound effect volume
            //create instances of specific sound effects for more control
            instance = soundEffects[0].CreateInstance();
            pkupKey = soundEffects[0].CreateInstance();
            doorSealed = soundEffects[6].CreateInstance();


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
                    //if the current state is new stop the previous song and play the menuTheme
                    if (currentState != oldState)
                    {
                        MediaPlayer.Stop();
                        MediaPlayer.Play(menuTheme);
                    }
                    oldState = currentState;
                    if (SingleKeyPress(Keys.Enter))
                    {
                        IsMouseVisible = false;
                        currentState = GameState.MainGame;

                        level.LoadCorridors();
                        map.SetMapTexture();
                        monster.CurrentTexture = monsterImg;

                        for(int i = 0; i < keys.Count; i++)
                        {
                            keys[i].CurrentTexture = keyTexture;
                        }
                        for (int i = 0; i < doors.Count; i++)
                        {
                            doors[i].CurrentTexture = doorImg;
                        }
                    }
                    if(SingleKeyPress(Keys.C))
                    {
                        IsMouseVisible = true;
                        currentState = GameState.Controls;
                    }
                    break;
                case GameState.Controls:
                    //if the current state is new stop the previous song and play the menuTheme
                    if (currentState != oldState)
                    {
                        MediaPlayer.Stop();
                        MediaPlayer.Play(menuTheme);
                    }
                    oldState = currentState;
                    // to return to the Main Menu from the Controls screen, press C again
                    if (SingleKeyPress(Keys.C))
                    {
                        IsMouseVisible = true;
                        currentState = GameState.MainMenu;
                    }
                    
                    break;
                case GameState.MainGame:
                    //if the current state is new stop the previous song and play the mainTheme
                    if (currentState != oldState)
                    {
                        MediaPlayer.Stop();
                        MediaPlayer.Play(mainTheme);
                    }
                    oldState = currentState;
                    // during the game, the player can press tab to bring up the map overlay
                    if (SingleKeyPress(Keys.Tab))
                    {
                        IsMouseVisible = true;
                        currentState = GameState.MapOverlay;
                    }
                    //Space To Control the Flashlight On/ Off
                    if (SingleKeyPress(Keys.Space)) 
                    {
                        if (lightOn) lightOn = false;
                        else lightOn = true;
                    }

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

                    //if the current sound efects is stopped generate a new instance with random walking sound effect
                    if(instance.State == SoundState.Stopped)
                    {
                        instance = soundEffects[rng.Next(1, 4)].CreateInstance();
                    }
                    // finite state machine
                    switch (direction)
                    {
                        case "Walk Left":
                            //if the current sound effect is not playing play it
                            if (instance.State == SoundState.Stopped)
                            {
                                instance.Play( );
                            }
                            // Calculate the frame to draw based on the time
                            framesElapsed = (int)(gameTime.TotalGameTime.TotalMilliseconds / timePerFrame);
                            frame = framesElapsed % numFrames + 1;
                            charState = CharState.WalkLeft;
                            break;
                        case "Walk Right":
                            //if the current sound effect is not playing play it
                            if (instance.State == SoundState.Stopped)
                            {
                                instance.Play();
                            }
                            // Calculate the frame to draw based on the time
                            framesElapsed = (int)(gameTime.TotalGameTime.TotalMilliseconds / timePerFrame);
                            frame = framesElapsed % numFrames + 1;
                            charState = CharState.WalkRight;
                            break;
                        case "Walk Up":
                            //if the current sound effect is not playing play it
                            if (instance.State == SoundState.Stopped)
                            {
                                instance.Play();
                            }
                            // Calculate the frame to draw based on the time
                            framesElapsed = (int)(gameTime.TotalGameTime.TotalMilliseconds / timePerFrame);
                            frame = framesElapsed % numFrames + 1;
                            charState = CharState.WalkUp;
                            break;
                        case "Walk Down":
                            //if the current sound effect is not playing play it
                            if (instance.State == SoundState.Stopped)
                            {
                                instance.Play();
                            }
                            // Calculate the frame to draw based on the time
                            framesElapsed = (int)(gameTime.TotalGameTime.TotalMilliseconds / timePerFrame);
                            frame = framesElapsed % numFrames + 1;
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
                    monster.aiMove(player,map, kbState, lightOn);
                    monster.UpdateCurrPos(map);

                    if(monster.CurrentDirection == 0)
                    {
                        enemyState = EnemyState.WalkUp;
                        enemyFramesElapsed = (int)(gameTime.TotalGameTime.TotalMilliseconds / timePerFrame);
                        enemyFrame = enemyFramesElapsed % numFrames + 1;
                    }
                    if (monster.CurrentDirection == 1)
                    {
                        enemyState = EnemyState.WalkDown;
                        enemyFramesElapsed = (int)(gameTime.TotalGameTime.TotalMilliseconds / timePerFrame);
                        enemyFrame = enemyFramesElapsed % numFrames + 1;
                    }
                    if (monster.CurrentDirection == 2)
                    {
                        enemyState = EnemyState.WalkLeft;
                        enemyFramesElapsed = (int)(gameTime.TotalGameTime.TotalMilliseconds / timePerFrame);
                        enemyFrame = enemyFramesElapsed % numFrames + 1;
                    }
                    if (monster.CurrentDirection == 3)
                    {
                        enemyState = EnemyState.WalkRight;
                        enemyFramesElapsed = (int)(gameTime.TotalGameTime.TotalMilliseconds / timePerFrame);
                        enemyFrame = enemyFramesElapsed % numFrames + 1;
                    }

                    

                    //key stuff
                    for (int i = 0; i < keys.Count; i++)
                    {
                        //if the player collides with key and it is visable
                        if (collDetect.SimpleCheck(player.PositionCurr, keys[i].PositionCurr) == true && keys[i].Rendered)
                        {
                            keys[i].Rendered = false;
                            player.NumKeyParts++;              
                            pkupKey.Play(); //play the key pick up sound
                            if (player.NumKeyParts >= 2)
                            {
                                for (int j = 0; j < doors.Count; j++) // open the doors on the map if the player has 2 keys
                                {
                                    doors[j].Open = true;
                                }
                            }
                        }
                    }

                    for (int i = 0; i < keys.Count; i++)
                    {
                        keys[i].UpdateCurrPos(map);
                    }

                    //door stuff
                    for (int i = 0; i < doors.Count; i++)
                    {
                        if (collDetect.SimpleCheck(player.PositionCurr, doors[i].PositionCurr) == true && player.NumKeyParts >= 2)
                        {
                            soundEffects[5].Play();
                            currentState = GameState.Winner;
                        }
                        else if (collDetect.SimpleCheck(player.PositionCurr, doors[i].PositionCurr) == true && doorSealed.State == SoundState.Stopped)
                        {
                            doorSealed.Play();
                        }
                    }

                    for (int i = 0; i < doors.Count; i++)
                    {
                        doors[i].UpdateCurrPos(map);
                    }

                    // monster collisions and player health
                    if (collDetect.SimpleCheck(player.PositionCurr, monster.PositionCurr) == true && invincible <= 0)
                    {
                        invincible = 60;
                        player.Health--;
                        //if the player is hurt but not dead play the pain soundeffect
                        if(player.Health > 0)
                        {
                            soundEffects[rng.Next(7, 9)].Play();
                        }
                        //if the player is dead play a dead sound effect and game over
                        else if (player.Health <= 0)
                        {
                            soundEffects[rng.Next(10, 11)].Play();
                            currentState = GameState.GameOver;
                        }
                    }

                    if (invincible > 0) //reduces the time of invincible
                    {
                        invincible--;
                    }
                    break;
                case GameState.MapOverlay:
                    // once in the phone menu screen, press tab again to return back to the game
                    if (SingleKeyPress(Keys.Tab))
                    {
                        IsMouseVisible = false;
                        currentState = GameState.MainGame;
                    }
                    break;
                case GameState.GameOver:
                    //if the game over state has just occured play the stop current song and play the EndTheme
                    if (currentState != oldState)
                    {
                        MediaPlayer.Stop();
                        MediaPlayer.Play(endTheme);
                    }
                    oldState = currentState;
                    //resest level, player health, and keys pickedup
                    Settings.currentLevel = 0;
                    player.Health = 3;
                    player.NumKeyParts = 0;
                    for (int i = 0; i < keys.Count; i++)
                    {
                        keys[i].Rendered = true;
                    }
                    for (int j = 0; j < doors.Count; j++) // open the doors on the map if the player has 2 keys
                    {
                        doors[j].Open = false;
                    }
                    monster = new Monster(3520, 960, ENEMY_WIDTH, ENEMY_HEIGHT, 8, 2);
                    map = new Map(-3200, -320, 7680, 6240);
                    if (SingleKeyPress(Keys.Enter))
                    {
                        currentState = GameState.MainMenu;
                    }

                    break;
                case GameState.Winner:
                    //if (currentState != oldState)
                    //{
                    //    MediaPlayer.Stop();
                    //    MediaPlayer.Play(winTheme);
                    //}
                    //oldState = currentState;
                    Settings.currentLevel = 0;
                    player.Health = 3;
                    player.NumKeyParts = 0;

                    if (SingleKeyPress(Keys.Enter))
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
                spriteBatch.DrawString(text, "Tab  -  Map Overlay", new Vector2((GraphicsDevice.Viewport.Height / 3) + 40, 540), Color.White);
                spriteBatch.DrawString(text, "Space  -  Flashlight", new Vector2((GraphicsDevice.Viewport.Height / 3) + 40, 585), Color.White);
            }
            if (currentState == GameState.MainGame)
            {
                //draw the map
                map.Draw(spriteBatch);

                // draw the player to the screen
                // if the player is walking in a direction
                if (charState == CharState.WalkUp)
                {
                    spriteBatch.Draw(playerImg, new Vector2(player.X, player.Y), new Rectangle(CHAR_X_OFFSET + (frame * CHAR_WIDTH), CHAR_Y, CHAR_WIDTH, CHAR_HEIGHT), Color.White, -1.57f, new Vector2(CHAR_WIDTH, 0), 1, SpriteEffects.None, 0);
                }
                if (charState == CharState.WalkRight)
                {
                    spriteBatch.Draw(playerImg, new Vector2(player.X, player.Y), new Rectangle(CHAR_X_OFFSET + (frame * CHAR_WIDTH), CHAR_Y, CHAR_WIDTH, CHAR_HEIGHT), Color.White);
                }
                if (charState == CharState.WalkDown)
                {
                    spriteBatch.Draw(playerImg, new Vector2(player.X, player.Y), new Rectangle(CHAR_X_OFFSET + (frame * CHAR_WIDTH), CHAR_Y, CHAR_WIDTH, CHAR_HEIGHT), Color.White, 1.57f, new Vector2(0, CHAR_HEIGHT), 1, SpriteEffects.None, 0);
                }
                if (charState == CharState.WalkLeft)
                {
                    spriteBatch.Draw(playerImg, new Vector2(player.X, player.Y), new Rectangle(CHAR_X_OFFSET + (frame * CHAR_WIDTH), CHAR_Y, CHAR_WIDTH, CHAR_HEIGHT), Color.White, 3.14f, new Vector2(CHAR_WIDTH, CHAR_HEIGHT), 1, SpriteEffects.None, 0);
                }

                // if the player is only facing a direction (not walking)
                if (charState == CharState.FaceUp)
                {
                    spriteBatch.Draw(playerImg, new Vector2(player.X, player.Y), new Rectangle(CHAR_X_OFFSET + (frame * CHAR_WIDTH), CHAR_Y, CHAR_WIDTH, CHAR_HEIGHT), Color.White, -1.57f, new Vector2(CHAR_WIDTH, 0), 1, SpriteEffects.None, 0);
                }
                if (charState == CharState.FaceRight)
                {
                    spriteBatch.Draw(playerImg, player.Position, new Rectangle(0, 0, player.Width, player.Height), Color.White);
                }
                if (charState == CharState.FaceDown)
                {
                    spriteBatch.Draw(playerImg, new Vector2(player.X, player.Y), new Rectangle(0, 0, player.Width, player.Height), Color.White, 1.57f, new Vector2(0, CHAR_HEIGHT), 1, SpriteEffects.None, 0);
                }
                if (charState == CharState.FaceLeft)
                {
                    spriteBatch.Draw(playerImg, new Vector2(player.X, player.Y), new Rectangle(0, 0, player.Width, player.Height), Color.White, 3.14f, new Vector2(CHAR_WIDTH, CHAR_HEIGHT), 1, SpriteEffects.None, 0);
                }

                // draw the enemy's animation
                if (enemyState == EnemyState.WalkUp)
                {
                    spriteBatch.Draw(monsterImg, new Vector2(monster.XCurr, monster.YCurr), new Rectangle(ENEMY_X_OFFSET + (enemyFrame * ENEMY_WIDTH), ENEMY_Y, ENEMY_WIDTH, ENEMY_HEIGHT), Color.White, -1.57f, new Vector2(ENEMY_WIDTH, 0), 1, SpriteEffects.None, 0);
                }
                if (enemyState == EnemyState.WalkRight)
                {
                    spriteBatch.Draw(monsterImg, new Vector2(monster.XCurr, monster.YCurr), new Rectangle(ENEMY_X_OFFSET + (enemyFrame * ENEMY_WIDTH), ENEMY_Y, ENEMY_WIDTH, ENEMY_HEIGHT), Color.White);
                }
                if (enemyState == EnemyState.WalkDown)
                {
                    spriteBatch.Draw(monsterImg, new Vector2(monster.XCurr, monster.YCurr), new Rectangle(ENEMY_X_OFFSET + (enemyFrame * ENEMY_WIDTH), ENEMY_Y, ENEMY_WIDTH, ENEMY_HEIGHT), Color.White, 1.57f, new Vector2(0, ENEMY_HEIGHT), 1, SpriteEffects.None, 0);
                }
                if (enemyState == EnemyState.WalkLeft)
                {
                    spriteBatch.Draw(monsterImg, new Vector2(monster.XCurr, monster.YCurr), new Rectangle(ENEMY_X_OFFSET + (enemyFrame * ENEMY_WIDTH), ENEMY_Y, ENEMY_WIDTH, ENEMY_HEIGHT), Color.White, 3.14f, new Vector2(ENEMY_WIDTH, ENEMY_HEIGHT), 1, SpriteEffects.None, 0);
                }

                //key rendering
                for (int i = 0; i < keys.Count; i++)
                {
                    if (keys[i].Rendered == true)
                    {
                        keys[i].Draw(spriteBatch);
                    }
                }

                // door rendering
                for (int i = 0; i < doors.Count; i++)
                {
                    doors[i].Draw(spriteBatch);
                }
/*
                //draw the Flashlight
                if (lightOn)
                {
                    spriteBatch.Draw(flashLightOn, new Vector2(-90, -100), Color.White);
                }
                else
                {
                    spriteBatch.Draw(flashLightOff, new Vector2(-90, -100), Color.White);
                }
*/
                // draw the level, level score and timer
                spriteBatch.DrawString(text, "Level   " + Settings.currentLevel, new Vector2(5, 10), Color.White);
                spriteBatch.DrawString(text, "Key Pieces   " + player.NumKeyParts, new Vector2(5, 40), Color.White);
                spriteBatch.DrawString(text, String.Format("Timer   {0:0.00}", timer), new Vector2(5, 70), Color.White);
                spriteBatch.DrawString(text, "Health   " + player.Health, new Vector2(5, 100), Color.White);
                spriteBatch.DrawString(text, "Find 2 Keys And Escape Through A Trap Door", new Vector2((GraphicsDevice.Viewport.Width / 2) - 140, 10), Color.White);
            }
            if (currentState == GameState.MapOverlay) // stretch goal
            {
                // draw the player on the overlay so that the player knows where they are on the map
                spriteBatch.Draw(map.CurrentTexture, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                 
                if (charState == CharState.FaceUp)
                {
                    spriteBatch.Draw(playerImg, new Rectangle((Math.Abs(map.PositionCurr.X) + player.PositionCurr.X) / 10 + 13, (Math.Abs(map.PositionCurr.Y) + player.PositionCurr.Y) / 8 , player.Width / 4, player.Height / 4), new Rectangle(CHAR_X_OFFSET + (frame * CHAR_WIDTH), CHAR_Y, CHAR_WIDTH, CHAR_HEIGHT), Color.White, -1.57f, new Vector2(CHAR_WIDTH, 0), SpriteEffects.None, 0);
                }
                if (charState == CharState.FaceRight)
                {
                    spriteBatch.Draw(playerImg, new Rectangle((Math.Abs(map.PositionCurr.X) + player.PositionCurr.X) / 10 + 12, (Math.Abs(map.PositionCurr.Y) + player.PositionCurr.Y) / 8 - 3, player.Width / 4, player.Height / 4), new Rectangle(0, 0, player.Width, player.Height), Color.White);
                }
                if (charState == CharState.FaceDown)
                {
                    spriteBatch.Draw(playerImg, new Rectangle((Math.Abs(map.PositionCurr.X) + player.PositionCurr.X) / 10 + 13, (Math.Abs(map.PositionCurr.Y) + player.PositionCurr.Y) / 8, player.Width / 4, player.Height / 4), new Rectangle(0, 0, player.Width, player.Height), Color.White, 1.57f, new Vector2(0, CHAR_HEIGHT), SpriteEffects.None, 0);
                }
                if (charState == CharState.FaceLeft)
                {
                    spriteBatch.Draw(playerImg, new Rectangle((Math.Abs(map.PositionCurr.X) + player.PositionCurr.X) / 10 + 12, (Math.Abs(map.PositionCurr.Y) + player.PositionCurr.Y) / 8 - 3, player.Width / 4, player.Height / 4), new Rectangle(0, 0, player.Width, player.Height), Color.White, 3.14f, new Vector2(CHAR_WIDTH, CHAR_HEIGHT), SpriteEffects.None, 0);
                }

                // display the coordinates of the player on the top left corner of the screen (for testing)
                spriteBatch.DrawString(text, "X Coordinate   " + (Math.Abs(map.PositionCurr.X) + player.PositionCurr.X), new Vector2(5, 10), Color.White);
                spriteBatch.DrawString(text, "Y Coordinate   " + (Math.Abs(map.PositionCurr.Y) + player.PositionCurr.Y), new Vector2(5, 40), Color.White);
            }
            if (currentState == GameState.GameOver)
            {
                // currentState = GameState.MainMenu;
                spriteBatch.Draw(loseScreen, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.DrawString(text, "Press Enter to Return to the Main Menu", new Vector2((GraphicsDevice.Viewport.Height / 4) + 40, 575), Color.Red);
            }
            if (currentState == GameState.Winner)
            {
                // currentState = GameState.MainMenu;
                spriteBatch.Draw(winScreen, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);
                spriteBatch.DrawString(text, "Press Enter to Return to the Main Menu", new Vector2((GraphicsDevice.Viewport.Height / 4) + 40, 625), Color.Red);
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
