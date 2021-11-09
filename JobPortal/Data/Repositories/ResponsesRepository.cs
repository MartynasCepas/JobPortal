using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Data.Repositories
{
    public interface IResponsesRepository
    {
        Task<IEnumerable<Response>> GetAllAsync();
        Task<Response> GetByIdAsync(int id);
        Task InsertAsync(Response response);
        Task UpdateAsync(Response response);
        Task DeleteAsync(Response response);
    }

    public class ResponsesRepository : IResponsesRepository
    {
        private readonly RestContext _restContext;

        public ResponsesRepository(RestContext restContext)
        {
            _restContext = restContext;
        }

        public async Task<IEnumerable<Response>> GetAllAsync()
        {
            return await _restContext.Responses.ToListAsync();
        }

        public async Task<Response> GetByIdAsync(int id)
        {
            return await _restContext.Responses.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task InsertAsync(Response response)
        {
            _restContext.Responses.Add(response);
            await _restContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Response response)
        {
            _restContext.Responses.Update(response);
            await _restContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Response response)
        {
            _restContext.Responses.Remove(response);
            await _restContext.SaveChangesAsync();
        }
    }
}
