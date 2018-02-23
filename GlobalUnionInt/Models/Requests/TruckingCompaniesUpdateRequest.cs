using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlobalUnionInt.Models.Requests
{
    public class TruckingCompaniesUpdateRequest : TruckingCompaniesAddRequest
    {
        public int Id { get; set; }
    }
}