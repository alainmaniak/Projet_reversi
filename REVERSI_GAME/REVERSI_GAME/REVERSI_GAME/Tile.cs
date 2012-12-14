using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace REVERSI_GAME
{
    /// <summary>
    /// création de la tuile"tile", séléction de la tuile
    /// </summary>
    static class Tile
    {
        /// <summary>
        /// variable de texture
        /// </summary>
        static public Texture2D TileSetTexture;
        public static int Tilelargeur = 48;
        public static int Tilehauteur = 48;

        /// <summary>
        /// choisir la tuile
        /// </summary>
        /// <param name="tileIndex">index de la tuile</param>
        /// <returns>le rectangle représentant le tileIndex</returns>
        static public Rectangle GetSourceRectangle(int tileIndex)
        {


            int TileY = tileIndex / (TileSetTexture.Width / Tilelargeur);
            int TileX = tileIndex % (TileSetTexture.Width / Tilelargeur);
            return new Rectangle(tileIndex * Tilelargeur, TileY*Tilehauteur, Tilelargeur, Tilehauteur);
        }


    }
}
