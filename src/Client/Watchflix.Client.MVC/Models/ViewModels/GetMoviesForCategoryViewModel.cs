namespace Watchflix.Client.MVC.Models.ViewModels
{
    public class GetMoviesForCategoryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Duration { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public double Rating { get; set; }
        public string CorrectDuration => ConfigureDuration();


        private string ConfigureDuration()
        {
            return this.Duration.ToString().Split(",")[0];
        }
    }
}
