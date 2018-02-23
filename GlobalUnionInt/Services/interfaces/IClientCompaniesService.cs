using System.Collections.Generic;
using GlobalUnionInt.Models.Domains;
using GlobalUnionInt.Models.Requests;

namespace GlobalUnionInt.Services
{
    public interface IClientCompaniesService
    {
        void Delete(int id);
        int Insert(ClientCompaniesAddRequest model);
        IEnumerable<ClientCompanies> SelectAll();
        void Update(ClientCompaniesUpdateRequest model);
    }
}