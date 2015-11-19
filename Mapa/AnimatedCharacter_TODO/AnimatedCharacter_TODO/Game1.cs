#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

#endregion


//Trabajo realizado por: Tanya Tapia Ocampo y Ulises Ruiz Salgado 
namespace AnimatedCharacter_TODO
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Link link;
      //  Enemy enemigo;
        BasicMap theMap;
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            link = new Link();
           // enemigo = new Enemy();
            theMap= new BasicMap();
            link.SetMap(theMap);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            link.LoadContent(Content);
            Rectangle temp = link.Pos;
            temp.X = 450;
            temp.Y = 400;
            link.Pos = temp;

            theMap.LoadContent(Content, "Forest_transitable", "Forest_over");

            //Definir tamaño de pantalla
           // enemigo.setHeightLimits( graphics.GraphicsDevice.Viewport.Height);
            //enemigo.setWidthLimits(graphics.GraphicsDevice.Viewport.Width);
            
            link.setHeightLimits(graphics.GraphicsDevice.Viewport.Height);
            link.setWidthLimits(graphics.GraphicsDevice.Viewport.Width);

            //enemigo.LoadContent(Content);
           
            

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            link.Update(gameTime);
       //     enemigo.Update(gameTime);

       
          //  link.Collision(enemigo.GetRect());
           

          //  enemigo.Collision(link.GetRect());
            

            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGreen);

            // TODO: Add your drawing code here
            
         // enemigo.Draw(spriteBatch);

            theMap.DrawOver(spriteBatch);
            link.Draw(spriteBatch);
            theMap.DrawUnder(spriteBatch);
            
            base.Draw(gameTime);
        }
    }
}
