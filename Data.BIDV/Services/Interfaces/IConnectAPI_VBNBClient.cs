using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.BIDV.Services.Interfaces
{
    public interface IConnectAPI_VBNBClient
    {
        Task<string> Get_Documents(string page, string username, string password);

        Task<string> Upsert_Documents(string json);
    }
}
