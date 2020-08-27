using System;
using FunnyGame01.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FunnyGame01
{
    public static class CameraSystem
    {
        public static Camera MainCamera;
        
        public static Vector2 CameraUp => new Vector2((float)Math.Cos(MainCamera.Rotation - (float)Math.PI / 2), (float)Math.Sin(MainCamera.Rotation - (float)Math.PI / 2));

        public static void Load()
        {
            MainCamera = new Camera();
            MainCamera.Viewport = Globals.Graphics.GraphicsDevice.Viewport;
            MainCamera.Position = new Vector2(1920 * .5f, 1080 * .5f);
            MainCamera.Zoom = 4f;
            MainCamera.Rotation = 0f;
        }

        public static void Update()
        {
            if (Input.IsKeyDown(Keys.E))
                MainCamera.Rotation -= .01f;
            if (Input.IsKeyDown(Keys.Q))
                MainCamera.Rotation += .01f;
            MainCamera.Position = Vector2.Lerp(MainCamera.Position, Player.Transform.Position, .25f);
            MainCamera.Transform = Matrix.CreateTranslation(new Vector3(
                                       new Vector2((int) -MainCamera.Position.X, (int) -MainCamera.Position.Y), 0f)) * Matrix.CreateScale(MainCamera.Zoom) *
                                   Matrix.CreateRotationZ(MainCamera.Rotation) *
                                   Matrix.CreateTranslation(new Vector3(MainCamera.Viewport.Width / 2,
                                       MainCamera.Viewport.Height / 2, 0f));
        }
    }
}