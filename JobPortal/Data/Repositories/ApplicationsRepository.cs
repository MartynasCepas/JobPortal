using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Data.Repositories
{
    public interface IApplicationsRepository
    {
        Task<IEnumerable<Application>> GetAllAsync();
        Task<Application> GetByIdAsync(int id);
        Task InsertAsync(Application offer);
        Task UpdateAsync(Application offer);
        Task DeleteAsync(Application offer);
    }

    public class ApplicationsRepository : IApplicationsRepository
    {
        private readonly RestContext _restContext;

        public ApplicationsRepository(RestContext restContext)
        {
            _restContext = restContext;
        }

        public async Task<IEnumerable<Application>> GetAllAsync()
        {
            return await _restContext.Applications.ToListAsync();
        }

        public async Task<Application> GetByIdAsync(int id)
        {
            return await _restContext.Applications.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task InsertAsync(Application application)
        {
            _restContext.Applications.Add(application);
            await _restContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Application application)
        {
            _restContext.Applications.Update(application);
            await _restContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Application application)
        {
            _restContext.Applications.Remove(application);
            await _restContext.SaveChangesAsync();
        }
    }
}
