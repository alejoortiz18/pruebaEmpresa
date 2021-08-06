using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ServicesSite.Domain;
using ServicesSite.Domain.Entities;
using ServicesSite.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSite.Persistence.Queries
{
    public interface IClientesQueries
    {
        Task<List<ClienteE>> GetListCLients();
    }

    public class ClientesQueries: IDisposable , IClientesQueries
    {
        private PruebaDbContext _context = null;
        private readonly ConnectionString _settings;

        public ClientesQueries(IOptions<ConnectionString> settings)
        {
            _settings = settings.Value;
            _context = new PruebaDbContext(_settings.PruebaConnection);
        }

        #region Implementación Dispose
        bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                _context?.Dispose();
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
        #endregion

        public async Task<List<ClienteE>> GetListCLients()
        {
            List<ClienteE> itemList = null;
            try
            {
                itemList = await _context.ClienteEs.FromSqlRaw("dbo.GetListCLients").ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

            return itemList;
        }
    }
}
