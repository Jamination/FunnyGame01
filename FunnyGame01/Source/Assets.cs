using Microsoft.Xna.Framework.Graphics;

namespace FunnyGame01
{
    public static class Assets
    {
        public static Texture2D SquareTexture;

        public static void Load()
        {
            SquareTexture = Globals.Content.Load<Texture2D>("Sprites/Square");
        }
    }
}