using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Projet_jeu
{
    class GameMain
    {
        //FIELDS
        Rectangle luke;
       

        //CONSTRUCTOR
        public GameMain()
        {
            
            luke = new Rectangle(0, 0, 16, 16);
            
 
        }



        //METHODS

        //UPDATE & DRAW

        public void Update(MouseState mouse, KeyboardState keyboard)
        {
            if (keyboard.IsKeyDown(Keys.Up) || keyboard.IsKeyDown(Keys.U))
            {
                luke.Y--;
            }
            if (keyboard.IsKeyDown(Keys.Down))
            {
                luke.Y++;
            }
            if (keyboard.IsKeyDown(Keys.Left))
            {
                luke.X--;
            }
            if (keyboard.IsKeyDown(Keys.Right))
            {
                luke.X++;
            }
 
        }

        public void Draw(SpriteBatch SpriteBatch)
        {
            SpriteBatch.Draw(Ressources.luke, luke, Color.White);
 
        }
    }
}
