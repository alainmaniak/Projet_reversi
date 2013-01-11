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
        public static int Tilelargeur = 64;
        public static int Tilehauteur = 64;
        static public int TileStepX = 64;
        static public int TileStepY = 16;
        static public int OddRowXOffset = 32;
        static public int HeightTileOffset = 32;

        static public Vector2 originPoint = new Vector2(19, 39);
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
