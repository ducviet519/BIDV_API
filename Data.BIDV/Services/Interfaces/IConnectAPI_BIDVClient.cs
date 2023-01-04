using DataBIDV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBIDV.Services.Interfaces
{
    public interface IConnectAPI_BIDVClient
    {

        public Task<Root_GiaoDich> Get_DanhSachGiaoDich_Encrypt(RequestBody request);
        public Task<string> Get_DanhSachGiaoDich_Json(RequestBody request);
    }
}
