using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sm_coding_challenge.Models;
using sm_coding_challenge.Services.DataProvider;
using smcodingchallenge.Models;

namespace sm_coding_challenge.Controllers
{
    public class HomeController : Controller
    {

        private IDataProvider _dataProvider;
        public HomeController(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PlayersAsync(string ids)
        {
            var idList = ids.Split(',');
            return Ok(await _dataProvider.GetPlayers(idList, (int)PlayersFlagType.players));
        }

        [HttpGet]
        public async Task<IActionResult> AllPlayersAsync()
        {
            return Ok(await _dataProvider.GetPlayers(null, (int)PlayersFlagType.allPlayers));
        }

        [HttpGet]
        public async Task<IActionResult> LatestPlayersAsync()
        {
            return Ok(await _dataProvider.GetPlayers(null, (int)PlayersFlagType.latestPlayers));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
