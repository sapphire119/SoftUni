namespace p04.OnlineRadioDatabase
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            var songs = new List<Song>();

            var numberOfSongs = int.Parse(Console.ReadLine());

            for (int count = 0; count < numberOfSongs; count++)
            {
                try
                {
                    CreateAndAddSong(songs);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            PrintOutput(songs);
        }

        private static void PrintOutput(List<Song> songs)
        {
            Console.WriteLine($"Songs added: {songs.Count}");

            var totalDurationSeconds = songs.Sum(sd => sd.TotalDurationOfSong.TotalSeconds);

            var resultInSeconds = TimeSpan.FromSeconds(totalDurationSeconds);
            var result = string.Format("{0}h {1}m {2}s", resultInSeconds.Hours, resultInSeconds.Minutes, resultInSeconds.Seconds);
            Console.WriteLine($"Playlist length: {result}");
        }

        private static void CreateAndAddSong(List<Song> songs)
        {
            var songInput = Console.ReadLine().Split(';');
            
            if (songInput.Length != 3)
            {
                throw new ArgumentException("Invalid song.");
            }

            var artistName = songInput[0];
            var songName = songInput[1];
            var minutesAndSeconds = songInput[2];
            
            var song = new Song(artistName, songName, minutesAndSeconds);
            songs.Add(song);

            Console.WriteLine("Song added.");
        }
    }
}
