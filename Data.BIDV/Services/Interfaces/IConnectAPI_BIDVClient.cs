﻿using DataBIDV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBIDV.Services.Interfaces
{
    public interface IConnectAPI_BIDVClient
    {
        public Task<List<GiaoDich>> Get_DanhSachGiaoDich_Encrypt(RequestBody request);

    }
}
