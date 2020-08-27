using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SudokuWebsite.Models;
using SudokuWebsite.Services;

namespace SudokuWebsite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileGameAdService GameAdService;
        public IEnumerable<GameAd> GameAds { get; private set; }

        public IndexModel(ILogger<IndexModel> logger,
            JsonFileGameAdService gameAdService)
        {
            _logger = logger;
            GameAdService = gameAdService; //lets not get null
        }

        public void OnGet()
        {
            GameAds = GameAdService.GetAds();
        }
    }
}
