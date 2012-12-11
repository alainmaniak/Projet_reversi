using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Projet_jeu
{
    class Ressources
    {

        //STATIC FIELDS

        public static Texture2D luke;

        //LOAD CONTENT

        public static void LoadContent(ContentManager Content)
        {
           
            luke = Content.Load<Texture2D>("calk_hero3");
 
        }
    }
}
