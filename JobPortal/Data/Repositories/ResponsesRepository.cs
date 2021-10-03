using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobPortal.Data.Entities;

namespace JobPortal.Data.Repositories
{
    public interface IResponsesRepository
    {
        Task<IEnumerable<Response>> GetAll();
        Task<Response> Get(int id);
        Task<Response> Create(Response response);
        Task<Response> Put(Response response);
        Task Delete(Response response);
    }

    public class ResponsesRepository : IResponsesRepository
    {
        public async Task<IEnumerable<Response>> GetAll()
        {
            return new List<Response>
            {
                new Response()
                {
                    Message = "Mock message1",
                    Status = "Rejected",
                    CreationTimeUtc = DateTime.UtcNow
                },
                new Response()
                {
                    Message = "Mock message2",
                    Status = "Accepted",
                    CreationTimeUtc = DateTime.UtcNow
                }
            };
        }

        public async Task<Response> Get(int id)
        {
            return new Response()
            {
                Message = "Mock message1",
                Status = "Accepted",
                CreationTimeUtc = DateTime.UtcNow
            };
        }

        public async Task<Response> Create(Response response)
        {
            return new Response()
            {
                Message = "Mock message1",
                Status = "Accepted",
                CreationTimeUtc = DateTime.UtcNow
            };
        }

        public async Task<Response> Put(Response response)
        {
            return new Response()
            {
                Message = "Mock message1",
                Status = "Accepted",
                CreationTimeUtc = DateTime.UtcNow
            };
        }

        public async Task Delete(Response response)
        {

        }
    }
}
