using GlobalUnionInt.Services.interfaces;
using LeaseHold.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlobalUnionInt.Services
{
    public class StateProvinceService : BaseService, IStateProvinceService
    {
        public IEnumerable<StateProvince> SelectAll()
        {
            return Adapter.LoadObject<StateProvince>("dbo.StateProvince_SelectAll");
        }
    }
}