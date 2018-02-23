using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaseHold.Models.Domain
{
    public class StateProvince
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string StateProvinceCode { get; set; }
        public string CountryRegionCode { get; set; }
        public bool IsOnlyStateProvinceFlag{ get; set; }
        public string Name { get; set; }
        public int TerritoryID { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
