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
    class AutoCharacter : AnimatedCharacter
    {
        //atributos
        bool move = true;
        int incrementoY = 2, incrementoX=2;
        bool abajo = false, arriba = true, derecha=true,izquierda=false;
       
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Rectangle currentPos = this.Pos;

            //metodo para movimiento automático

            if (move)
            {               
               if (currentPos.Y >= (heightLimit - currentPos.Height))
               {
                   abajo = true;
                   arriba = false;
                  
               }
               if (currentPos.Y <= 0)
               {
                   abajo = false;
                   arriba = true;
                   
               }

               if (currentPos.X<=0)
               {
                   derecha = true;
                   izquierda = false;
               }
               if(currentPos.X>=(widthLimit-currentPos.Width))
               {
                   derecha = false;
                   izquierda = true;
               }

               if (abajo)
               {
                   direccion = SideDirection.Move_Up;
                   currentPos.Y -= incrementoY;
                   walkUp.Update(gameTime);
               }

               if (arriba)
               {
                   direccion = SideDirection.Move_Down;
                   currentPos.Y += incrementoY;
                   walkDown.Update(gameTime);
               }
               if (derecha)
               {
                   direccion = SideDirection.Move_Right;
                   currentPos.X += incrementoX;
                   walkRigh.Update(gameTime);
               }
              if (izquierda)
              {
                  direccion = SideDirection.Move_Left;
                  currentPos.X -= incrementoX;
                  walkLeft.Update(gameTime);
              }
                
            }
            this.Pos = currentPos;
        }


    }
}
