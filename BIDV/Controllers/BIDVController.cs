using DataBIDV.Extensions;
using DataBIDV.Models;
using DataBIDV.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIDV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BIDVController : Controller
    {
        private readonly IUnitOfWork _services;
        public BIDVController(IUnitOfWork services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string accountNo, string transDate, string pageNum)
        {
            RequestBody requestBody = new RequestBody() { accountNo = accountNo, transDate = transDate, pageNum = Int32.Parse(pageNum) };
            return Ok(await _services.API.Get_DanhSachGiaoDich_Encrypt(requestBody));
        }
    }
}
