using System;

namespace HotDogGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new BallVoidGame())
                game.Run();
        }
    }
}
