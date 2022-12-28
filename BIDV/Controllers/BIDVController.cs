using DataBIDV.Models;
using DataBIDV.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<List<GiaoDich>> Get(RequestBody requestBody)
        {
            List<GiaoDich> DanhSachGiaoDich_Encrypt = await _services.API.Get_DanhSachGiaoDich_Encrypt(requestBody);
            return DanhSachGiaoDich_Encrypt;
        }
    }
}
