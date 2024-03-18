namespace MinecraftCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Game game = new Game(1024, 768, "Game"))
            {
                game.Run();
            }
        }
    }
}
