namespace DRMusicRest.Model
{
    public class Record
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }

        public int Duration { get; set; }
        public int PublicationYear { get; set; }

        public Record(int id, string title, string artist, int duration, int publicationYear)
        {
            Id = id;
            Title = title;
            Artist = artist;
            Duration = duration;
            PublicationYear = publicationYear;
        }

        public Record()
        {
        }
    }
}
