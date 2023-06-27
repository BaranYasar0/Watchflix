using Watchflix.Api.Movies.Models.Entities;

namespace Watchflix.Api.Movies.EntityFramework
{
    public static class DataSeeding
    {

        //public static List<Category> SeedCategories()
        //{
        //    var Aksiyon = new Category("Aksiyon", "Aksiyon Filmleri veya Dizileri");
        //    var Dram = new Category("Dram", "Dram Filmleri veya Dizileri");
        //    var BilimKurgu = new Category("Bilim Kurgu", "Bilim Kurgu Filmleri veya Dizileri");
        //    var Fantastik = new Category("Fantastik", "Fantastik Filmleri veya Dizileri");
        //    var Komedi = new Category("Komedi", "Komedi Filmleri veya Dizileri");

        //    return new List<Category>() { Aksiyon, Dram, BilimKurgu, Fantastik, Komedi };
        //}

        //public static List<Movie> SeedMovies()
        //{
        //    var categories = SeedCategories();
        //    return new List<Movie>
        //    {
        //        new Movie((categories.Where(x => x.Name == "Aksiyon").ToList()), "Hızlı ve Öfkeli 10", 134m,
        //            "Aile her şeydir!", 7.2),
        //        new Movie((categories.Where(x => x.Name == "Dram").ToList()), "After ayrılık", 100m,
        //            "İki arasındaki ilişkiyi konu alır.", 7.0),
        //        new Movie((categories.Where(x => x.Name == "Bilim Kurgu").ToList()), "Interstellar", 113m,
        //            "Uzayda geçen bilim kurgu filmi.", 8.4),
        //        new Movie((categories.Where(x => x.Name == "Fantastik").ToList()), "Yenilmezler:Sonsuzluk Savaşı", 150m,
        //            "Thanosa karşı son savaşı veren yenilmezler,zamanda geriye yolculuk yaparak sonsuzluk taşlarını geri almaya çalışır", 9.5),
        //        new Movie((categories.Where(x => x.Name == "Komedi").ToList()), "A.R.O.G", 110m,
        //            "Zamanda geriye giden arif evine dönüş yolu arar.", 9.8)
        //    };
        //}

        //public static List<Series> SeedSeries()
        //{
        //    var categories = SeedCategories();
        //    return new List<Series>
        //    {
        //        new Series("The Flash",categories.Where(x=>x.Name=="Fantastik"||x.Name=="Aksiyon").ToList(),10,22),
        //        new Series("Witcher",categories.Where(x=>x.Name=="Bilim Kurgu"||x.Name=="Fantastik").ToList(),10,22),
        //        new Series("Mentalist",categories.Where(x=>x.Name=="Komedi"||x.Name=="Aksiyon").ToList(),10,22),
        //    };
        //}
    }
}
