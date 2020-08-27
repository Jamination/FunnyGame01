using FunnyGame01.Components;
using TiledSharp;

namespace FunnyGame01
{
    public static class MainMap
    {
        public static Map Map;
        
        public static void Load()
        {
            Map = new Map();
            Functions.NewMap(ref Map, "../../../Content/Maps/Map1.xml");
        }

        public static void Draw()
        {
            Functions.Draw(ref Map);
        }
    }
}