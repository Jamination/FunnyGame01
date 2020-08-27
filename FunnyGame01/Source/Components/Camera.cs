using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FunnyGame01.Components
{
    public struct Camera
    {
        public Vector2 Position;
        public float Zoom, Rotation;
        public Matrix Transform;
        public Viewport Viewport;
    }
}