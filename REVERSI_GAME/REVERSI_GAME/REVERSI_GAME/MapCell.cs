using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REVERSI_GAME
{
    /// <summary>
    /// cellule à parcourir pour créer une map
    /// </summary>
    class MapCell
    {

        public int TileID { get; set; }

        public MapCell(int tileID)
        {
            TileID = tileID;
        }
    }
}
