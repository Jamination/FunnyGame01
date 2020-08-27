using System;
using System.IO;
using System.Linq;
using FunnyGame01.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TiledSharp;

namespace FunnyGame01
{
 public static class Functions
    {
        public static void Draw(ref Sprite sprite, ref Transform transform)
        {
            var centerOrigin = Vector2.Zero;
            
            if (sprite.Centered)
                centerOrigin = sprite.Texture.Bounds.Size.ToVector2() * .5f;
            
            Globals.SpriteBatch.Draw(
                sprite.Texture,
                new Vector2((int)transform.Position.X, (int)transform.Position.Y),
                sprite.SourceRect,
                sprite.Colour,
                transform.Rotation,
                centerOrigin + sprite.Origin,
                transform.Scale,
                sprite.Effects,
                sprite.LayerDepth
            );
        }
        
        public static void Draw(ref SpriteStack spriteStack, ref Transform transform)
        {
            for (int i = 0; i < spriteStack.Textures.Length; i++)
            {
                var centerOrigin = spriteStack.Textures[i].Bounds.Size.ToVector2() * .5f;
                
                Globals.SpriteBatch.Draw(
                    spriteStack.Textures[i],
                    new Vector2((int)transform.Position.X + i * .2f, (int)transform.Position.Y + i * .5f),
                    null,
                    new Color(0f, 0f, 0f, 1f / i * .25f),
                    transform.Rotation,
                    centerOrigin + spriteStack.Origin,
                    transform.Scale,
                    spriteStack.Effects,
                    spriteStack.LayerDepth
                );
            }
            
            for (int i = 0; i < spriteStack.Textures.Length; i++)
            {
                var centerOrigin = spriteStack.Textures[i].Bounds.Size.ToVector2() * .5f;
                
                Globals.SpriteBatch.Draw(
                    spriteStack.Textures[i],
                    new Vector2((int)transform.Position.X, (int)transform.Position.Y) + CameraSystem.CameraUp * i * .5f,
                    null,
                    spriteStack.Colour,
                    transform.Rotation,
                    centerOrigin + spriteStack.Origin,
                    transform.Scale,
                    spriteStack.Effects,
                    spriteStack.LayerDepth
                );
            }
        }

        public static void Draw(ref Map map)
        {
            /*var centerOrigin = Vector2.Zero;
            
            if (sprite.Centered)
                centerOrigin = sprite.Texture.Bounds.Size.ToVector2() * .5f;*/

            var tileset = Globals.Content.Load<Texture2D>("TileSets/" + map.TmxMap.Tilesets[0].Name.ToString());

            int tileSetTilesWide = tileset.Width / map.TileWidth;
            int tileSetTilesHigh = tileset.Height / map.TileHeight;

            for (int i = 0; i < map.TmxMap.Layers.Count; i++)
            {
                for (int j = 0; j < map.TmxMap.Layers[i].Tiles.Count; j++)
                {
                    int gid = map.TmxMap.Layers[i].Tiles[j].Gid;

                    if (gid != 0)
                    {
                        int tileFrame = gid - 1;
                        int column = tileFrame % tileSetTilesWide;
                        int row = (int)Math.Floor((double)tileFrame / (double)tileSetTilesWide);

                        float x = (j % map.MapWidth) * map.TileWidth;
                        float y = (float)Math.Floor(j / (double)map.MapHeight) * map.TileHeight;

                        var tilesetRec = new Rectangle(map.TileWidth * column, map.TileHeight * row, map.TileWidth, map.TileHeight);

                        Globals.SpriteBatch.Draw(tileset, new Rectangle((int)x, (int)y, map.TileWidth, map.TileHeight), tilesetRec, Color.White);
                    }
                }
            }
        }

        public static void NewMap(ref Map map, string filename)
        {
            map = new Map();
            map.TmxMap = new TmxMap(filename);
            map.MapWidth = map.TmxMap.Width;
            map.MapHeight = map.TmxMap.Height;
            map.TileWidth = map.TmxMap.Tilesets[0].TileWidth;
            map.TileHeight = map.TmxMap.Tilesets[0].TileHeight;
        }
        
        public static float Map(float value, float fromLow, float fromHigh, float toLow, float toHigh) => (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
        
        public static T Choose<T>(params T[] list) => list[Globals.Random.Next(0, list.ToArray().Length)];
    }
}