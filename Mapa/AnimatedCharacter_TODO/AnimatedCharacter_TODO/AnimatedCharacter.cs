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
    enum SideDirection { Stand_Up, Stand_Down, Stand_Left, Stand_Right, Move_Up, Move_Down, Move_Left, Move_Right }//PARA IMAGENES EN COLISIONES, Collision}

    class AnimatedCharacter
    {
        // Attributes
        protected BasicSprite standLeft, standRight, standUp, standDown;
        protected BasicAnimatedSprite walkLeft, walkRigh, walkUp, walkDown; //PARA IMAGENES EN COLISIONES: collisi;   
        
        protected Rectangle pos;
        protected SideDirection direccion;
        protected int incX = 1;
        protected int incY = 1;
        protected Rectangle col;
        protected int heightLimit, widthLimit;
        protected bool collision;
        BasicMap map;

        // Properties
        public virtual Rectangle Pos
        {
            set
            {
                try
                {
                    standLeft.Pos = value;
                    standRight.Pos = value;
                    standUp.Pos = value;
                    standDown.Pos = value;
                    walkUp.Pos = value;
                    walkLeft.Pos = value;
                    walkRigh.Pos = value;
                    walkDown.Pos = value;
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Valores de posicion no encontrados");
                }
               //PARA IMAGENES EN COLISIONES: collisi.Pos = value;
            }
            get { return standUp.Pos; }
        }

        // Methods 

        //Load content para imagenes estáticas (BasicSprite)

        public virtual void LoadContent_StandDown(ContentManager Content, string dirName, String name)
        {
            standDown = new BasicSprite();
            direccion = SideDirection.Stand_Down;
            standDown.LoadContent(Content, dirName, name);
        }
        public virtual void LoadContent_StandUp(ContentManager Content, string dirName, String name)
        {
            standUp = new BasicSprite();
            direccion = SideDirection.Stand_Up;
            standUp.LoadContent(Content, dirName, name);
        }
        public virtual void LoadContent_StandLeft(ContentManager Content, string dirName, String name)
        {
            standLeft = new BasicSprite();
            direccion = SideDirection.Stand_Left;
            standLeft.LoadContent(Content, dirName, name);
        }
        public virtual void LoadContent_StandRight(ContentManager Content, string dirName, String name)
        {
            standRight = new BasicSprite();
            direccion = SideDirection.Stand_Right;
            standRight.LoadContent(Content, dirName, name);
        }



        //Loading metodo para animaciones con multiples archivos (BasicAnimatedSprite)

        public virtual void LoadContent_WalkDown(ContentManager Content, String nameDir, String nameFile, int frameCount, float timePerFrame)
        {
            walkDown = new BasicAnimatedSprite();
            direccion = SideDirection.Move_Down;
            walkDown.LoadContent(Content, nameDir, nameFile, frameCount, timePerFrame);
        }
        public virtual void LoadContent_WalkUp(ContentManager Content, String nameDir, String nameFile, int frameCount, float timePerFrame)
        {
            walkUp = new BasicAnimatedSprite();
            direccion = SideDirection.Move_Up;
            walkUp.LoadContent(Content, nameDir, nameFile, frameCount, timePerFrame);
        }
        public virtual void LoadContent_WalkLeft(ContentManager Content, String nameDir, String nameFile, int frameCount, float timePerFrame)
        {
            walkLeft = new BasicAnimatedSprite();
            direccion = SideDirection.Move_Left;
            walkLeft.LoadContent(Content, nameDir, nameFile, frameCount, timePerFrame);
        }
        public virtual void LoadContent_WalkRight(ContentManager Content, String nameDir, String nameFile, int frameCount, float timePerFrame)
        {
            walkRigh = new BasicAnimatedSprite();
            direccion = SideDirection.Move_Right;
            walkRigh.LoadContent(Content, nameDir, nameFile, frameCount, timePerFrame);
        }

       /*PARA IMAGENES EN COLISIONES 
        * public virtual void LoadContent_Collision(ContentManager Content, String nameDir, String nameFile, int frameCount, float timerPerFrame)
        {
            collisi = new BasicAnimatedSprite();
            direccion = SideDirection.Collision;
            collisi.LoadContent(Content, nameDir, nameFile, frameCount, timerPerFrame);

        }*/ 

        //Loading metodo para animaciones con un solo archivo (BasicAnimatedSprite)

        public virtual void LoadContent_WalkDown(ContentManager Content, string dirName, String name, int frameWidth, int frameHeight, int frameCount, float timePerFrame)
        {
            walkDown = new BasicAnimatedSprite();
            direccion = SideDirection.Move_Down;
            walkDown.LoadContent(Content, dirName, name, frameWidth, frameHeight, frameCount, timePerFrame);
        }
        public virtual void LoadContent_WalkUp(ContentManager Content, string dirName, String name, int frameWidth, int frameHeight, int frameCount, float timePerFrame)
        {
            walkUp = new BasicAnimatedSprite();
            direccion = SideDirection.Move_Up;
            walkUp.LoadContent(Content, dirName, name, frameWidth, frameHeight, frameCount, timePerFrame);
        }
        public virtual void LoadContent_WalkLeft(ContentManager Content, string dirName, String name, int frameWidth, int frameHeight, int frameCount, float timePerFrame)
        {
            walkLeft = new BasicAnimatedSprite();
            direccion = SideDirection.Move_Left;
            walkLeft.LoadContent(Content, dirName, name, frameWidth, frameHeight, frameCount, timePerFrame);
        }
        public virtual void LoadContent_WalkRight(ContentManager Content, string dirName, String name, int frameWidth, int frameHeight, int frameCount, float timePerFrame)
        {
            walkRigh = new BasicAnimatedSprite();
            direccion = SideDirection.Move_Right;
            walkRigh.LoadContent(Content, dirName, name, frameWidth, frameHeight, frameCount, timePerFrame);
        }

       /*
        * PARA IMAGENES EN COLISIONES
        * public virtual void LoadContent_Collision(ContentManager Content, String dirName, String name, int frameWidth, int frameHeight, int frameCount, float timePerFrame)
        {
            collisi = new BasicAnimatedSprite();
            direccion = SideDirection.Collision;
            collisi.LoadContent(Content, dirName, name, frameWidth, frameHeight, frameCount, timePerFrame);

        }*/


        //Los siguientes dos metodos (setHeightLimits, setWidth) son para delimitar la pantalla 
        public void setHeightLimits(int b)
        {
            heightLimit = b;
        }

        public void setWidthLimits(int a)
        {
            widthLimit = a;
        }

        //Checar colisiones
        public virtual bool Collision(Rectangle rect)
        {
            standLeft.Colision(rect);
            standRight.Colision(rect);
            standDown.Colision(rect);
            walkDown.Colision(rect);
            walkLeft.Colision(rect);
            walkRigh.Colision(rect);
            walkUp.Colision(rect);
            collision= walkUp.Colision(rect);
            return collision;
        }

        public virtual Rectangle GetRect()
        {
            col = walkDown.Pos;
            return col;
        }
        //Cambiar de color
        public void SetColor_StaRig(int n)
        {
            standRight.Co(n);
        }
        public void SetColor_StaLeft(int n )
        {
            standLeft.Co(n);
        }
        public void SetColor_StaUp(int n)
        {
            standUp.Co(n);
        }
        public void SetColor_StaDown(int n)
        {
            standDown.Co(n);
        }
        public virtual void Update(GameTime gameTime)
        {
            //Poner los valores por default 

            if (direccion == SideDirection.Move_Down)
            {
                direccion = SideDirection.Stand_Down;
            }
            if (direccion == SideDirection.Move_Up)
            {
                direccion = SideDirection.Stand_Up;
            }
            if (direccion == SideDirection.Move_Left)
            {
                direccion = SideDirection.Stand_Left;
            }
            if (direccion == SideDirection.Move_Right)
            {
                direccion = SideDirection.Stand_Right;
            }
  
            /*if (collision)
            {
             * PARA IMAGENES EN COLISIONES
                direccion = SideDirection.Collision;
            }*/ 


        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            try
            {
                switch (direccion)
                {
                    case SideDirection.Move_Up:
                        {
                            walkUp.Draw(spriteBatch);
                            break;
                        }
                    case SideDirection.Move_Down:
                        {
                            walkDown.Draw(spriteBatch);
                            break;
                        }
                    case SideDirection.Move_Left:
                        {
                            walkLeft.Draw(spriteBatch);
                            break;
                        }
                    case SideDirection.Move_Right:
                        {
                            walkRigh.Draw(spriteBatch);
                            break;
                        }
                    case SideDirection.Stand_Up:
                        {
                            standUp.Draw(spriteBatch);
                            break;
                        }
                    case SideDirection.Stand_Down:
                        {
                            standDown.Draw(spriteBatch);
                            break;
                        }
                    case SideDirection.Stand_Left:
                        {
                            standLeft.Draw(spriteBatch);
                            break;
                        }
                    case SideDirection.Stand_Right:
                        {
                            standRight.Draw(spriteBatch);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error");
            }
        }
    }
}
