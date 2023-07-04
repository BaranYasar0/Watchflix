namespace Watchflix.Client.MVC.Models.ViewModels
{
    public class GetMovieViewModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Rating { get; set; }
        public GetCategoryViewModel GetCategoryViewModel { get; set; }
    }
}
