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

namespace Projet_jeu
{
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameMain Main;

       // int etat;
       // int timesuivant;
       

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            graphics.IsFullScreen = false;
           // etat = 0;
            //timesuivant = 0;
            

        }

        
        protected override void Initialize()
        {
            

            base.Initialize();
            
        }

        
        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Ressources.LoadContent(Content);
            Main = new GameMain();

           
        }

       
        protected override void UnloadContent()
        {
            Content.Unload();
        }

        
        protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            Main.Update(Mouse.GetState(), Keyboard.GetState());
            /*timesuivant += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timesuivant > 100)
            {
                etat++;
                timesuivant = 0;
            }
            if (etat > 8*6-1)
                etat = 0;*/
            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            Main.Draw(spriteBatch);
           // spriteBatch.Draw(Ressources.luke, new Rectangle(0,0,30,60), new Rectangle((etat % 6) * Ressources.luke.Width / 6, (etat/8)* Ressources.luke.Height / 8, Ressources.luke.Width / 6, Ressources.luke.Height / 8), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
