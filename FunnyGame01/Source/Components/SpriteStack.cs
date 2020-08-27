using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FunnyGame01.Components
{
    public struct SpriteStack
    {
        public Texture2D[] Textures;
        public Color Colour;
        public Vector2 Origin;
        public SpriteEffects Effects;
        public float LayerDepth;
    }
}