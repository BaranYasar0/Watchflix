namespace Watchflix.Api.Movies.Models.Dtos
{
    public class PageRequestDto
    {
        public int Index { get; set; } = 0;
        public int Size { get; set; } = 10;
    }
}
