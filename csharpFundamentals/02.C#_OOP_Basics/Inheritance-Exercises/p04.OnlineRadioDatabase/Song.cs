using System;

public class Song : Exceptions
{
    //private const int MinArtistNameLength = 3;
    //private const int MaxArtistNameLength = 20;

    //private const int MinSongNameLength = 3;
    //private const int MaxSongNameLength = 30;

    //private const int MinSongLenght = 0;
    //private const int MaxSongLenght = 15;

    //private const int MinSongMinutes = 0;
    //private const int MaxSongMinutes = 14;

    //private const int MinSongSeconds = 0;
    //private const int MaxSongSeconds = 59;

    //private const string ArtistNameError = "Artist name should be between {0} and {1} symbols.";
    //private const string SongNameError = "Song name should be between {0} and {1} symbols.";
    //private const string InvalidSongError = "Invalid song length.";
    //private const string InvalidSongMinutesError = "Song minutes should be between {0} and {1}.";
    //private const string InvalidSongSecondsError = "Song seconds should be between {0} and {1}.";

    private string artist;
    private string name;
    private string duration;

    public Song() { }

    public Song(string artist, string name, string duration)
        : this()
    {
        this.Duration = duration;
        this.Name = name;
        this.Artist = artist;
    }

    public string Duration
    {
        get
        {
            return this.duration;
        }
        set
        {
            ValidateSongDuration(value);
            this.duration = value;
        }
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (!(MinSongNameLength <= value.Length && value.Length <= MaxSongNameLength))
            {
                throw new ArgumentException(string.Format(SongNameError, MinSongNameLength, MaxSongNameLength));
            }
            this.name = value;
        }
    }

    public string Artist
    {
        get
        {
            return this.artist;
        }
        set
        {
            if (!(MinArtistNameLength <= value.Length && value.Length <= MaxArtistNameLength))
            {
                throw new ArgumentException(string.Format(ArtistNameError, MinArtistNameLength, MaxArtistNameLength));
            }
            this.artist = value;
        }
    }

    public TimeSpan TotalDurationOfSong
    {
        get
        {
            return this.CalculateSongDuration(this.Duration);
        }
    }

    private TimeSpan CalculateSongDuration(string duration)
    {
        var minutesAndSeconds = duration.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        var minutes = int.Parse(minutesAndSeconds[0]);
        var seconds = int.Parse(minutesAndSeconds[1]);

        var durationTimeSpan = new TimeSpan(0, minutes, seconds);

        return durationTimeSpan;
    }

    private void ValidateSongDuration(string value)
    {
        var minutesAndSeconds = value.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

        //if (minutesAndSeconds.Length != 2)
        //{
        //    throw new ArgumentException(InvalidSongError);
        //}
        
        var isItInMinutes = int.TryParse(minutesAndSeconds[0], out int minutes);
        var isItInSeconds = int.TryParse(minutesAndSeconds[1], out int seconds);

        if (!isItInMinutes || !isItInSeconds)
        {
            throw new ArgumentException(InvalidSongError);
        }

        var duration = new TimeSpan(0, minutes, seconds);

        if (!(MinSongMinutes <= minutes && minutes <= MaxSongMinutes))
        {
            throw new ArgumentException(string.Format(InvalidSongMinutesError, MinSongMinutes, MaxSongMinutes));

        }
        else if (!(MinSongSeconds <= seconds && seconds <= MaxSongSeconds))
        {
            throw new ArgumentException(string.Format(InvalidSongSecondsError, MinSongSeconds, MaxSongSeconds));
        }
        
    }
}