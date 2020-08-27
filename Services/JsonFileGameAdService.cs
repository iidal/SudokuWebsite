using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using SudokuWebsite.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace SudokuWebsite.Services
{
    public class JsonFileGameAdService
    {
        public JsonFileGameAdService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName //get the game ad file
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "AdsToProjects.json"); }
        }

        public IEnumerable<GameAd> GetAds()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<GameAd[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions //not interested in lower case or upper case characters
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        /*
        public void AddRating(string productId, int rating)
        {
            var products = GetProducts();

            if (products.First(x => x.Id == productId).Ratings == null)
            {
                products.First(x => x.Id == productId).Ratings = new int[] { rating };
            }
            else
            {
                var ratings = products.First(x => x.Id == productId).Ratings.ToList();
                ratings.Add(rating);
                products.First(x => x.Id == productId).Ratings = ratings.ToArray();
            }

            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Product>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                );
            }*/
    }
}
