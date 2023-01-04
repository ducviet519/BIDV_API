using Data.BIDV.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using DataBIDV.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Data.BIDV.Services.Repositories
{
    public class ConnectAPI_VBNBClient : IConnectAPI_VBNBClient
    {
        private readonly string _baseUrl = "http://vbnb.bvta.vn/";
        #region Database Connection
        private readonly IConfiguration _configuration;
        public ConnectAPI_VBNBClient(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("DefaultConnection");
            provideName = "System.Data.SqlClient";
        }
        public string ConnectionString { get; }
        public string provideName { get; }
        public IDbConnection Connection
        {
            get { return new SqlConnection(ConnectionString); }
        }

        #endregion

        public async Task<string> Get_Documents(string page, string username, string password)
        {
            var options = new RestClientOptions(_baseUrl);
            using var client = new RestClient(options)
            {
                Authenticator = new HttpBasicAuthenticator(username, password),
            };

            var request = new RestRequest("api/documents/");
            request.AddParameter("page", page);
            var response = await client.GetAsync(request);

            if (response.IsSuccessful)
            {
                return response.Content;
            }

            return null;
        }

        public async Task<string> Upsert_Documents(string json)
        {
            string result = String.Empty;
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();
                    var data = (await dbConnection.ExecuteAsync("sp_VBNBCu_Get",
                    new
                    {
                        json = json,
                    },
                        commandType: CommandType.StoredProcedure));
                    if (data > 0)
                    {
                        result = "OK";
                    }
                    dbConnection.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return result;
            }
        }
    }
}
