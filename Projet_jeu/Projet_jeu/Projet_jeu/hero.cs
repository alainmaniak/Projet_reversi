using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Projet_jeu
{
    public enum Direction
    { 
        Up, Down, Left, Right, UpLeft, UpRight, DownLeft, DownRight
    };

    class hero
    {

        //FIELDS
        Rectangle luke;

        Direction Direction;

        int Frameline;
        int Framecolumn;


        int speed = 2;

        //CONSTRUCTOR

        public hero()
        {

         this.luke = new Rectangle(0, 0, 30, 50);
         this.Frameline = 1;
         this.Framecolumn = 1;
        }

        //METHODS

        //UPDATE & DRAW

        public void Update(MouseState mouse, KeyboardState keyboard)
        {
            if (keyboard.IsKeyDown(Keys.Up) || keyboard.IsKeyDown(Keys.U))
            {
                this.luke.Y -= this.speed;
                this.Direction = Direction.Up;
                
            }

            if (keyboard.IsKeyDown(Keys.Down))
            {
                this.luke.Y+= this.speed;
                this.Direction = Direction.Down;
            }

            if (keyboard.IsKeyDown(Keys.Left))
            {
                this.luke.X-= this.speed;
                this.Direction = Direction.Left;
            }

            if (keyboard.IsKeyDown(Keys.Right))
            {
                this.luke.X+= this.speed;
                this.Direction = Direction.Right;
            }

        }

        public void Draw(SpriteBatch SpriteBatch)
        {
            SpriteBatch.Draw(Ressources.luke, this.luke,
                new Rectangle((this.Frameline - 1) * 30, (this.Framecolumn - 1) * 50, 30, 50), Color.White);

        }

    }
}

