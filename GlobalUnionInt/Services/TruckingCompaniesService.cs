using DbConnector.Tools;
using GlobalUnionInt.Models.Domains;
using GlobalUnionInt.Models.Requests;
using GlobalUnionInt.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlobalUnionInt.Services
{
    public class TruckingCompaniesService : BaseService, ITruckingCompaniesService
    {
        public int Insert(TruckingCompaniesAddRequest model)
        {
            int id = 0;

            Adapter.ExecuteQuery("dbo.TruckingCompanies_Insert", new[]
            {
                SqlDbParameter.Instance.BuildParameter("@TruckingCompanyName", model.TruckingCompanyName, System.Data.SqlDbType.NVarChar, 50),
                SqlDbParameter.Instance.BuildParameter("@Location", model.Location, System.Data.SqlDbType.NVarChar, 50),
                SqlDbParameter.Instance.BuildParameter("@Id", 0,  System.Data.SqlDbType.Int, paramDirection: System.Data.ParameterDirection.Output)
            },
            (parameters =>
            {
                id = parameters.GetParamValue<int>("@Id");
            }));

            return id;
        }

        public IEnumerable<TruckingCompanies> SelectAll()
        {
            return Adapter.LoadObject<TruckingCompanies>("dbo.TruckingCompanies_SelectAll");
        }

        public void Update(TruckingCompaniesUpdateRequest model)
        {
            Adapter.ExecuteQuery("dbo.TruckingCompanies_Update", new[]
            {
                SqlDbParameter.Instance.BuildParameter("@Id", model.Id, System.Data.SqlDbType.Int),
                SqlDbParameter.Instance.BuildParameter("@TruckingCompanyName", model.TruckingCompanyName, System.Data.SqlDbType.NVarChar, 50),
                SqlDbParameter.Instance.BuildParameter("@Location", model.Location, System.Data.SqlDbType.NVarChar, 50)
            });
        }

        public void Delete(int id)
        {
            Adapter.ExecuteQuery("dbo.TruckingCompanies_Delete", new[]
            {
                SqlDbParameter.Instance.BuildParameter("@Id", id, System.Data.SqlDbType.Int)
            });
        }
    }
}