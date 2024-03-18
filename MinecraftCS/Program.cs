using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace MinecraftCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var window = new Game(1024, 768, "Game"))
            {
                window.Run();
            }
        }
    }
}
