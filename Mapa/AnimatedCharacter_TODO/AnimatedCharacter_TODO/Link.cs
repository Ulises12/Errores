using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace AnimatedCharacter_TODO
{
    class Link : UserCharacter
    {
       
        public void LoadContent(ContentManager Content)
        {


            this.setKeys(Keys.Up, Keys.Down, Keys.Left, Keys.Right);
           //PARA IMAGENES EN COLISIONES:  this.LoadContent_Collision(Content, "Collision", "Colision", 5, 0.12f);
            try
            {
                this.LoadContent_WalkUp(Content, "LinkBack", "LinkBack_f", 8, 0.12f);
                this.LoadContent_WalkDown(Content, "LinkFront", "LinkFront_f", 8, 0.12f);
                this.LoadContent_WalkLeft(Content, "LinkLeft", "LinkLeft_f", 8, 0.12f);
               // this.LoadContent_WalkRight(Content, "LinkRight", "LinkRight_f", 8, 0.12f);
                this.LoadContent_StandUp(Content, "LinkBackStand", "LinkBackStand");
                this.LoadContent_StandDown(Content, "LinkFrontStand", "LinkFrontStand");
                this.LoadContent_StandLeft(Content, "LinkLeftStand", "LinkLeftStand");
                this.LoadContent_StandRight(Content, "LinkRightStand", "LinkRightStand");
            }
            catch (Exception Exception)
            {
                System.Console.WriteLine("Error al cargar ls sprites");
            }
       
        }


    }
}
