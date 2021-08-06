using AsNet.Shared.Constants;
using AsNet.Shared.Entities;
using ServiceSite.Persistence.Queries;
using ServicesSite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApi.Application.Queries
{
    public interface IClientesQueriesB
    {
        Task<BResult<List<ClienteE>, int>> GetList();
    }


    public class ClientesQueriesB : IClientesQueriesB
    {
        IClientesQueries _clientes;
        public ClientesQueriesB(IClientesQueries clientes)
        {
            _clientes = clientes;
        }

        public async Task<BResult<List<ClienteE>, int>> GetList()
        {
            BResult<List<ClienteE>, int> bResult = null;
            TimeDto timeDto = new TimeDto() { Start = DateTime.Now };
            try
            {
                List<ClienteE> lstclientes = await _clientes.GetListCLients();
                bResult = BResult<List<ClienteE>, int>.MethodSuccess(lstclientes, 1, timeDto);
            }
            catch (Exception ex)
            {
                string methodName = $"{MethodBase.GetCurrentMethod().DeclaringType}.{MethodBase.GetCurrentMethod().Name}";
                string messageSend = $"{ex.ToString()} - {methodName}";
                bResult = BResult<List<ClienteE>, int>.MethodFailure(null, "SelectRecordsFailure", DataConstants.RPTA_RETURN_DATA_NOSELECT, messageSend, -1, timeDto);

            }

            return bResult;
        }
    }
}
