using Data.BIDV.Models;
using DataBIDV.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        [HttpGet("GetDocuments/{page}")]
        public async Task<IActionResult> Get(int page)
        {
            string result = String.Empty;
            List<Root> List = new List<Root>();

            string json = await _services.VBNB.Get_Documents(page.ToString(), "vietld", "0975318195");
            result = await _services.VBNB.Upsert_Documents(json);

            if (result == "OK") { return Ok("Lấy dữ liệu thành công"); }
            else { return BadRequest("Lỗi khi truy xuất dữ liệu!"); }
        }

        [HttpGet("GetAllDocuments")]
        public async Task<IActionResult> GetAllDocuments()
        {
            string result = String.Empty;
            List<Root> List = new List<Root>();
            for (int page = 1; page <= 559; page++)
            {
                string json = await _services.VBNB.Get_Documents(page.ToString(), "vietld", "0975318195");
                result = await _services.VBNB.Upsert_Documents(json);
                Thread.Sleep(60000);
            }

            if (result == "OK") { return Ok("Lấy dữ liệu thành công"); }
            else { return BadRequest("Lỗi khi truy xuất dữ liệu!"); }
        }        

        [HttpGet("GetCabinet/{id}")]
        public async Task<IActionResult> Get_Cabinets(int id)
        {
            string result = String.Empty;
            List<Root> List = new List<Root>();

            string json = await _services.VBNB.Get_Documents_Cabinets(id.ToString(), "vietld", "0975318195");
            result = await _services.VBNB.Upsert_Documents_Cabinets(json, id);

            if (result == "OK") { return Ok("Lấy dữ liệu thành công"); }
            else { return BadRequest("Lỗi khi truy xuất dữ liệu!"); }
        }


    }
}
