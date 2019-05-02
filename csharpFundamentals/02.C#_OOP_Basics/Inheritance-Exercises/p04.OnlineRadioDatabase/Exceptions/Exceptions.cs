public class Exceptions
{
    protected const int MinArtistNameLength = 3;
    protected const int MaxArtistNameLength = 20;

    protected const int MinSongNameLength = 3;
    protected const int MaxSongNameLength = 30;

    protected const int MinSongLenght = 0;
    protected const int MaxSongLenght = 15;

    protected const int MinSongMinutes = 0;
    protected const int MaxSongMinutes = 14;

    protected const int MinSongSeconds = 0;
    protected const int MaxSongSeconds = 59;

    protected const string ArtistNameError = "Artist name should be between {0} and {1} symbols.";
    protected const string SongNameError = "Song name should be between {0} and {1} symbols.";
    protected const string InvalidSongError = "Invalid song length.";
    protected const string InvalidSongMinutesError = "Song minutes should be between {0} and {1}.";
    protected const string InvalidSongSecondsError = "Song seconds should be between {0} and {1}.";
}   