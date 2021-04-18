using RestSharp;
using RestSharpDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RestSharpDemo.Caller
{
    public class RestClientCaller : IRestClientCaller
    {
        private readonly RestClient _client;
        private readonly string _url = "https://localhost:44302/";

        public RestClientCaller()
        {
            _client = new RestClient(_url);
        }
        public void Create(member data)
        {
            var request = new RestRequest("api/CRUD/Create", Method.POST);
            request.AddJsonBody(data);
            _client.Execute(request);
        }

        public void Delete(int Id)
        {
            var request = new RestRequest("api/CRUD/Delete?id=" + Id, Method.DELETE);
            _client.Execute(request);
        }

        public async Task<member> GetMemberByID(int Id)
        {
            var request = new RestRequest("api/CRUD/GetMembersById?Id=" + Id, Method.GET)
            { RequestFormat = DataFormat.Json };

            var response = await _client.ExecuteAsync<member>(request);

            return response.Data;
        }

        public async Task<List<member>> GetMembers()
        {
            var request = new RestRequest("api/CRUD/GetMembers", Method.GET)
            { RequestFormat = DataFormat.Json };

            var response = await _client.ExecuteAsync<List<member>>(request);
            return response.Data;
        }

        public void Update(member data)
        {
            var request = new RestRequest("api/CRUD/Update", Method.PUT);
            request.AddJsonBody(data);
            _client.Execute(request);
        }
    }
}