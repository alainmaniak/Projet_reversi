using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Projet_jeu
{
    class hero
    {
        
        //FIELDS

        //CONSTRUCTOR
        Rectangle luke;

        //METHODS

        //UPDATE & DRAW

        public void Update(MouseState mouse, KeyboardState keyboard)
        {
            if (keyboard.IsKeyDown(Keys.Up) || keyboard.IsKeyDown(Keys.U))
            {
                this.luke.Y--;
            }
            if (keyboard.IsKeyDown(Keys.Down))
            {
                this.luke.Y++;
            }
            if (keyboard.IsKeyDown(Keys.Left))
            {
                this.luke.X--;
            }
            if (keyboard.IsKeyDown(Keys.Right))
            {
                this.luke.X++;
            }
 
        }

        public void Draw(SpriteBatch SpriteBatch)
        {
            SpriteBatch.Draw(Ressources.luke, this.luke, Color.White);
 
        }
      
    }
}

