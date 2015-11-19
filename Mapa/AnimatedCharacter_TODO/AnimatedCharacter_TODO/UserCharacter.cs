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
    class UserCharacter : AnimatedCharacter
    {
        //atributos
        Keys left, right, up, down;
        bool colli;
        BasicMap map;
        //metodo para asignar teclas

        public virtual void setKeys(Keys Up, Keys Down, Keys Left, Keys Right)
        {
            this.up = Up;
            this.down = Down;
            this.left = Left;
            this.right = Right;
        }

        public void SetMap(BasicMap theMap)
        {
            map = theMap;
        }
     
        public override void Update(GameTime gameTime)
        {
 	        base.Update(gameTime);
            Rectangle currentPos = this.Pos;

            //Control de movimiento por teclado
            /*PARA IMAGENES EN COLISIONES
             * if (collision)
            {
                collisi.Update(gameTime);

            }*/
            
            if (Keyboard.GetState().IsKeyDown(up))
            {
                standUp.Co(0);
                standDown.Co(0);
                standLeft.Co(0);
                standRight.Co(0);
                walkDown.Co(0);
                walkLeft.Co(0);
                walkRigh.Co(0);
                walkUp.Co(0);
                if (currentPos.Y >= 0)
                {
                    
                    direccion = SideDirection.Move_Up;
                    walkUp.Update(gameTime);
                    
                    Rectangle pos = new Rectangle(currentPos.X, currentPos.Y, currentPos.Width, currentPos.Height);
                    
                    pos.Y -= incY;
                    standUp.Co(4);
                    walkUp.Co(4);
                    if (map.VallidateCollision(pos))
                    {
                        currentPos.Y -= incY;
                        standUp.Co(0);
                        walkUp.Co(0);
                    }
                }
            }
            if (Keyboard.GetState().IsKeyDown(down))
            {
                if (currentPos.Y <= (this.heightLimit - currentPos.Height))
                {
                   
                    direccion = SideDirection.Move_Down;
                    walkDown.Update(gameTime);
                    
                    Rectangle pos = new Rectangle(currentPos.X, currentPos.Y, currentPos.Width, currentPos.Height);
                    pos.Y += incY;
                    standDown.Co(3);
                    walkDown.Co(3);
                    if (map.VallidateCollision(pos))
                    {
                        currentPos.Y += incY;
                        standDown.Co(0);
                        walkDown.Co(0);
                    }
                     
                }
            }
            if (Keyboard.GetState().IsKeyDown(left))
            {
                if (currentPos.X >= 0)
                {

                    direccion = SideDirection.Move_Left;
                    walkLeft.Update(gameTime);
                    //Checar colision con mapa
                    Rectangle pos = new Rectangle(currentPos.X, currentPos.Y, currentPos.Width, currentPos.Height);
                    pos.X -= incX;
                    
                    standLeft.Co(2);
                    walkLeft.Co(2);
                    if (map.VallidateCollision(pos))
                    {
                        currentPos.X -= incX;
                        standLeft.Co(0);
                        walkLeft.Co(0);
                    }
                }
            }
            if (Keyboard.GetState().IsKeyDown(right))
            {
                if (currentPos.X<= (widthLimit-currentPos.Width))
                {
                    
                    direccion = SideDirection.Move_Right;
                    walkRigh.Update(gameTime);
                    
                    Rectangle pos = new Rectangle(currentPos.X, currentPos.Y, currentPos.Width, currentPos.Height);
                    standRight.Co(5);
                    walkRigh.Co(5);
                    pos.X += incX;
                    if (map.VallidateCollision(pos))
                    {
                        currentPos.X += incX;
                        standRight.Co(0);
                        walkRigh.Co(0);
                    }
                }
            }
            
            this.Pos = currentPos;


        }


    }

}
