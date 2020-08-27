using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace SudokuWebsite.Models
{
    public class GameAd
    {

        public string Id  { get; set; }

        [JsonPropertyName("img")]
        public string Image  { get; set; }
        public string Url  { get; set; }
        public string Title  { get; set; }
        public string Description  { get; set; }



        public override string ToString() => JsonSerializer.Serialize<GameAd>(this);
        
    }
}
