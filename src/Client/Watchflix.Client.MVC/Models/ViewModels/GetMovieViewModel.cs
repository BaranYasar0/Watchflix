namespace Watchflix.Client.MVC.Models.ViewModels
{
    public class GetMovieViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Duration { get; set; }
        public string PictureUrl { get; set; }
        public double Rating { get; set; }
        public GetCategoryViewModel CategoryResponseDto { get; set; }
    }
}
