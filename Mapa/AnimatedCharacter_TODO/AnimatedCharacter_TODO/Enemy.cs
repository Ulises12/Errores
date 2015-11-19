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
    class Enemy : AutoCharacter
    {


        public void LoadContent(ContentManager Content)
        {   
            this.LoadContent_WalkUp(Content, "ManBack", "ManBack", 50, 50, 12, 0.12f);
            this.LoadContent_WalkDown(Content, "ManFront", "ManFront", 50, 50, 12, 0.12f);
            this.LoadContent_WalkLeft(Content, "ManLeft", "ManLeft", 50, 50, 8, 0.12f);
            this.LoadContent_WalkRight(Content, "ManRight", "ManRight", 50, 50, 8, 0.12f);

            this.LoadContent_StandUp(Content, "ManBackStand", "ManBackStand");
            this.LoadContent_StandDown(Content, "ManFrontStand", "ManFrontStand");
            this.LoadContent_StandLeft(Content, "ManLeftStand", "ManLeftStand");
            this.LoadContent_StandRight(Content, "ManRightStand", "ManRightStand");
           //PARA IMAGENES EN COLISIONES:  this.LoadContent_Collision(Content, "Collision", "Colision", 5, 0.14f);
        }
    }
}
