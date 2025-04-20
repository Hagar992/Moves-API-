namespace Moves_API_.Dtos
{
    public class MoviesDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public double Rate { get; set; }
        public string StoryLine { get; set; }
        public byte[] Poster { get; set; }
        public byte GenreId { get; set; }
        public String GenreName { get; set; }
    }
}
