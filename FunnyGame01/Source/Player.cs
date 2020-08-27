using FunnyGame01.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FunnyGame01
{
    public static class Player
    {
        public static SpriteStack SpriteStack;
        public static Transform Transform;

        public static Vector2 Velocity;

        public const float MoveSpeed = .1f;

        public static void Load()
        {
            SpriteStack = new SpriteStack();
            SpriteStack.Textures = new Texture2D[32];

            for (int i = 0; i < SpriteStack.Textures.Length; i++)
                SpriteStack.Textures[i] = Assets.SquareTexture;
            
            SpriteStack.Colour = Color.White;
            
            Transform.Scale = Vector2.One;
            Transform.Rotation = MathHelper.ToRadians(45f);
            Transform.Position = new Vector2((float)MainMap.Map.TmxMap.ObjectGroups["SpawnPoints"].Objects["PlayerSpawn"].X,
                (float)MainMap.Map.TmxMap.ObjectGroups["SpawnPoints"].Objects["PlayerSpawn"].Y);
        }

        public static void Update()
        {
            Velocity = Vector2.Zero;
            
            if (Input.IsKeyDown(Keys.A))
                Velocity.X--;
            if (Input.IsKeyDown(Keys.D))
                Velocity.X++;
            if (Input.IsKeyDown(Keys.W))
                Velocity.Y--;
            if (Input.IsKeyDown(Keys.S))
                Velocity.Y++;

            if (Input.IsKeyDown(Keys.F))
                Transform.Rotation -= .01f;
            if (Input.IsKeyDown(Keys.G))
                Transform.Rotation += .01f;

            if (Velocity != Vector2.Zero)
                Velocity = Vector2.Normalize(Velocity);

            Transform.Position += Velocity * MoveSpeed * Time.DeltaTime;
        }

        public static void Draw()
        {
            Functions.Draw(ref SpriteStack, ref Transform);
        }
    }
}