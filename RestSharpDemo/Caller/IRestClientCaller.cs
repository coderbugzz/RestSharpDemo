using RestSharpDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo.Caller
{
    public interface IRestClientCaller
    {
        void Create(member data);
        Task<List<member>> GetMembers();
        void Update(member data);
        void Delete(int Id);
        Task<member> GetMemberByID(int Id);
            
    }
}
