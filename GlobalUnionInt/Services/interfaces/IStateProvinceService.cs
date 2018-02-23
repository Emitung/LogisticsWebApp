using System.Collections.Generic;
using LeaseHold.Models.Domain;

namespace GlobalUnionInt.Services.interfaces
{
    public interface IStateProvinceService
    {
        IEnumerable<StateProvince> SelectAll();
    }
}