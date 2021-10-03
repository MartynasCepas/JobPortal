using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortal.Data.Entities;

namespace JobPortal.Data.Repositories
{
    public interface IApplicationsRepository
    {
        Task<IEnumerable<Application>> GetAll();
        Task<Application> Get(int id);
        Task<Application> Create(Application offer);
        Task<Application> Put(Application offer);
        Task Delete(Application offer);
    }

    public class ApplicationsRepository : IApplicationsRepository
    {
        public async Task<IEnumerable<Application>> GetAll()
        {
            return new List<Application>
            {
                new Application()
                {
                    ApplicantName = "name1",
                    Description = "description",
                    CreationTimeUtc = DateTime.UtcNow
                },
                new Application()
                {
                    ApplicantName = "name2",
                    Description = "description",
                    CreationTimeUtc = DateTime.UtcNow
                }
            };
        }

        public async Task<Application> Get(int id)
        {
            return new Application()
            {
                ApplicantName = "name1",
                Description = "description",
                CreationTimeUtc = DateTime.UtcNow
            };
        }

        public async Task<Application> Create(Application offer)
        {
            return new Application()
            {
                ApplicantName = "name1",
                Description = "description",
                CreationTimeUtc = DateTime.UtcNow
            };
        }

        public async Task<Application> Put(Application offer)
        {
            return new Application()
            {
                ApplicantName = "name1",
                Description = "description",
                CreationTimeUtc = DateTime.UtcNow
            };
        }

        public async Task Delete(Application offer)
        {

        }
    }
}
