using FunnyGame01.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FunnyGame01
{
    public static class WallSystem
    {
        public static Wall[] Walls = new Wall[100];

        public static void Load()
        {
            for (int i = 0; i < Walls.Length; i++)
                NewWall(ref Walls[i]);

            for (int i = 0; i < MainMap.Map.TmxMap.ObjectGroups["Walls"].Objects.Count; i++)
            {
                var wall = MainMap.Map.TmxMap.ObjectGroups["Walls"].Objects[i];
                Walls[i].Active = true;
                Walls[i].Transform.Position = new Vector2((float)wall.X, (float)wall.Y);
            }
        }

        public static void Update()
        {
            
        }

        public static void Draw()
        {
            for (int i = 0; i < Walls.Length; i++)
            {
                if (Walls[i].Active)
                    Functions.Draw(ref Walls[i].SpriteStack, ref Walls[i].Transform);
            }
        }

        public static void NewWall(ref Wall wall)
        {
            wall = new Wall();
            wall.Active = false;
            
            wall.Transform.Scale = Vector2.One;
            
            wall.SpriteStack = new SpriteStack();
            wall.SpriteStack.Colour = Color.White;
            wall.SpriteStack.Textures = new Texture2D[32];

            for (int i = 0; i < wall.SpriteStack.Textures.Length; i++)
                wall.SpriteStack.Textures[i] = Assets.SquareTexture;
        }
    }
}