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
       
       hero localhero;


        //CONSTRUCTOR
        /// <summary>
        /// qesdffdr
        /// </summary>
        public GameMain()
        {

            localhero = new hero();
            
 
        }



        //METHODS

        //UPDATE & DRAW

       public void Update(MouseState mouse, KeyboardState keyboard)
        {

            localhero.Update(mouse, keyboard);
 
        }

        public void Draw(SpriteBatch SpriteBatch)
        {

            localhero.Draw(SpriteBatch);
 
        }
    }
}
