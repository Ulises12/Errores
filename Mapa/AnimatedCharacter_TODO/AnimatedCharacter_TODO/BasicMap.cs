using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
//using Microsoft.Xna.Framework.GamerServices;


namespace AnimatedCharacter_TODO
{
    class BasicMap
    {
        //Atributos

        Texture2D transitable;
        Texture2D notransitable;
        Rectangle pos;
        Color[] OverData;

        bool test;

        //Metodos
        public void LoadContent(ContentManager Content, String transi, String notransi)
        {
            transitable = Content.Load<Texture2D>(transi);
            notransitable = Content.Load<Texture2D>(notransi);//back

            OverData = new Color[transitable.Width * transitable.Height];
            transitable.GetData(OverData);

            pos = new Rectangle(0, 0, transitable.Width, transitable.Height);
        }

        //No se necesita este Updated
        public void Update()
        {

        }

        //Codigo recuperado del video "11.- Contruccion OO - Mapas"
        public bool VallidateCollision(Rectangle characterSize)
        {
            Color col1, col2, col3, col4; //Variables temporales que almacenan el color de la imagen
            int xTex, yTex;

            xTex = characterSize.X-1;
            yTex = characterSize.Y-1;
            col1 = OverData[(yTex * transitable.Width) + xTex];

            xTex = characterSize.X + characterSize.Width;
            yTex = characterSize.Y;
            col2 = OverData[(yTex * transitable.Width) + xTex];

            xTex = characterSize.X;
            yTex = characterSize.Y + characterSize.Height/2;
            col3 = OverData[(yTex * transitable.Width) + xTex];

            xTex = characterSize.X + characterSize.Width;
            yTex = characterSize.Y + characterSize.Height/2;
            col4 = OverData[(yTex * transitable.Width) + xTex];

           /* if (col1.A == 0 || col2.A == 0 || col3.A == 0 || col4.A == 0)
            {
                throw new System.ArgumentException("Alguno de los puntos no es tranparente ");
            }*/

                if (col1.A != 0 && col2.A != 0 && col3.A != 0 && col4.A != 0)
                    return true;
                else
                    return false;
         

        }
        public void DrawUnder(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(notransitable, pos, Color.White);
            spriteBatch.End();
        }

        public void DrawOver(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(transitable, pos, Color.White);
            spriteBatch.End();
        }

    }
}