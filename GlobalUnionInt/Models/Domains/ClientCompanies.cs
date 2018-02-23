using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlobalUnionInt.Models.Domains
{
    public class ClientCompanies
    {
        public int Id { get; set; }
        public string ClientCompanyName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public string PostalCode { get; set; }
    }
}