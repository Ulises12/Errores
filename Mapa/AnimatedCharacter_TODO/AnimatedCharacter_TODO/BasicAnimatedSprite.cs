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


namespace AnimatedCharacter_TODO
{
    class BasicAnimatedSprite
    {
        // Attributes
        // Contains all attributes of basic sprite
        // -------------------------------------------
        Texture2D image;
        Rectangle pos;
        // for animation
        int frameCount;         // How many images
        int currentFrame;       // Which image to draw now
        ArrayList textureList;  // Texture array for multiple images
        float timer;            // To calc how long each frame will be shown
        float timePerFrame;     // Time to show each frame
        bool multipleFiles;     // True if multiple files used for animation
        int frameWidth;         // Size of the frame
        int frameHeight;        // Size of the frame

        bool collision;
        // Metodos
        // -------------------------------------------
        // Load multiple images for animation

        int c; // PARA LOS COLORES
        public void LoadContent(ContentManager Content, String nameDir, String nameFile, int frameCount, float timePerFrame)
        {
            this.frameCount = frameCount;
            this.timePerFrame = timePerFrame;
            this.currentFrame = 0;
            this.timer = 0.0f;
            this.textureList = new ArrayList();
            this.multipleFiles = true;

            // Load all the texture images
            for (int k = 1; k <= frameCount; k++)
            {
                Texture2D tex;
                tex = Content.Load<Texture2D>(nameDir + "/" + nameFile + k.ToString("00"));
                textureList.Add(tex);
            }

            // we will assume all images have same dimensions (width/height)
            pos = new Rectangle(0, 0, ((Texture2D)textureList[0]).Width, ((Texture2D)textureList[0]).Height);
        }

        // Load single image for animation
        public void LoadContent(ContentManager Content,String dirName, String name, int frameWidth, int frameHeight, int frameCount, float timePerFrame)
        {
            this.frameCount = frameCount;
            this.timePerFrame = timePerFrame;
            this.currentFrame = 0;
            this.timer = 0.0f;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.multipleFiles = false;

            // Actually load the texture
            image = Content.Load<Texture2D>(dirName + "/" + name);

            // we will assume all images have same dimensions (width/height)
            // OJO!!! This rectangle is DIFFERENT to the one used for selecting the frame
            pos = new Rectangle(0, 0, frameWidth, frameHeight);
        }

        // Update function is the same for both types of animation
        public void Update(GameTime gameTime)
        {
            // Calculate how much time has passed
            timer = timer + (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer >= timePerFrame)
            {
                currentFrame = (currentFrame + 1) % frameCount;
                timer = timer - timePerFrame;
            }
        }


        //Metodo para checar la colision, incluso cuando el personaje se encuentra en movimiento
        public bool Colision(Rectangle rect)
        {
            collision = pos.Intersects(rect);
            return collision;
        }


        public void Co(int n)
        {
            c = n;
        }
        // Draw function - same for both but with a control flag
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            // Draw animated sprite based on multiple files


            if ( multipleFiles )
            {
                if (currentFrame < textureList.Count)
                {
                    switch (c)
                    {

                        case 0:
                            {
                                Texture2D tex = (Texture2D)textureList[currentFrame];
                                spriteBatch.Draw(tex, pos, Color.White);
                                break;
                            }
                        case 2:
                            {
                                Texture2D tex = (Texture2D)textureList[currentFrame];
                                spriteBatch.Draw(tex, pos, Color.Red);

                                break;
                            }
                        case 3:
                            {
                                Texture2D tex = (Texture2D)textureList[currentFrame];
                                spriteBatch.Draw(tex, pos, Color.Aqua);
                                break;
                            }
                        case 4:
                            {
                                Texture2D tex = (Texture2D)textureList[currentFrame];
                                spriteBatch.Draw(tex, pos, Color.DarkGreen);
                                break;
                            }

                        case 5:
                            {
                                Texture2D tex = (Texture2D)textureList[currentFrame];
                                spriteBatch.Draw(tex, pos, Color.Brown);
                                break;
                            }
                    }
                    /*
                    if (collision)
                    {
                        Texture2D tex = (Texture2D)textureList[currentFrame];
                        spriteBatch.Draw(tex, pos, Color.Red);
                    }
                    else
                    {
                        Texture2D tex = (Texture2D)textureList[currentFrame];
                        spriteBatch.Draw(tex, pos, Color.White);
                    }*/ // EN CASO DE COLISIONES 
                }
            }
            // Draw animated sprite based on single file with multiple frames
            else
            {
                    int xTex, yTex;
                    Rectangle sourceRect;

                    xTex = currentFrame * frameWidth;
                    yTex = 0;
                    sourceRect = new Rectangle(xTex, yTex, frameWidth, frameHeight);
                    if (collision)
                    spriteBatch.Draw(image, pos, sourceRect, Color.Red);
                    else
                       spriteBatch.Draw(image, pos, sourceRect, Color.White);
            }
            collision = false;
            spriteBatch.End();
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
