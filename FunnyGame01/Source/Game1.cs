using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FunnyGame01
{
    public class Game1 : Game
    {
        public Game1()
        {
            Globals.Window = Window;
            Globals.Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Globals.Content = Content;

            Globals.Graphics.PreferredBackBufferWidth = GameSettings.ScreenWidth;
            Globals.Graphics.PreferredBackBufferHeight = GameSettings.ScreenHeight;
            Globals.Graphics.GraphicsProfile = GraphicsProfile.HiDef;
            Globals.Graphics.PreferMultiSampling = true;
            Globals.Graphics.SynchronizeWithVerticalRetrace = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            Window.Title = "Funny Game";
            
            IsMouseVisible = false;
            IsFixedTimeStep = true;
            
            Globals.Graphics.PreferredBackBufferWidth = GameSettings.ScreenWidth;
            Globals.Graphics.PreferredBackBufferHeight = GameSettings.ScreenHeight;
            Globals.Graphics.GraphicsProfile = GraphicsProfile.HiDef;
            Globals.Graphics.PreferMultiSampling = true;
            Globals.Graphics.SynchronizeWithVerticalRetrace = true;
            Globals.Graphics.IsFullScreen = GameSettings.Fullscreen;
            
            Globals.Graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);
            
            Assets.Load();
            MainMap.Load();
            CameraSystem.Load();
            WallSystem.Load();
            Player.Load();
        }

        protected override void Update(GameTime gameTime)
        {
            Input.UpdateState();
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Input.IsKeyPressed(Input.KeyMap["quit"]))
                Exit();

            Time.GameTime = gameTime;
            Time.DeltaTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            
            Player.Update();
            WallSystem.Update();
            CameraSystem.Update();
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(0f, .05f, .1f, 1f));
                
            Globals.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, transformMatrix: CameraSystem.MainCamera.Transform);

            MainMap.Draw();
            WallSystem.Draw();
            Player.Draw();
            
            Globals.SpriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}