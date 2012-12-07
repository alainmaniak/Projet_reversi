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

        public static Texture2D Player1,luke;

        //LOAD CONTENT

        public static void LoadContent(ContentManager Content)
        {
            Player1 = Content.Load<Texture2D>("Player1");
            luke = Content.Load<Texture2D>("calk_hero3");
 
        }
    }
}
