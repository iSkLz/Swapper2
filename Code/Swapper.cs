using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using SwapperV2.Scenes;
using SwapperV2.World;
using SwapperV2.Graphics;
using SwapperV2.Text;
using SwapperV2.Inputs;

namespace SwapperV2
{
    public class Swapper : Game
    {
        public static Swapper Instance;

        public GraphicsDeviceManager Graphics;
        public SpriteBatch Batch;

        public Scene ActiveScene;

        public float DeltaTime;

        public static event Action<float> OnUpdate;
        public static event Action<float> OnEndUpdate;

        public Font MainFont;

        public int Width => Window.ClientBounds.Width;
        public int Height => Window.ClientBounds.Height;
        public int CenterX => Width / 2;
        public int CenterY => Height / 2;

        public Settings Settings = Settings.Load();

        public Swapper()
        {
            Instance = this;
            Graphics = new GraphicsDeviceManager(this);
        }

        protected override void LoadContent()
        {
            Batch = new SpriteBatch(GraphicsDevice);
            SwapperV2.Content.Sprites.Load();
            MainFont = new Font("thaelah");
        }

        protected override void Initialize()
        {
            base.Initialize();

            Graphics.PreferredBackBufferWidth = 1280;
            Graphics.PreferredBackBufferHeight = 720;

            Graphics.ApplyChanges();

            Input.UpdateBinds();

            // Never forget to keep this line last, all other initializations should precede
            ActiveScene = new MainMenu();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            OnUpdate?.Invoke(DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds);
            ActiveScene.Update(DeltaTime);
            OnEndUpdate?.Invoke(DeltaTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Update(gameTime);
            GraphicsDevice.Clear(ActiveScene.Background);
            // Pixel settings
            Batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend,
                SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone);
            ActiveScene.Render();
            Batch.End();
        }
    }
}
