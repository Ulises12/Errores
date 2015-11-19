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
    class BasicSprite
    {
        //atributos
        Texture2D image;
        Rectangle pos;
        bool collision;
        int c;
        // metodo de inicializacion
        public void LoadContent(ContentManager Content,String dirName, String name)
        {
            try
            {
                image = Content.Load<Texture2D>(dirName + "/" + name);
                // Set the size of the displayed image the same size of the texture
                pos = new Rectangle(0, 0, image.Width, image.Height);
            }
            catch (Exception e)
            {
                image = null;
                Console.WriteLine("Ocurrio un error al cargar la imagen ", e);
            }
           
        }
        public bool Colision(Rectangle rect)
        {
            bool tempCol = pos.Intersects(rect);
            if (collision || tempCol)

                collision = true;
            return collision;
        }

        public void Co (int n)
        {
            c = n;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
             switch (c){
          
             case 0:  { 
                    spriteBatch.Draw(image, pos, Color.White); 
                    break;}             
              case 2:{ spriteBatch.Draw(image, pos, Color.Red);
              
                    break;}
              case 3: { spriteBatch.Draw(image, pos, Color.Aqua); 
                    break;}
              case 4: { spriteBatch.Draw(image, pos, Color.DarkGreen);
                      break;}

              case 5:
                  {spriteBatch.Draw(image, pos, Color.Brown);
                      break;}
             }
                
            spriteBatch.End();
            collision = false;
        }

        // Get/Set the current position of the character, as a Rectangle
        public Rectangle Pos
        {
            set
            {
                pos = value;
            }
            get
            {
                return pos;
            }
        }
    }
}
