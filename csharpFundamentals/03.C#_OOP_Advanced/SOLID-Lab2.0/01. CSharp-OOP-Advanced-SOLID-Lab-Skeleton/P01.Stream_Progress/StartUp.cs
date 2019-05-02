namespace P01.Stream_Progress
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var file = new File("ivan", 40, 500);
            var music = new Music("pesho", "izgrani", 24, 500);
            var game = new Game("MMORPG", 50, 250, 500);

            
            StreamProgressInfo stream = new StreamProgressInfo(file);
            var test = stream.CalculateCurrentPercent();
            var gameLength = game.Length;
            var gameBytes = game.BytesSent;

            StreamProgressInfo info = new StreamProgressInfo(game);
            var test2 = info.CalculateCurrentPercent();
        }
    }
}
