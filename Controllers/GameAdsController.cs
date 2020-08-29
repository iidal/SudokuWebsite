using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SudokuWebsite.Models;
using SudokuWebsite.Services;

namespace SudokuWebsite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameAdsController : ControllerBase
    {

        public GameAdsController(JsonFileGameAdService gameAdService) {
            this.GameAdService = gameAdService;
        }
        public JsonFileGameAdService GameAdService { get; }

        [HttpGet]
        public IEnumerable<GameAd> Get() {
            return GameAdService.GetAds();
        }
    }
}
