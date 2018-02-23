using DbConnector.Tools;
using GlobalUnionInt.Models.Domains;
using GlobalUnionInt.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlobalUnionInt.Services
{
    public class ClientCompaniesService : BaseService, IClientCompaniesService
    {
        public int Insert(ClientCompaniesAddRequest model)
        {

            int id = 0;

            Adapter.ExecuteQuery("dbo.ClientCompanies_Insert", new[]
            {
                SqlDbParameter.Instance.BuildParameter("@ClientCompanyName", model.ClientCompanyName, System.Data.SqlDbType.NVarChar, 200),
                SqlDbParameter.Instance.BuildParameter("@StreetAddress", model.StreetAddress, System.Data.SqlDbType.NVarChar, 200),
                SqlDbParameter.Instance.BuildParameter("@City", model.City, System.Data.SqlDbType.NVarChar, 150),
                SqlDbParameter.Instance.BuildParameter("@StateId", model.StateId, System.Data.SqlDbType.Int),
                SqlDbParameter.Instance.BuildParameter("@PostalCode", model.PostalCode, System.Data.SqlDbType.NVarChar, 15),
                SqlDbParameter.Instance.BuildParameter("@Id", 0, System.Data.SqlDbType.Int, paramDirection: System.Data.ParameterDirection.Output)
            },
            (parameters =>
            {
                id = parameters.GetParamValue<int>("@Id");
            }));

            return id;
        }

        public IEnumerable<ClientCompanies> SelectAll()
        {
            return Adapter.LoadObject<ClientCompanies>("dbo.ClientCompanies_SelectAll");
        }

        public void Update(ClientCompaniesUpdateRequest model)
        {
            Adapter.ExecuteQuery("dbo.ClientCompanies_Update", new[]
            {
                SqlDbParameter.Instance.BuildParameter("@Id", model.Id, System.Data.SqlDbType.Int),
                SqlDbParameter.Instance.BuildParameter("@ClientCompanyName", model.ClientCompanyName, System.Data.SqlDbType.NVarChar, 200),
                SqlDbParameter.Instance.BuildParameter("@StreetAddress", model.StreetAddress, System.Data.SqlDbType.NVarChar, 200),
                SqlDbParameter.Instance.BuildParameter("@City", model.City, System.Data.SqlDbType.NVarChar, 150),
                SqlDbParameter.Instance.BuildParameter("@StateId", model.StateId, System.Data.SqlDbType.Int),
                SqlDbParameter.Instance.BuildParameter("@PostalCode", model.PostalCode, System.Data.SqlDbType.NVarChar, 15)
            });
        }

        public void Delete(int id)
        {
            Adapter.ExecuteQuery("dbo.ClientCompanies_Delete", new[]
            {
                SqlDbParameter.Instance.BuildParameter("@Id", id, System.Data.SqlDbType.Int)
            });
        }
    }
}