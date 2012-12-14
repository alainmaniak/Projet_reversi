using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REVERSI_GAME
{


    /// <summary>
    /// rangée de cellule horizontale ou verticale pour créer la map, c'est une liste d'éléments
    /// </summary>
    class MapRow
    {
        /// <summary>
        /// Cette liste contient les cellules de MapCell: Type MapCell
        /// </summary>
        public List<MapCell> Colonnes = new List<MapCell>();
    }
    /// <summary>
    /// créer la Map
    /// </summary>
    class TileMap
    {
        /// <summary>
        /// on crée une liste qui contient l'ancienne liste de cellule"liste de liste"
        /// Notre carte sera effectivement consister en une liste d'objets MapRow, 
        /// qui à leur tour sont des listes de MapCells. En utilisant une liste de listes, 
        /// nous créons ce qui est essentiellement un tableaux à deux dimensions similaires à l'exemple de feuille de calcul. 
        /// Créons un simple constructeur de notre classe tilemap qui va initialiser la carte et créer des données temporaires de départ.
        /// </summary>
        public List<MapRow> Lignes = new List<MapRow>();//rows = lignes; columns = colonnes
        public int MapWidth = 50;//largeur de la Map
        public int MapHeight = 50;//hauteur de la Map

        public TileMap()
        {
            for (int y = 0; y < MapHeight; y++)
            {
                MapRow thisRow = new MapRow();
                for (int x = 0; x < MapWidth; x++)
                {
                    thisRow.Colonnes.Add(new MapCell(0));//TileID = 0 valeur par défaut de la tuile
                }
                Lignes.Add(thisRow);
            }

            // placement des "tuiles" sur la carte
# region;

            Lignes[0].Colonnes[3].TileID = 5;
            Lignes[0].Colonnes[4].TileID = 3;
            Lignes[0].Colonnes[5].TileID = 1;
            Lignes[0].Colonnes[6].TileID = 1;
            Lignes[0].Colonnes[7].TileID = 1;

            Lignes[1].Colonnes[3].TileID = 3;
            Lignes[1].Colonnes[4].TileID = 1;
            Lignes[1].Colonnes[5].TileID = 1;
            Lignes[1].Colonnes[6].TileID = 1;
            Lignes[1].Colonnes[7].TileID = 1;

            Lignes[2].Colonnes[2].TileID = 2;
            Lignes[2].Colonnes[3].TileID = 1;
            Lignes[2].Colonnes[4].TileID = 1;
            Lignes[2].Colonnes[5].TileID = 1;
            Lignes[2].Colonnes[6].TileID = 1;
            Lignes[2].Colonnes[7].TileID = 1;

            Lignes[3].Colonnes[2].TileID = 3;
            Lignes[3].Colonnes[3].TileID = 1;
            Lignes[3].Colonnes[4].TileID = 1;
            Lignes[3].Colonnes[5].TileID = 2;
            Lignes[3].Colonnes[6].TileID = 2;
            Lignes[3].Colonnes[7].TileID = 2;

            Lignes[4].Colonnes[2].TileID = 3;
            Lignes[4].Colonnes[3].TileID = 1;
            Lignes[4].Colonnes[4].TileID = 1;
            Lignes[4].Colonnes[5].TileID = 2;
            Lignes[4].Colonnes[6].TileID = 2;
            Lignes[4].Colonnes[7].TileID = 2;

            Lignes[5].Colonnes[2].TileID = 3;
            Lignes[5].Colonnes[3].TileID = 1;
            Lignes[5].Colonnes[4].TileID = 1;
            Lignes[5].Colonnes[5].TileID = 2;
            Lignes[5].Colonnes[6].TileID = 2;
            Lignes[5].Colonnes[7].TileID = 2;


          

#endregion;
        }
    }
}
