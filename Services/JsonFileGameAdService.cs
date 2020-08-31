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

    }
}
