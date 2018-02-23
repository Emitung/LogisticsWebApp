using System.Collections.Generic;
using GlobalUnionInt.Models.Requests;
using GlobalUnionInt.Models.Domains;

namespace GlobalUnionInt.Services.interfaces
{
    public interface ITruckingCompaniesService
    {
        int Insert(TruckingCompaniesAddRequest model);
        IEnumerable<TruckingCompanies> SelectAll();
        void Update(TruckingCompaniesUpdateRequest model);
        void Delete(int id);
    }
}