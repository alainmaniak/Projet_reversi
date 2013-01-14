using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace REVERSI
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameMain Main;
        SpriteFont pericles6;


        TileMap myMap;
        int squaresAcross = 17;
        int squaresDown = 37;
        int baseOffsetX = -32;
        int baseOffsetY = -64;
        float heightRowDepthMod = 0.00001f;


        Texture2D hilight;//effet sur la souris lors du d�placement

        SpriteAnimation vlad;


        //Menu..
        MainMenu.GameState CurrentGameState = MainMenu.GameState.MainMenu;
        int screenWidth = 800, screenHeight = 600;
        Button btnPlay, btnQuit, btnMenu, btnOptions;

        //song
        Song song;
        public static float Volume { get; set; }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //apparition de la souris sur l'�cran
            this.IsMouseVisible = true;
            //R�solution de l'�cran
            graphics.PreferredBackBufferWidth = 924;
            graphics.PreferredBackBufferHeight = 500;
            graphics.IsFullScreen = false;



        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            this.Window.Title = "REVERSI";
            this.IsMouseVisible = true;
            

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
            Main = new GameMain();

            myMap = new TileMap(
                           Content.Load<Texture2D>(@"Textures\TileSets\mousemap"),
                           Content.Load<Texture2D>(@"Textures\TileSets\part9_slopemaps"));

            hilight = Content.Load<Texture2D>(@"Textures\TileSets\hilight");

            Tile.TileSetTexture = Content.Load<Texture2D>(@"Textures\TileSets\part4_tileset");

            pericles6 = Content.Load<SpriteFont>(@"Fonts\Pericles6");

            Camera.ViewWidth = this.graphics.PreferredBackBufferWidth;
            Camera.ViewHeight = this.graphics.PreferredBackBufferHeight;
            Camera.WorldWidth = ((myMap.MapWidth - 2) * Tile.TileStepX);
            Camera.WorldHeight = ((myMap.MapHeight - 2) * Tile.TileStepY);
            Camera.DisplayOffset = new Vector2(baseOffsetX, baseOffsetY);

            //animation du joueur
            #region
            vlad = new SpriteAnimation(Content.Load<Texture2D>(@"Textures\Characters\T_Vlad_Sword_Walking_48x48"));

            vlad.AddAnimation("WalkEast", 0, 48 * 0, 48, 48, 8, 0.1f);
            vlad.AddAnimation("WalkNorth", 0, 48 * 1, 48, 48, 8, 0.1f);
            vlad.AddAnimation("WalkNorthEast", 0, 48 * 2, 48, 48, 8, 0.1f);
            vlad.AddAnimation("WalkNorthWest", 0, 48 * 3, 48, 48, 8, 0.1f);
            vlad.AddAnimation("WalkSouth", 0, 48 * 4, 48, 48, 8, 0.1f);
            vlad.AddAnimation("WalkSouthEast", 0, 48 * 5, 48, 48, 8, 0.1f);
            vlad.AddAnimation("WalkSouthWest", 0, 48 * 6, 48, 48, 8, 0.1f);
            vlad.AddAnimation("WalkWest", 0, 48 * 7, 48, 48, 8, 0.1f);

            vlad.AddAnimation("IdleEast", 0, 48 * 0, 48, 48, 1, 0.2f);
            vlad.AddAnimation("IdleNorth", 0, 48 * 1, 48, 48, 1, 0.2f);
            vlad.AddAnimation("IdleNorthEast", 0, 48 * 2, 48, 48, 1, 0.2f);
            vlad.AddAnimation("IdleNorthWest", 0, 48 * 3, 48, 48, 1, 0.2f);
            vlad.AddAnimation("IdleSouth", 0, 48 * 4, 48, 48, 1, 0.2f);
            vlad.AddAnimation("IdleSouthEast", 0, 48 * 5, 48, 48, 1, 0.2f);
            vlad.AddAnimation("IdleSouthWest", 0, 48 * 6, 48, 48, 1, 0.2f);
            vlad.AddAnimation("IdleWest", 0, 48 * 7, 48, 48, 1, 0.2f);

            vlad.Position = new Vector2(100, 100);
            vlad.DrawOffset = new Vector2(-24, -38);
            vlad.CurrentAnimation = "WalkEast";
            vlad.IsAnimating = true;
            #endregion


            //son du jeu
            song = Content.Load<Song>(@"Songs\sonjeu");
            MediaPlayer.Play(song);
            Volume = 0.1f;

            MediaPlayer.Volume = Volume;
            MediaPlayer.IsRepeating = true;


            //Menu..
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            btnPlay = new Button(Content.Load<Texture2D>(@"Buttons\Play"), graphics.GraphicsDevice);
            btnPlay.setPosition(new Vector2(330, 300));

            btnQuit = new Button(Content.Load<Texture2D>(@"Buttons\Exit"), graphics.GraphicsDevice);
            btnQuit.setPosition(new Vector2(330, 400));

            btnOptions = new Button(Content.Load<Texture2D>(@"Buttons\Options"), graphics.GraphicsDevice);
            btnOptions.setPosition(new Vector2(330, 350));

            btnMenu = new Button(Content.Load<Texture2D>(@"Buttons\ReversiMenu"), graphics.GraphicsDevice);
            btnMenu.setPosition(new Vector2(330, 450));


        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {

            MouseState mouse = Mouse.GetState();

            switch (CurrentGameState)
            {

                //Pause..
                case MainMenu.GameState.MainMenu:
                    if (btnPlay.isClicked == true) CurrentGameState = MainMenu.GameState.Jeu;
                    btnPlay.Update(mouse);
                    if (btnQuit.isClicked == true) Exit();
                    btnQuit.Update(mouse);
                    if (btnOptions.isClicked == true) CurrentGameState = MainMenu.GameState.Options;
                    btnOptions.Update(mouse);
                    break;


                case MainMenu.GameState.Paused:
                    if (btnPlay.isClicked == true) CurrentGameState = MainMenu.GameState.Jeu;
                    btnPlay.Update(mouse);
                    if (btnQuit.isClicked == true) Exit();
                    btnQuit.Update(mouse);
                    if (btnMenu.isClicked == true) CurrentGameState = MainMenu.GameState.MainMenu;
                    if (btnOptions.isClicked == true) CurrentGameState = MainMenu.GameState.Options;
                    btnOptions.Update(mouse);
                    break;




                case MainMenu.GameState.Jeu:
                    //d�placement du joueur        
                    #region
                    Vector2 moveVector = Vector2.Zero;
                    Vector2 moveDir = Vector2.Zero;
                    string animation = "";

                    KeyboardState ks = Keyboard.GetState();

                    if (ks.IsKeyDown(Keys.NumPad7))
                    {
                        moveDir = new Vector2(-2, -1);
                        animation = "WalkNorthWest";
                        moveVector += new Vector2(-2, -1);
                    }

                    if (ks.IsKeyDown(Keys.NumPad8))
                    {
                        moveDir = new Vector2(0, -1);
                        animation = "WalkNorth";
                        moveVector += new Vector2(0, -1);
                    }

                    if (ks.IsKeyDown(Keys.NumPad9))
                    {
                        moveDir = new Vector2(2, -1);
                        animation = "WalkNorthEast";
                        moveVector += new Vector2(2, -1);
                    }

                    if (ks.IsKeyDown(Keys.NumPad4))
                    {
                        moveDir = new Vector2(-2, 0);
                        animation = "WalkWest";
                        moveVector += new Vector2(-2, 0);
                    }

                    if (ks.IsKeyDown(Keys.NumPad6))
                    {
                        moveDir = new Vector2(2, 0);
                        animation = "WalkEast";
                        moveVector += new Vector2(2, 0);
                    }

                    if (ks.IsKeyDown(Keys.NumPad1))
                    {
                        moveDir = new Vector2(-2, 1);
                        animation = "WalkSouthWest";
                        moveVector += new Vector2(-2, 1);
                    }

                    if (ks.IsKeyDown(Keys.NumPad2))
                    {
                        moveDir = new Vector2(0, 1);
                        animation = "WalkSouth";
                        moveVector += new Vector2(0, 1);
                    }

                    if (ks.IsKeyDown(Keys.NumPad3))
                    {
                        moveDir = new Vector2(2, 1);
                        animation = "WalkSouthEast";
                        moveVector += new Vector2(2, 1);
                    }


                    //Pause..

                    if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                        CurrentGameState = MainMenu.GameState.Paused;








                    //////aumentation et dimiution du volume
                    if (ks.IsKeyDown(Keys.RightControl) && ks.IsKeyDown(Keys.Up))
                    {
                        Volume += 0.1f;
                        MediaPlayer.Volume = Volume;

                    }
                    if (ks.IsKeyDown(Keys.RightControl) && ks.IsKeyDown(Keys.Down))
                    {
                        Volume -= 0.1f;
                        MediaPlayer.Volume = Volume;
                    }
                    //////



                    //Point nopoint;
                    // Point where = myMap.WorldToMapCell(new Point(Mouse.GetState().X, Mouse.GetState().Y), out nopoint);

                    //interaction entre le joueur et la Map


                    if (myMap.GetCellAtWorldPoint(vlad.Position + moveDir).Walkable == false)
                    {
                        moveDir = Vector2.Zero;
                    }

                    if (Math.Abs(myMap.GetOverallHeight(vlad.Position) - myMap.GetOverallHeight(vlad.Position + moveDir)) > 10)
                    {
                        moveDir = Vector2.Zero;
                    }

                    if (moveDir.Length() != 0)
                    {
                        vlad.MoveBy((int)moveDir.X, (int)moveDir.Y);
                        if (vlad.CurrentAnimation != animation)
                            vlad.CurrentAnimation = animation;
                    }
                    else
                    {
                        vlad.CurrentAnimation = "Idle" + vlad.CurrentAnimation.Substring(4);
                    }
                    float vladX = MathHelper.Clamp(
                        vlad.Position.X, 0 + vlad.DrawOffset.X, Camera.WorldWidth);
                    float vladY = MathHelper.Clamp(
                        vlad.Position.Y, 0 + vlad.DrawOffset.Y, Camera.WorldHeight);

                    vlad.Position = new Vector2(vladX, vladY);

                    Vector2 testPosition = Camera.WorldToScreen(vlad.Position);

                    if (testPosition.X < 100)
                    {
                        Camera.Move(new Vector2(testPosition.X - 100, 0));
                    }

                    if (testPosition.X > (Camera.ViewWidth - 100))
                    {
                        Camera.Move(new Vector2(testPosition.X - (Camera.ViewWidth - 100), 0));
                    }

                    if (testPosition.Y < 100)
                    {
                        Camera.Move(new Vector2(0, testPosition.Y - 100));
                    }

                    if (testPosition.Y > (Camera.ViewHeight - 100))
                    {
                        Camera.Move(new Vector2(0, testPosition.Y - (Camera.ViewHeight - 100)));
                    }
                    /////////////////////////////////////////////
                    vlad.Update(gameTime);
                    break;
            }
#endregion;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);



            gameTime = new GameTime();
            switch (CurrentGameState)
            {

                //Menu..
                case MainMenu.GameState.MainMenu:
                    spriteBatch.Begin();
                    spriteBatch.Draw(Content.Load<Texture2D>(@"fonds\ReversiMenu"), new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    btnPlay.Draw(spriteBatch);
                    btnQuit.Draw(spriteBatch);
                    btnOptions.Draw(spriteBatch);
                    spriteBatch.End();
                    break;

                case MainMenu.GameState.Paused:
                    spriteBatch.Begin();
                    spriteBatch.Draw(Content.Load<Texture2D>(@"fonds\image_pause"), new Rectangle(0, 0, screenWidth, screenHeight), Color.White);
                    btnPlay.Draw(spriteBatch);
                    btnQuit.Draw(spriteBatch);
                    btnMenu.Draw(spriteBatch);
                    btnOptions.Draw(spriteBatch);
                    spriteBatch.End();
                    break;


                case MainMenu.GameState.Jeu:
                    #region;
                    GraphicsDevice.Clear(Color.Black);

                    spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                    Main.Draw(spriteBatch);

                    Vector2 firstSquare = new Vector2(Camera.Location.X / Tile.TileStepX, Camera.Location.Y / Tile.TileStepY);
                    int firstX = (int)firstSquare.X;
                    int firstY = (int)firstSquare.Y;

                    Vector2 squareOffset = new Vector2(Camera.Location.X % Tile.TileStepX, Camera.Location.Y % Tile.TileStepY);
                    int offsetX = (int)squareOffset.X;
                    int offsetY = (int)squareOffset.Y;

                    float maxdepth = ((myMap.MapWidth + 1) * ((myMap.MapHeight + 1) * Tile.TileWidth)) / 10;
                    float depthOffset;

                    Point vladMapPoint = myMap.WorldToMapCell(new Point((int)vlad.Position.X, (int)vlad.Position.Y));

                    for (int y = 0; y < squaresDown; y++)
                    {
                        int rowOffset = 0;
                        if ((firstY + y) % 2 == 1)
                            rowOffset = Tile.OddRowXOffset;

                        for (int x = 0; x < squaresAcross; x++)
                        {
                            int mapx = (firstX + x);
                            int mapy = (firstY + y);
                            depthOffset = 0.7f - ((mapx + (mapy * Tile.TileWidth)) / maxdepth);

                            if ((mapx >= myMap.MapWidth) || (mapy >= myMap.MapHeight))
                                continue;

                            foreach (int tileID in myMap.Rows[mapy].Columns[mapx].BaseTiles)
                            {
                                spriteBatch.Draw(
                                    Tile.TileSetTexture,
                                    Camera.WorldToScreen(
                                        new Vector2((mapx * Tile.TileStepX) + rowOffset, mapy * Tile.TileStepY)),
                                    Tile.GetSourceRectangle(tileID),
                                    Color.White,
                                    0.0f,
                                    Vector2.Zero,
                                    1.0f,
                                    SpriteEffects.None,
                                    1.0f);
                            }
                            int heightRow = 0;

                            foreach (int tileID in myMap.Rows[mapy].Columns[mapx].HeightTiles)
                            {
                                spriteBatch.Draw(
                                    Tile.TileSetTexture,
                                    Camera.WorldToScreen(
                                        new Vector2(
                                            (mapx * Tile.TileStepX) + rowOffset,
                                            mapy * Tile.TileStepY - (heightRow * Tile.HeightTileOffset))),
                                    Tile.GetSourceRectangle(tileID),
                                    Color.White,
                                    0.0f,
                                    Vector2.Zero,
                                    1.0f,
                                    SpriteEffects.None,
                                    depthOffset - ((float)heightRow * heightRowDepthMod));
                                heightRow++;
                            }

                            foreach (int tileID in myMap.Rows[y + firstY].Columns[x + firstX].TopperTiles)
                            {
                                spriteBatch.Draw(
                                    Tile.TileSetTexture,
                                    Camera.WorldToScreen(
                                        new Vector2((mapx * Tile.TileStepX) + rowOffset, mapy * Tile.TileStepY)),
                                    Tile.GetSourceRectangle(tileID),
                                    Color.White,
                                    0.0f,
                                    Vector2.Zero,
                                    1.0f,
                                    SpriteEffects.None,
                                    depthOffset - ((float)heightRow * heightRowDepthMod));
                            }

                            if ((mapx == vladMapPoint.X) && (mapy == vladMapPoint.Y))
                            {
                                vlad.DrawDepth = depthOffset - (float)(heightRow + 2) * heightRowDepthMod;
                            }

         ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            spriteBatch.DrawString(pericles6, (x + firstX).ToString() + ", " + (y + firstY).ToString(),
                                new Vector2((x * Tile.TileStepX) - offsetX + rowOffset + baseOffsetX + 24,
                                    (y * Tile.TileStepY) - offsetY + baseOffsetY + 48), Color.White, 0f, Vector2.Zero,
                                    1.0f, SpriteEffects.None, 0.0f);
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////                
                        
                        }
                    }

                    vlad.Draw(spriteBatch, 0, -myMap.GetOverallHeight(vlad.Position));

                    Vector2 hilightLoc = Camera.ScreenToWorld(new Vector2(Mouse.GetState().X, Mouse.GetState().Y));
                    Point hilightPoint = myMap.WorldToMapCell(new Point((int)hilightLoc.X, (int)hilightLoc.Y));

                    int hilightrowOffset = 0;
                    if ((hilightPoint.Y) % 2 == 1)
                        hilightrowOffset = Tile.OddRowXOffset;

                    spriteBatch.Draw(
                                    hilight,
                                    Camera.WorldToScreen(
                                    new Vector2(
                                        (hilightPoint.X * Tile.TileStepX) + hilightrowOffset,
                                        (hilightPoint.Y + 2) * Tile.TileStepY)),
                                    new Rectangle(0, 0, 64, 32),
                                    Color.White * 0.3f,
                                    0.0f,
                                    Vector2.Zero,
                                    1.0f,
                                    SpriteEffects.None,
                                    0.0f);
                    spriteBatch.End();
                    break;
            }

                    #endregion;


            base.Draw(gameTime);
        }
    }
}
