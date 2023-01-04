using Data.BIDV.Models;
using DataBIDV.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIDV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VBNBController : Controller
    {
        private readonly IUnitOfWork _services;
        public VBNBController(IUnitOfWork services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page)
        {
            string result = String.Empty;
            List<Root> List = new List<Root>();
            //for (int page = 1; page <= 559; page++)
            //{
            //    string json = await _services.VBNB.Get_Documents(page.ToString(), "vietld", "0975318195");
            //    result = await _services.VBNB.Upsert_Documents(json);
            //}
            string json = await _services.VBNB.Get_Documents(page.ToString(), "vietld", "0975318195");
                result = await _services.VBNB.Upsert_Documents(json);

            if (result == "OK") { return Ok(); }
            else { return BadRequest(); }
        }
    }
}
